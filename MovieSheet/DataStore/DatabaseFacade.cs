using System.Collections.Generic;
using System.Linq;
using Raven.Client.Linq;

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

		public static List<Movie> GetMovies()
		{
			using (var documentSession = RavenDbConfig.Store.OpenSession())
			{
				return documentSession.Query<Movie>().ToList();
			}
		}
	}
}