# Blazorade Mermaid

Blazorade Mermaid is a library that allows you to easily add [Mermaid diagrams](https://mermaid.js.org/) to your Blazor application. You don't have to bother with importing the JavaScript library, or calling the right JavaScript functions in the Mermaid library at the right time.

You just add the `MermaidDiagram` component to your application, set its `Code` parameter to the Mermaid code you want to render as a diagram, the Blazorade Mermaid takes care of the rest.

## Getting Started

Please refer to the Blazorade Mermaid wiki for information on how to get started with the library.
> Please note that this library is still in beta phase, and the wiki is still heavily under construction. However, using Blazorade is pretty simple.

- Add a reference to `Blazorade.Mermaid`
- Add a `using` statement to the following namespace: `Blazorade.Mermaid.Components`
- Add the `<MermaidDiagram />` to the page or component where you want to display a diagram.
- Set the `Code` property of the `MermaidDiagram` component to the Mermaid Code you want to render as a diagram.

Blazorade Mermaid will take care of the rest for you.

## Version Highlights

### v1.0.0-beta.1

The first published prerelease of the library.