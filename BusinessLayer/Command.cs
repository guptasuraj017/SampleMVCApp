using Newtonsoft.Json;
using System;
using System.Management.Automation;


namespace BusinessLayer
{
    public class Command
    {
        public PSObject RunCmdlets(string commandName,string commandParameterCommandName)
        {
            
            try
            {
                var ps = PowerShell.Create().AddCommand(commandName).AddParameter("Name", commandParameterCommandName).Invoke()[0];
                return ps;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
