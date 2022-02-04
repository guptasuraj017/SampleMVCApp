using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Models
{
    public class Command
    {
        public ObjectId _id { get; set; }
        public long CommandId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public List<CommandParameter> Params { get; set; }
    }
}
