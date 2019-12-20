using PetAdote_Infra.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Utils
{
    public class Utils
    {
        private static PetAdoteDbContext _context = new PetAdoteDbContext();

        public static string UploadPhoto(HttpPostedFileBase file)
        {
            string path = string.Empty;
            string pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Photos"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            return pic;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}