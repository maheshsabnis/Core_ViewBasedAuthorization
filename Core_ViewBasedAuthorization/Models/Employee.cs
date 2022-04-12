namespace Core_ViewBasedAuthorization.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
    }


    public class Employyees : List<Employee>
    {
        public Employyees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "A" });
            Add(new Employee() { EmpNo = 102, EmpName = "B" });
            Add(new Employee() { EmpNo = 103, EmpName = "C" });
            Add(new Employee() { EmpNo = 104, EmpName = "D" });
            Add(new Employee() { EmpNo = 105, EmpName = "E" });
            Add(new Employee() { EmpNo = 106, EmpName = "F" });
            Add(new Employee() { EmpNo = 107, EmpName = "G" });
            Add(new Employee() { EmpNo = 108, EmpName = "H" });
            Add(new Employee() { EmpNo = 109, EmpName = "I" });
            Add(new Employee() { EmpNo = 110, EmpName = "J" });
        }
    }
}
