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
    class Cliente : Conexion
    {
        private string RutCliente;
        private string RazonSocial;
        private string NombreContacto;
        private string MailContacto;
        private string Direccion;
        private string Telefono;
        string  ActividadEmpresa;
        string TipoEmpresa;

        public string RutCliente1 { get => RutCliente; set => RutCliente = value; }
        public string RazonSocial1 { get => RazonSocial; set => RazonSocial = value; }
        public string NombreContacto1 { get => NombreContacto; set => NombreContacto = value; }
        public string MailContacto1 { get => MailContacto; set => MailContacto = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string ActividadEmpresa1 { get => ActividadEmpresa; set => ActividadEmpresa = value; }
        public string TipoEmpresa1 { get => TipoEmpresa; set => TipoEmpresa = value; }



        /*public bool Read() { }*/
        
        public bool Delete(string Proceso, string rutCliente)
        {
            try
            {
                conexion(Proceso);
                cmd.Parameters.Add(new MySqlParameter("_RutCliente", rutCliente));

                MySqlParameter result = new MySqlParameter("respuesta", null);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);
                cmd.ExecuteNonQuery();
                cnn.Close();
                if (Int32.Parse(cmd.Parameters["respuesta"].Value.ToString()) == 1)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(string Proceso)
        {
            try
            {
                conexion(Proceso);
                cmd.Parameters.Add(new MySqlParameter("_Direccion", Direccion1));
                cmd.Parameters.Add(new MySqlParameter("_IdActividadEmpresa", Ids(TipoEmpresa1, ActividadEmpresa1)[1]));
                cmd.Parameters.Add(new MySqlParameter("_IdTipoEmpresa", Ids(TipoEmpresa1, ActividadEmpresa1)[0]));
                cmd.Parameters.Add(new MySqlParameter("_MailContacto", MailContacto1));
                cmd.Parameters.Add(new MySqlParameter("_NombreContacto", NombreContacto1));
                cmd.Parameters.Add(new MySqlParameter("_RazonSocial", RazonSocial1));
                cmd.Parameters.Add(new MySqlParameter("_RutCliente", RutCliente1));
                cmd.Parameters.Add(new MySqlParameter("_Telefono", Telefono1));

                MySqlParameter result = new MySqlParameter("respuesta", false);
                result.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(result);

                cmd.ExecuteNonQuery();
                cnn.Close();
                if (Int32.Parse(cmd.Parameters["respuesta"].Value.ToString()) == 1)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public List<int> Ids (string TipoEMpresa,string ActividadEMpresa)
        {
            TipoEmpresa tipo = new TipoEmpresa();
            ActividadEmpresa actividad = new ActividadEmpresa();
            List<int> Ids = new List<int>();
            Ids.Add(0);
            Ids.Add(0);
            for (int i = 0; i < tipo.Read().Count; i++)
            {
                if (tipo.Read()[i].Descripcion1.Equals(TipoEMpresa))
                {
                    Ids[0] = tipo.Read()[i].Id1;
                }
                
            }
            
            for (int i = 0; i<actividad.Read().Count; i++)
            {
                if (actividad.Read()[i].Descripcion1.Equals(ActividadEMpresa))
                {
                    Ids[1]=actividad.Read()[i].Id;
                }
            }
            return Ids;
        }
        public bool Create(string Proceso)
        {
            try
            {
                conexion(Proceso);
                
                cmd.Parameters.Add(new MySqlParameter("_Direccion", Direccion1));
                cmd.Parameters.Add(new MySqlParameter("_IdActividadEmpresa", Ids(TipoEmpresa1, ActividadEmpresa1)[1]));
                cmd.Parameters.Add(new MySqlParameter("_IdTipoEmpresa", Ids(TipoEmpresa1, ActividadEmpresa1)[0]));
                cmd.Parameters.Add(new MySqlParameter("_MailContacto", MailContacto1));
                cmd.Parameters.Add(new MySqlParameter("_NombreContacto", NombreContacto1));
                cmd.Parameters.Add(new MySqlParameter("_RazonSocial", RazonSocial1));
                cmd.Parameters.Add(new MySqlParameter("_RutCliente", RutCliente1));
                cmd.Parameters.Add(new MySqlParameter("_Telefono", Telefono1));

                MySqlParameter result = new MySqlParameter("ingresado", false);
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
        public ObservableCollection<Cliente> ReadAll(string proceso, string rutCliente, int tipoEmpresa, int idActividadEmpresa)
        {
            try
            {
                conexion(proceso);
                cmd.Parameters.Add(new MySqlParameter("_RutCliente", rutCliente));
                cmd.Parameters.Add(new MySqlParameter("_idTipoEmpresa", tipoEmpresa));
                cmd.Parameters.Add(new MySqlParameter("_idActividadEmpresa", idActividadEmpresa));
                terminoConexion();
                ObservableCollection<Cliente> ColecctionCliente = new ObservableCollection<Cliente>();

                for (int i = 0; i < tabla.Rows.Count; i++)
                {

                    RutCliente1 = tabla.Rows[i]["RutCliente"].ToString();
                    RazonSocial1 = tabla.Rows[i]["RazonSocial"].ToString();
                    NombreContacto1 = tabla.Rows[i]["NombreContacto"].ToString();
                    MailContacto1 = tabla.Rows[i]["MailContacto"].ToString();
                    Direccion1 = tabla.Rows[i]["Direccion"].ToString();
                    Telefono1 = tabla.Rows[i]["Telefono"].ToString();
                    ActividadEmpresa1 = tabla.Rows[i]["Actividad"].ToString();
                    TipoEmpresa1 = tabla.Rows[i]["Tipo Empresa"].ToString();
                    ColecctionCliente.Add(new Cliente(this.RutCliente1, this.RazonSocial1, this.NombreContacto1, this.MailContacto1, this.Direccion1, this.Telefono1, this.ActividadEmpresa1, this.TipoEmpresa1));
                }
                return ColecctionCliente;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public Cliente(string rutCliente1, string razonSocial1, string nombreContacto1, string mailContacto1, string direccion1, string telefono1, string actividadEmpresa1, string tipoEmpresa1)
        {
            RutCliente1 = rutCliente1;
            RazonSocial1 = razonSocial1;
            NombreContacto1 = nombreContacto1;
            MailContacto1 = mailContacto1;
            Direccion1 = direccion1;
            Telefono1 = telefono1;
            ActividadEmpresa1 = actividadEmpresa1;
            TipoEmpresa1 = tipoEmpresa1;
        }

        public Cliente()
        {
        }
    }
}