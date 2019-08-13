using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string _Descripcion;

        public Modulo(string Descripcion)
        {
            _Descripcion = Descripcion;
        }

        public string Descripcion
        {
            set { _Descripcion = value; }
            get { return _Descripcion; }
        }
    }
}
