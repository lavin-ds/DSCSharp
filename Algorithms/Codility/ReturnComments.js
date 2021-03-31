/*
Problem return comments
*/

'use strict';

/* global $, jQuery */

function solution() {
    var requests = $(".comment-list").attr("data-count");
     // console.log(requests)
   $.ajax({
                type: 'GET',
                url: 'https://www.example.com/comments?count='+requests,
                dataType: 'json',
                data: null,
                beforeSend: function() {
                    $(".comment-list").text('Loading...');
                },
                success: function(result){
                   // console.log(result)
                 $(".comment-list").empty();

               
                $.map(result, function(obj){
                     var parentDiv = $("<div></div>")
                            .addClass("comment-item");
                    var unCommentDiv = $("<div></div>")
                                .addClass("comment-item__username")
                                .text(obj.username);
                    
                    var msgCommentDiv = $("<div></div>")
                                .addClass("comment-item__message")
                                .text(obj.message);
                    
                    unCommentDiv.appendTo(parentDiv);
                    msgCommentDiv.appendTo(parentDiv);  
                     $(".comment-list").append(parentDiv);
                });
                },
                error: function(xhr) { // if error occured
                    $(".comment-list").empty();
                }                
            });
}