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
    /// Represents configuration properties of the Mermaid component.
    /// </summary>
    public sealed record MermaidConfiguration
    {
        /// <summary>
        /// The security level to use for the diagram.
        /// </summary>
        /// <remarks>
        /// The default value is <c>strict</c>.
        /// See https://mermaid.js.org/config/schema-docs/config.html#securitylevel for more information.
        /// </remarks>
        [JsonPropertyName("securityLevel")]
        public string? SecurityLevel { get; init; }
    }

    /// <summary>
    /// A base class for components with Mermaid functionality.
    /// </summary>
    public abstract class MermaidComponentBase : BlazoradeComponentBase
    {

        /// <summary>
        /// The (optional) configuration for this Mermaid component.
        /// </summary>
        [Parameter]
        public MermaidConfiguration? Configuration { get; set; }

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
