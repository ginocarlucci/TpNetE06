using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    class ComisionLogic : BusinessLogic
    {

        private Data.Database.ComisionAdapter _ComisionData;

        public ComisionLogic()
        {
            _ComisionData = new ComisionAdapter();
        }
        public Comision GetOne(int ID)
        {
            return _ComisionData.GetOne(ID);
        }
        public List<Comision> GetAll()
        {
            return _ComisionData.GetAll();
        }
        public void Save(Comision comision)
        {
            _ComisionData.Save(comision);
        }
        public void Delete(int ID)
        {
            _ComisionData.Delete(ID);
        }

    }
}
