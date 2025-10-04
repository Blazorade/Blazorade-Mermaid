import mermaid from "https://cdn.jsdelivr.net/npm/mermaid@11/dist/mermaid.esm.min.mjs";

export async function run(id, definition, configuration) {
    console.debug("run (id, definition, configuration)", id, definition, configuration);
    const elem = document.getElementById(id);
    if (!elem) {
        console.warn("Mermaid: no element with id:", id);
        return;
    }

    // Reset old render flags from previous versions/renders
    elem.removeAttribute("data-processed");
    elem.innerHTML = definition;

    // Render just this element
    await renderOnly(elem, configuration);
}

let renderCount = 0;

export async function renderOnly(target, configuration) {
    console.debug("renderOnly(target, configuration)", target, configuration);

    if (renderCount === 0) {
        renderCount = 1;            // set BEFORE prerender to avoid recursion
        await prerenderDiagram();   // ← await the warm-up render
    }

    if (configuration) {
        mermaid.initialize(configuration);
    }

    // Accept a selector string or a Node; pass explicit nodes to Mermaid
    let nodes;
    if (typeof target === "string") {
        nodes = Array.from(document.querySelectorAll(target));
    } else if (target instanceof Element) {
        nodes = [target];
    } else {
        nodes = [];
    }

    if (nodes.length === 0) return;

    await mermaid.run({ nodes });
    renderCount++;
}

/**
 * This function is called if no diagrams have been rendered previously. It is used to render a very simple
 * flow chart diagram with no themes. Once the diagram has been rendered, it is removed from the DOM.
 * This is to work around a problem that occurs on initial rendering of diagrams that include inline 
 * themes. That problem does not occur after the initial diagram has been rendered.
 * 
 * Warm up the renderer once, then remove the temp element AFTER the async render completes.
 */
async function prerenderDiagram() {
    const body = document.body;
    if (!body) return;

    const dt = new Date();
    const id = `blzrd-${dt.getFullYear()}${dt.getMonth()}${dt.getDate()}${dt.getHours()}${dt.getMinutes()}${dt.getSeconds()}${dt.getMilliseconds()}`;

    const diagElement = document.createElement("pre");
    diagElement.id = id;
    body.appendChild(diagElement);

    // IMPORTANT: await the render before removing the node
    await run(id, "flowchart TB\na-->b");

    diagElement.remove();
}
