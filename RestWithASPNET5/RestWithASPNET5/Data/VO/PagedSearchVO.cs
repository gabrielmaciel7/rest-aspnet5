using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Data.VO
{
    public class PagedSearchVO<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public Dictionary<string, Object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO() { }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
        }

        public PagedSearchVO(int currentPage, int pageSize, string sortFields, Dictionary<string, object> filters) :
            this(currentPage, pageSize, sortFields)
        {
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields) : this(currentPage, 10, sortFields) { }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : CurrentPage;
        }
    }
}
