using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class Conexion
    {
        protected MySqlConnection cnn;
        protected MySqlCommand cmd;
        protected MySqlDataAdapter data;
        protected DataTable tabla;

        protected bool conexion(string Proceso)
        {
            try
            {
                cnn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=onbreak");
                cnn.Open();
                cmd = new MySqlCommand();
                cmd.CommandText = Proceso;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;
                return true;
            }
            catch 
            {
                return false;
            }
        }
        protected void terminoConexion() 
        {
            data = new MySqlDataAdapter(cmd);
            tabla = new DataTable();
            data.Fill(tabla);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public Conexion()
        {
        }
    }
}
