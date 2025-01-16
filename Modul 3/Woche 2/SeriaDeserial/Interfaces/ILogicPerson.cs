using SeriaDeserial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriaDeserial.Interfaces
{
    public interface ILogicPerson
    {    
        public string? Serialize(IPerson person);

        public IPerson? Deserialize();
    }
}
