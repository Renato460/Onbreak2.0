using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class TipoEvento : Conexion
    {
        private int Id;
        private string Descripcion;

        public int Id1 { get => Id; set => Id = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public List<TipoEvento> Read(string Proceso, int _tipoevento)
        {
            conexion(Proceso);
            cmd.Parameters.Add(new MySqlParameter("_tipoevento", _tipoevento));
            terminoConexion();
            List<TipoEvento> tipoEvento = new List<TipoEvento>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Id1 = Int32.Parse(tabla.Rows[i]["IdTipoEvento"].ToString());
                Descripcion1 = tabla.Rows[i]["Descripcion"].ToString();
                tipoEvento.Add(new TipoEvento(Id1, Descripcion1));
            }
            return tipoEvento;

        }

        public TipoEvento()
        {
        }

        public TipoEvento(int id1, string descripcion1)
        {
            Id1 = id1;
            Descripcion1 = descripcion1;
        }
    }
}
