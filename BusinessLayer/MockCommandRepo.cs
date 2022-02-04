using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MockCommandRepo : ICommandRepo
    {
        public List<Command> GetAllCommands()
        {
            
            return new List<Command>()
            {
                new Command(){ _id=new MongoDB.Bson.ObjectId(), Key="Get Command Details", Value="Get-Command"}
            };
        }

        public Command GetCommand(int commandId)
        {
            throw new NotImplementedException();
        }
    }
}
