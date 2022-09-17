setTimeout(function () {
    mychatloadfunction(e)
}, 1500);
function mychatloadfunction(e) {
    let Id = parseInt(e.dataset.connectid);
    let Name = e.dataset.connectdname;

    $.ajax({
        type: "POST",
        url: '/ChatApp/GetChat',
        data: {Id: Id},
        success: (data) => {
            if (data !== null && data.res == "Success") {
                
                $('#messagesList').children().remove();
                $('#CanidateName').text(Name);
                $('#ChatAppHub_PeopleHubId').val(Id);
                let li = '';
                for (var i = 0; i < data.chatlist.length; i++) {
                    let otherId = $('#ChatAppHub_UserId').val();
                    //let isCurrentUserMessage = data.chatlist[i].userId === otherId;
                    var chatposition = "";
                    
                    if (data.chatlist[i].userId == otherId)
                    {
                        chatposition = "chat-list-right";
                    }
                    debugger;
                    var currentdate = new Date(data.chatlist[i].messageDateTime);
                    currentdate = (currentdate.getMonth() + 1) + "-"
                        + currentdate.getDate() + "-"
                        + currentdate.getFullYear() + " "
                        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

                    li += `<li class=${chatposition}>
                            <div class="chat-content">
                                <div class="chat-text">
                                    ${data.chatlist[i].message}
                                </div>
                                <div class="chat-time">${currentdate}</div>
                            </div>
                        </li>`;
                }
                $('#messagesList').append(li);
                var div = document.getElementById("messagesList");
                div.scrollTop = div.scrollHeight - div.clientHeight;
            }
            else {
                ShowToaster(0, "Couldn't load message due to error.!");
            }
        }
    });
}