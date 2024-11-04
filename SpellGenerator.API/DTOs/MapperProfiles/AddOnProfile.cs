using AutoMapper;
using SpellGenerator.Business.BusinessModels.AddOns;
using SpellGenerator.Data.DataModels.Enums;

namespace SpellGenerator.API.DTOs.MapperProfiles
{
    public class AddOnProfile : Profile
    {
        public AddOnProfile()
        {
            // Mapping pour BasicAddOn vers AddOnDTO
            CreateMap<BasicAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.Base))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => 0)) // Default pour BasicAddOn
                .ForMember(dest => dest.ModifierValue, opt => opt.MapFrom(src => (string?)null))
                .ReverseMap();

            // Mapping pour InstabilityModifierAddOn vers AddOnDTO
            CreateMap<InstabilityModifierAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.InstabilityOnly))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => src.InstabilityModificationValue))
                .ReverseMap();

            // Mapping pour RangeModifierAddOn vers AddOnDTO
            CreateMap<RangeModifierAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.Range))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => src.InstabilityModificationValue))
                .ForMember(dest => dest.ModifierValue, opt => opt.MapFrom(src => src.RangeModificationValue))
                .ReverseMap();

            // Mapping pour RangeModifierAddOn vers AddOnDTO
            CreateMap<CastModifierAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.Cast))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => src.InstabilityModificationValue))
                .ForMember(dest => dest.ModifierValue, opt => opt.MapFrom(src => src.CastModificationValue))
                .ReverseMap();

            // Mapping pour RangeModifierAddOn vers AddOnDTO
            CreateMap<TargetModifierAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.Target))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => src.InstabilityModificationValue))
                .ForMember(dest => dest.ModifierValue, opt => opt.MapFrom(src => src.TargetModificationValue))
                .ReverseMap();

            // Mapping pour RangeModifierAddOn vers AddOnDTO
            CreateMap<DurationModifierAddOn, AddOnCreationDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => AddOnTypeEnum.Duration))
                .ForMember(dest => dest.InstabilityValue, opt => opt.MapFrom(src => src.InstabilityModificationValue))
                .ForMember(dest => dest.ModifierValue, opt => opt.MapFrom(src => src.DurationModificationValue))
                .ReverseMap();
        }
    }
}
