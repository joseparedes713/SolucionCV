using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AplicacionSIPA1
{
    public class DBHelper
    {
        /*
        public static bool ExecuteXel(string sql, SqlParameter[] sqlParameters, System.Xml.XmlDocument xmlDocument)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandTimeout = Convert.ToInt16(ConfigurationManager.AppSettings.Get("connectionCommnadTimeout"));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if(sqlParameters != null)
            {
                foreach(SqlParameter parameter in sqlParameters)
                {
                    cmd.Parameters.Add(sqlParameters);
                }
            }
            con.Close();
            bool bReturn;
            try
            {
                using (SqlDataReader dt = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dt.Read())
                    {
                        System.Data.SqlTypes.SqlXml sqlXml = dt.GetSqlXml(dt.GetOrdinal("Xml"));
                        xmlDocument.LoadXml(sqlXml.Value);
                    }
                    else
                    {
                        bReturn = false;
                    }
                }
            }

        }

    */
    }
}