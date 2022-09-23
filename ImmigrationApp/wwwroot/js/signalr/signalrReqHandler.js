var connection = new signalR.HubConnectionBuilder()
    .withUrl('/notify')
    .build();
connection.on('ReceiveMessage', addMessageToChat);

connection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(user, message) {
    debugger;
    connection.invoke('SendMessage', user, message)
}