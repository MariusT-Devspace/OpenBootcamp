
const paragraphs = document.querySelectorAll(".paragraph");

paragraphs.forEach(paragraph => {
    paragraph.addEventListener("dragstart", event => {
        paragraph.classList.add("dragging");
        event.dataTransfer.setData("id", paragraph.id);
        const ghostElement = document.querySelector(".ghost-element");
        event.dataTransfer.setDragImage(ghostElement, 0, 0);
    });

    paragraph.addEventListener("dragend", () => {
        paragraph.classList.remove("dragging");
    });
});

const sections = document.querySelectorAll(".section");
sections.forEach(section => {
    section.addEventListener("dragover", event => {
        event.preventDefault();
        event.dataTransfer.dropEffect = "move";
    });
        
    section.addEventListener("drop", event => {
        console.log("Bin drop");
        const paragraphId = event.dataTransfer.getData("id");
        const paragraph = document.getElementById(paragraphId);
        section.appendChild(paragraph);
    });
});

const bin = document.querySelector("#bin");
bin.addEventListener("dragover", event => {
    event.preventDefault();
});

bin.addEventListener("drop", event => {
    const paragraphId = event.dataTransfer.getData("id");
    const paragraph = document.getElementById(paragraphId);
    const section = paragraph.parentElement;
    section.removeChild(paragraph);
    if(section.children.length == 0){
        section.parentElement.removeChild(section);
    }
});

