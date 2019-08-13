using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _Descripcion;
        private int _IdEspecialidad;

        public Plan(string Descripcion, int IdEspecialidad)
        {
            _Descripcion = Descripcion;
            _IdEspecialidad = IdEspecialidad;
        }

        public string Descripcion
        {
            set { _Descripcion = value; }
            get { return _Descripcion; }
        }

        public int IdEspecialidad
        {
            set { _IdEspecialidad = value; }
            get { return IdEspecialidad; }
        }
    }
}
