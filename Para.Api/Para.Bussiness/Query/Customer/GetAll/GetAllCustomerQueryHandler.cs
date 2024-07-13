﻿using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Para.Schema;

namespace Para.Bussiness.Query.Customer.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ApiResponse<List<CustomerResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Para.Data.Domain.Customer> entityList = await unitOfWork.CustomerRepository.GetAll();
            var mappedList = mapper.Map<List<CustomerResponse>>(entityList);
            return new ApiResponse<List<CustomerResponse>>(mappedList);
        }
    }
}
