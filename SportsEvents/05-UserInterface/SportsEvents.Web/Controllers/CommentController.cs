using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsEvents.Services.Interfaces;
using SportsEvents.Web.Models.CommentModels;

namespace SportsEvents.Web.Controllers
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
                _mapper.Map<Web.Models.CommentModels.CommentType, SportsEvents.Domain.Entities.CommentType>(
                    model.CommentType));
            return new JsonResult(comments);
        }


    }

}
