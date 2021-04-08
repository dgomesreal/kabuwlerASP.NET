// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkValue() {
    var valueCheck = (document.getElementById('CrawlerText').value)
    if (valueCheck == null || valueCheck == "") {
        window.alert("Enter a Value!")
    } else {
        $('#load').css('display', 'none')
    }
}