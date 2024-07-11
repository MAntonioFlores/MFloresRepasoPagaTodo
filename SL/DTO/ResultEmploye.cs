namespace SL.DTO
{
    public class ResultEmploye
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ML.Employe EmployeData { get; set; }
        public Exception Exception { get; set; }
    }
}
