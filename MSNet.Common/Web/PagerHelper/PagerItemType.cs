﻿namespace MSNet.Common.Web.Pager
{
    using System;

    internal enum PagerItemType : byte
    {
        FirstPage = 0,
        LastPage = 3,
        MorePage = 4,
        NextPage = 1,
        NumericPage = 5,
        PrevPage = 2
    }
}

