using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
namespace Portafolio
{
    public partial class Mantenedor_Tareas_Subordinada : System.Web.UI.Page
    {
        //String de conexión
        public Oracle.DataAccess.Client.OracleConnection ora = new Oracle.DataAccess.Client.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        public System.Data.OracleClient.OracleConnection ora2 = new System.Data.OracleClient.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        String lblidddl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            txtCorreoEncargado_2.Text = Session["Value"].ToString();
            Array enumList1 = Enum.GetValues(typeof(tiposTarea));
            foreach (tiposTarea getTipoTarea in enumList1)
            {
                ddlTipoTarea_2.Items.Add(new ListItem(getTipoTarea.ToString(), ((int)getTipoTarea).ToString()));
            }
            CargarQuerys();
        }
        public enum tiposTarea
        {
            Diseñador = 0,
            Trabajador = 1
        }

        public void CargarQuerys()
        {
            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_devueltas2");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;

                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablasTareasDevueltas.DataSource = dt;
                tablasTareasDevueltas.DataBind();

                if (tablasTareasDevueltas.Rows.Count == 0)
                {
                    // Response.Write("<script>('No hay tareas pendientes')</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
            }

            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_y_flujo");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreoEncargado_2.Text;
                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablaTareas.DataSource = dt;
                tablaTareas.DataBind();

                if (tablaTareas.Rows.Count == 0)
                {
                    Response.Write("<script>('No hay tareas pendientes')</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (drv["ESTADO"].ToString().Equals("PENDIENTE"))
                    {
                        e.Row.Cells[4].BackColor = Color.Red;
                    }
                    if (drv["ESTADO"].ToString().Equals("REALIZANDOSE"))
                    {
                        e.Row.Cells[4].BackColor = Color.Yellow;
                    }
                    if (drv["ESTADO"].ToString().Equals("TERMINADA"))
                    {
                        e.Row.Cells[4].BackColor = Color.Green;
                    }
                }
            }
        }


        protected void IngresarTarea_2_Click(object sender, EventArgs e)
        {
            try
            {
                //Para el Usuario
                ora.Open();
                //Llamar al Stored Procedure
                Oracle.DataAccess.Client.OracleCommand comando1 = new Oracle.DataAccess.Client.OracleCommand("seleccionar_usuarios", ora);
                comando1.CommandType = System.Data.CommandType.StoredProcedure;
                //Asignar variable de cursor
                comando1.Parameters.Add("p_correo", OracleDbType.Varchar2).Value = txtCorreoEncargado_2.Text;
                comando1.Parameters.Add("o_id", OracleDbType.Int32, null, ParameterDirection.Output);
                comando1.ExecuteNonQuery();

                Oracle.DataAccess.Client.OracleDataReader dr = comando1.ExecuteReader();
                int id = Int32.Parse(comando1.Parameters["o_id"].Value.ToString());
                lblidddl = id.ToString();
                ora.Close();

                //Para la Tarea
                string tipo = ddlTipoTarea_2.SelectedItem.ToString();
                lblidddl = tipo;
                GridViewRow rowTarea = tablaTareas.SelectedRow;
                string textTarea = rowTarea.Cells[1].Text;

                //FECHA
                var date = fecha.SelectedDate;

                ora2.Open();
                System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("INSERT_TAREA_SUB", ora2);
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando2.Parameters.Add("P_NOMBRE", OracleType.VarChar).Value = txtNombre.Text;
                comando2.Parameters.Add("P_DESCRIPCION", OracleType.VarChar).Value = txtDescripcionTarea_2.Text;
                comando2.Parameters.Add("P_IDUSUARIO", OracleType.Int32).Value = id;
                comando2.Parameters.Add("P_ESTADO", OracleType.Int32).Value = 4;
                comando2.Parameters.Add("P_TIPOTAREA", OracleType.VarChar).Value = tipo;
                comando2.Parameters.Add("P_FECHA", OracleType.DateTime).Value = date.ToString();
                comando2.ExecuteNonQuery();
                // ora2.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Insertada');</script>");
                CargarQuerys();
                txtDescripcionTarea_2.Text = "";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error' " + ex.ToString() + "');</script>");
            }
        }

        protected void reasignar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row using the SelectedRow property.
                GridViewRow rowTarea = tablasTareasDevueltas.SelectedRow;
                string textTarea = rowTarea.Cells[1].Text;
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("update_tarea_reasignar4");
                comando.Connection = ora2;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreoReasignar.Text;
                comando.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando.ExecuteNonQuery();
                ora2.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea reaignada');</script>");
                CargarQuerys();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");

            }

        }

    }
}