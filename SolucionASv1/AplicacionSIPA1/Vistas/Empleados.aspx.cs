using AplicacionSIPA1.Controladores;
using AplicacionSIPA1.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Vistas
{
    public partial class Empleados : System.Web.UI.Page
    {
        FuncionesVarias func;
        Menu_C menu_C;
        Menu_M menu_M;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarEmpleadoDDl(ddlEmpleados);
                llenarEmpleados(gvEmpleado);
                limpiar();
            }
        }


        public void llenarEmpleadoDDl(DropDownList drop )
        {
            dt = new DataTable();
            menu_C = new Menu_C();
            dt = menu_C.llenarEmpleadoDDL();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Elija un valor");
            drop.Items[0].Value = "0";
            drop.DataSource = menu_C.llenarEmpleadoDDL();
            drop.DataTextField = "nombre";
            drop.DataValueField = "e_idEmpleado";
            drop.DataBind();

        }
        public void llenarEmpleados(GridView grid)
        {
            grid.DataSource = null;
            menu_C = new Menu_C();
            grid.DataSource = menu_C.listadoUsaurioDT();
            grid.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            menu_C = new Menu_C();
            menu_M = new Menu_M();
            func = new FuncionesVarias();
            dt = new DataTable();
            string  key = "b14ca5898a4e4133bbce2ea2315a1916";
            //            string encryp = func.EncryptString(key, txtContrasenia.Text); .Rows[0]["mensaje"].ToString()
            if (validarControles() == true) 
            {
                menu_M.usuario = txtUsuario.Text;
                menu_M.contrasenia = func.EncryptString(key, txtContrasenia.Text);
                menu_M.idEmpledo = int.Parse( ddlEmpleados.SelectedValue);
                try
                {
                    dt = menu_C.ingresoUsuario(menu_M);
                    if (dt.Rows.Count > 0)
                    {
                        lblSuccess.Visible = true;
                        lblSuccess.Text = "Ingreso Exitosamente" + dt.Rows[0]["mensaje"].ToString();
                        //limpiar();
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Error al ingresar";
                    }

                }catch(Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "Error.." + ex.ToString();
                }


            }
        }

        public void limpiar()
        {
            ddlEmpleados.ClearSelection();
            txtUsuario.Text = txtContrasenia.Text = txtVcontrasenia.Text = string.Empty;
            lblError.Visible = lblSuccess.Visible = false;
        }
        public bool validarControles()
        {
            if(txtUsuario.Text == string.Empty)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese un usuaio";
                return false;
            }
            if(ddlEmpleados.SelectedValue != "0")
            {
                lblError.Visible = true;
                lblError.Text = "Seleccione el Empleado";
                return false;


            }
            if ( txtContrasenia.Text == string.Empty)
            {
                lblError.Visible = true;
                lblError.Text = "Ingrese un usuaio";
                return false;
            }
            if(txtContrasenia.Text != txtVcontrasenia.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Las contrase;as no coinciden";
                return false;

            }
            return true;
        }
    }
}