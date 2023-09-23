namespace Cosmetics.Tests.Helpers
{
    public static class TestData
    {
        public static class CategoryData
        {
			private const int NameMinLength = 2;
			private const int NameMaxLength = 15;

			public static string ValidName = new string('x', NameMinLength + 1);
			public static string InvalidName = new string('x', NameMaxLength + 1);
		}

        public static class ShampooData
        {
			private const int NameMinLength = 3;
			private const int NameMaxLength = 10;
			private const int BrandMinLength = 2;
			private const int BrandMaxLength = 10;

			public static string ValidName = new string('x', NameMinLength + 1);
			public static string InvalidName = new string('x', NameMaxLength + 1);

			public static string ValidBrand = new string('x', BrandMinLength + 1);
			public static string InvalidBrand = new string('x', BrandMaxLength + 1);
		}

        public static class ToothpasteData
        {
			private const int NameMinLength = 3;
			private const int NameMaxLength = 10;
			private const int BrandMinLength = 2;
			private const int BrandMaxLength = 10;

			public static string ValidName = new string('x', NameMinLength + 1);
			public static string InvalidName = new string('x', NameMaxLength + 1);

			public static string ValidBrand = new string('x', BrandMinLength + 1);
			public static string InvalidBrand = new string('x', BrandMaxLength + 1);
		}

		public static class CreamData
		{
			private const int NameMinLength = 3;
			private const int NameMaxLength = 15;
			private const int BrandMinLength = 3;
			private const int BrandMaxLength = 15;

			public static string ValidName = new string('x', NameMinLength + 1);
			public static string InvalidName = new string('x', NameMaxLength + 1);

			public static string ValidBrand = new string('x', BrandMinLength + 1);
			public static string InvalidBrand = new string('x', BrandMaxLength + 1);
		}
	}
}
