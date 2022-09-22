const dialogButton = document.querySelector("#dialogButton");
dialogButton.addEventListener("click", () => {
    alert("You clicked the button");
});

$("#dialogButton").on("click", () => {
    console.log("Hi, I'm using JQuery");
});