using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Mermaid.Components
{
    /// <summary>
    /// This component is used to render dynamically generated HTML content that potentially contains one or more Mermaid diagram definition.
    /// </summary>
    partial class HtmlRender
    {

        /// <summary>
        /// The HTML content to render.
        /// </summary>
        [Parameter]
        public string? HtmlContent { get; set; }



        private MarkupString? MarkupContent { get; set; }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if(this.HtmlContent?.Length > 0)
            {
                this.MarkupContent = new MarkupString(this.HtmlContent);
            }
            else
            {
                this.MarkupContent = null;
            }
        }
    }
}
