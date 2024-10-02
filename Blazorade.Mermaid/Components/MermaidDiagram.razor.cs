using Blazorade.Mermaid.Model;
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
        private const string DefaultDefinition = @"
---
title: Diagram definition not specified
---
flowchart TB

s1[Click here to read more on the Blazorade-Mermaid Wiki]

click s1 ""https://github.com/Blazorade/Blazorade-Mermaid/wiki"" ""Open Blazorade-Mermaid Wiki"" _blank
";

        /// <summary>
        /// The Mermaid definition to render as a diagram.
        /// </summary>
        /// <remarks>
        /// Read more about Mermaid and diagrams on https://mermaid.js.org/intro/.
        /// </remarks>
        [Parameter]
        public string Definition { get; set; } = default!;

        /// <summary>
        /// The ID for the diagram.
        /// </summary>
        /// <remarks>
        /// This will be automatically set on the component, if not set in your code.
        /// </remarks>
        [Parameter]
        public string? Id { get; set; }

        /// <summary>
        /// The callback method that will be called by Mermaid JS when a diagram element is clicked.
        /// </summary>
        [JSInvokable]
        public Task OnElementClickCallbackAsync(ElementClickCallbackArgs args)
        {
            // TODO: Still lacks implementations.
            return Task.CompletedTask;
        }


        /// <inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await this.UpdateDiagramAsync();
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            this.AddClasses("mermaid");
            this.SetIdIfEmpty();
            base.OnParametersSet();
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

        private ValueTask RegisterClickCallbacksAsync()
        {
            // TODO: Still lacks implementations.
            return ValueTask.CompletedTask;
        }

        private async ValueTask UpdateDiagramAsync()
        {
            var jsModule = await this.GetBlazoradeMermaidModuleAsync();

            if (string.IsNullOrEmpty(this.Definition))
            {
                // If the definition parameter is not set, then we try to figure it out.
                // We use the following order to get the definition.
                // 1. Get the inner text of the current element if it exists
                // 2. Use the default definition.

                var dDef = await jsModule.InvokeAsync<string?>("getInnerText", this.Id);
                this.Definition = dDef?.Length > 0 ? dDef : DefaultDefinition;
            }

            if(null == this.ChildContent && this.Definition?.Length > 0)
            {
                await jsModule.InvokeVoidAsync("run", this.Id, this.Definition, this.GetConfig());
            }

            await this.RegisterClickCallbacksAsync();
        }
    }
}
