using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AplicacionSIPA1.Modelo;
using AplicacionSIPA1.Controladores;

namespace AplicacionSIPA1
{
    public partial class Login : System.Web.UI.Page
    {
        Menu_M menu_m;
        Menu_C menu_c;
        FuncionesVarias func;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                if (Session["usuario"] != null)
                {
                    Response.Redirect("./Login.aspx");
                }

            }
        }

        protected void btnInicioSession_Click(object sender, EventArgs e)
        {
            menu_m = new Menu_M();
            menu_c = new Menu_C();
            func = new FuncionesVarias();
            string key = "b14ca5898a4e4133bbce2ea2315a1916";


            menu_m.usuario = txtUser.Text;
            menu_m.contrasenia = func.EncryptString(key, txtPassword.Text);
            string resultado = menu_c.inicioSesion(menu_m);
            if (resultado != "false")
            {
                if (resultado == txtUser.Text)
                {
                    Session["usuario"] = txtUser.Text;
                    Response.Redirect("~/WebForm1.aspx");

                }else
                {
                    lblError.Visible = true;
                    lblError.Text = "Usuario/Contraseña no coinciden";
                    txtPassword.Text = string.Empty;
                }

            }else
            {
                lblError.Visible = true;
                lblError.Text = "Algo ocurrio mal..";
            }

           

        }

        public void limpiarCampos()
        {
            txtUser.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }
    }
}