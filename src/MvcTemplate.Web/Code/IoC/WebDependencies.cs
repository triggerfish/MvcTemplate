using Ninject.Modules;

namespace MvcTemplate.Web
{
    public class WebDependencies : NinjectModule
    {
        public override void Load()
        {
			Bind<IAuthenticationProvider>()
				.To<FormsAuthenticationProvider>()
				.InRequestScope();
			Bind<GenreBinder>()
				.To<GenreBinder>()
				.InRequestScope();
			Bind<ArtistBinder>()
				.To<ArtistBinder>()
				.InRequestScope();
			Bind<UserBinder>()
				.To<UserBinder>()
				.InRequestScope();
		}
    }
}
