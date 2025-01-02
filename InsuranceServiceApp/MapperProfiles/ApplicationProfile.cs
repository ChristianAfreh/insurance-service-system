using AutoMapper;
using InsuranceServiceApp.Models.Data;
using InsuranceServiceApp.ViewModels;

namespace InsuranceServiceApp.MapperProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Client, ClientForAddViewModel>().ReverseMap();
            CreateMap<Client, ClientForEditViewModel>().ReverseMap();
        }
    }
}
