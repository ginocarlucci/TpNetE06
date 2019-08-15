using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        
        private String _NombreUsuario;
        private String _ClaveUsuario;
        private Boolean _Habilitado;
        private String _NombrePersona;
        private String _ApellidoPersona;
        private String _Email;
        private Boolean _CambiaClave;
        private int _IdPersona;


        public Usuario(string NombreUsuario, string ClaveUsuario, bool Habilitado, int IdPersona)
        {
            _NombreUsuario = NombreUsuario;
            _ClaveUsuario = ClaveUsuario;
            _Habilitado = Habilitado;
            _CambiaClave = false;
            _IdPersona = IdPersona;
        }

        public Usuario()
        { }

        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string ClaveUsuario { get => _ClaveUsuario; set => _ClaveUsuario = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
        public string NombrePersona { get => _NombrePersona; set => _NombrePersona = value; }
        public string ApellidoPersona { get => _ApellidoPersona; set => _ApellidoPersona = value; }
        public string Email { get => _Email; set => _Email = value; }
        public bool CambiaClave { get => _CambiaClave; set => _CambiaClave = value; }
        public int IdPersona { get => _IdPersona; set => _IdPersona = value; }
    }
}
