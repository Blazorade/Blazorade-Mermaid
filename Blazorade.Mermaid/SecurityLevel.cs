using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Mermaid
{
    /// <summary>
    /// Defines different security levels for Mermaid diagrams.
    /// </summary>
    public enum SecurityLevel
    {
        /// <summary>
        /// Default. HTML tags in the text are encoded and click functionality is disabled.
        /// </summary>
        Strict,
        /// <summary>
        /// HTML tags in text are allowed and click functionality is enabled.
        /// </summary>
        Loose,
        /// <summary>
        /// HTML tags in text are allowed (only script elements are removed), and click functionality is enabled.
        /// </summary>
        AntiScript,
        /// <summary>
        /// With this security level, all rendering takes place in a sandboxed iframe. This prevent any JavaScript
        /// from running in the context. This may hinder interactive functionality of the diagram, like scripts,
        /// popups in the sequence diagram, or links to other tabs or targets, etc.
        /// </summary>
        Sandbox
    }
}
