using AutoMapper;
using Models;
using Models.Request;
using Models.Response;

namespace GrpcService
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() {

            CreateMap<AddPersonRequestMessage, AddPersonRequest>()
                .ForMember(dest=> dest.FirstName , opt=> opt.MapFrom(src=> src.FirstName))
                .ForMember(dest=> dest.LastName , opt=> opt.MapFrom(src=> src.LastName))
                .ForMember(dest=> dest.BirthDate , opt=> opt.MapFrom(src=> src.BirthDate))
                .ForMember(dest=> dest.NationalCode , opt=> opt.MapFrom(src=> src.NationlaCode));
            CreateMap<AddPersonResponse, AddPersonResponseMessage>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.Warnings, opt => opt.MapFrom(src => src.Warnings));
            CreateMap<GetAllPersonsResponse, GetAllPersonResponseMessage>()
                .ForMember(dest=> dest.Message , opt => opt.MapFrom(src => src.Message))
                .ForMember(dest=> dest.IsSuccess , opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest=> dest.Persons , opt => opt.MapFrom(src => src.Persons.Select(x=> new PersonMessage() { BirthDate = x.birthDate.ToUnixTimeSeconds(), FirstName = x.FirstName, LastName = x.LastName, Id = x.Id, NationlaCode = x.NationalCode })))
                .ForMember(dest => dest.Warnings, opt => opt.MapFrom(src => src.Warnings));
            CreateMap<ResponseMessage, GeneralRsponseMessage>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.IsSuccess, opt => opt.MapFrom(src => src.IsSuccess))
                .ForMember(dest => dest.Warnings, opt => opt.MapFrom(src => src.Warnings));

            CreateMap<PersonMessage, UpdatePersonRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.NationlaCode))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate));







        }
    }
}
