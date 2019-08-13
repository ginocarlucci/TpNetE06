using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private int _IdDictado;
        public int IdDictado
        {
            get { return _IdDictado; }
            set { _IdDictado = value; }
        }
        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        private int _IdDocente;
        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }
        private int _Cargo;
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public DocenteCurso(int IdCurso, int IdDocente, int Cargo)
        {
            _IdCurso = IdCurso;
            _IdDocente = IdDocente;
            _Cargo = Cargo;
        }
        public DocenteCurso()
        {
        
        }

    }
}
