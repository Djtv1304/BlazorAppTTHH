
function viewProduct(headerModalText, bodyModalText) {
    $("#viewProductName").text(headerModalText);
    $("#viewProductDescription").text(bodyModalText);
    $('#viewProductModal').modal('show');
}

function hideProductModal() {
    $('#viewProductModal').modal('hide');
}

