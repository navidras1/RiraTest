using AutoMapper;
using DataAccess.RiraModels;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Models.Request;
using Service;

namespace GrpcService.Services
{
    public class PersonService : PersonCrud.PersonCrudBase
    {
        private readonly ILogger<PersonService> logger;
        private readonly IPersonCrudService _personCrudService;
        private IMapper _mapper;
        public PersonService(ILogger<PersonService> logger, IPersonCrudService personCrudService, IMapper mapper)
        {
            this.logger = logger;
            this._personCrudService = personCrudService;
            this._mapper = mapper;
        }
        public override Task<AddPersonResponseMessage> AddPerson(AddPersonRequestMessage request, ServerCallContext context)
        {
            var addPersonRequest = _mapper.Map<AddPersonRequest>(request);
            var addpersonRes = _personCrudService.AddPerson(addPersonRequest);
            var res = _mapper.Map<AddPersonResponseMessage>(addpersonRes);
            return Task.FromResult(res);

        }
        public override Task<GetAllPersonResponseMessage> GetAllPersons(Empty request, ServerCallContext context)
        {
            Models.Response.GetAllPersonsResponse persons = _personCrudService.GetAllPersons();
            var res = _mapper.Map<GetAllPersonResponseMessage>(persons);
            return Task.FromResult(res);
        }

        public override Task<GeneralRsponseMessage> DeletePerson(DeletePersonRequestMessage request, ServerCallContext context)
        {
            var deleteRes = _personCrudService.DeletePerson(new DeletePersonRequest { Id = request.Id });
            var res = _mapper.Map<GeneralRsponseMessage>(deleteRes);
            return Task.FromResult(res);
        }

        public override Task<GeneralRsponseMessage> UpdatePerson(PersonMessage request, ServerCallContext context)
        {
            var updatePersonRequest = _mapper.Map<UpdatePersonRequest>(request);
            
            var updateRes = _personCrudService.UpdatePerson(updatePersonRequest);

             var res = _mapper.Map<GeneralRsponseMessage>(updateRes);
            
            return Task.FromResult(res);
        }




    }
}
