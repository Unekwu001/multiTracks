using Autofac;
using DataAccess;
using MultiTracks_API.Repositories;

namespace MultiTracks_API
{
	public class AutofacConfig
	{
		public static IContainer ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			// Register the repositories
			builder.RegisterType<ArtistRepository>().As<IArtistRepository>().InstancePerLifetimeScope();

			// Register other dependencies if needed

			// Build the container
			var container = builder.Build();

			return container;
		}
	}
}