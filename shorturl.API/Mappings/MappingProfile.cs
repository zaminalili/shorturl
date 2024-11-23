using AutoMapper;
using shorturl.API.Models.Dtos;
using shorturl.API.Models.Entities;

namespace shorturl.API.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Url, GetUrlDto>().ReverseMap();
    }
}
