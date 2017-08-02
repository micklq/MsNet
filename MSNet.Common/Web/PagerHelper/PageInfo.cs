using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSNet.Common.Web.Pager
{
    [Serializable]
    public class PageInfo
    {
        public PageInfo( int page, int size, int itemCount )            
        {
            if (page <= 0) { page = 1; }
            if (size <= 0) { size = 10; }
            if (itemCount < 0) { itemCount = 0; }
                
            Page = page;
            Size = size;
            ItemCount = itemCount;
            Start = ((Page - 1) * Size) + 1;
            End = (ItemCount > (Page * Size)) ? (Page * Size) : ItemCount;
            PageCount = (int)Math.Ceiling( (double)( ( (double)ItemCount ) / ( (double)Size ) ) );
        }        

        public int Page
        {
            get;
            private set;
        }

        public int Size
        {
            get;
            private set;
        }

        public int Start
        {
            get;
            private set;
        }

        public int End
        {
            get;
            private set;
        }

        public int ItemCount
        {
            get;
            private set;
        }

        public int PageCount
        {
            get;
            private set;
        }
    }
}
