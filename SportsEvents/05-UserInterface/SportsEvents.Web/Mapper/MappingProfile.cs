using AutoMapper;

namespace SportsEvents.Web.Mapper
{
    public  class  MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SportsEvents.Domain.Entities.CommentType, SportsEvents.Web.Models.CommentModels.CommentType>();
            //CreateMap<SportsEvents.Web.Domain.Entities.Comment, Models.CommentModels.SearchModel>();


        }
    }
}
