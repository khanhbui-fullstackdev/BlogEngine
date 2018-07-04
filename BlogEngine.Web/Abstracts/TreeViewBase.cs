using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Web.Abstracts
{
    public abstract class TreeViewBase
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public List<int> Tags { get; set; }
    }
}