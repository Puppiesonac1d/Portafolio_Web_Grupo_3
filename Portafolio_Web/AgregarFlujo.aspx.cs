using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portafolio
{
    public partial class AgregarFlujo : System.Web.UI.Page
    {

        public System.Data.OracleClient.OracleConnection ora2 = new System.Data.OracleClient.OracleConnection("Data Source=localhost;Password=HR;USER ID=HR;");
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("listar_flujo");
                comando.Connection = ora2;
                comando.Connection = ora2;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tblFlujo.DataSource = dt;
                tblFlujo.DataBind();
                ora2.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }

        protected void btnGuardarFlujo_Click(object sender, EventArgs e)
        {
            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("INSERT_flujo", ora2);
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("P_DESCRIPCION", OracleType.VarChar).Value = txtNombreFlujo.Text;
                comando2.Parameters.Add("P_ESTADO", OracleType.VarChar).Value = "Pendiente de Aprobación";
                comando2.ExecuteNonQuery();
                ora2.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Flujo Agregado');</script>");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }

            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("listar_flujo");
                comando.Connection = ora2;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                tblFlujo.DataSource = dt;
                tblFlujo.DataBind();
                ora2.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }
    }
}