using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class EspecialidadLogic : BusinessLogic
    {
        private Data.Database.EspecialidadAdapter _EspecialidadData;

        public EspecialidadLogic()
        {
            _EspecialidadData = new EspecialidadAdapter();
        }
        public Especialidad GetOne(int ID)
        {
            return _EspecialidadData.GetOne(ID);
        }
        public List<Especialidad> GetAll()
        {
            return _EspecialidadData.GetAll();
        }
        public void Save(Especialidad especialidad)
        {
            _EspecialidadData.Save(especialidad);
        }
        public void Delete(int ID)
        {
            _EspecialidadData.Delete(ID);
        }
    }
}
