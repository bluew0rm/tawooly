function deleteAlert() {
    var deleteAlert = window.confirm('このテキストを削除しますか？');

    if (!deleteAlert) { return false; }
}

function getId() {
    var table = document.getElementById("boardTable"), rIndex;

    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            console.log(rIndex);

            document.getElementById("itemId").value = this.cells[0].innerHTML;
        };
    }
}

function getAll() {
    var table = document.getElementById("boardTable"), rIndex;

    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            console.log(rIndex);

            document.getElementById("itemId").value = this.cells[0].innerHTML;

            document.querySelector("form").submit();
        };
    }
}

function getTitle() {
    var table = document.getElementById("boardTable"), rIndex;

    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            console.log(rIndex);

            document.getElementById("itemId").value = this.cells[0].innerHTML;

            document.querySelector("form").submit();
        };
    }
}

function pagint() {

}

function searchJson2() {


    var id = document.getElementById("searchId");
    var writer = document.getElementById("searchwriter");
    var title = document.getElementById("searchtitle");
    var fromDate = document.getElementById("searchFromDate");
    var toDate = document.getElementById("searchToDate");

    var requestData = {

        "Id": id.value,
        "Writer": writer.value,
        "Title": title.value,
        "FromDate": fromDate.value,
        "ToDate": toDate.value

    }

    $.ajax("/Board/Search", {
        method: "POST",
        data: requestData,
        headers: {
            'Accept': 'application/json'
        }
    }).then(function (r) {
        console.log("done");
    }, function (e) {
        alert("error: " + e);
    });

}

function searchJson() {

    var id = document.getElementById("searchId");
    var writer = document.getElementById("searchwriter");
    var title = document.getElementById("searchtitle");
    var fromDate = document.getElementById("searchFromDate");
    var toDate = document.getElementById("searchToDate");

    var requestData = {

        "Id": id.value,
        "Writer": writer.value,
        "Title": title.value,
        "FromDate": fromDate.value,
        "ToDate": toDate

    }

}

function createJson() {
    var Title = document.getElementById("createTitle");
    var Writer = document.getElementById("createWriter");
    var Date = document.getElementById("createDate");
    var Text = document.getElementById("createText");

    {
        Title: title.value;
        Writer: writer.value;
        Date: Date.value;
        Text: Text;
    }
}