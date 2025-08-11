
import mermaid from "https://cdn.jsdelivr.net/npm/mermaid@11/dist/mermaid.esm.min.mjs";

export function run(id, definition, configuration) {
    console.debug("run (id, definition, configuration)", id, definition, configuration);
    var elem = document.getElementById(id);
    elem.removeAttribute("data-processed");

    elem.innerHTML = definition;
    renderOnly("#" + id, configuration);
}

var renderCount = 0;
export async function renderOnly(selector, configuration) {
    console.debug("renderOnly(selector, configuration)", selector, configuration);

    if (renderCount == 0) {
        renderCount = 1;
        prerenderDiagram();
    }

    if (configuration) {
        mermaid.initialize(configuration);
    }

    await mermaid.run({ querySelector: selector });
    renderCount++;
}

/**
 * This function is called if no diagrams have been rendered previously. It is used to render a very simple
 * flow chart diagram with no themes. Once the diagram has been rendered, it is removed from the DOM.
 * This is to work around a problem that occurs on initial rendering of diagrams that include inline 
 * themes. That problem does not occur after the initial diagram has been rendered.
 */
function prerenderDiagram() {
    var body = document.getElementsByTagName("body");
    if (body.length > 0) {
        var diagElement = document.createElement("pre");
        var dt = new Date();
        var id = "blzrd-" + dt.getFullYear() + dt.getMonth() + dt.getDate() + dt.getHours() + dt.getMinutes() + dt.getSeconds() + dt.getMilliseconds();
        diagElement.setAttribute("id", id);
        body.item(0).appendChild(diagElement);

        run(id, "flowchart TB\n    a-->b");

        body.item(0).removeChild(diagElement);
    }
}
