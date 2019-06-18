using MyShop.Northwind.MvcWebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace MyShop.Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo, string route)
        {
            int totalPage = (int)Math.Ceiling
                ((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);
            var stringBuilder = new StringBuilder();
            var ulTagBuilder = new TagBuilder("ul");
            ulTagBuilder.MergeAttribute("class", "pagination");
            var liTagBuilder = new TagBuilder("li");

            for (int i = 1; i <= totalPage; i++)
            {
                if (pagingInfo.CurrentPage == i)
                {
                    liTagBuilder.Attributes.Clear();
                    liTagBuilder.MergeAttribute("class", "page-item active");
                }
                else
                {
                    liTagBuilder.Attributes.Clear();
                    liTagBuilder.MergeAttribute("class", "page-item");
                }
                var atagBuilder = new TagBuilder("a");
                atagBuilder.MergeAttribute("class", "page-link");
                atagBuilder.MergeAttribute("href",
                    String.Format(route + "?page={0}&category={1}", i, pagingInfo.CurrentCategory));
                atagBuilder.InnerHtml = i.ToString();
                liTagBuilder.InnerHtml = atagBuilder.ToString();
                stringBuilder.Append(liTagBuilder);
            }
            ulTagBuilder.InnerHtml = stringBuilder.ToString();
            stringBuilder.Clear();
            stringBuilder.Append(ulTagBuilder);
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}