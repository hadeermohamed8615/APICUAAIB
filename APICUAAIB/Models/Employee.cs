using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICUAAIB.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        [StringLength(20)]
        [MinLength(5,ErrorMessage ="Name must be more than 5 chars")]
       // [Unique]
        public string Name { get; set; }
        [Range(22,65,ErrorMessage = "Age Must be between 22 and 65")]
        public int Age { get; set; }
        [RegularExpression("[a-zA-Z]{5,20}")]
        public string Address { get; set; }
        [Range(2500,6000,ErrorMessage ="Salary Must be in Range (2500 , 6000)")]
        [Remote("TestSalary","Employee")]
        public int Salary { get; set; }

      //  public bool IsDeleted { get; set; } = false;
        [ForeignKey("Department")]
        public int DeptId { get; set; }
     //   [JsonIgnore]
        public virtual Department Department { get; set; }
    }
}
