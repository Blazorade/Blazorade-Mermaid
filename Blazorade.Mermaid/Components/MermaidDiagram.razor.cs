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
    /// Use this component to display Mermaid diagrams in your application.
    /// </summary>
    /// <remarks>
    /// For more information on Mermaid and what kind of diagrams you can display with it, please
    /// refer to https://mermaid.js.org/
    /// </remarks>
    partial class MermaidDiagram
    {
        private const string MermaidClass = "mermaid";

        /// <summary>
        /// The Mermaid code to render as a diagram.
        /// </summary>
        /// <remarks>
        /// Read more about Mermaid and diagrams on https://mermaid.js.org/intro/.
        /// </remarks>
        [Parameter]
        public string Code { get; set; } = @"
sequenceDiagram

participant A as Alice
participant B as Bob

A ->> B: Hello Bob, how are you ?
B ->> A: Fine, thank you. And you?

create participant C as Carl

A ->> C: Hi Carl!

create actor D as Donald

C ->> D: Hi!

destroy C

A -x C: We are too many

destroy B

B ->> A: I agree
";


        [Inject]
        private IJSRuntime JSRuntime { get; set; } = null!;

        /// <inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                var jsModule = await this.GetBlazoradeMermaidModuleAsync();
                await jsModule.InvokeVoidAsync("run", $".{MermaidClass}");
            }
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            this.AddClasses(MermaidClass);
            base.OnParametersSet();
        }

        private IJSObjectReference _BlazoradeMermaidModule = null!;
        private async ValueTask<IJSObjectReference> GetBlazoradeMermaidModuleAsync()
        {
            return _BlazoradeMermaidModule ??= await this.JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Blazorade.Mermaid/js/blazoradeMermaid.js");
        }
    }
}
