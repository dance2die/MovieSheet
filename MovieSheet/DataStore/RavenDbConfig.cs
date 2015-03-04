using System.Reflection;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Database.Server;

namespace DataStore
{
	/// <remarks>http://www.codeproject.com/Tips/846036/Embedded-RavenDb-in-MVC?fid=1873980</remarks>
	public class RavenDbConfig
	{
		private static IDocumentStore _store;
		public static IDocumentStore Store
		{
			get
			{
				if (_store == null)
					Initialize();
				return _store;
			}
		}

		public static IDocumentStore Initialize()
		{
			_store = new EmbeddableDocumentStore
			{
				ConnectionStringName = "RavenDB",
				//DataDirectory = "Database",
				UseEmbeddedHttpServer = true
			};
			NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8081);
			_store.Conventions.IdentityPartsSeparator = "-";
			_store.Initialize();
			IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
			return _store;
		}
	}
}