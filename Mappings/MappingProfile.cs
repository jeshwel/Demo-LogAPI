using AutoMapper;
using Demo_LogAPI.DTOs;
using Demo_LogAPI.Models;

namespace Demo_LogAPI.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();//Map from Message Object to MessageDTO Object
        }
    }
}
