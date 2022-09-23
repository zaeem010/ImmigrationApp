$(function () {
    var _message = "";
    var _Datetime = "";
    //
});
document.getElementById('sendButton').addEventListener('click', () => {
    var ChatAppHub = {};
    ChatAppHub.UserId = $('#ChatAppHub_UserId').val();
    ChatAppHub.Type = $('#ChatAppHub_Type').val();
    ChatAppHub.Message = $('#ChatAppHub_Message').val();
    ChatAppHub.MessageDateTime = $('#ChatAppHub_MessageDateTime').val();
    ChatAppHub.PeopleHubId = $('#ChatAppHub_PeopleHubId').val();
    //
    var currentdate = new Date();
    currentdate=(currentdate.getMonth() + 1) + "-"
        + currentdate.getDate() + "-"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
    _Datetime = currentdate;
    ChatAppHub.MessageDateTime = currentdate;
        
    //Date End
    if (ChatAppHub.Message.trim() === "") return;
    _message = ChatAppHub.Message;
    //Save In Database
    $.ajax({
        type: "POST",
        url: '/ChatApp/Save',
        data: ChatAppHub,
        success: (res) => {
            if (res !== null) {
                if (res == "Registerd Successfully")
                {
                    let sendmessage = {
                        userId: ChatAppHub.UserId,
                        message: ChatAppHub.Message
                    }
                    $('#ChatAppHub_Message').val('');
                    sendMessageToHub(ChatAppHub.UserId, ChatAppHub.Message);
                    addMessageToChat(sendmessage);
                } else
                {
                    ShowToaster(0, "Couldn't send message due to error.!");
                }
            }else {
                ShowToaster(0, "Couldn't send message due to error.!");
            }
        }
    });
    //Save In Database
});

function addMessageToChat(value) {
    debugger;
    if (value.message != undefined) {
        let isCurrentUserMessage = value.userId === $('#UserId').val();
        var chatposition = "";
        if (isCurrentUserMessage) {
            chatposition = "chat-list-right";
        }
        let li = `<li class=${chatposition}>
                <div class="chat-content">
                    <div class="chat-text">
                        ${value.message}
                    </div>
                    <div class="chat-time">${_Datetime}</div>
                </div>
            </li>`;
        $('#messagesList').append(li);
        var div = document.getElementById("messagesList");
        div.scrollTop = div.scrollHeight - div.clientHeight;
    }
}
