using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        /// <summary>
        /// The Mermaid definition to render as a diagram.
        /// </summary>
        /// <remarks>
        /// Read more about Mermaid and diagrams on https://mermaid.js.org/intro/.
        /// </remarks>
        [Parameter]
        public string Definition { get; set; } = @"
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

        /// <summary>
        /// The ID for the diagram.
        /// </summary>
        /// <remarks>
        /// This will be automatically set on the component, if not set in your code.
        /// </remarks>
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = null!;

        /// <inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            var jsModule = await this.GetBlazoradeMermaidModuleAsync();
            await jsModule.InvokeVoidAsync("run", this.Id, this.Definition);
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            this.AddClasses("mermaid");
            this.SetIdIfEmpty();
            base.OnParametersSet();
        }

        private IJSObjectReference _BlazoradeMermaidModule = null!;
        private async ValueTask<IJSObjectReference> GetBlazoradeMermaidModuleAsync()
        {
            return _BlazoradeMermaidModule ??= await this.JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Blazorade.Mermaid/js/blazoradeMermaid.js");
        }

        private void SetIdIfEmpty(string? id = null)
        {
            if(!this.Attributes.ContainsKey("id"))
            {
                // Assuming that the first 8 chars is unique enough in the context of the page the component is shown on.
                // Unnecessarily long ID values may cause problems with certain frameworks.
                id = this.Id ?? id ?? $"m{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12)}";
                this.Id = id;
                this.Attributes.Add("id", id);
            }
        }
    }
}
