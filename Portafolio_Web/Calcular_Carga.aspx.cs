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
    public partial class Calcular_Carga : System.Web.UI.Page
    {
        //String de conexión
        public Oracle.DataAccess.Client.OracleConnection ora = new Oracle.DataAccess.Client.OracleConnection("Data Source=localhost;Password=HR;USER ID=HR;");
        public System.Data.OracleClient.OracleConnection ora2 = new System.Data.OracleClient.OracleConnection("Data Source=localhost;Password=HR;USER ID=HR;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                div_calcular_carga_correo.Visible = false;
                txtCorreo.Text = Session["Value"].ToString();
                txtCorreo.Enabled = false;
                txtError_asignacion.Visible = false;
                try
                {
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_y_flujo");
                    comando3.Connection = ora2;
                    comando3.CommandType = System.Data.CommandType.StoredProcedure;
                    comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                    comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                    System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                    adaptador.SelectCommand = comando3;
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    tablaCarga.DataSource = dt;
                    tablaCarga.DataBind();

                    if (tablaCarga.Rows.Count == 0)
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
                    System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_sub_y_flujo");
                    comando3.Connection = ora2;
                    comando3.CommandType = System.Data.CommandType.StoredProcedure;
                    comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                    comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                    System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                    adaptador.SelectCommand = comando3;
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    tablaCarga2.DataSource = dt;
                    tablaCarga2.DataBind();

                    if (tablaCarga2.Rows.Count == 0)
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
                    System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_sub_asignandose");
                    comando3.Connection = ora2;
                    comando3.CommandType = System.Data.CommandType.StoredProcedure;
                    comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                    comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                    System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                    adaptador.SelectCommand = comando3;
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    tablaPendientes2.DataSource = dt;
                    tablaPendientes2.DataBind();

                    if (tablaPendientes2.Rows.Count == 0)
                    {
                        // Response.Write("<script>('No hay tareas pendientes')</script>");
                    }
                    ora2.Close();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
                }

                Array enumList3 = Enum.GetValues(typeof(estado));
                foreach (estado getEstado in enumList3)
                {
                    ddlCambiarEstado.Items.Add(new ListItem(getEstado.ToString(), ((int)getEstado).ToString()));
                    ddlCambiarEstado2.Items.Add(new ListItem(getEstado.ToString(), ((int)getEstado).ToString()));
                }

                try
                {
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("LISTAR_TAREAS_ASIGNANDOSE");
                    comando3.Connection = ora2;
                    comando3.CommandType = System.Data.CommandType.StoredProcedure;
                    comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                    comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                    System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                    adaptador.SelectCommand = comando3;
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    tablaPendientes.DataSource = dt;
                    tablaPendientes.DataBind();
                    /*
                    if (dt.ToString().Length == null)
                    {

                        txtError_asignacion.Visible = true;
                        // Response.Write("<script>('No hay tareas pendientes')</script>");
                        txtError_asignacion.Text = "No hay tareas pendientes";
                    }
                    */
                    if (tablaPendientes.Rows.Count == 0)
                    {
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas pendientes');</script>");
                    }

                    ora2.Close();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
                }
            }
        }

        //Enumerador
        public enum estado
        {
            Pendiente,
            Realizandose,
            Terminada
        }



        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row using the SelectedRow property.
                GridViewRow rowTarea = tablaPendientes.SelectedRow;
                string textTarea = rowTarea.Cells[1].Text;
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("update_tarea_reasignar");
                comando.Connection = ora2;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando.Parameters.Add("p_estado", OracleType.Int32).Value = 1;
                comando.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando.ExecuteNonQuery();
                ora2.Close();


            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");

            }

            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("LISTAR_TAREAS_ASIGNANDOSE");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablaPendientes.DataSource = dt;
                tablaPendientes.DataBind();

                if (tablaPendientes.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas pendientes');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea asignada a ' " + txtCorreo.Text + "');</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error cargando tareas');</script>");

            }

        }


        protected void btnAsignar_2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row using the SelectedRow property.
                GridViewRow rowTarea = tablaPendientes2.SelectedRow;
                string textTarea = rowTarea.Cells[1].Text;
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando = new System.Data.OracleClient.OracleCommand("update_tarea_sub_reasignar");
                comando.Connection = ora2;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando.Parameters.Add("p_estado", OracleType.Int32).Value = 1;
                comando.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando.ExecuteNonQuery();
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");

            }

            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_sub_y_flujo");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablaCarga2.DataSource = dt;
                tablaCarga2.DataBind();

                if (tablaCarga2.Rows.Count == 0)
                {
                    // Response.Write("<script>('No hay tareas pendientes')</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
            }

        }


        protected void btnCargarTareas_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row using the SelectedRow property.
                GridViewRow rowTarea = tablaCarga.SelectedRow;
                // In this example, the first column (index 0) contains
                string textTarea = rowTarea.Cells[1].Text;

                int id = ddlCambiarEstado.SelectedIndex + 1;
                string idTarea = id.ToString();
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_estado");
                comando2.Connection = ora2;
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("p_estado", OracleType.Int32).Value = id;
                comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando2.ExecuteNonQuery();
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

            }


            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_y_flujo");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablaCarga.DataSource = dt;
                tablaCarga.DataBind();

                if (tablaCarga.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas');</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

            }

        }

        protected void btnCargarTareas_2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row using the SelectedRow property.
                GridViewRow rowTarea = tablaCarga2.SelectedRow;
                // In this example, the first column (index 0) contains
                string textTarea = rowTarea.Cells[1].Text;

                int id = ddlCambiarEstado2.SelectedIndex + 1;
                string idTarea = id.ToString();
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_sub_estado");
                comando2.Connection = ora2;
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("p_estado", OracleType.Int32).Value = id;
                comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando2.ExecuteNonQuery();
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

            }
            try
            {
                ora2.Open();
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_sub_y_flujo");
                comando3.Connection = ora2;
                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                comando3.Parameters.Add("p_correo", OracleType.VarChar).Value = txtCorreo.Text;
                comando3.Parameters.Add("p_recordset", OracleType.Cursor).Direction = ParameterDirection.Output;
                System.Data.OracleClient.OracleDataAdapter adaptador = new System.Data.OracleClient.OracleDataAdapter();

                adaptador.SelectCommand = comando3;
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                tablaCarga2.DataSource = dt;
                tablaCarga2.DataBind();

                if (tablaCarga2.Rows.Count == 0)
                {
                    // Response.Write("<script>('No hay tareas pendientes')</script>");
                }
                ora2.Close();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");
            }


        }
    }
}