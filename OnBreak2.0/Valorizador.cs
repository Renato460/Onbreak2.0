using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak2._0
{
    class Valorizador
    {
        Cliente cliente;

        public float CalcularValorEvento(string tipoEvento, string modalidadEvento,int asistentes,int _PersonalAdicional)
        {
            try
            {
                int recargoAsistentes = 0;
                double recargoPersonal = 0;
                int personalBase = 0;
                TipoEvento evento = new TipoEvento();
                int _IdTipoEvento = 0;
                ModalidadServicio modalidadServicio = new ModalidadServicio();
                float valorBaseModalidad = 0;
                for (int i = 0; i < evento.Read("getTipoEvento", 0).Count; i++)
                {
                    if (evento.Read("getTipoEvento", 0)[i].Descripcion1.Equals(tipoEvento))
                    {
                        _IdTipoEvento = evento.Read("getTipoEvento", 0)[i].Id1;

                    }
                }

                for (int i = 0; i < modalidadServicio.Read("getModServicio", _IdTipoEvento).Count; i++)
                {
                    if (modalidadServicio.Read("getModServicio", _IdTipoEvento)[i].Nombre1.Equals(modalidadEvento))
                    {
                        valorBaseModalidad = modalidadServicio.Read("getModServicio", _IdTipoEvento)[i].ValorBase1;
                        personalBase = modalidadServicio.Read("getModServicio", _IdTipoEvento)[i].PersonalBase1;
                    }
                }
                
                if (_PersonalAdicional == 2)
                {
                    recargoPersonal = 2;
                }
                if (_PersonalAdicional == 3)
                {
                    recargoPersonal = 3;
                }
                if (_PersonalAdicional == 4)
                {
                    recargoPersonal = 3.5;
                }
                if (_PersonalAdicional > 4)
                {
                    recargoPersonal = 3.5 + (_PersonalAdicional - 4) * 0.5;
                }

                if (asistentes >= 1 && asistentes <= 20)
                {
                    recargoAsistentes = 3;
                }
                if (asistentes >= 21 && asistentes <= 50)
                {
                    recargoAsistentes = 5;
                }
                if (asistentes > 50)
                {
                    recargoAsistentes = (asistentes / 20) * 2;
                }
                //Valor Total Evento = Valor Base Tipo Evento + Recargo Asistentes + Recargo Personal
                float ValorTotalEvento = valorBaseModalidad + (float)recargoAsistentes + (float)recargoPersonal;

                return ValorTotalEvento;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
