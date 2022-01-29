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
        [Display(Name ="Name")]
        public int employeeid { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Age")]
        public short age { get; set; }
        [Display(Name = "Department")]
        public string department { get; set; }
        [Display(Name = "Salary")]
        public int salary { get; set; }
    }
}