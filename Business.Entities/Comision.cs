using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {

        private String _DescComision;
        private int _AnioEspecialidad;
        private int _IdPlan;

        //Constructor
        public Comision(string DescComision, int AnioEspecialidad, int IdPlan)
        {
            _DescComision = DescComision;
            _AnioEspecialidad = AnioEspecialidad;
            _IdPlan = IdPlan;
        }

        public string DescComision { get => _DescComision; set => _DescComision = value; }
        public int AnioEspecialidad { get => _AnioEspecialidad; set => _AnioEspecialidad = value; }
        public int IdPlan { get => _IdPlan; set => _IdPlan = value; }


    }
}
