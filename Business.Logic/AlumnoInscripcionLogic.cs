using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class AlumnoInscripcionLogic : BusinessLogic
    {
        private Data.Database.AlumnoInscripcionAdapter _AlumnoInscripcionData;

        public AlumnoInscripcionLogic()
        {
            _AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }
        public AlumnoInscripcion GetOne(int ID)
        {
            return _AlumnoInscripcionData.GetOne(ID);
        }
        public List<AlumnoInscripcion> GetAll()
        {
            return _AlumnoInscripcionData.GetAll();
        }
        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            _AlumnoInscripcionData.Save(alumnoInscripcion);
        }
        public void Delete(int ID)
        {
            _AlumnoInscripcionData.Delete(ID);
        }
    }
}
