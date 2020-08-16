using System.Collections.Generic;

namespace LetsSuggest.Personnel.Core.Model.CustomLibrary
{
    public class CategoryTreeNode
    {
        public int BusinessCategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? IconId { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int data { get; set; }
        public string Label { get; set; }
        private List<CategoryTreeNode> _children;
        public List<CategoryTreeNode> Children
        {
            get => _children ?? (_children = new List<CategoryTreeNode>());
            set => _children = value;
        }
    }
}
