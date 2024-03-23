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
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper? urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext!);
           
        }
    }
    }
    
    