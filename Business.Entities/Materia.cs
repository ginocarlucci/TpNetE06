using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {

        private String _DescMateria;
        public String DescMateria
        {
            get { return _DescMateria; }
            set { _DescMateria = value; }
        }
        private int _HsSemanales;
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }
        private int _HsTotales;
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
        }
        private int _IdPlan;
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }

        //constructor
        public Materia(string DescMateria, int HsSemanales, int HsTotales, int IdPlan)
        {
            _DescMateria = DescMateria;
            _HsSemanales = HsSemanales;
            _HsTotales = HsTotales;
            _IdPlan = IdPlan;
        }   
    }
}
