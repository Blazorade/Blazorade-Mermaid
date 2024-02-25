
import mermaid from "https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs";
mermaid.initialize({ startOnLoad: false });

export function run(id, code) {
    var elem = document.getElementById(id);
    elem.removeAttribute("data-processed");
    elem.innerHTML = code;
    mermaid.run({ querySelector: "#" + id });
}