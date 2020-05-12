using AplicacionSIPA1.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        DataTable dt;
        Menu_C menu_c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = new DataTable();
                dt = this.GetData(0);
                PopulateMenu(dt, 0, null);

                if(Session["usuario"] != null)
                {
                    lblUser.Text = Session["usuario"].ToString();
                }else 
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }
        public DataTable GetData(int id)
        {
            menu_c = new Menu_C();
            dt = new DataTable();
            dt = menu_c.llenarMenu(id);
            return dt;
        }
        private void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = row["m_idMenu"].ToString(),
                    Text = row["m_Titulo"].ToString(),
                    NavigateUrl = row["m_url"].ToString(),
                    Selected = row["m_url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                    PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {
                    parentMenuItem.ChildItems.Add(menuItem);
                }
            }
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}