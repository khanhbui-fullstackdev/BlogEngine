namespace BlogEngine.Web.ViewModels
{
    public class CommentViewModel
    {
        public int ID { set; get; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }

        public int PostID { get; set; }

        public virtual PostViewModel Post { get; set; }
    }
}