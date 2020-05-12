using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using AplicacionSIPA1.Modelo;

namespace AplicacionSIPA1.Controladores
{
    public class Menu_C
    {
        ConexionDB conectar;
        DataTable dt;

        public DataTable llenarMenu(int idMenu)
        {
            conectar = new ConexionDB();
            dt = new DataTable();
            try
            {
                string query = string.Format("SELECT m_idMenu, m_Titulo, m_descripcion, m_url from so_menu where m_idPadre = {0}", idMenu);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(dt);
                conectar.CerrarConexion();


            }catch(Exception ex)
            {
                dt = null;
                conectar.CerrarConexion();
            }

            return dt;
        }

        public String inicioSesion(Menu_M menu_m)
        {
            conectar = new ConexionDB();
            string usuario = "";
            try
            {
                conectar.AbrirConexion();
                string query = string.Format("call sp_iniciarSession(0, '{0}', '{1}',0, 1);", menu_m.usuario, menu_m.contrasenia);
                MySqlCommand cmd = new MySqlCommand(query, conectar.conectar);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    usuario = dt.GetString("u_usuario");
                }
            }catch(Exception ex){ usuario = "false"; conectar.CerrarConexion();}

            return usuario;

        }


        public DataTable llenarEmpleadoDDL()
        {
            conectar = new ConexionDB();
           
            dt = new DataTable();
            string query = string.Format("call sp_iniciarSession(0, 0, 0,0, 3);");
            try
            {
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(dt);
                conectar.CerrarConexion();
            }
            catch(Exception ex) { conectar.CerrarConexion(); }
             return dt;

        }

        public DataTable listadoUsaurioDT()
        {
            conectar = new ConexionDB();

            dt = new DataTable();
            string query = string.Format("call sp_iniciarSession(0, 0, 0, 0,4);");
            try
            {
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(dt);
                conectar.CerrarConexion();

            }
            catch (Exception ex) { conectar.CerrarConexion(); }
            return dt;
        }
        public DataTable ingresoUsuario(Menu_M menu_M)
        {
            conectar = new ConexionDB();
            dt = new DataTable();
            try
            {
                string query = string.Format("call sp_iniciarSession(0, '{0}', '{1}',{2}, 2);",menu_M.usuario, menu_M.contrasenia, menu_M.idEmpledo);
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(dt);
                dt.Rows[0]["mensaje"].ToString();
                conectar.CerrarConexion();

                return dt;
                
            }
            catch (Exception ex) { conectar.CerrarConexion(); return null; }
            

        }

    }
}