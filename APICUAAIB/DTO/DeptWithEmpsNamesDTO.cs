namespace APICUAAIB.DTO
{
    public class DeptWithEmpsNamesDTO
    {
        public int Department_Number { get; set; }
        public string  Department_Name { get; set; }
        public string Department_Location { get; set; }
        public List<string> Department_Emps{ get; set;}
    }
}
