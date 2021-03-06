﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using ExportToExcel;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace AplicacionSIPA1
{
    public class FuncionesVarias
    {

        public  string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public  string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public bool esEntero(string valor)
        {
            try
            {
                int.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool esDecimal(string valor)
        {
            try
            {
                decimal.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public decimal StringToDecimal(string s)
        {
            try
            {
                s = s.Replace("Q. ", "");
                s = s.Replace("Q.", "");
                s = s.Replace("Q", "");
                s = s.Replace(" ", "");
                s = s.Replace(",", "");

                if (s.Equals(""))
                    s = "00.000000000";

                string[] sValor = s.Split('.');
                decimal d = 0;

                if (sValor.Length == 1)
                    d = decimal.Parse(sValor[0] + ".000000000");

                else
                {

                   if (sValor[1].Length == 4)
                        sValor[1] += "0000";
                    if (sValor[1].Length == 3)
                        sValor[1] += "00000";
                    if (sValor[1].Length == 2)
                        sValor[1] += "000000";
                    if (sValor[1].Length == 1)
                        sValor[1] += "0";

                    d = decimal.Parse(sValor[0] + "." + sValor[1].Substring(0, 8));
                }

                return d;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public decimal StringTo2Decimal(string s)
        {
            try
            {
                s = s.Replace("Q. ", "");
                s = s.Replace("Q.", "");
                s = s.Replace("Q", "");
                s = s.Replace(" ", "");
                s = s.Replace(",", "");

                if (s.Equals(""))
                    s = "00.00";

                string[] sValor = s.Split('.');
                decimal d = 0;

                if (sValor.Length == 1)
                    d = decimal.Parse(sValor[0] + ".00");

                else
                {

                    if (sValor[1].Length == 4)
                        sValor[1] += "0000";
                    if (sValor[1].Length == 3)
                        sValor[1] += "00000";
                    if (sValor[1].Length == 2)
                        sValor[1] += "000000";
                    if (sValor[1].Length == 1)
                        sValor[1] += "0000000";

                    d = decimal.Parse(sValor[0] + "." + sValor[1].Substring(0, 8));
                }

                return d;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public decimal StringToDecimales(string s)
        {
            s = s.Replace("Q. ", "");
            s = s.Replace("Q.", "");
            s = s.Replace("Q", "");
            s = s.Replace(" ", "");
            s = s.Replace(",", "");

            /*if (s.Equals(""))
                s = "00.00";

            string[] sValor = s.Split('.');
            decimal d = 0;

            if (sValor.Length == 1)
                d = decimal.Parse(sValor[0] + ".00");

            else
            {
                if (sValor[1].Length == 1)
                    sValor[1] += "0";

                d = decimal.Parse(sValor[0] + "." + sValor[1].Substring(0, 2));
            }*/

            return decimal.Parse(s);
        }

        public DataSet StringToFechaMySql(string stringFecha)
        {
            DataSet dsResultado = new DataSet();
            dsResultado.Tables.Add();
            dsResultado.Tables[0].Columns.Add("FECHA_VALIDA", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("MSG_ERROR", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("DIA", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("MES", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("ANIO", typeof(System.String));
            dsResultado.Tables[0].Columns.Add("FECHA_FORMATO_INSERT_MYSQL", typeof(System.String));

            DataRow dr = dsResultado.Tables[0].NewRow();
            dr["FECHA_VALIDA"] = "false";

            try
            {
                string[] sValor = { "" };

                if (stringFecha.Contains("/"))
                    sValor = stringFecha.Split('/');
                else if (stringFecha.Contains("-"))
                    sValor = stringFecha.Split('-');

                int dia, mes, anio;
                dia = mes = anio = 0;

                if (sValor.Length != 3)
                    throw new Exception();

                if (stringFecha.Contains("/"))
                {
                    int.TryParse(sValor[0], out dia);
                    int.TryParse(sValor[1], out mes);
                    int.TryParse(sValor[2], out anio);
                }
                else if (stringFecha.Contains("-"))
                {
                    int.TryParse(sValor[0], out anio);
                    int.TryParse(sValor[1], out mes);
                    int.TryParse(sValor[2], out dia);
                }

                DateTime fecha = new DateTime(anio, mes, dia);
                dr["FECHA_VALIDA"] = "true";
                dr["MSG_ERROR"] = "";
                dr["DIA"] = dia;
                dr["MES"] = mes;
                dr["ANIO"] = anio;
                //dr["FECHA_FORMATO_INSERT_MYSQL"] = anio + "-" + mes + "-" + dia;

                dr["FECHA_FORMATO_INSERT_MYSQL"] = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            }
            catch (Exception ex)
            {
                dr["FECHA_VALIDA"] = "false";
                dr["MSG_ERROR"] = ex.Message;
                dr["DIA"] = "";
                dr["MES"] = "";
                dr["ANIO"] = "";
            }
            dsResultado.Tables[0].Rows.Add(dr);
            return dsResultado;
        }

        public DataSet ArmarDsResultado()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("RESULTADO");

            dt.Columns.Add("ERRORES", typeof(String));
            dt.Columns.Add("MSG_ERROR", typeof(String));
            dt.Columns.Add("VALOR", typeof(String));
            dt.Columns.Add("CODIGO", typeof(String));
            ds.Tables.Add(dt);

            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].Rows[0]["ERRORES"] = true;
            ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
            return ds;
        }

        public string[] DatosUsuarios()
        {
            IPHostEntry host;
            string[] localIP = new string[3];
            host = Dns.GetHostEntry(Dns.GetHostName());


            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {

                    localIP[0] = ip.ToString();
                }
            }
            localIP[2] = host.HostName;
            localIP[1] = host.AddressList[0].ToString();
            return localIP;
        }
    }
}