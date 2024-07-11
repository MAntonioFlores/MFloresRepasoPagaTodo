namespace ML
{
    public class Employe
    {
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? Salary { get; set; }
        public List<Employe>? Employes { get; set; }
    }
}
