using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SportsEvents.Web.Mapper
{
    public  class  MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SportsEvents.Domain.Entities.CommentType, SportsEvents.Web.Models.CommentModels.CommentType>();
            //CreateMap<SportsEvents.Domain.Entities.Comment, Models.CommentModels.SearchModel>();


        }
    }
}
