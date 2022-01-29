using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleMVCApp.Models
{
    [Table("employee",Schema ="employeedb")]
    public class Employee
    {
        [Key]
        public int employeeid { get; set; }
        public string name { get; set; }
        public short age { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
    }
}