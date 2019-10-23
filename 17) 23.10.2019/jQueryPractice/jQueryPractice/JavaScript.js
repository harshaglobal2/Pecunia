//selecting & css
//$("#div1").css("background-color", "lightgreen");

//set html
//$("#div1").html("<p>new para</p>");

//get html
//var s = $("#div1").html();
//console.log(s);

//before
$(document).ready(function ()
{
    $("#div1").before("<p>new para</p>");
});


$(window).load(function ()
{
    $("#div1").before("<p>new para</p>");
});


