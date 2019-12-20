using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetAdote_Dominio.Entities;
using PetAdote_Application.Context;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace PetAdote_Application.Configuration
{
    public class ManagerUser : UserManager<User>
    {
        public ManagerUser(IUserStore<User> store) : base(store)
        {

        }
        public static ManagerUser Create(IdentityFactoryOptions<ManagerUser> options, IOwinContext context)
        {
            PetAdoteIdentityDbContext db = context.Get<PetAdoteIdentityDbContext>();
            ManagerUser manager = new ManagerUser(new UserStore<User>(db));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false
            };
            // Definindo a classe de serviço de e-mail
            manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
        
    }
}
