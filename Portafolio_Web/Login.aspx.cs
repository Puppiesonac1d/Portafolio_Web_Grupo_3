using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio
{
    public partial class Login : System.Web.UI.Page
    {
        //String de conexión
        public OracleConnection ora = new OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (correo != null)
                {
                    lblError.Visible = true;
                    //Abrir conexión
                    ora.Open();
                    //Llamar al Stored Procedure
                    OracleCommand comando = new OracleCommand("iniciar_sesion_usuario", ora);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    //Asignar variable de cursor
                    comando.Parameters.Add("p_correo", OracleDbType.Varchar2).Value = correo.Value.ToUpper();
                    comando.Parameters.Add("p_contrasena", OracleDbType.Varchar2).Value = contrasena.Value;
                    comando.Parameters.Add("o_correo", OracleDbType.Varchar2, 30, null, ParameterDirection.Output);
                    comando.Parameters.Add("o_contrasena", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);
                    comando.Parameters.Add("o_credencial", OracleDbType.Int32, null, ParameterDirection.Output);
                    comando.ExecuteNonQuery();

                    OracleDataReader dr = comando.ExecuteReader();
                    string correoTMP = comando.Parameters["o_correo"].Value.ToString().ToUpper();
                    string contrasenaTMP = comando.Parameters["o_contrasena"].Value.ToString();
                    string credencialStr = comando.Parameters["o_credencial"].Value.ToString();

                    if (correoTMP == correo.Value.ToString().ToUpper() && contrasenaTMP == contrasena.Value.ToString() && credencialStr != "1")
                    {
                        Session["Value"] = correoTMP.ToString();
                        Session["Value2"] = contrasenaTMP.ToString();
                        Session["Value3"] = credencialStr.ToString();
                        if (Session["Value"] != null)
                        {
                            Response.Redirect("Calcular_Carga.aspx");

                        }
                        else
                        {
                            lblError.Text = "Ha ocurrido un error";
                        }

                    }

                    ora.Close();
                }
                else
                {
                    lblError.Text = "Debe ingresar los datos de usuario";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Debe ingresar los datos de usuario";
            }

        }
    }
}