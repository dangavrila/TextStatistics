using AutoMapper;
using TextServices.Entities;
using TextWebServices.Models;

namespace TextWebServices
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
			CreateMap<TextItem, TextEntity>();
			CreateMap<TextStatisticsEntity, TextStatistics>();
		}
	}
}
