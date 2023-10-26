namespace StepHR365.Model.ResponseModel
{
    public class UploadResponse<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string FirstFile { get; set; }
        public List<string> ListData { get; set; }
        public int NrOfRecords { get; set; }
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }
    }
}
