var connection = new signalR.HubConnectionBuilder()
    .withUrl('/notify')
    .build();
connection.on('ReceiveMessage', addMessageToChat);

connection.start().then(function () {
    connection.invoke("GetConnectionId").then(function (Id) {
        $('#ReceiverEmail').val(Id);
        //document.getElementById("connectionId").innerText = id;
    });
}).catch(function (err) {
    return console.error(err.toString());
});

function sendMessageToHub(user, message) {
    connection.invoke('SendMessage', user, message)
}
function sendMessageToUser(user, receiverConnectionId, message) {
    connection.invoke('SendToUser', user, receiverConnectionId, message)
}