using AutoMapper;
using TextWebServices.Entities;
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
