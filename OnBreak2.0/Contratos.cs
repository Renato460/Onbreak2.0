using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class Contratos : Conexion
    {
        private string NumeroContrato;
        private DateTime Creacion;
        private DateTime Termino;
        private string RutCliente;
        private string NombreCliente;
        private string Modalidad;
        private string TipoEvento;
        private DateTime FechaHoraInicio;
        private DateTime FechaHoraTermino;
        private int Asistentes;
        private int PersonalAdicional;
        private int Realizado;
        private float ValorTotalContrato;
        private string Observaciones;

        public string NumeroContrato1 { get => NumeroContrato; set => NumeroContrato = value; }
        public DateTime Creacion1 { get => Creacion; set => Creacion = value; }
        public DateTime Termino1 { get => Termino; set => Termino = value; }
        public string RutCliente1 { get => RutCliente; set => RutCliente = value; }
        public string NombreCliente1 { get => NombreCliente; set => NombreCliente = value; }
        public string Modalidad1 { get => Modalidad; set => Modalidad = value; }
        public string TipoEvento1 { get => TipoEvento; set => TipoEvento = value; }
        public DateTime FechaHoraInicio1 { get => FechaHoraInicio; set => FechaHoraInicio = value; }
        public DateTime FechaHoraTermino1 { get => FechaHoraTermino; set => FechaHoraTermino = value; }
        public int Asistentes1 { get => Asistentes; set => Asistentes = value; }
        public int PersonalAdicional1 { get => PersonalAdicional; set => PersonalAdicional = value; }
        public int Realizado1 { get => Realizado; set => Realizado = value; }
        public float ValorTotalContrato1 { get => ValorTotalContrato; set => ValorTotalContrato = value; }
        public string Observaciones1 { get => Observaciones; set => Observaciones = value; }


        /*
      
        
        public bool Delete() { }
        public bool ReadAll() { }*/
        public bool TerminoContrato(string Proceso, string _Numero, DateTime _termino)
        {
            conexion(Proceso);
            cmd.Parameters.Add(new MySqlParameter("_Numero", _Numero));
            cmd.Parameters.Add(new MySqlParameter("_termino", _termino));
            MySqlParameter result = new MySqlParameter("ingresado", 0);
            result.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(result);
            cmd.ExecuteNonQuery();
            cnn.Close();
            if (Int32.Parse(cmd.Parameters["ingresado"].Value.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(string Proceso, string _Numero, string _IdModalidad, int _IdTipoEvento, DateTime _FechaHoraInicio,
            DateTime _FechaHoraTermino, int _Asistentes, int _PersonalAdicional, int _Realizado, float _ValorTotalContrato, string _Observaciones) 
        {
            try
            {
                conexion(Proceso);
                cmd.Parameters.Add(new MySqlParameter("_Numero", _Numero));
                cmd.Parameters.Add(new MySqlParameter("_IdModalidad", _IdModalidad));
                cmd.Parameters.Add(new MySqlParameter("_IdTipoEvento", _IdTipoEvento));
                cmd.Parameters.Add(new MySqlParameter("_FechaHoraInicio", _FechaHoraInicio));
                cmd.Parameters.Add(new MySqlParameter("_FechaHoraTermino", _FechaHoraTermino));
                cmd.Parameters.Add(new MySqlParameter("_Asistentes", _Asistentes));
                cmd.Parameters.Add(new MySqlParameter("_PersonalAdicional", _PersonalAdicional));
                cmd.Parameters.Add(new MySqlParameter("_Realizado", _Realizado));
                cmd.Parameters.Add(new MySqlParameter("_ValorTotalContrato", _ValorTotalContrato));
                cmd.Parameters.Add(new MySqlParameter("_Observaciones", _Observaciones));
                MySqlParameter result = new MySqlParameter("ingresado", 0);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);
                cmd.ExecuteNonQuery();
                cnn.Close();
                if (Int32.Parse(cmd.Parameters["ingresado"].Value.ToString()) == 1)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public bool Create(string Proceso,string _Numero, DateTime _Creacion, string _RutCliente, string _IdModalidad,int _IdTipoEvento, DateTime _FechaHoraInicio, 
            DateTime _FechaHoraTermino, int _Asistentes,int _PersonalAdicional,int _Realizado,float _ValorTotalContrato, string _Observaciones)
        {
            try
            {
                conexion(Proceso);

                cmd.Parameters.Add(new MySqlParameter("_Numero", _Numero));
                cmd.Parameters.Add(new MySqlParameter("_Creacion", _Creacion));
                cmd.Parameters.Add(new MySqlParameter("_RutCliente", _RutCliente));
                cmd.Parameters.Add(new MySqlParameter("_IdModalidad", _IdModalidad));
                cmd.Parameters.Add(new MySqlParameter("_IdTipoEvento", _IdTipoEvento));
                cmd.Parameters.Add(new MySqlParameter("_FechaHoraInicio", _FechaHoraInicio));
                cmd.Parameters.Add(new MySqlParameter("_FechaHoraTermino", _FechaHoraTermino));
                cmd.Parameters.Add(new MySqlParameter("_Asistentes", _Asistentes));
                cmd.Parameters.Add(new MySqlParameter("_PersonalAdicional", _PersonalAdicional));
                cmd.Parameters.Add(new MySqlParameter("_Realizado", _Realizado));
                cmd.Parameters.Add(new MySqlParameter("_ValorTotalContrato", _ValorTotalContrato));
                cmd.Parameters.Add(new MySqlParameter("_Observaciones", _Observaciones));

                MySqlParameter result = new MySqlParameter("ingresado", 0);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);
                cmd.ExecuteNonQuery();
                cnn.Close();
                if (Int32.Parse(cmd.Parameters["ingresado"].Value.ToString()) == 1)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
       
        /*public int prueba(string Proceso, string numero, string rutCliente, string modalidad, int tipoEvento)
        {
            if (conexion(Proceso))
            {
                cmd.Parameters.Add(new MySqlParameter("_numero", numero));
                cmd.Parameters.Add(new MySqlParameter("_rutCliente", rutCliente));
                cmd.Parameters.Add(new MySqlParameter("_idModalidad", modalidad));
                cmd.Parameters.Add(new MySqlParameter("_idTipoEvento", tipoEvento));
                MySqlParameter result = new MySqlParameter("respuesta", 0);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);
                terminoConexion();
                int total = tabla.Rows.Count;
                return total;
            }
            else
            {
                return 0;
            }
            
        }*/

        public ObservableCollection<Contratos> Read(string Proceso,string numero,string rutCliente, string modalidad, int tipoEvento )
        {
            try
            {
                conexion(Proceso);

                cmd.Parameters.Add(new MySqlParameter("_numero", numero));
                cmd.Parameters.Add(new MySqlParameter("_rutCliente", rutCliente));
                cmd.Parameters.Add(new MySqlParameter("_idModalidad", modalidad));
                cmd.Parameters.Add(new MySqlParameter("_idTipoEvento", tipoEvento));
                MySqlParameter result = new MySqlParameter("respuesta", 0);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);
                terminoConexion();

                ObservableCollection<Contratos> ColecctionContrato = new ObservableCollection<Contratos>();
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    
                    NumeroContrato1 = tabla.Rows[i]["Numero"].ToString();
                    Creacion1 = DateTime.Parse(tabla.Rows[i]["Creacion"].ToString());
                    Termino1 = DateTime.Parse(tabla.Rows[i]["Termino"].ToString());
                    RutCliente1 = tabla.Rows[i]["RutCliente"].ToString();
                    NombreCliente1 = tabla.Rows[i]["NombreContacto"].ToString();
                    Modalidad1 = tabla.Rows[i]["Nombre"].ToString();
                    TipoEvento1 = tabla.Rows[i]["Descripcion"].ToString();
                    FechaHoraInicio1 = DateTime.Parse(tabla.Rows[i]["FechaHoraInicio"].ToString());
                    FechaHoraTermino1 = DateTime.Parse(tabla.Rows[i]["FechaHoraTermino"].ToString());
                    Asistentes1 = Int32.Parse(tabla.Rows[i]["Asistentes"].ToString());
                    PersonalAdicional1 = Int32.Parse(tabla.Rows[i]["PersonalAdicional"].ToString());
                    Realizado1 = Int32.Parse(tabla.Rows[i]["Realizado"].ToString());
                    ValorTotalContrato1 = float.Parse(tabla.Rows[i]["ValorTotalContrato"].ToString());
                    Observaciones1 = tabla.Rows[i]["Observaciones"].ToString();

                    ColecctionContrato.Add(new Contratos(NumeroContrato1, Creacion1, Termino1, RutCliente1, NombreCliente1, Modalidad1, TipoEvento1, FechaHoraInicio1, FechaHoraTermino1, Asistentes1, PersonalAdicional1, Realizado1, ValorTotalContrato1, Observaciones1));
                }
                return ColecctionContrato;
            }
            catch
            {
                return null;
            }
        }

        public Contratos(string numeroContrato1, DateTime creacion1, DateTime termino1, string rutCliente1, string nombreCliente1, string modalidad1, string tipoEvento1, DateTime fechaHoraInicio1, DateTime fechaHoraTermino1, int asistentes1, int personalAdicional1, int realizado1, float valorTotalContrato1, string observaciones1)
        {
            NumeroContrato1 = numeroContrato1;
            Creacion1 = creacion1;
            Termino1 = termino1;
            RutCliente1 = rutCliente1;
            NombreCliente1 = nombreCliente1;
            Modalidad1 = modalidad1;
            TipoEvento1 = tipoEvento1;
            FechaHoraInicio1 = fechaHoraInicio1;
            FechaHoraTermino1 = fechaHoraTermino1;
            Asistentes1 = asistentes1;
            PersonalAdicional1 = personalAdicional1;
            Realizado1 = realizado1;
            ValorTotalContrato1 = valorTotalContrato1;
            Observaciones1 = observaciones1;
        }

        public Contratos()
        {
        }
    }
}
