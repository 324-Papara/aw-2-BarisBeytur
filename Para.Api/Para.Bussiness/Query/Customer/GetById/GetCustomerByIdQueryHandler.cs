using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Query.Customer.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ApiResponse<CustomerResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<CustomerResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.CustomerRepository.GetById(request.CustomerId);
            var mapped = mapper.Map<CustomerResponse>(entity);
            return new ApiResponse<CustomerResponse>(mapped);
        }
    }
}
