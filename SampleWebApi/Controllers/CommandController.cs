using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : Controller
    {
        private readonly IConfiguration _configuration;


        public CommandController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("GetAllCommands")]
        public JsonResult GetAllCommands()
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));

                var commandList = dbClient.GetDatabase("Test2").GetCollection<Command>("Command").AsQueryable();

                return new JsonResult(commandList);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetCommand")]
        public JsonResult GetCommand(long commandId)
        {
            try
            {
                MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("EmployeeAppCon"));
                var commandObtained = dbClient.GetDatabase("Test2").GetCollection<Command>("Command").Find(x => x.CommandId == commandId).FirstOrDefault();
                return new JsonResult(commandObtained);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
