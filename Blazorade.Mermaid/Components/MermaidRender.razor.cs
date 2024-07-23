using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Mermaid.Components
{
    /// <summary>
    /// A component that renders any element that matches a selector into a Mermaid diagram.
    /// </summary>
    /// <remarks>
    /// This component can be useful if you for instance have HTML content coming from a data source
    /// where the content contains HTML content in addition to the Mermaid definitions. Then this
    /// component would render that content into diagrams.
    /// </remarks>
    partial class MermaidRender
    {

        /// <summary>
        /// The selector for the elements containing Mermaid definitions to render into diagrams.
        /// </summary>
        /// <remarks>
        /// The default value is <c>.mermaid</c>.
        /// </remarks>
        [Parameter]
        public string Selector { get; set; } = ".mermaid";

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var jsModule = await this.GetBlazoradeMermaidModuleAsync();
            await jsModule.InvokeVoidAsync("renderOnly", this.Selector, this.GetConfig());
        }
    }
}
