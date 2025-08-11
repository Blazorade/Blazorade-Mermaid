# Blazorade Mermaid

Blazorade Mermaid is a library that allows you to easily add [Mermaid diagrams](https://mermaid.js.org/) to your Blazor application. You don't have to bother with importing the JavaScript library, or calling the right JavaScript functions in the Mermaid library at the right time.

You just add the `MermaidDiagram` component to your application, set its `Code` parameter to the Mermaid code you want to render as a diagram, the Blazorade Mermaid takes care of the rest.

## Getting Started

Please refer to the [Blazorade Mermaid wiki](https://github.com/Blazorade/Blazorade-Mermaid/wiki) for information on how to get started with the library.
> Please note that this library is still in beta phase, and the wiki is still heavily under construction. However, using Blazorade is pretty simple.

- Add a reference to `Blazorade.Mermaid`
- Add a `using` statement to the following namespace: `Blazorade.Mermaid.Components`
- Add the `<MermaidDiagram />` to the page or component where you want to display a diagram.
- Set the `Definition` property of the `MermaidDiagram` component to the Mermaid Code you want to render as a diagram.

Blazorade Mermaid will take care of the rest for you.

## Version Highlights

### v2.0.1

- Updated reference to v11 of the Mermaid JavaScript library, using https://cdn.jsdelivr.net/npm/mermaid@11/dist/mermaid.esm.min.mjs

### v2.0.0

- Updated reference to `Blazorade.Core` to version 4.0.0, which targets .NET 8. The previous version of `Blazorade.Core` targeted .NET 6.

### v1.3.0

- Added new `HtmlRender` component for use with dynamically generated and changing HTML content that potentially contains Mermaid diagram definitions.

### v1.2.0

- Async fix to `blazoradeMermaid.js`
- Added configuration option for defining the `securityLevel` for the rendered Mermaid diagrams.

### v1.1.1

- Fixed a bug that caused diagrams with inline themese not to render when the diagram with inline theme was the first diagram to render after the page load. [PR #7](https://github.com/Blazorade/Blazorade-Mermaid/pull/7)

### v1.1.0

- Added the `MermaidRender` component which can be added on a page to render Mermaid definitions published mixed with other HTML content. Read more about how to use this component on the [wiki](https://github.com/Blazorade/Blazorade-Mermaid/wiki/Sample2).

### v1.0.1

- Changed package icon.
- Added XML documentation file to the package to enable inline documentation with intellisense.

### v1.0.0

The first stable version of Blazorade Mermaid.
- Changed the `Code` parameter on the `MermaidDiagram` component to `Definition` to better match the terminology on the [Mermaid website](https://mermaid.js.org/intro/).

### v1.0.0-beta.3

- Prefixed the generated ID for the `MermaidDiagram` component with the character `m` to ensure that it never starts with a digit. `id` attributes for HTML elements **MUST** start with a letter, not a digit.

### v1.0.0-beta.2

- Added support for updating the diagram after it has been rendered the first time.

### v1.0.0-beta.1

The first published prerelease of the library.