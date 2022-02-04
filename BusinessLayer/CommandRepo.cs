using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;


namespace BusinessLayer
{
    public class CommandRepo:ICommandRepo
    {
        public List<Command> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public void GetCommand(int commandId)
        {
            throw new NotImplementedException();
        }

        public Collection<PSObject> RunCmdlets(Command command)
        {
            
            try
            {
               
                IDictionary parameters = new Dictionary<String, String>();
                foreach (var parameter in command.Params)
                {
                    parameters.Add(parameter.ParameterName, @parameter.ParameterValue);
                }

                var ps = PowerShell.Create().AddCommand(command.Value).AddParameters(parameters).Invoke();
                return ps;
            }
            catch (Exception )
            {

                return null;
            }
        }

        Command ICommandRepo.GetCommand(int commandId)
        {
            throw new NotImplementedException();
        }
    }
}
