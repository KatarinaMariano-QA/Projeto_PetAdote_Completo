using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PetAdote_Application.Configuration;
using PetAdote_Dominio.Entities;
using PetAdote_Web.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetAdote_Web.Controllers
{
    public class AccountController : Controller
    {
        #region Helpers

        private ManagerUser _managerUser;
        public ManagerUser ManagerUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ManagerUser>();
            }
            private set => _managerUser = value;
        }

        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Nome, Email = model.Email, EmailConfirmed = true, PhoneNumber = model.Telefone, ONG = model.ONG };
                var resulte = await ManagerUser.CreateAsync(user, model.Senha);
                if (model.Senha == model.ConfirmaSenha)
                {
                    if (resulte.Succeeded)
                    {
                        AuthManager.SignOut();
                        //await GerenciadorUsuario.SendEmailAsync(user.Id, "Boas Vindas", "Obrigado por fazer parte desta equipe");
                        return View("DisplayEmail");

                    }
                    else
                    {
                        AddErrorsFromResult(resulte);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Senhas não correspondem.");
                }
            }
            return View(model);
        }
    }
}