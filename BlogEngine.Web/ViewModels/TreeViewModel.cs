using System.Collections.Generic;

namespace BlogEngine.Web.ViewModels
{
    public class TreeViewModel
    {
        // Cheating data structure for using bootstrap-treeview
        public int _parentid { get; set; }
        public string Text { get; set; }
        public string _slug { get; set; }
        public List<NodeViewModel> Nodes { get; set; }
        public List<int> Tags { get; set; }

        public TreeViewModel TreeViewMappingCategory(CategoryViewModel categoryViewModel)
        {
            TreeViewModel treeViewModel = new TreeViewModel();
            treeViewModel.Text = categoryViewModel.Name;
            treeViewModel._parentid = categoryViewModel.ID;
            treeViewModel._slug = categoryViewModel.Slug;

            if (categoryViewModel.SubCategories.Count != 0)
            {
                foreach (var subcategory in categoryViewModel.SubCategories)
                {
                    NodeViewModel nodeViewModel = new NodeViewModel();
                    nodeViewModel._nodeid = subcategory.ID;
                    nodeViewModel.Text = subcategory.Name;
                    nodeViewModel._slug = subcategory.Slug;
                    treeViewModel.Nodes.Add(nodeViewModel);
                }
            }
            return treeViewModel;
        }

        public List<TreeViewModel> TreeViewMappingCategory(IEnumerable<CategoryViewModel> categoriesViewModel)
        {
            List<TreeViewModel> treeViewModels = new List<TreeViewModel>();

            foreach (var categoryViewModel in categoriesViewModel)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel._parentid = categoryViewModel.ID;
                treeViewModel.Text = categoryViewModel.Name;
                treeViewModel._slug = categoryViewModel.Slug;
                treeViewModel.Tags = new List<int>();
                if (categoryViewModel.SubCategories.Count != 0)
                {
                    treeViewModel.Tags.Add(categoryViewModel.SubCategories.Count);
                    treeViewModel.Nodes = new List<NodeViewModel>();
                    foreach (var subcategory in categoryViewModel.SubCategories)
                    {
                        NodeViewModel nodeViewModel = new NodeViewModel();
                        nodeViewModel._nodeid = subcategory.ID;
                        nodeViewModel.Text = subcategory.Name;
                        nodeViewModel._slug = subcategory.Slug;
                        treeViewModel.Nodes.Add(nodeViewModel);
                    }
                }
                else
                {
                    treeViewModel.Tags.Add(0);
                }
                treeViewModels.Add(treeViewModel);
            }
            return treeViewModels;
        }
    }
}