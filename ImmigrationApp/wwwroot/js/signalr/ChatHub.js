var myVar;
$(document).ready(function () {
    myVar = setInterval("mychatloadfunction()", 10000);
});
$(function () {
    scrolltobottom();
    //
});
function scrolltobottom() {
    debugger;
    var div = document.getElementById("messagesList");
    div.scrollTop = div.scrollHeight - div.clientHeight;
}
$(document).keypress(function (e) {
    if (e.which == 13 || event.keyCode == 13) {
        savechat();
    }
});


function savechat() {
    var ChatAppHub = {};
    ChatAppHub.UserId = $('#ChatAppHub_UserId').val();
    ChatAppHub.Type = $('#ChatAppHub_Type').val();
    ChatAppHub.Message = $('#ChatAppHub_Message').val();
    ChatAppHub.MessageDateTime = $('#ChatAppHub_MessageDateTime').val();
    ChatAppHub.PeopleHubId = $('#ChatAppHub_PeopleHubId').val();
    let receiverConnectionId = $('#ReceiverEmail').val();
    //
    var currentdate = new Date();
    currentdate = (currentdate.getMonth() + 1) + "-"
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
                if (res == "Registerd Successfully") {
                    let li = `<li class="chat-list-right">
                            <div class="chat-content">
                                <div class="chat-text">
                                    ${ChatAppHub.Message}
                                </div>
                                <div class="chat-time">${ChatAppHub.MessageDateTime}</div>
                            </div>
                        </li>`;
                    $('#messagesList').append(li);
                    var div = document.getElementById("messagesList");
                    div.scrollTop = div.scrollHeight - div.clientHeight;
                    //
                    $('#ChatAppHub_Message').val('');
                    //sendMessageToHub(ChatAppHub.UserId, ChatAppHub.Message);
                    //sendMessageToUser(ChatAppHub.UserId, receiverConnectionId, ChatAppHub.Message);
                } else {
                    ShowToaster(0, "Couldn't send message due to error.!");
                }
            } else {
                ShowToaster(0, "Couldn't send message due to error.!");
            }
        }
    });
    //Save In Database
}
function addMessageToChat(value,message) {
    debugger;
    if (message != undefined) {
        let userId = $('#ChatAppHub_UserId').val();
        let isCurrentUserMessage = value === userId;
        var chatposition = "";
        if (isCurrentUserMessage) {
            chatposition = "chat-list-right";
        }
        let li = `<li class=${chatposition}>
                <div class="chat-content">
                    <div class="chat-text">
                        ${message}
                    </div>
                    <div class="chat-time">${_Datetime}</div>
                </div>
            </li>`;
        $('#messagesList').append(li);
        var div = document.getElementById("messagesList");
        div.scrollTop = div.scrollHeight - div.clientHeight;
    }
}
