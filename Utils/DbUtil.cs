using Microsoft.EntityFrameworkCore;
using StepHR365.Utils;
using System.Linq.Dynamic.Core;

namespace StepronEOP.Utils
{
    public static class DbUtil
    {
        public async static Task<DALFetchResponseModel<IEnumerable<T>>> GenericFetch<T>(Search2<T> item, IQueryable<T> retObjList, string defaultSortString, int maxRecPerPage)
        {
            int skip = item.PageNr == 0 ? 0 : item.NrOfRecPerPage * (item.PageNr - 1);
            int take = item.NrOfRecPerPage == 0 ? maxRecPerPage : item.NrOfRecPerPage;

            retObjList = AllFilter_Strings(retObjList, item.FullSearch);
            retObjList = SearchList(retObjList, item.SearchList);
            retObjList = SortByCondition(retObjList, item.SortList, defaultSortString);

            DALFetchResponseModel<IEnumerable<T>> retObj = new DALFetchResponseModel<IEnumerable<T>>
            {
                Data = await retObjList.Skip(skip).Take(take).ToListAsync(),
                NrOfRecords = item.IncludeRecordNr == true ? await retObjList.CountAsync() : 0
            };

            return retObj;
        }

        public static IQueryable<T> AllFilter_Strings<T>(IQueryable<T> source, string term, bool doNotSearchInSystemFields = true)
        {
            if (string.IsNullOrEmpty(term)) { return source; }

            //var elementType = source.ElementType;
            var elementType = typeof(T);

            // Get all the string property names on this specific type.
            var stringProperties =
                elementType.GetProperties()
                    .Where(x => x.PropertyType == typeof(string))
                    .ToArray();

            var intProperties =
                elementType.GetProperties()
                .Where(x => x.PropertyType == typeof(int))
                .ToArray();


            if (doNotSearchInSystemFields == true)
            {

                var stringProperties1 = elementType.GetProperties()
                    .Where(x => x.PropertyType == typeof(string) && x.Name != "CreatedByUser" && x.Name != "ModifiedByUser")
                    .ToArray();


                var intProperties1 = elementType.GetProperties()
                    .Where(x => x.PropertyType == typeof(int) && x.Name != "CreatedBy" && x.Name != "ModifiedBy")
                    .ToArray();

                stringProperties = stringProperties1;
                intProperties = intProperties1;

            }


            //if (!stringProperties.Any()) { return source; }

            string filterExpr = String.Empty;
            string filterExpr2 = String.Empty;

            // Build the string expression
            if (stringProperties.Any())
            {
                filterExpr = string.Join(
                " || ",
                stringProperties.Select(prp => $"{prp.Name}.Contains(@0)")
                );
            }

            int number1 = 0;
            bool canConvert = int.TryParse(term, out number1);

            if (intProperties.Any() && canConvert == true)
            {
                filterExpr2 = string.Join(
                " || ",
                intProperties.Select(prp => $"{prp.Name}=@0")
                );
            }



            filterExpr = filterExpr + ((filterExpr.Length > 0 && filterExpr2.Length > 0) ? " || " + filterExpr2 : filterExpr2);

            if (filterExpr.Trim().Length > 0)
                return source.Where(filterExpr.Trim(), term);

            return source;
        }

        public static IQueryable<T> SearchList<T>(IQueryable<T> source, List<T> list)
        {
            if (list == null) return source;

            var elementType = typeof(T);

            var props = elementType.GetProperties().ToArray();
            if (!props.Any()) { return source; }


            foreach (var obj in list)
            {

                foreach (var pi in props)
                {
                    string filterExpr = String.Empty;

                    if (pi.PropertyType == typeof(string))
                    {
                        string value = (string)pi.GetValue(obj);
                        if (String.IsNullOrEmpty(value))
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}.Contains(@0)");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                    if (pi.PropertyType == typeof(int))
                    {
                        int value = (int)pi.GetValue(obj);
                        if (value == 0)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                     if (pi.PropertyType == typeof(int?))
                    {
                        int? value = (int?)pi.GetValue(obj);
                        if (value == null)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                    if (pi.PropertyType == typeof(decimal))
                    {
                        decimal value = (decimal)pi.GetValue(obj);
                        if (value == 0)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                     if (pi.PropertyType == typeof(decimal?))
                    {
                        decimal? value = (decimal?)pi.GetValue(obj);
                        if (value == null)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                    if (pi.PropertyType == typeof(DateTime?))
                    {
                        DateTime? value = (DateTime?)pi.GetValue(obj);
                        if (value == null)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                    else
                    if (pi.PropertyType == typeof(bool?))
                    {
                        bool? value = (bool?)pi.GetValue(obj);
                        if (value == null)
                            continue;

                        filterExpr = string.Join(" && ", $"{pi.Name}=@0");
                        source = source.Where(filterExpr.Trim(), value);
                        continue;
                    }
                }

            }

            return source;
        }


        public static IQueryable<T> SortByCondition<T>(IQueryable<T> source, List<SortBy> list, string defSortString = "")
        {
            var stringOrderBy = String.Empty;
            if (list != null)
            {
                if (list.Count() > 0)
                {
                    foreach (var obj in list)
                    {
                        if (String.IsNullOrEmpty(obj.FieldName) || String.IsNullOrEmpty(obj.Direction))
                            continue;

                        stringOrderBy += obj.FieldName + " " + obj.Direction + ",";
                    }
                }
            }

            if (String.IsNullOrEmpty(stringOrderBy) && !String.IsNullOrEmpty(defSortString))
                stringOrderBy = defSortString + ",";

            if (!String.IsNullOrEmpty(stringOrderBy))
            {
                stringOrderBy = stringOrderBy.Substring(0, stringOrderBy.Length - 1);
                if (!String.IsNullOrEmpty(stringOrderBy))
                    source = source.OrderBy(stringOrderBy);
            }

            return source;
        }
    }
}
