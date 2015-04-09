$(document).ready(function ()
{
    var months = ["janúar", "febrúar", "mars", "apríl", "maí", "júní", "júlí", "ágúst", "september", "október", "nóvember", "desember"];

    $("#btnSubmit").click(function ()
    {
        
        $("#waitingMessage").fadeIn(500);
        $.post("/Home/Index", { comment: $("#CommentText").val() }, function (data)
        {

            //alert("wut");
            var count = 1;
            var list = "";
            var comment_div = document.getElementById('comment_list');

            //list += '<ul  class="commentList" id="commentList">';
            list = "";
            // alert(list);
            $('.yolo').remove();
            $.each(data, function (i, val)
            {

                //alert(val.UserName);
                count++;
                
                var dateString = new Date(parseInt(val.CommentDate.substr(6)))
                var dd = dateString.getDate();
                var mm = months[dateString.getMonth()];
                var hh = dateString.getHours();
                var min = dateString.getMinutes();
                if (dd <= 9)
                {
                    dd = "0" + dd;
                }

                if (hh <= 9)
                {
                    hh = "0" + hh;
                }

                if (min <= 9)
                {
                    min = "0" + min;
                }

               
              
                    list = '<li class="yolo">'
                         + '<a href="http://www.ru.is">'
                            + '<img alt="Notandi" src="/Content/Images/User.jpg"></img>'
                         + '</a>'
                         + '<div class="commentBody">'
                             + '<a href="http://www.ru.is">' + val.UserName
                                 + '</a>'
                                    + '<span> ' + val.CommentText
                                    + '</span>'
                                    + '<div>'
                                        + '<abbr title="#">' + dd + ". " + mm + " " + hh + ":" + min + " "
                                        + '</abbr>'
                                        + '<a href="#" class="commentLike" id="' + val.ID + '">Like dis'
                                        + '</a>'
                              + '</a>'
                       + '</div>'
                       + '</div>'
                    + '</li>';
                //$(".commentList").prepend(list);
                //$(list).insertAfter('#commentAdd');
                   // var beforeFirst = Math.ceil($()).length - (length - 1);
                $('.commentAdd').before(list);

            });


            $('#CommentText').val('');
            

        });
        bind_likes();
    });

    bind_likes();

    $(".like_div").hide();

    $(".commentLike").click(function ()
    {
        $(this).hide();
    });
    
    
    $(".like_count").mouseenter(function ()
    {
        $(".like_div").hide("");
        var likeid = trim_id($(this).attr("id"));

        $("#like_" + likeid).show("");
    }).mouseleave(function ()
    {
        $(".like_div").hide("");
    });

});


function trim_id(string_counter)
{
    var stuff = string_counter.substring(6);
    //alert(stuff);
    return stuff;
}

function has_liked(like_div_id, username)
{
    var like_id = "like_" + like_div_id
    var user = trim_username(username);
}

function trim_username(username)
{
}

function bind_likes()
{
    $(".commentLike").click(function ()
    {
        var likeid = $(this).attr("id");
        //alert(likeid);
        $.post("/Home/Index2", { id: $(this).attr("id") }, function (data)
        {

            //alert(data.UserName);
            //alert(data.UserName);
            //data.UserName
            //var likeid = $(this).attr("id");
            //alert(likeid);


        });

    });
}


