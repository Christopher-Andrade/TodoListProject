namespace SportsEvents.Web.Models.CommentModels
{
    public class SearchModel
    {
        public string ParentIdentifier { get; set; }

        public CommentType CommentType { get; set; }
        
    }

    public enum CommentType
    { 
        Unknown = 0,

        Article = 1,

        Event = 2,

        NotSpecified = 3
    }
}
