var totalAmount = document.getElementById("counter");
var count = 0;

$(".coin").click(function () {
    count += +this.innerHTML;
    totalAmount.innerHTML = count;
    $.ajax({
        type: "POST",
        url: "/Home/SendCoin",
        data: { "coin": +this.innerHTML },
        success: function (data) {
            console.log(data);
        }
    });
    validateBeverage();
});

$(".sendBeverage").click(function () {
    var divElems = document.getElementById("divElems");
    var elementsH5 = divElems.getElementsByTagName("h5");
    count -= this.value;
    totalAmount.innerHTML = count;
    $.ajax({
        type: "POST",
        url: "/Home/SendBeverage",
        data: { "id": this.id },
        success: function (data) {
            console.log(data);
        }
    });

    for (var i = 0; i < elementsH5.length; i++) {
        if (+elementsH5[i].id === +this.id) {
            var x = +elementsH5[i].innerHTML.replace(/\D+/g, "");
            elementsH5[i].innerHTML = "Осталось штук: " + --x;
            validateBeverage();
        }
    }
    
});

var validateBeverage = function () {
    var divElems = document.getElementById("divElems");
    var elementsH4 = divElems.getElementsByTagName("h4");
    var elementButton = divElems.getElementsByTagName("button");
    var elementsH5 = divElems.getElementsByTagName("h5");

    for (var i = 0; i < elementsH4.length; i++) {
        var elementH4 = +elementsH4[i].innerHTML.replace(/\D+/g, "");
        for (var z = i; z < elementsH5.length; z++) {
            var elementH5 = +elementsH5[z].innerHTML.replace(/\D+/g, "");
            for (var y = z; y < elementButton.length; y++) {
                var inputButton = elementButton[y];
                if (count >= elementH4 && elementH5 > 0) {
                    inputButton.disabled = false;
                } else if (count < elementH4 || elementH5 <= 0) {
                    inputButton.disabled = true;
                }
            }
        }
    }
}
