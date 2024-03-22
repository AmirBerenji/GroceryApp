using CommunityToolkit.Mvvm.ComponentModel;

namespace GroceryApp.Models
{
    public class Category
    {
        public Category(int id,string name,int parentId,string image,string credit) 
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Image = image;
            Credit = credit;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ParentId { get; set; }
        public string? Credit { get; set; }
        public bool IsMainCategory => ParentId == 0;
    }

}
