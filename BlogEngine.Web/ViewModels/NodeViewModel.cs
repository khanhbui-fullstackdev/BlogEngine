using BlogEngine.Web.Abstracts;

namespace BlogEngine.Web.ViewModels
{
    public class NodeViewModel : TreeViewBase
    {
        public int _nodeid { get; set; }

        public string _slug { get; set; }
    }
}