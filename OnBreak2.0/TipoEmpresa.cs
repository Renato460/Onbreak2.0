using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class TipoEmpresa : Conexion
    {
        private int Id = 0;
        private string Descripcion;

        public int Id1 { get => Id; set => Id = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public TipoEmpresa()
        {
        }

        public TipoEmpresa(int id1, string descripcion1)
        {
            Id1 = id1;
            Descripcion1 = descripcion1;
        }

        public List<TipoEmpresa> Read() 
        {
            conexion("TipoEmpresa");
            terminoConexion();
            List<TipoEmpresa> ListaTipoEmpresa = new List<TipoEmpresa>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Id1 = Int32.Parse(tabla.Rows[i]["ID"].ToString());
                Descripcion1 = tabla.Rows[i]["Descripcion"].ToString();
                ListaTipoEmpresa.Add(new TipoEmpresa(this.Id1, this.Descripcion1));
            }

            return ListaTipoEmpresa;
        }


    }
}
