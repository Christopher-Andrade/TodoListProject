using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ToDoList.Web.Mapper
{
    public  class  MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoList.Domain.Entities.CommentType, ToDoList.Web.Models.CommentModels.CommentType>();
            //CreateMap<TodoList.Domain.Entities.Comment, Models.CommentModels.SearchModel>();


        }
    }
}
