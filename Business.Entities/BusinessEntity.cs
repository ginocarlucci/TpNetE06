using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _Id;
        public int ID
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private States _State;
        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
        public enum States
        {
            Delete,
            New,
            Modified,
            Unmodified
        }
    }
}
