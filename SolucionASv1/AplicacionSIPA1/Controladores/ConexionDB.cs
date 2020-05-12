using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace AplicacionSIPA1.Controladores
{
    public class ConexionDB
    {



        private String contenido = "server=localhost; database =db_solucion; user=root; password =admin";
        //private String contenido = "server=localhost; database =dbcdagsipaprueba2; user=root; password =admin";

        //    private String contenido = "server=10.200.2.198; database =dbcdagsipa;user=usr_cdag_sipa; password =5sr_cd1g_s3pa";
        public MySqlConnection conectar;// = new MySqlConnection();
        public void AbrirConexion()
        {
            string sConn;
            sConn = contenido;
            conectar = new MySqlConnection();
            conectar.ConnectionString = sConn;

            try
            {
                conectar.Open();
                Console.WriteLine("Conexión Exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Fallo en la Conexión");

                throw;
            }
        }

        public void CerrarConexion()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }

        


    }
}