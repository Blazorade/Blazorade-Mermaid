using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazorade.Mermaid.Model
{
    /// <summary>
    /// Callback arguments for when a diagram element is clicked.
    /// </summary>
    public class ElementClickCallbackArgs
    {
        /// <summary>
        /// The Mermaid ID of the element that was clicked.
        /// </summary>
        public string Id { get; set; } = string.Empty;

    }
}
