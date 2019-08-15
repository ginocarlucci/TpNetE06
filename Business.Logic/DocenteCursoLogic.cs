using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class DocenteCursoLogic : BusinessLogic
    {
        private Data.Database.DocenteCursoAdapter _DocenteCursoData;

        public DocenteCursoLogic()
        {
            _DocenteCursoData = new DocenteCursoAdapter();
        }
        public DocenteCurso GetOne(int ID)
        {
            return _DocenteCursoData.GetOne(ID);
        }
        public List<DocenteCurso> GetAll()
        {
            return _DocenteCursoData.GetAll();
        }
        public void Save(DocenteCurso docenteCurso)
        {
            _DocenteCursoData.Save(docenteCurso);
        }
        public void Delete(int ID)
        {
            _DocenteCursoData.Delete(ID);
        }
    }
}
