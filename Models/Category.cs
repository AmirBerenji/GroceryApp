using CommunityToolkit.Mvvm.ComponentModel;

namespace GroceryApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ParentId { get; set; }
        public bool IsMainCategory => ParentId == 0;
    }

}
