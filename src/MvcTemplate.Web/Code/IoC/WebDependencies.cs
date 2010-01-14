using Ninject.Modules;
using System.Security.Cryptography;

namespace MvcTemplate.Web
{
    public class WebDependencies : NinjectModule
    {
        public override void Load()
        {
			Bind<IEncryptor>()
				.To<BCryptEncryptor>()
				.InRequestScope();
			Bind<IAuthenticationProvider>()
				.To<FormsAuthenticationProvider>()
				.InRequestScope();
			Bind<IMembershipProvider>()
				.To<DefaultMembershipProvider>()
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
