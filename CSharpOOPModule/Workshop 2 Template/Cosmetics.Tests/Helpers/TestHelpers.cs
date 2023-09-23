using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using Cosmetics.Models;

using System.Collections.Generic;
using System.Linq;

using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Helpers
{
    public class TestHelpers
    {
		/// <summary>
		/// Returns a new List with size equal to wantedSize.
		/// Useful when you do not care what the contents of the List are,
		/// for example when testing if a list of a command throws exception
		/// when it's parameters list's size is less/more than expected.
		/// </summary>
		/// <param name="wantedSize">the size of the List to be returned</param>
		/// <returns>a new List with size equal to wantedSize</returns>
		public static List<string> InitializeListWithSize(int wantedSize)
        {
            return new string[wantedSize].ToList();
        }

        public static Repository InitializeRepository()
        {
            return new Repository();
        }

        public static ICategory InitializeCategory()
        {
            return new Category(TestData.CategoryData.ValidName);
        }

        public static IProduct InitializeTestProduct()
        {
			return new Shampoo(
				ShampooData.ValidName,
				ShampooData.ValidBrand,
				10m,
				GenderType.Unisex,
				100,
				UsageType.EveryDay);
		}
        public static ICategory AddInitializedCategoryToRepo(IRepository repository)
        {
            repository.CreateCategory(CategoryData.ValidName);
            return repository.FindCategoryByName(CategoryData.ValidName);
        }

        public static IProduct AddInitializedProductToRepo(IRepository repository)
        {
            repository.CreateShampoo(
                ShampooData.ValidName,
                ShampooData.ValidBrand,
                10m, GenderType.Unisex,
                100, UsageType.EveryDay);

            return repository.FindProductByName(ShampooData.ValidName);
        }
    }
}
