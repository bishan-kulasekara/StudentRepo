﻿namespace StudentRepo.Server.Models
{
    public class PagedResult<T>
    {

            public IEnumerable<T> Data { get; set; }
            public int TotalRecords { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        
    }
}
