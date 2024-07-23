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
    }
}
