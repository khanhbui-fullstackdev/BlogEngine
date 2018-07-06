using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.Web.ViewModels
{
    public class AutocompleteWidgetViewModel
    {
        public string Label { get; set; }

        public string Category { get; set; }

        public string Value { get; set; }

        public List<AutocompleteWidgetViewModel> AutocompleteWidgetMappingSearchResult(SearchResultViewModel searchResultViewModel)
        {
            List<AutocompleteWidgetViewModel> autocompleteWidgetViewModels = new List<AutocompleteWidgetViewModel>();
            if (searchResultViewModel != null)
            {
                var posts = searchResultViewModel.Posts;
                var categories = searchResultViewModel.Categories;
                if (posts.Count() != 0)
                {
                    foreach (var post in posts)
                    {
                        AutocompleteWidgetViewModel autocompletePost = new AutocompleteWidgetViewModel
                        {
                            Category = post.Category.Name,
                            Label = post.Name                           
                        };
                        autocompleteWidgetViewModels.Add(autocompletePost);
                    }
                }
                if (categories.Count() != 0)
                {
                    foreach (var category in categories)
                    {
                        AutocompleteWidgetViewModel autocompleteCategory = new AutocompleteWidgetViewModel
                        {
                            Category = "Category",
                            Label = category.Name                           
                        };
                        autocompleteWidgetViewModels.Add(autocompleteCategory);
                    }
                }
            }
            return autocompleteWidgetViewModels;
        }
    }
}