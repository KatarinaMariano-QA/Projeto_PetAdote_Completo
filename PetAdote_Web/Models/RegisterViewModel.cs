using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetAdote_Web.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string ONG { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}