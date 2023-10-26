namespace StepHR365.Utils
{
    public class DALFetchResponseModel<T>
    {
        public T Data { get; set; }
        public int NrOfRecords { get; set; }

        internal IEnumerable<object> Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
