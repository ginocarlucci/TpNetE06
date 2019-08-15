using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class ModuloLogic : BusinessLogic
    {
        private Data.Database.ModuloAdapter _ModuloData;

        public ModuloLogic()
        {
            _ModuloData = new ModuloAdapter();
        }
        public Modulo GetOne(int ID)
        {
            return _ModuloData.GetOne(ID);
        }
        public List<Modulo> GetAll()
        {
            return _ModuloData.GetAll();
        }
        public void Save(Modulo modulo)
        {
            _ModuloData.Save(modulo);
        }
        public void Delete(int ID)
        {
            _ModuloData.Delete(ID);
        }
    }
}
