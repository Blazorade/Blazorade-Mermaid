using Blazorade.Core.Components;
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
    /// A base class for components with Mermaid functionality.
    /// </summary>
    public abstract class MermaidComponentBase : BlazoradeComponentBase
    {

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
    }
}
