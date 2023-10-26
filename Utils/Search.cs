using System.ComponentModel.DataAnnotations;

namespace StepHR365.Utils
{
    public class Search<T>
    {
        [Key]
        public int Id { get; set; }
        public int NrOfRecPerPage { get; set; }
        public int PageNr { get; set; }
        public string FullSearch { get; set; }
        public int UserId { get; set; }
        public bool FetchAllowedRecordsOnly { get; set; }

        public List<T> SearchList { get; set; }

        //public List<FilterBy> FilterListAnd { get; set; }
        //public List<FilterBy> FilterListOr { get; set; }
        public List<SortBy> SortList { get; set; }

        public string TypeOfObjectReturned { get; set; }

        public bool IncludeRecordNr { get; set; }

        public bool DoNotSearchInSystemFields { get; set; }
    }
}
