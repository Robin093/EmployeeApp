using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Models
{
    // this is an employee model class for tblEmployee in Database
    // Model is created for sample table 
    // to perform CRUD operations
    public class Employee
    {
        // Primary key
        [Key]
        public int EmpId { get; set; }
        // username of emplyee
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        // email address of empolyee
        [Required(ErrorMessage ="Please enter email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        // phone no of employee
        [Required(ErrorMessage ="Please provide mobile no")]
        public string Mobile { get; set; }
    }
}
