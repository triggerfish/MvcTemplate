using Ninject.Modules;
using System.Security.Cryptography;
using MvcTemplate.Model;

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
			Bind<ModelBinder<IGenre>>()
				.To<GenreBinder>()
				.InRequestScope();
			Bind<ModelBinder<IArtist>>()
				.To<ArtistBinder>()
				.InRequestScope();
			Bind<ModelBinder<IUser>>()
				.To<UserBinder>()
				.InRequestScope();
		}
    }
}
