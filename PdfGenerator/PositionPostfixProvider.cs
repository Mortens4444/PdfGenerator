namespace PdfGenerator
{
	class PositionPostfixProvider
	{
		public static string Get(uint position)
		{
			switch (position)
			{
				case 1:
					return "st";
				case 2:
					return "nd";
				case 3:
					return "rd";
				default:
					return "th";
			}
		}
	}
}
