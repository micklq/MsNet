namespace MSNet.Common.Web.Pager
{
    using System;
    using System.Runtime.CompilerServices;

    public class PagerOptions
    {
        private string _containerTagName;
        

        public PagerOptions()
        {
            this.ByRawUrl = true;
            this.AutoHide = true;
            this.FirstPageText = "首页";
            this.PrevPageText = "<";
            this.NextPageText = ">";
            this.LastPageText = "末页";
            this.ContainerTagName = "div";
            this.NavigationPagerItemWrapperFormatString = "<span>{0}</span>";
            this.NumericPagerItemWrapperFormatString = "<span>{0}</span>";
            this.CurrentPagerItemWrapperFormatString = "<span class='this' id='td_currentPage'>{0}</span>";
            this.MorePagerItemWrapperFormatString = "<span>{0}</span>";
            this.CurrentPageNumberFormatString = "{0}";
            this.AlwaysShowFirstLastPageNumber = false;
            this.CssClass = "AP_Default_Main";
            this.GoButtonText = "Go";
            this.GoToPageSectionWrapperFormatString = "<span>{0}</span>";
            this.PageIndexBoxType = PageIndexBoxType.DropDownList;
            this.PageIndexBoxWrapperFormatString = "<span>{0}</span>";
            this.PagerItemWrapperFormatString = "<span>{0}</span>";
            this.PageNumberFormatString = "{0}";
            this.ShowPrevNext = true;
            this.SeparatorHtml = "";
            this.ShowPageIndexBox = false;
            this.ShowDisabledPagerItems = true;
            this.ShowFirstLast = true;
            this.MaximumPageIndexItems = 5;
            this.PageIndexParameterName = "page";
            this.ShowGoButton = true;
            this.ShowMorePagerItems = true;
            this.ShowNumericPagerItems = true;           
            this.NumericPagerItemCount = 10;            
            this.ShowPrevNext = true; 
            this.ShowNumericPagerItems = true;  
            this.ShowMorePagerItems = true;
            this.MorePageText = "...";
            this.ShowDisabledPagerItems = true;
            this.SeparatorHtml = "&nbsp;&nbsp;";
            this.UseJqueryAjax = false;         
            this.InvalidPageIndexErrorMessage = "Invalid page index";
            this.PageIndexOutOfRangeErrorMessage = "Page index out of range";
        }

        /// <summary>
        /// 根据当前请求的原始Url进行页码替换，默认false,  devid 2012-09-27
        /// 设置为true时      
        /// </summary>
        public bool ByRawUrl
        {
            get;
            set;
        }

        public bool AlwaysShowFirstLastPageNumber
        {
            get;set;
        }

        public bool AutoHide
        {
            get;
            set;
        }

        public string ContainerTagName
        {
            get
            {
                return this._containerTagName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("ContainerTagName can not be null or empty", "ContainerTagName");
                }
                this._containerTagName = value;
            }
        }

        public string CssClass
        {
            get;
            set;
        }

        public string CurrentPageNumberFormatString
        {
            get;
            set;
        }

        public string CurrentPagerItemWrapperFormatString
        {
            get;
            set;
        }

        public string FirstPageText
        {
            get;
            set;
        }

        public string GoButtonText
        {
            get;
            set;
        }

        public string GoToPageSectionWrapperFormatString
        {
            get;
            set;
        }

        public string HorizontalAlign
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string InvalidPageIndexErrorMessage
        {
            get;
            set;
        }

        public string LastPageText
        {
            get;
            set;
        }

        public int MaximumPageIndexItems
        {
            get;
            set;
        }

        public string MorePagerItemWrapperFormatString
        {
            get;
            set;
        }

        public string MorePageText
        {
            get;
            set;
        }       
        public string NavigationPagerItemWrapperFormatString
        {
            get;
            set;
        }
        public string NextPageText
        {
            get;
            set;
        }

        public int NumericPagerItemCount
        {
            get;
            set;
        }

        public string NumericPagerItemWrapperFormatString
        {
            get;
            set;
        }

        public PageIndexBoxType PageIndexBoxType
        {
            get;
            set;
        }

        public string PageIndexBoxWrapperFormatString
        {
            get;
            set;
        }

        public string PageIndexOutOfRangeErrorMessage
        {
            get;
            set;
        }

        public string PageIndexParameterName
        {
            get;
            set;
        }

        public string PageNumberFormatString
        {
            get;
            set;
        }

        public string PagerItemWrapperFormatString
        {
            get;
            set;
        }

        public string PrevPageText
        {
            get;
            set;
        }

        public string SeparatorHtml
        {
            get;
            set;
        }

        public bool ShowDisabledPagerItems
        {
            get;
            set;
        }

        public bool ShowFirstLast
        {
            get;
            set;
        }

        public bool ShowGoButton
        {
            get;
            set;
        }

        public bool ShowMorePagerItems
        {
            get;
            set;
        }

        public bool ShowNumericPagerItems
        {
            get;
            set;
        }

        public bool ShowPageIndexBox
        {
            get;
            set;
        }

        public bool ShowPrevNext
        {
            get;
            set;
        }

        internal bool UseJqueryAjax
        {
            get;
            set;
        }
    }
}

