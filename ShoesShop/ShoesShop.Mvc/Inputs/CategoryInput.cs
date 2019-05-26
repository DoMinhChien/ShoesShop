namespace ShoesShop.Mvc.Inputs
{
    public class CategoryInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}