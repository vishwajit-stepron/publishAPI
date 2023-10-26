namespace StepHR365.Utils
{
    public class ObjectResponse<T>
    {
        public string Message { get; set; }
        public T ObjData { get; set; }
    }
}
