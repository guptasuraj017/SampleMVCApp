using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface ICommandRepo
    {
        Command GetCommand(int commandId);
        List<Command> GetAllCommands();
        
    }
}
