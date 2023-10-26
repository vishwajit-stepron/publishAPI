namespace StepHR365.Utils
{
    public class SaveHelperObj<T>
    {
        public bool? ReturnRecordId { get; set; }
        public bool? ReturnRecordError { get; set; }
        public List<T>? SaveList { get; set; }
        public int? UserId { get; set; }
    }
}
