using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using Oracle.DataAccess.Client;

namespace Portafolio
{
    public partial class Mantenedor_Tareas : System.Web.UI.Page
    {
        //String de conexión
        public Oracle.DataAccess.Client.OracleConnection ora = new Oracle.DataAccess.Client.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");

        public System.Data.OracleClient.OracleConnection ora2 = new System.Data.OracleClient.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblidddl.Visible = false;
                txtCorreo.Text = Session["Value"].ToString();
                panelCRUDtarea.Visible = true;

                Array enumList1 = Enum.GetValues(typeof(tiposTarea));
                foreach (tiposTarea getTipoTarea in enumList1)
                {
                    ddlTipoTarea.Items.Add(new ListItem(getTipoTarea.ToString(), ((int)getTipoTarea).ToString()));
                }

                try
                {
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("listar_flujo_aprobado");
                    comando.Connection = ora2;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                    System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                    System.Data.OracleClient.OracleDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {

                        ddlFlujo.Items.Add(rdr.GetString(0).ToString());
                    }
                    ora2.Close();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error' " + ex.ToString() + "');</script>");
                }


            }
        }



        public enum tiposTarea
        {
            Diseñador = 0,
            Trabajador = 1
        }

        public enum tipoCrud
        {
            Crear_Tarea,
            Cambiar_Estado
        }

        public enum estado
        {
            Pendiente,
            Realizandose,
            Terminada,
            Asignandose
        }

        protected void ingresarTarea_Click(object sender, EventArgs e)
        {
            try
            {
                lblidddl.Text = "";
                //Para el Usuario
                ora.Open();
                //Llamar al Stored Procedure
                Oracle.DataAccess.Client.OracleCommand comando1 = new Oracle.DataAccess.Client.OracleCommand("seleccionar_usuarios", ora);
                comando1.CommandType = System.Data.CommandType.StoredProcedure;
                //Asignar variable de cursor
                comando1.Parameters.Add("p_correo", OracleDbType.Varchar2).Value = txtCorreo.Text;
                comando1.Parameters.Add("o_id", OracleDbType.Int32, null, ParameterDirection.Output);
                comando1.ExecuteNonQuery();

                Oracle.DataAccess.Client.OracleDataReader dr = comando1.ExecuteReader();
                int id = Int32.Parse(comando1.Parameters["o_id"].Value.ToString());
                lblidddl.Text = id.ToString();
                ora.Close();

                //Para la Tarea
                string tipo = ddlTipoTarea.SelectedItem.ToString();
                lblidddl.Text = tipo;
                int flujo = ddlFlujo.SelectedIndex + 1;

                //FECHA
                var date = fecha.SelectedDate;

                ora2.Open();
                System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("INSERT_TAREA", ora2);
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("P_NOMBRE", OracleType.VarChar).Value = txtNombre.Text;
                comando2.Parameters.Add("P_DESCRIPCION", OracleType.VarChar).Value = txtDescripcion.Text;
                comando2.Parameters.Add("P_IDUSUARIO", OracleType.Int32).Value = id;
                comando2.Parameters.Add("P_ESTADO", OracleType.Int32).Value = 4;
                comando2.Parameters.Add("P_TIPOTAREA", OracleType.VarChar).Value = tipo;
                comando2.Parameters.Add("P_FLUJO", OracleType.VarChar).Value = flujo;
                comando2.Parameters.Add("P_FECHA", OracleType.DateTime).Value = date.ToString();
                comando2.ExecuteNonQuery();
                // ora2.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Insertada');</script>");
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                // txtCorreo.Text = "";

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error' " + ex.ToString() + "');</script>");
            }

        }
    }
}