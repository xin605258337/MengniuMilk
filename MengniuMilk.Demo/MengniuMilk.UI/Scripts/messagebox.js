﻿function showmessagebox(flag,message) {
    if (flag) {
        $(".messageBox").removeClass("messageError").text(message).css("mafrgin-left", -($(".messageBox").outerWidth() / 2)).animate({ top: 0 }, "fast").delay(1500).animate({ top: "-57px" }, "fast");  
    }
    else {
        $(".messageBox").addClass("messageError").text(message).css("margin-left", -($(".messageBox").outerWidth() / 2)).animate({ top: 0 }, "fast").delay(1500).animate({ top: "-57px" }, "fast");     
    }
}