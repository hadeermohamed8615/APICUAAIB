using APICUAAIB.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace APICUAAIB.Models
{
    public class Department
    {
        public int Id { get; set; }
       // [Unique]
       // [Remote("","","")]
        public string Name { get; set; }
       // [JsonIgnore]
        public string Location { get; set; }
      //  [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } 
    }
}
