using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace UBS.EmployeeData.Abstraction
{
    public class Employee
    {
        [BsonId]
        [Required ]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is Required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [StringLength(10, MinimumLength = 4)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1-100 in years.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "DepartmentName is Required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Salary is Required")]
        public double Salary { get; set; }
    }
}
