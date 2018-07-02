namespace BlogEngine.Web.ViewModels
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }

        public int TagID { set; get; }

        public virtual PostViewModel Post { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}