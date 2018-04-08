using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace MSNet.Common.Web.Pager
{
    public static class PagerHelper
    {
        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, AjaxOptions ajaxOptions )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, null, null );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, null, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
        }

        private static MvcHtmlString AjaxPager( HtmlHelper html, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes )
        {
            return new PagerBuilder( html, null, pagerOptions, htmlAttributes ).RenderPager();
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, string routeName, AjaxOptions ajaxOptions )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, null, null );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, null, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, null );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, htmlAttributes );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, string routeName, object routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, null );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, pagerOptions, routeValues, ajaxOptions, null );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, string actionName, string controllerName, PagerOptions pagerOptions, AjaxOptions ajaxOptions )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, null );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, actionName, controllerName, null, pagerOptions, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, string routeName, object routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString AjaxPager<T>( this HtmlHelper html, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return AjaxPager( html, pagerOptions, htmlAttributes );
            }
            return html.AjaxPager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString AjaxPager( this HtmlHelper html, int totalPageCount, int pageIndex, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagerOptions == null )
            {
                pagerOptions = new PagerOptions();
            }
            pagerOptions.UseJqueryAjax = true;

            PagerBuilder
                builder = new PagerBuilder( html, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, new RouteValueDictionary( routeValues ), ajaxOptions, new RouteValueDictionary( htmlAttributes ) );
            return builder.RenderPager();
        }

        public static MvcHtmlString AjaxPager( this HtmlHelper html, int totalPageCount, int pageIndex, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagerOptions == null )
            {
                pagerOptions = new PagerOptions();
            }
            pagerOptions.UseJqueryAjax = true;
            PagerBuilder
                builder = new PagerBuilder( html, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes );
            return builder.RenderPager();
        }







        //public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList )
        //{
        //    if( pagedList == null )
        //    {
        //        return Pager( helper, null, null );
        //    }
        //    return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, null, ( (RouteValueDictionary)null ), ( (IDictionary<string, object>)null ) );
        //}

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, AjaxOptions ajaxOptions )
        {
            if ( pagedList != null )
            {
                return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, null, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
            }
            return Pager( ajax, null, null );
        }

        private static MvcHtmlString Pager( AjaxHelper ajax, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes )
        {
            return new PagerBuilder( null, ajax, pagerOptions, htmlAttributes ).RenderPager();
        }
        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList )
        {
            return helper.Pager<T>( pagedList, new PagerOptions() );
        }
        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, null );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, null, ( (RouteValueDictionary)null ), ( (IDictionary<string, object>)null ) );
        }

        private static MvcHtmlString Pager( HtmlHelper helper, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes )
        {
            return new PagerBuilder( helper, null, pagerOptions, htmlAttributes ).RenderPager();
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions )
        {
            if ( pagedList != null )
            {
                return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, ( (RouteValueDictionary)null ), ajaxOptions, ( (IDictionary<string, object>)null ) );
            }
            return Pager( ajax, pagerOptions, null );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, htmlAttributes );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, null, null, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, null, null, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, pagerOptions, htmlAttributes );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, pagerOptions, null, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, string routeName, object routeValues, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, null, new RouteValueDictionary( htmlAttributes ) );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, routeName, routeValues, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, null, htmlAttributes );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, null, routeName, routeValues, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, object routeValues )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, null );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, routeName, routeValues, null );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, null );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, routeName, routeValues, null );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, null, new RouteValueDictionary( htmlAttributes ) );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, null, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, null, htmlAttributes );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, null, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, object routeValues, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, routeName, routeValues, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this HtmlHelper helper, PagedList<T> pagedList, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( helper, pagerOptions, htmlAttributes );
            }
            return helper.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, pagerOptions, routeName, routeValues, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, string routeName, object routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, pagerOptions, new RouteValueDictionary( htmlAttributes ) );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager<T>( this AjaxHelper ajax, PagedList<T> pagedList, string routeName, RouteValueDictionary routeValues, PagerOptions pagerOptions, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            if ( pagedList == null )
            {
                return Pager( ajax, pagerOptions, htmlAttributes );
            }
            return ajax.Pager( pagedList.PageInfo.PageCount, pagedList.PageInfo.Page, null, null, routeName, pagerOptions, routeValues, ajaxOptions, htmlAttributes );
        }

        public static MvcHtmlString Pager( this HtmlHelper helper, int totalPageCount, int pageIndex, string actionName, string controllerName, PagerOptions pagerOptions, string routeName, object routeValues, object htmlAttributes )
        {
            PagerBuilder
                builder = new PagerBuilder( helper, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );

            return builder.RenderPager();
        }

        public static MvcHtmlString Pager( this HtmlHelper helper, int totalPageCount, int pageIndex, string actionName, string controllerName, PagerOptions pagerOptions, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
        {
            PagerBuilder
                builder = new PagerBuilder( helper, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, htmlAttributes );
            return builder.RenderPager();
        }

        public static MvcHtmlString Pager( this AjaxHelper ajax, int totalPageCount, int pageIndex, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
        {
            PagerBuilder builder = new PagerBuilder( ajax, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, new RouteValueDictionary( routeValues ), ajaxOptions, new RouteValueDictionary( htmlAttributes ) );
            return builder.RenderPager();
        }

        public static MvcHtmlString Pager( this AjaxHelper ajax, int totalPageCount, int pageIndex, string actionName, string controllerName, string routeName, PagerOptions pagerOptions, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
        {
            PagerBuilder builder = new PagerBuilder( ajax, actionName, controllerName, totalPageCount, pageIndex, pagerOptions, routeName, routeValues, ajaxOptions, htmlAttributes );
            return builder.RenderPager();
        }




        public static string IndexPager( this HtmlHelper helper, int page, int size, int itemCount, string actionName, string controllerName, object routeValues, object htmlAttributes )
        {
            RouteValueDictionary
                rd = new RouteValueDictionary( routeValues );
            RouteValueDictionary
                hd = new RouteValueDictionary( htmlAttributes );
            string
                urlFormat = "/{0}/{1}?page=".StringFormat( controllerName, actionName ) + "{0}";

            foreach ( var k in rd.Keys )
                urlFormat += "&{0}={1}".StringFormat( k, rd[k] );

            string attrs = "";
            foreach ( var k in hd.Keys )
            {
                attrs += "{0}=\"{1}\"".StringFormat( k, hd[k] );
            }
            int
                pageCount = (int)( Math.Ceiling( (decimal)itemCount / (decimal)size ) );

            System.Text.StringBuilder
                sbPager = new System.Text.StringBuilder();

            sbPager.Append( "<ul>" );
            if ( pageCount <= 5 )
            {
                for ( int i = 1; i <= pageCount; i++ )
                {
                    if ( i == page )
                        sbPager.AppendFormat( "<li class=\"page_sel\" {1}>{0}</li>", i, attrs );
                    else
                        sbPager.AppendFormat( "<li><a href=\"{2}\" {1}>{0}</a></li>", i, attrs, urlFormat.StringFormat( i ) );
                }
            }
            else
            {
                for ( int i = 1; i <= 5; i++ )
                {
                    if ( i == page )
                        sbPager.AppendFormat( "<li class=\"page_sel\" {1}>{0}</li>", i, attrs, urlFormat.StringFormat( i ) );
                    else
                        sbPager.AppendFormat( "<li><a href=\"{2}\" {1}>{0}</a></li>", i, attrs, urlFormat.StringFormat( i ) );
                }

                sbPager.AppendFormat( "<li><a href=\"{1}\" {0}>....</a></li>", attrs, urlFormat.StringFormat( 6 ) );
                sbPager.AppendFormat( "<li><a href=\"{2}\" {1}>{0}</a></li>", pageCount, attrs, urlFormat.StringFormat( pageCount ) );
            }

            sbPager.AppendFormat( "<li class=\"page_num\">{0}条&nbsp;{1}条/页&nbsp;共{2}页</li>", itemCount, page * size, pageCount );
            sbPager.Append( "</ul>" );

            return helper.Raw( sbPager.ToString() ).ToHtmlString();
        }
    }
}

