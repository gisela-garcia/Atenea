using Atenea.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atenea.Data
{
    public class DescriptoresData
    {
        private static string constr { get { return ConfigurationManager.ConnectionStrings["PLATAFORMAS"].ConnectionString; } }
        public List<Descriptor> GetListDescriptores()
        {
            ///Conexión a la base de datos
            SqlConnection connection = new SqlConnection(constr);
            List<Descriptor> lista = new List<Descriptor> ();
            try
            {

                SqlCommand com = new SqlCommand("LIST_ATENEA_DESCRIPTORES", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 120;

                if (connection.State == ConnectionState.Closed) { connection.Open(); }

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Descriptor temp = new Descriptor
                    {
                        claveSubcompetencia = (!reader.IsDBNull(0) ? reader.GetString(0) : ""),
                        nivel0 = (!reader.IsDBNull(1) ? reader.GetString(1) : ""),
                        nivel1 = (!reader.IsDBNull(2) ? reader.GetString(2) : ""),
                        nivel2 = (!reader.IsDBNull(3) ? reader.GetString(3) : ""),
                        nivel3 = (!reader.IsDBNull(4) ? reader.GetString(4) : ""),
                        nivel4 = (!reader.IsDBNull(5) ? reader.GetString(5) : "")
                    };
                    lista.Add(temp);
                }
                reader.Close();

                com.Dispose();

            }
            catch (Exception ex)
            {
                var res = ex.Message;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return lista;
        }

        public string AgregaDescriptor(Descriptor data)
        {
            ///Conexión a la base de datos
            SqlConnection connection = new SqlConnection(constr);
            string Result = "";
            try
            {

                SqlCommand com = new SqlCommand("PROC_AGREGA_ATENEA_DESCRIPTOR", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 120;

                com.Parameters.Add(new SqlParameter("claveSubcompetencia", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.claveSubcompetencia
                });
                com.Parameters.Add(new SqlParameter("nivel0", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.nivel0
                });
                com.Parameters.Add(new SqlParameter("nivel1", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.nivel1
                });
                com.Parameters.Add(new SqlParameter("nivel2", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.nivel2
                });
                com.Parameters.Add(new SqlParameter("nivel3", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.nivel3
                });
                com.Parameters.Add(new SqlParameter("nivel4", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = data.nivel4
                });
                


                if (connection.State == ConnectionState.Closed) { connection.Open(); }

                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    Result = (!reader.IsDBNull(0) ? reader.GetString(0) : "");
                }
                reader.Close();

                com.Dispose();

            }
            catch (Exception ex)
            {
                var res = ex.Message;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return Result;
        }
    }
}