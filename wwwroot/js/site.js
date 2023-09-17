// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Edit customer click handler
    $(".add-edit-customer").click(function () {
        var customerId = $(this).data("customer-id");
        $.get("/Customer/AddEdit/" + customerId, function (data) {
            $("#addEditCustomerModal .modal-body").html(data);
            $("#addEditCustomerModal").modal("show");
            $.validator.unobtrusive.parse("#addEditCustomerModal");
        });
    });
});