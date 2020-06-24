using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class ModalidadServicio : Conexion
    {
        private string Id;
        private TipoEvento TipoEvento;
        private string Nombre;
        private float ValorBase;
        private int PersonalBase;

        public string Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public float ValorBase1 { get => ValorBase; set => ValorBase = value; }
        public int PersonalBase1 { get => PersonalBase; set => PersonalBase = value; }
        internal TipoEvento TipoEvento1 { get => TipoEvento; set => TipoEvento = value; }

        public List<ModalidadServicio> Read(string Proceso, int _tipoevento)
        {
            conexion(Proceso);
            cmd.Parameters.Add(new MySqlParameter("_tipoevento", _tipoevento));
            terminoConexion();

            List<ModalidadServicio> modalidadServicio = new List<ModalidadServicio>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Id1 = tabla.Rows[i]["IdModalidad"].ToString();
                Nombre1 = tabla.Rows[i]["Nombre"].ToString();
                ValorBase1 = float.Parse(tabla.Rows[i]["ValorBase"].ToString());
                PersonalBase1 = Int32.Parse(tabla.Rows[i]["PersonalBase"].ToString());
                TipoEvento tipoEvento = new TipoEvento();
                TipoEvento1 = tipoEvento.Read("getTipoEvento", Int32.Parse(tabla.Rows[i]["IdTipoEvento"].ToString()))[0];
                modalidadServicio.Add(new ModalidadServicio(Id1, Nombre1, ValorBase1, PersonalBase1, TipoEvento1));
            }
            return modalidadServicio;
        }

        public ModalidadServicio()
        {
        }

        public ModalidadServicio(string id1, string nombre1, float valorBase1, int personalBase1, TipoEvento tipoEvento1)
        {
            Id1 = id1;
            Nombre1 = nombre1;
            ValorBase1 = valorBase1;
            PersonalBase1 = personalBase1;
            TipoEvento1 = tipoEvento1;
        }
    }
}
