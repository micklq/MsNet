using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace MSNet.Common.Web.Pager
{
    public class PagedList<T> : List<T>
    {        
   
        /// <summary>
        /// 只作为容器，不负责从数据源获取数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        public PagedList(List<T> list, int page, int size, int itemCount) 
        {
            base.AddRange(list);
            PageInfo = new PageInfo(page, size, itemCount);
        }       

       
        public PageInfo PageInfo
        {
            get;
            set;
        }  
    }

}
