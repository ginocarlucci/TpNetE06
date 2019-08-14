using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    class ModuloUsuarioLogic
    {
        private Data.Database.ModuloUsuarioAdapter _ModuloUsuarioData;

        public ModuloUsuarioLogic()
        {
            _ModuloUsuarioData = new ModuloUsuarioAdapter();
        }
        public ModuloUsuario GetOne(int ID)
        {
            return _ModuloUsuarioData.GetOne(ID);
        }
        public List<ModuloUsuario> GetAll()
        {
            return _ModuloUsuarioData.GetAll();
        }
        public void Save(ModuloUsuario moduloUsuario)
        {
            _ModuloUsuarioData.Save(moduloUsuario);
        }
        public void Delete(int ID)
        {
            _ModuloUsuarioData.Delete(ID);
        }
    }
}
