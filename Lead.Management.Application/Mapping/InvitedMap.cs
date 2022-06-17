using AutoMapper;
using Lead.Management.Application.Models;
using Lead.Management.Domain.Entities;
using Lead.Management.Domain.Models;

namespace Lead.Management.Application.Mapping
{
    public class InvitedMap : Profile
    {
        public InvitedMap()
        {
            CreateMap<Contacts, InvitedModel>().ReverseMap();
            CreateMap<Contacts, InviteCreateModel>().ReverseMap();
            CreateMap<Contacts, AcceptedModel>().ReverseMap();    
        }
    }
}
