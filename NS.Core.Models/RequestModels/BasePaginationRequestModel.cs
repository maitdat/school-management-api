﻿using NS.Core.Commons;

namespace NS.Core.Models.RequestModels
{
    public class BasePaginationRequestModel 
    {
        public int PageSize { get; set; } = Constants.DefaultValue.DEFAULT_PAGE_SIZE;
        public int PageNo { get; set; } = Constants.DefaultValue.DEFAULT_PAGE_NO;
        public string Keyword { get; set; } = string.Empty;
    }
}
