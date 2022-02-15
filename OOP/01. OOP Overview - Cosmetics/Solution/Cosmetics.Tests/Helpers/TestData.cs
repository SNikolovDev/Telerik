using Cosmetics.Models;

namespace Cosmetics.Tests.Helpers
{
    public class TestData
    {
        public static class CategoryData
        {
            public static string VALID_NAME = new string('x', Category.NameMinLength + 1);
        }

        public static class ProductData
        {
            public static string VALID_NAME = new string('x', Product.NameMinLength + 1);
            public static string VALID_BRAND_NAME = new string('x', Product.BrandMinLength + 1);
        }
    }
}
