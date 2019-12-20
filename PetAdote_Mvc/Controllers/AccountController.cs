using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PetAdote_Application.Configuration;
using PetAdote_Dominio.Entities;
using PetAdote_Mvc.Models.AccountViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PetAdote_Mvc.Controllers
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
                var user = new User { UserName = model.Name, Email = model.Email, EmailConfirmed = true, PhoneNumber = model.Telephone, ONG = model.ONG };
                var resulte = await ManagerUser.CreateAsync(user, model.Password);

                if (model.Password == model.ConfirmPassword)
                {
                    if (resulte.Succeeded)
                    {
                        AuthManager.SignOut();
                        await ManagerUser.SendEmailAsync(user.Id, "Boas Vindas", "Obrigado por fazer parte desta equipe");
                        return View("RegisterConfirmed");

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

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var findEmail = ManagerUser.FindByEmail(model.Email);

                if (findEmail == null)
                {
                    ModelState.AddModelError("", "Email	ou senha inválido(s).");
                }
                else
                {
                    var user = ManagerUser.Find(findEmail.UserName, model.Password);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Email	ou senha inválido(s).");
                    }
                    else {
                    ClaimsIdentity ident = ManagerUser.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                   
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    if (returnUrl == null)
                    {
                        returnUrl = "/HomePage";
                    }
                    return RedirectToAction("IndexUser", "User");
                    }
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("HomePage", "HomePage");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = await ManagerUser.FindByEmailAsync(model.Email);
                if (user == null || !(await ManagerUser.IsEmailConfirmedAsync(user.Id)))
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var code = await ManagerUser.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await ManagerUser.SendEmailAsync(user.Id, "Esqueci a senha", "Por favor altere sua senha clicando aqui: "+ callbackUrl);
                    return View("ForgotPasswordConfirmation");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = ManagerUser.FindByEmail(model.Email);
            if (user == null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await ManagerUser.ResetPasswordAsync(user.Id, model.Code, model.Password);
            user.PasswordHash = ManagerUser.PasswordHasher.HashPassword(model.Password);
            result = ManagerUser.Update(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrorsFromResult(result);
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}