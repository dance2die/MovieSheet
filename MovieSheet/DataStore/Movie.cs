namespace DataStore
{
	public class Movie
	{
		private System.Text.RegularExpressions.Group title;

		public string Title { get; set; }
		public string Line { get; set; }

		public Movie(string title, string line)
		{
			Title = title;
			Line = line;
		}
	}
}