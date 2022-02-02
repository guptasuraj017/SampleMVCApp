using Newtonsoft.Json;
using System;
using System.Management.Automation;


namespace BusinessLayer
{
    public class Command
    {
        public PSObject RunCmdlets(string commandName)
        {
            
            try
            {
                var ps = PowerShell.Create().AddCommand("Get-Command").AddParameter("Name", commandName).Invoke()[0];
                return ps;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
