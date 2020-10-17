// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    var tweettable = $('#tweets').DataTable({
        "bAutoWidth": true,
        scrollY: '50vh',
        responsive: true,
        scrollCollapse: true,
        "order": [[1, "DESC"]]
    });
   // tweettable.height = "100px";
});
