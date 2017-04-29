$(document).ready(function() {
    $("#create-button").click(function() {
        window.location.href = "/activityusers/create";
    });

    $("#edit-button").click(function () {
        window.location.href = "/activityusers/edit/"+$(this).data("item-id");
    });

    $("#view-button").click(function () {
        window.location.href = "/activityusers/details/"+$(this).data("item-id");
    });

    $("#delete-button").click(function () {
        window.location.href = "/activityusers/delete/" + $(this).data("item-id");
    });
});