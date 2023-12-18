using AutoMapper;
using CountryExplorer.BusinessLogic.Models.Dtos;
using CountryExplorer.Domain.Models;

namespace CountryExplorer.BusinessLogic.Mappings
{
	internal class CountryMappingProfile : Profile
	{
		public CountryMappingProfile()
		{
			CreateMap<Country, CountryPartialDto>()
				.ForMember(dest => dest.Capital, opt => opt.MapFrom(src => string.Join(", ", src.Capital)))
				.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => string.Join(", ", src.Currencies.Select(e => e.Name))))
				.ForMember(dest => dest.Language, opt => opt.MapFrom(src => string.Join(", ", src.Languages.Select(e => e.Name))));
		}
	}
}
