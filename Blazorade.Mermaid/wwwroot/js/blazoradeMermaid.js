
import mermaid from "https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.esm.min.mjs";
mermaid.initialize({ startOnLoad: false });

export function run(querySelector) {
    mermaid.run({ querySelector: querySelector });
}