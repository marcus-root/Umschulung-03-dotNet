namespace _09._02___Produkte__WPF_
{
    class Category
    {
        public String CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public String[] GetProductNames()
        {
            return (from p in Products select p.Name).ToArray();
        }

        public double[] GetProductPrices()
        {
            return (from p in Products select p.Price).ToArray();
        }
    }
}