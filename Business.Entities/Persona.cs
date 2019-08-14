using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        
        private String _Nombre;
        private String _Apellido;
        private String _Direccion;
        private String _Email;
        private String _Telefono;
        private DateTime _FechaNacimiento;
        private int _Legajo;
        private int _TipoPersona;
        private int _IdPlan;


        //Constructor
        public Persona(string Nombre, string Apellido, string Direccion, string Email, string Telefono, DateTime FechaNacimiento, int Legajo, int TipoPersona, int IdPlan)
        {
            _Nombre = Nombre;
            _Apellido = Apellido;
            _Direccion = Direccion;
            _Email = Email;
            _Telefono = Telefono;
            _FechaNacimiento = FechaNacimiento;
            _Legajo = Legajo;
            _TipoPersona = TipoPersona;
            _IdPlan = IdPlan;
        }
        public Persona()
        {

        }

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }
        public int IdPlan { get => _IdPlan; set => _IdPlan = value; }
    }
}
