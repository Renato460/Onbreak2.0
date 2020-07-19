using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class ActividadEmpresa : Conexion
    {
        private int id = 0;
        private string Descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public List<ActividadEmpresa> Read() 
        {
            conexion("ActiEmpresa");
            terminoConexion();
            List<ActividadEmpresa> ListaActividad = new List<ActividadEmpresa>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Id = Int32.Parse(tabla.Rows[i]["ID"].ToString());
                Descripcion1 = tabla.Rows[i]["Descripcion"].ToString();
                ListaActividad.Add(new ActividadEmpresa(this.Id,this.Descripcion1));
            }

            return ListaActividad;
        }

        public ActividadEmpresa(int id, string descripcion1)
        {
            Id = id;
            Descripcion1 = descripcion1;
        }

        public ActividadEmpresa()
        {
        }
    }
}
