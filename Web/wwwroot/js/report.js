function valudateForm() {
    return $('#from').val() && $('#To').val();
}

function onButtonClick() {
    if (!valudateForm()) {
        alert("შეავსეთ თარიღები!");
        return;
    }

    $.ajax({
        url: "Report/GetData",
        data: {
            "From": $('#from').val(),
            "To": $('#To').val()
        },
        cache: false,
        type: "GET",
        success: function (response) {
            appendLabbelValue(response);
        },
        error: function (xhr) {
            alert("error");
        }
    });
}

function appendLabbelValue(response) {
    var stringResult = '';
    if (response) {
        stringResult += "OrderId:" + response.orderId + "; " + "Amount:" + response.orderTotalAmount;
        $("#result").text(stringResult);
    }
    else {
        $("#result").text('Not found');
    }
}
