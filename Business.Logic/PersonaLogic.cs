using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class PersonaLogic : BusinessLogic
    {
        private Data.Database.PersonaAdapter _PersonaData;

        public PersonaLogic()
        {
            _PersonaData = new PersonaAdapter();
        }
        public Persona GetOne(int ID)
        {
            return _PersonaData.GetOne(ID);
        }
        public List<Persona> GetAll()
        {
            return _PersonaData.GetAll();
        }
        public void Save(Persona persona)
        {
            _PersonaData.Save(persona);
        }
        public void Delete(int ID)
        {
            _PersonaData.Delete(ID);
        }
    }
}
