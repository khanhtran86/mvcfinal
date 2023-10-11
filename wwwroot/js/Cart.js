var updateQty = (qty, price) => {
    if (qty > 0) {
        $('.total').text('$' + qty * price)
        $('#qtyupdate').val(qty);
    }
}