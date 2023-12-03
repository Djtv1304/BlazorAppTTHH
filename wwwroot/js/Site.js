
function viewProduct(headerModalText, bodyModalText) {

    $(document).ready(function () {

        var modal = $('#viewProductModal');
        if (modal.length) {
            $("#viewProductName").text(headerModalText);
            $("#viewProductDescription").text(bodyModalText);
            modal.modal('show');
        } else {
            console.error('Modal not found');
        }

    });

}

function hideProductModal() {

    $(document).ready(function () {

        var modal = $('#viewProductModal');
        if (modal.length) {
            modal.modal('hide');
        } else {
            console.error('Modal not found');
        }

    });

}


/*function viewProduct(headerModalText, bodyModalText) {
    $("#viewProductName").text(headerModalText);
    $("#viewProductDescription").text(bodyModalText);
    $('#viewProductModal').modal('show');
}

function hideProductModal() {
    $('#viewProductModal').modal('hide');
}*/

