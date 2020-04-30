using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcademiaDeBaile.Controllers
{
    public class HomeController : Controller
    {
        AcademiaDeBaileEntities baseDatos = new AcademiaDeBaileEntities();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //Lo que ocurre aqui de igual manera es un sucess
        public String LoginUsuario (String usuario, String password)
        {
            
            var usuarioLogin = baseDatos.LoginUsuario1.Where(u => u.NombreUsuario.Equals(usuario)
                 && u.PasswordUsuario.Equals(password)).FirstOrDefault();

            if (usuarioLogin!= null )
            {
                FormsAuthentication.SetAuthCookie(usuarioLogin.NombreUsuario, false);
                return JsonConvert.SerializeObject(usuarioLogin);
            }
            else
            {
                return "{\"Error\" : \"Datos de usuario inválido\"}";
                //return JsonConvert.SerializeObject("{\"Error\" : \"Datos de usuario inválido\"}");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}