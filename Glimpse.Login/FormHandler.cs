using System.Reflection;
using System.Web;

namespace Glimpse.Login
{
    public class FormHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            using (
                var file = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream("Glimpse.Login.form.html"))
            {
                context.Response.ContentType = "text/html";
                file.CopyTo(context.Response.OutputStream);
            }
        }

        public bool IsReusable { get { return true; } }
    }
}