// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    var tweetTable = $('#tweets').DataTable({
        "bAutoWidth": true,
        scrollY: '45vh',
        responsive: true,
        scrollCollapse: true,
        "rowCallback": function(row, data, index) {
            if (data[2] === "D") {
                $("td", row).css("border-color", "blue");
            }
            if (data[2] === "R") {
                $("td", row).css("border-color", "red");
            }
        },
        "order": [[0, "DESC"]]
    });
});
