using System;
using DataStore;

namespace WriteToGoogleSheet
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach (Movie movie in DatabaseFacade.GetMovies())
			{
				Console.WriteLine("Title: \"{0}\"", movie.Title);
			}
		}
	}
}
