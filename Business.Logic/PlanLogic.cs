using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class PlanLogic : BusinessLogic
    {
        private Data.Database.PlanAdapter _PlanData;

        public PlanLogic()
        {
            _PlanData = new PlanAdapter();
        }
        public Plan GetOne(int ID)
        {
            return _PlanData.GetOne(ID);
        }
        public List<Plan> GetAll()
        {
            return _PlanData.GetAll();
        }
        public void Save(Plan plan)
        {
            _PlanData.Save(plan);
        }
        public void Delete(int ID)
        {
            _PlanData.Delete(ID);
        }
    }
}
