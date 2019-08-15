using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class CursoLogic : BusinessLogic
    {
        private Data.Database.CursoAdapter _CursoData;

        public CursoLogic()
        {
            _CursoData = new CursoAdapter();
        }
        public Curso GetOne(int ID)
        {
            return _CursoData.GetOne(ID);
        }
        public List<Curso> GetAll()
        {
            return _CursoData.GetAll();
        }
        public void Save(Curso curso)
        {
            _CursoData.Save(curso);
        }
        public void Delete(int ID)
        {
            _CursoData.Delete(ID);
        }
    }
}
