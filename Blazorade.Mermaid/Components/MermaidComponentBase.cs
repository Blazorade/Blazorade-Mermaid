using Blazorade.Core.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazorade.Mermaid.Components
{

    /// <summary>
    /// A base class for components with Mermaid functionality.
    /// </summary>
    public abstract class MermaidComponentBase : BlazoradeComponentBase
    {

        /// <summary>
        /// Level of trust for parsed diagram.
        /// </summary>
        [Parameter]
        public SecurityLevel? SecurityLevel { get; set; }

        
        /// <summary>
        /// Injected JavaScript Runtime implementation.
        /// </summary>
        [Inject]
        protected IJSRuntime JSRuntime { get; set; } = null!;

        private IJSObjectReference _BlazoradeMermaidModule = null!;
        /// <summary>
        /// Returns a reference to the Blazorade Mermaid JavaScript file.
        /// </summary>
        protected async ValueTask<IJSObjectReference> GetBlazoradeMermaidModuleAsync()
        {
            return _BlazoradeMermaidModule ??= await this.JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Blazorade.Mermaid/js/blazoradeMermaid.js");
        }

        /// <summary>
        /// Returns a configuration object to send to Mermaid when rendering diagrams.
        /// </summary>
        protected Dictionary<string, object?> GetConfig()
        {
            var config = new Dictionary<string, object?>();

            if(this.SecurityLevel.HasValue)
            {
                config["securityLevel"] = this.SecurityLevel?.ToString()?.ToLower();
            }

            return config;
        }

        /// <summary>
        /// Invokes the rendering of a Mermaid diagram on the client side for the specified CSS selector.
        /// </summary>
        /// <remarks>This method uses the Blazorade Mermaid JavaScript module to render the diagram.
        /// Ensure that the specified selector matches an existing HTML element on the page.</remarks>
        /// <param name="selector">The CSS selector identifying the HTML element where the Mermaid diagram should be rendered. Cannot be null
        /// or empty.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected async Task InvokeRenderOnlyAsync(string selector)
        {
            await this.InvokeMermaidModuleVoidAsync("renderOnly", selector, this.GetConfig());
        }

        /// <summary>
        /// Executes the Mermaid diagram rendering process for the specified element and definition.
        /// </summary>
        /// <remarks>This method invokes the JavaScript function responsible for rendering Mermaid
        /// diagrams  in the specified HTML element. Ensure that the provided <paramref name="id"/> corresponds  to a
        /// valid HTML element on the page and that the <paramref name="definition"/> contains  a valid Mermaid diagram
        /// syntax.</remarks>
        /// <param name="id">The ID of the HTML element where the Mermaid diagram will be rendered.</param>
        /// <param name="definition">The Mermaid diagram definition to be rendered.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected async Task InvokeRunAsync(string? id, string definition)
        {
            await this.InvokeMermaidModuleVoidAsync("run", id, definition, this.GetConfig());
        }

        /// <summary>
        /// Invokes a JavaScript function within the Blazorade Mermaid module without returning a result.
        /// </summary>
        /// <remarks>This method is asynchronous and ensures that the Blazorade Mermaid JavaScript module
        /// is loaded before invoking the specified function. Use this method when the JavaScript function does not
        /// return a value.</remarks>
        /// <param name="identifier">The identifier of the JavaScript function to invoke.</param>
        /// <param name="args">An optional array of arguments to pass to the JavaScript function. Can be null.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected async Task InvokeMermaidModuleVoidAsync(string identifier, params object?[]? args)
        {
            try
            {
                var jsModule = await this.GetBlazoradeMermaidModuleAsync();
                await jsModule.InvokeVoidAsync(identifier, args);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
