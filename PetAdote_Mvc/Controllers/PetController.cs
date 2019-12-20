using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PetAdote_Application.Configuration;
using PetAdote_Application.IServices;
using PetAdote_Dominio.Entities;
using PetAdote_Mvc.Models.PetViewModels;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetAdote_Infra.Context;
using System.Data.Entity;
using System.Threading.Tasks;
namespace PetAdote_Mvc.Controllers
{
    public class PetController : Controller
    {
        private ManagerUser _managerUser;
        public ManagerUser ManagerUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ManagerUser>();
            }
            private set => _managerUser = value;
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private readonly IPetService _pet;
        private readonly PetAdoteDbContext context = new PetAdoteDbContext();
        private readonly PetAdote_Application.Context.PetAdoteIdentityDbContext contextUser = new PetAdote_Application.Context.PetAdoteIdentityDbContext();
        public PetController(IPetService pet)
        {
            this._pet = pet;
        }
       
        public ActionResult AddPet()
        {
            ViewBag.TypeId = new SelectList(context.Types.OrderBy(b => b.TypeName), "TypeId", "TypeName");
            ViewBag.GenderId = new SelectList(context.Genders.OrderBy(g => g.GenderName), "GenderId", "GenderName");
            ViewBag.SizeId = new SelectList(context.Sizes.OrderBy(s => s.SizeName), "SizeId", "SizeName");
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddPet(AddPetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                User user2 = ManagerUser.FindById(user);
                if (model.Photo != null)
                 {                    
                     var pic = Utils.Utils.UploadPhoto(model.Photo);
                     if (!string.IsNullOrEmpty(pic))
                     {
                         model.PhotoAddress = string.Format("~/Images/Photos/{0}", pic);                        
                     }
                 }
                var pet = new Pet(User.Identity.GetUserId(), model.Name, model.Age, model.GenderName, model.SizeName, model.Cautions, model.Breed, model.History, "Adocao", model.PhotoAddress, model.Photo);
             
                if(model.TypeId == 1)
                {
                    pet.TypeName = "Cachorro";
                }
                else
                {
                    pet.TypeName = "Gato";
                }

                if(model.GenderId == 1)
                {
                    pet.GenderName = "Fêmea";
                }
                else
                {
                    pet.GenderName = "Macho";
                }

                
                if (model.SizeId == 1)
                {
                    pet.SizeName = "Pequeno";
                }
                else if (model.SizeId == 2)
                {
                    pet.SizeName = "Médio";
                }
                else
                {
                    pet.GenderName = "Grande";
                }
               
                _pet.SaveOrUpdate(pet);
                TempData["Message"] = "Pet Incluído Com Sucesso!! Estamos torcendo pela sua adoção.";
                return RedirectToAction("IndexUser", "User");
                }
                          
            return View(model);
        }
        [Authorize]
        public ActionResult ListMyPet()
        {
            var user = User.Identity.GetUserId();
            if (context.Pets == null)
            {
                return HttpNotFound();
            }

            else
            {                
               return View(context.Pets.Where(u => u.IdUser.Equals(user)));
                             
            }
            
        }

        public async Task<ActionResult> EditPet(int? id)
        {
            ViewBag.TypeId = new SelectList(context.Types.OrderBy(b => b.TypeName), "TypeId", "TypeName");
            ViewBag.GenderId = new SelectList(context.Genders.OrderBy(g => g.GenderName), "GenderId", "GenderName");
            ViewBag.SizeId = new SelectList(context.Sizes.OrderBy(s => s.SizeName), "SizeId", "SizeName");
            if (id == 0)
            {
                return HttpNotFound();
            }
            Pet editPet = await context.Pets.FindAsync(id);
            if (editPet == null)
            {
                return HttpNotFound();
            }

            var petViewModel = new EditPetViewModel
            {
                Name = editPet.Name,
                Age = editPet.Age,
                Cautions = editPet.Cautions,
                Breed = editPet.Breed,
                History = editPet.History,
                PhotoAddress = editPet.PhotoAddress,
                Photo = editPet.Photo
            };

            return View(petViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> EditPet(EditPetViewModel editPet)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                User user2 = ManagerUser.FindById(user);
                var pet = context.Pets.FirstOrDefault(p => p.Id == editPet.Id);

                if (pet == null)
                {
                    return HttpNotFound();
                }
                if (editPet.Photo != null)
                {
                    var pic = Utils.Utils.UploadPhoto(editPet.Photo);
                    if (!string.IsNullOrEmpty(pic))
                    {
                        editPet.PhotoAddress = string.Format("~/Images/Photos/{0}", pic);
                    }
                }
                pet.Name = editPet.Name;
                pet.Age = editPet.Age;
                pet.Cautions = editPet.Cautions;
                pet.Breed = editPet.Breed;
                pet.History = editPet.History;
                pet.PhotoAddress = editPet.PhotoAddress;
                pet.Photo = editPet.Photo;
                context.Entry(pet).State = EntityState.Modified;
                await context.SaveChangesAsync();        

                TempData["Message"] = "Dados do pet foram editados com sucesso.";
                return RedirectToAction("IndexUser", "User");
            }

            return View(editPet);
        }
        [Authorize]
        public ActionResult DetailsPet(int? id)
        {          
            if (id == null)
            {
                return HttpNotFound();
            }

            Pet detail = _pet.Get(id);
            if (detail == null)
            {
                return HttpNotFound();
            }


            return View(detail);
        }

        public ActionResult EditStatus(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Pet pet = context.Pets.Find(id);
            var editStatus = new EditStatusViewModel();
            editStatus.Photo = pet.Photo;
            editStatus.PhotoAddress = pet.PhotoAddress;
            return View(editStatus);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditStatus(EditStatusViewModel statusModel)
        {
            
            if (ModelState.IsValid)
            {
                var pet = context.Pets.FirstOrDefault(p => p.Id == statusModel.Id);
                if (statusModel == null)
                {
                    return HttpNotFound();
                }

                if (statusModel.status == "Adoption")
                {
                    pet.Status = "Adocao";
                }
                else if (statusModel.status == "Adopted")
                {
                    pet.Status = "Adotado";
                }
                else if (statusModel.status == "Deceased")
                {
                    pet.Status = "Falecido";
                }
                else if(statusModel.status == null)
                {
                    pet.Status = pet.Status;
                }
                _pet.SaveOrUpdate(pet);
                
                TempData["Message"] = "Dados do pet foram editados com sucesso.";
                return RedirectToAction("IndexUser", "User");
            }
                
            return View(statusModel);
        }
    }
}