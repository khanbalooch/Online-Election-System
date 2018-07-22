using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Web_Project_Server.Models;

namespace Web_Project_Server.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        
        public ActionResult Index()
        {
			//if (Session["UserName"] == null)
			//{
			//	return RedirectToAction("Index", "Login");
			//}
			User user = new User();

            return View(user);
        }
        
        [HttpPost]
        public ActionResult RegisterType(User user, FormCollection Form)
        {
            user.PicPath = SaveImage(user.PicPath.Substring(23, user.PicPath.Length - 23), user.UserName);
            ElectionCatalog db = new ElectionCatalog();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
        public string SaveImage(string data, string UserName)
        {

            UserName = @"/" + UserName + ".Jpeg";
            string path = Server.MapPath("~/UserImages");
            byte[] bytes = Convert.FromBase64String(data);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
                image.Save(path + UserName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return path;
        }
        

    }
}