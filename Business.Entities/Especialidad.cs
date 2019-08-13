using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        
        private String _DescEspecialidad;
        public String Desc_especialidad
        {
            get { return _DescEspecialidad; }
            set { _DescEspecialidad = value; }
        }

        //constructor
        public Especialidad(string desc_especialidad)
        {
            this._DescEspecialidad = desc_especialidad;
        }
        public Especialidad()
        {

        }
    }
}
