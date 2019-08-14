using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        private int _IdALumno, _IdCurso, _Nota;

        public AlumnoInscripcion(string Condicion, int IdALumno, int IdCurso, int Nota)
        {
            _Condicion = Condicion;
            _IdALumno = IdALumno;
            _IdCurso = IdCurso;
            _Nota = Nota;
        }
        public AlumnoInscripcion()
        {

        }

        public string Condicion
        {
            set { _Condicion = value; }
            get { return _Condicion; }
        }

        public int IdAlumno
        {
            set { _IdALumno = value; }
            get { return _IdALumno; }
        }

        public int IdCurso
        {
            set { _IdCurso = value; }
            get { return _IdCurso; }
        }

        public int Nota
        {
            set { _Nota = value; }
            get { return _Nota; }
        }
    }
}
