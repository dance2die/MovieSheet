using System.Collections.Generic;

namespace DataStore
{
	public static class DatabaseFacade
	{
		public static void Write(Movie movie)
		{
			using (var documentSession = RavenDbConfig.Store.OpenSession())
			{
				documentSession.Store(movie);
				documentSession.SaveChanges();
			}
		}

		public static void WriteRange(IEnumerable<Movie> movies)
		{
			using (var documentSession = RavenDbConfig.Store.OpenSession())
			{
				foreach (var movie in movies)
				{
					documentSession.Store(movie);
				}
				documentSession.SaveChanges();
			}
		}
	}
}