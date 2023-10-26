namespace StepHR365.Utils
{
    public class DeleteHelperObj<T>
    {
        public int UserId { get; set; }
        public bool ReturnRecordError { get; set; }
        public bool SoftDelete { get; set; }
        public List<T> DeleteList { get; set; }


    }
}
