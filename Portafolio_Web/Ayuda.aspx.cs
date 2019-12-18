using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio
{
    public partial class Ayuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename=ManualdeUsuarioWeb.pdf");
            Response.TransmitFile(Server.MapPath("~/ArchivosDescarga/Manual de Usuario Web.pdf"));
            Response.End();
        }
    }
} 