const connection = new signalR.HubConnection("/chathub");

connection.on("ReceiveMessage", (message) => {
    const encodedMsg = message;
    const li = document.createElement("li");
    li.innerText = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", event => {
     const message = document.getElementById("messageInput").value;
     connection.send("SendMessage", message).catch(err => console.error);
     event.preventDefault();
});

connection.start().catch(err => console.error);