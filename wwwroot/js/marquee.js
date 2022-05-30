let textbox = document.getElementById("warningMessage");
let marqueeMessage = document.getElementById("marquee");


let sendBtn = document.getElementById("sendBtn");

sendBtn.addEventListener('click', function () {
    if (textbox.value !== '') {
        marqueeMessage.innerText = textbox.value;

    }
    else {
        alert("Enter your message first!!!");
    }
});



