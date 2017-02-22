
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Services.Interfaces;
using ToDoList.Web.Models.CommentModels;
using TodoList.Domain;

namespace ToDoList.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        private CommentController()
        {
            
        }
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public IActionResult GetCommentsForParent(SearchModel model)
        {
            var comments = _commentService.GetCommentsForParent(model.ParentIdentifier,
                _mapper.Map<Models.CommentModels.CommentType, TodoList.Domain.Entities.CommentType>(
                    model.CommentType));
            return new JsonResult(comments);
        }


    }

}
