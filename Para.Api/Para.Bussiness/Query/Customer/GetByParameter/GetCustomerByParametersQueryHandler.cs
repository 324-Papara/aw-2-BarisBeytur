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

namespace Para.Bussiness.Query.Customer.GetByParameter
{
    public class GetCustomerByParametersQueryHandler : IRequestHandler<GetCustomerByParametersQuery, ApiResponse<List<CustomerResponse>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerByParametersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<List<CustomerResponse>>> Handle(GetCustomerByParametersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
