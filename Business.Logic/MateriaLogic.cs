using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class MateriaLogic : BusinessLogic
    {
        private Data.Database.MateriaAdapter _MateriaData;

        public MateriaLogic()
        {
            _MateriaData = new MateriaAdapter();
        }
        public Materia GetOne(int ID)
        {
            return _MateriaData.GetOne(ID);
        }
        public List<Materia> GetAll()
        {
            return _MateriaData.GetAll();
        }
        public void Save(Materia materia)
        {
            _MateriaData.Save(materia);
        }
        public void Delete(int ID)
        {
            _MateriaData.Delete(ID);
        }
    }
}
