var totalAmount = document.getElementById("Counter");
var count = 0;
$(".coin").click(function () {
    count += +this.innerHTML;
    totalAmount.innerHTML = count;
    var divElem = document.getElementById("divElem");
    var elementsH4 = divElem.getElementsByTagName("h4");
    var elementButton = divElem.getElementsByTagName("button");
    var elementsH5 = divElem.getElementsByTagName("h5");

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
}); 