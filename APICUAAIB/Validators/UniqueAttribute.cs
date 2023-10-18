using APICUAAIB.Entities;
using System.ComponentModel.DataAnnotations;

namespace APICUAAIB.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CompanyContext db = new CompanyContext();
            var name = value as string;
            var dept = db.Departments.FirstOrDefault(x => x.Name == name);
            if(dept != null)
            {
                return new ValidationResult("Name Already Exist !!");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}
