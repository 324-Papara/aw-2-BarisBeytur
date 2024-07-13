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

namespace Para.Bussiness.Command.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ApiResponse>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var mapped = mapper.Map<CustomerRequest, Data.Domain.Customer>(request.Request);
            mapped.Id = request.CustomerId;
            mapped.InsertUser = "system";
            mapped.InsertDate = DateTime.Now;
            unitOfWork.CustomerRepository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
