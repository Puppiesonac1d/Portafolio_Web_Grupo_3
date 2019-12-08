using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oracle.DataAccess.Client;
namespace Portafolio
{
    public partial class SiteMaster : MasterPage
    {
        //String de conexión
        public OracleConnection ora = new OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["Value"].ToString();
            if (Session["Value3"].ToString().Equals("2"))
            {
                agregarFlujo.Visible = false;
            }

        }
    }
}