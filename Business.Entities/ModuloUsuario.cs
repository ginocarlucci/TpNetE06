using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _IdModulo;
        public int IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        private int _IdUsuario;
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        private bool _Alta;
        public bool Alta
        {
            get { return _Alta; }
            set { _Alta = value; }
        }
        private bool _Baja;
        public bool Baja
        {
            get { return _Baja; }
            set { _Baja = value; }
        }
        private bool _Modificacion;
        public bool Modificacion
        {
            get { return _Modificacion; }
            set { _Modificacion = value; }
        }
        private bool _Consulta;
        public bool Consulta
        {
            get { return _Consulta; }
            set { _Consulta = value; }
        }

        //constructor
        public ModuloUsuario(int IdModulo, int IdUsuario, bool Alta, bool Baja, bool Modificacion, bool Consulta)
        {
            _IdModulo = IdModulo;
            _IdUsuario = IdUsuario;
            _Alta = Alta;
            _Baja = Baja;
            _Modificacion = Modificacion;
            _Consulta = Consulta;
        }
        public ModuloUsuario()
        {

        }
        
        
    }
}
