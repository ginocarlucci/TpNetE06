using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _IdEspecialidad,_AnioCalendario, _Cupo, _IdComision, _IdMateria;
        private string _Descripcion;

        public Curso(int AnioCalendario, int Cupo, int IdComision, int IdMateria, string Descripcion)
        {
            _AnioCalendario = AnioCalendario;
            _Cupo = Cupo;
            _IdComision = IdComision;
            _IdMateria = IdMateria;
            _Descripcion = Descripcion;
        }
        public Curso()
        {

        }
        public int IdEspecialidad
        {
            set{ _IdEspecialidad = value;}
            get{ return _IdEspecialidad; }
        }
        public string Descripcion
        {
            set { _Descripcion = value; }
            get { return _Descripcion; }
        }

        public int AnioCalendario
        {
            set { _AnioCalendario = value; }
            get { return _AnioCalendario; }
        }

        public int Cupo
        {
            set { _Cupo = value; }
            get { return _Cupo; }
        }

        public int IdComision
        {
            set { _IdComision = value; }
            get { return _IdComision; }
        }

        public int IdMateria
        {
            set { _IdMateria = value; }
            get { return _IdMateria; }
        }
    }
}
