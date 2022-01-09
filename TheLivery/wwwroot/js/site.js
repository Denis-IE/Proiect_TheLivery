// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".stare").each(function () {
    const value = $(this).text();
    if (value == "nepreluat") {
        $(this).css("background-color", "red");
    } else if (value == "livreaza") {
        $(this).css("background-color", "orange");
    } else {
        $(this).css("background-color", "green");
    }
});

/*var a = false;
var b = false;
var c = false;
$(".button-submit").each(function () {
    const buttonThis = $(this);
    $(".stare").each(function () {
        const stare = $(this).text();
        console.log(stare);
        if (stare == "nepreluat" && a == false) {
            buttonThis.attr("disabled", false);
            a = true;
            return false;
            console.log("Valoare sus:" + buttonThis.attr("disabled"));
        } else if (stare == "livreaza" && b == false) {
            buttonThis.attr("disabled", true);
            b = true;
            buttonThis.css("background-color", "#808080");
            return false;
            console.log("Valoare jos:" + buttonThis.attr("disabled"));
        } else {
            buttonThis.attr("disabled", true);
            buttonThis.css("background-color", "#808080");
        }
    })
});
*/