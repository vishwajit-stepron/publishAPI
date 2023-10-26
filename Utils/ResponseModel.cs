namespace StepHR365.Utils
{
    public class ResponseModel<T>
    {
        public string? Message { get; set; }
        public bool? Status { get; set; }
        public T? Data { get; set; }
        public int? NrOfRecords { get; set; }
        public List<string>? ListData { get; set; }
      
    }
}
