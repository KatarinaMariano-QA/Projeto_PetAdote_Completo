using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PetAdote_Application.Configuration;
using PetAdote_Dominio.Entities;
using PetAdote_Infra.Context;
using PetAdote_Mvc.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PetAdote_Mvc.Controllers
{
    public class ManagerController : Controller
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


        [Authorize]
        public ActionResult EditUser(string id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            User user = ManagerUser.FindById(id);
            if(user == null)
            {
                return HttpNotFound();
            }
            var edit = new EditUserViewModel();
            edit.Name = user.UserName;
            edit.Email = user.Email;
            edit.ONG = user.ONG;
            edit.Telephone = user.PhoneNumber;

            return View(edit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUser(EditUserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                User user = ManagerUser.FindById(editUser.Id);
                user.UserName = editUser.Name;
                user.Email = editUser.Email;
                user.ONG = editUser.ONG;
                user.PhoneNumber = editUser.Telephone;
                IdentityResult result = ManagerUser.Update(user);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Dados editados, realize login novamente para sincronizar com nossa base de dados";
                    return RedirectToAction("IndexUser", "User");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(editUser);
        }

        [Authorize]
        public ActionResult EditPassword(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User user = ManagerUser.FindById(id);
            if (user== null)
            {
                return HttpNotFound();
            }
            var edit = new EditPasswordViewModel();
            return View(edit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditPassword(EditPasswordViewModel editPassword)
        {
            if (ModelState.IsValid)
            {
                User user= ManagerUser.FindById(editPassword.Id);
                user.PasswordHash = ManagerUser.PasswordHasher.HashPassword(editPassword.Password);

                if (editPassword.Password == editPassword.ConfirmPassword)
                {
                    IdentityResult result = ManagerUser.Update(user);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "Dados editados, realize login novamente para sincronizar com nossa base de dados";
                        return RedirectToAction("IndexUser", "User");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Senhas não correspondem.");
                }
            }

            return View(editPassword);
        }
    }
}