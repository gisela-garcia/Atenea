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
    public class PruebaData
    {
        private static string constr { get { return ConfigurationManager.ConnectionStrings["GRADES"].ConnectionString; } }
        public List<Prueba> GetListDescriptores()
        {
            ///Conexión a la base de datos
            SqlConnection connection = new SqlConnection(constr);
            List<Prueba> lista = new List<Prueba> { };
            try
            {

                SqlCommand com = new SqlCommand("PROC_AGREGA_ASSIGNMENTS", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 120;

                com.Parameters.Add(new SqlParameter("ID_CURSO", SqlDbType.VarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = "CVA.DUMMY.2.2113.99999"
                });
                com.Parameters.Add(new SqlParameter("BANDERA", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = 2
                });

                if (connection.State == ConnectionState.Closed) { connection.Open(); }

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Prueba temp = new Prueba
                    {
                        name = (!reader.IsDBNull(1) ? reader.GetString(1) : ""),
                        id = (!reader.IsDBNull(2) ? reader.GetInt32(2) : 0)
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
    }
}