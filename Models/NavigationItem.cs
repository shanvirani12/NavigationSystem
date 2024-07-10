namespace NavigationSystem.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public NavigationItem Parent { get; set; }
        public ICollection<NavigationItem> Children { get; set; }
    }

}
