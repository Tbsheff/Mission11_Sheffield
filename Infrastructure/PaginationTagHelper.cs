using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission10_Sheffield.Models.ViewModels;

namespace Mission10_Sheffield.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            _urlHelperFactory = temp;
        }

        
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        
        public string? PageAction { get; set; }
        
        public PaginationInfo PageModel { get; set; }
        
        public bool PageClassesEnabled { get; set; } = false;
        
        public string PageClass { get; set; } = String.Empty;
        
        public string PageClassNormal { get; set; } = String.Empty;
        
        public string PageClassSelected { get; set; } = String.Empty;
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                
                output.TagName = "div";
                TagBuilder tag = new TagBuilder("div");
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder currentItem = new TagBuilder("a");
                    currentItem.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                    if (PageClassesEnabled)
                    {
                        currentItem.AddCssClass(PageClass);
                        currentItem.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    currentItem.InnerHtml.Append(i.ToString());
                    tag.InnerHtml.AppendHtml(currentItem);
                }
                output.Content.AppendHtml(tag);
            }
           
        }
    }
    }
    
    