using AutoMapper;
using SpellGenerator.Business.BusinessModels;

namespace SpellGenerator.API.DTOs.MapperProfiles
{
    public class MagicProfile : Profile
    {
        public MagicProfile()
        {
            /*/ Mapping pour créer une magie (sans Id)
            CreateMap<MagicCreationDTO, Magic>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Magic, MagicModificationDTO>();*/
        }
    }
}
