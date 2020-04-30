using System.Web;
using System.Web.Optimization;

namespace AcademiaDeBaile
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/miJs/jquery").Include("~/Scripts/jquery.js"));
            bundles.Add(new ScriptBundle("~/miJs/material").Include("~/Scripts/materialize.js"));
            bundles.Add(new ScriptBundle("~/miJs/materialize").Include("~/Scripts/miJQ.js"));
            bundles.Add(new StyleBundle("~/miCss/material").Include("~/Content/materialize.css"));
            bundles.Add(new StyleBundle("~/js/Ajax").Include("~/Scripts/EjemploAjax.js"));
            bundles.Add(new StyleBundle("~/miCss/miEstilo").Include("~/Content/webSite.css"));
            bundles.Add(new StyleBundle("~/miCss/miEstiloCompleto").Include("~/Content/MyStyle.css"));


        }
    }
}
