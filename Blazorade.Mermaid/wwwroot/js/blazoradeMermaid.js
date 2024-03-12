
import mermaid from "https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs";

export function run(id, definition) {

    var elem = document.getElementById(id);
    elem.removeAttribute("data-processed");

    elem.innerHTML = definition;
    mermaid.run({ querySelector: "#" + id });
}

function isEmpty(value) {
    return (value == null || (typeof value === "string" && value.trim().length === 0));
}