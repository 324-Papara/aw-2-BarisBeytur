﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Para.Base.Response;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetById
{
    public class GetCustomerByIdWithDetailsQueryHandler : IRequestHandler<GetCustomerByIdWithDetailsQuery, ApiResponse<Para.Data.Domain.Customer>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerByIdWithDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<Para.Data.Domain.Customer>> Handle(GetCustomerByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerId <= 0)
            {
                return new ApiResponse<Para.Data.Domain.Customer>()
                {
                    IsSuccess = false,
                    Message = "Invalid Customer Id"
                };
            }

            var customer = await unitOfWork.CustomerRepository
                .Include(c => c.CustomerAddresses, c => c.CustomerPhones)
                .FirstOrDefaultAsync(c => c.Id == request.CustomerId);

            if (customer == null)
            {
                return new ApiResponse<Para.Data.Domain.Customer>()
                {
                    IsSuccess = false,
                    Message = "Customer not found"
                };
            }

            return new ApiResponse<Para.Data.Domain.Customer>(customer);
        }
    }
}
