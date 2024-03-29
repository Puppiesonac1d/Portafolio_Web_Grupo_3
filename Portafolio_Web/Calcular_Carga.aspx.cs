﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows;

namespace Portafolio
{
    public partial class Calcular_Carga : System.Web.UI.Page
    {
        //String de conexión
        public Oracle.DataAccess.Client.OracleConnection ora = new Oracle.DataAccess.Client.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        public System.Data.OracleClient.OracleConnection ora2 = new System.Data.OracleClient.OracleConnection("Data Source=localhost;Password=portafolio;USER ID=portafolio;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtCorreo.Visible = false;
                txtCorreo.Text = Session["Value"].ToString();
                txtError_asignacion.Visible = false;
                lblMensaje.Visible = false;
                lblMensaje_2.Visible = false;
                CargarQuery();
                Array enumList3 = Enum.GetValues(typeof(estado));
                foreach (estado getEstado in enumList3)
                {
                    ddlCambiarEstado.Items.Add(new ListItem(getEstado.ToString(), ((int)getEstado).ToString()));
                    ddlCambiarEstado2.Items.Add(new ListItem(getEstado.ToString(), ((int)getEstado).ToString()));
                }
            }
        }

        //Enumerador
        public enum estado
        {
            Pendiente,
            Realizandose,
            Terminada,
            Devolver
        }

        public void CargarQuery()
        {
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
                System.Data.OracleClient.OracleCommand comando3 = new System.Data.OracleClient.OracleCommand("listar_tareas_asignandose");
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
                    lblMensaje.Visible = true;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas pendientes');</script>");
                }
                else
                {
                    lblMensaje.Visible = false;
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
                    lblMensaje_2.Visible = true;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas pendientes');</script>");
                }
                else
                {
                    lblMensaje_2.Visible = false;
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

        protected void GridView1_RowDataBound_2(object sender, GridViewRowEventArgs e)
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
                comando.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                comando.ExecuteNonQuery();
                ora2.Close();
                if (tablaPendientes.Rows.Count == 0)
                {
                    lblMensaje.Visible = true;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No hay tareas pendientes');</script>");
                }
                else
                {
                    lblMensaje.Visible = false;
                }
                CargarQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Asignada');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando');</script>");

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
                CargarQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Asignada');</script>");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error actualizando una tarea subordinada');</script>");

            }



        }


        protected void btnCargarTareas_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ddlCambiarEstado.SelectedIndex + 1;
                if (id == 4)
                {

                    // Get the currently selected row using the SelectedRow property.
                    GridViewRow rowTarea = tablaCarga.SelectedRow;
                    // In this example, the first column (index 0) contains
                    string textTarea = rowTarea.Cells[1].Text;
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_reasignar5");
                    comando2.Connection = ora2;
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                    comando2.ExecuteNonQuery();
                    ora2.Close();
                    CargarQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea devuelta, revisar el apartado de Agregar Tarea');</script>");
                }
                else
                {

                    // Get the currently selected row using the SelectedRow property.
                    GridViewRow rowTarea = tablaCarga.SelectedRow;
                    // In this example, the first column (index 0) contains
                    string textTarea = rowTarea.Cells[1].Text;
                    string idTarea = id.ToString();
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_estado");
                    comando2.Connection = ora2;
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("p_estado", OracleType.Int32).Value = id;
                    comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                    comando2.ExecuteNonQuery();
                    ora2.Close();
                    CargarQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Actualizada');</script>");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

            }
        }


        protected void btnCargarTareas_2_Click(object sender, EventArgs e)
        {
            int id = ddlCambiarEstado2.SelectedIndex + 1;
            if (id == 4)
            {
                try
                {
                    // Get the currently selected row using the SelectedRow property.
                    GridViewRow rowTarea = tablaCarga2.SelectedRow;
                    // In this example, the first column (index 0) contains
                    string textTarea = rowTarea.Cells[1].Text;

                    string idTarea = id.ToString();
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_reasignar3");
                    comando2.Connection = ora2;
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                    comando2.ExecuteNonQuery();
                    ora2.Close();
                    CargarQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea devuelta, revisar el apartado de Agregar Tarea Subordinada');</script>");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

                }
            }
            else
            {
                try
                {
                    // Get the currently selected row using the SelectedRow property.
                    GridViewRow rowTarea = tablaCarga2.SelectedRow;
                    // In this example, the first column (index 0) contains
                    string textTarea = rowTarea.Cells[1].Text;

                    string idTarea = id.ToString();
                    ora2.Open();
                    System.Data.OracleClient.OracleCommand comando2 = new System.Data.OracleClient.OracleCommand("update_tarea_sub_estado");
                    comando2.Connection = ora2;
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("p_estado", OracleType.Int32).Value = id;
                    comando2.Parameters.Add("P_IDTAREA", OracleType.Int32).Value = Int32.Parse(textTarea);
                    comando2.ExecuteNonQuery();
                    ora2.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Tarea Actualizada');</script>");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ha ocurrido un error');</script>");

                }
            }
            CargarQuery();
        }
    }
}