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

    var boardUrl = 'Board/Search';
    $.ajax(
        {
            url: boardUrl,
            method: "POST",
            data: requestData,
            headers: {
                'Accept': 'application/json'
        }
    }).then(function (r) {

        var json = JSON.parse(r); //文字列をJSONオブジェクトに変換

        var jsonid = document.getElementById("id");
        var jsonwriter = document.getElementById("writer");
        var jsontitle = document.getElementById("title");
        var jsondate = document.getElementById("date");

        var table = document.getElementById("boardTable");

        //引数1 : 表の1行目に追加
        var trId = table.insertRow(0);

        //thセルの追加
        var thId = document.createElement("th");

        var headCellId = trId.insertCell(0);
        var headCellWriter = trId.insertCell(1);
        var headCellTitle = trId.insertCell(2);
        var headCellDate = trId.insertCell(3);
        var headCellAllDelete = trId.insertCell(4);

        headCellId.textContent = "ID";
        headCellWriter.textContent = "Writer";
        headCellTitle.textContent = "Title";
        headCellDate.textContent = "UpdatedDate";
        headCellAllDelete.textContent = "AllDelete";

        trId.appendChild(thId);

        for (var i = 0; i < json.length; i++)
        {
            var trId = table.insertRow(i+1); 

            //tdセルの追加
            var tdId = document.createElement("td");
            trId.appendChild(tdId);
            var cellId = trId.insertCell(0);
            var cellWriter = trId.insertCell(1);
            var cellTitle = trId.insertCell(2);
            var cellDate = trId.insertCell(3);

            //textContent
            cellId.textContent = json[i].Id;
            cellWriter.textContent = json[i].Writer;
            cellTitle.textContent = json[i].Title;

            var allDate = new Date(json[i].UpdatedDate);
            var year = allDate.getFullYear();
            var month = allDate.getMonth() + 1;
            var date = allDate.getDate();

            var yyyy = year.toString();
            var mm = ("00" + month).slice(-2);
            var dd = ("00" + date).slice(-2);

            var yyyymmdd = yyyy + "年" + mm + "月" + dd + "日";

            cellDate.textContent = yyyymmdd;
        }

    }, function (e) {
        alert("error: " + e);
    });

}





function createJson() {
    var Title = document.getElementById("createTitle");
    var Text = document.getElementById("createText");
    var Writer = document.getElementById("createWriter");
    var Date = document.getElementById("createDate");
    

    var requestData = {
        "Title": Title.value,
        "Text": Text.value,
        "Writer": Writer.value,
        "UpdatedDate": Date.value,
        
    }

    var boardUrl = 'Board/Create';
    $.ajax(
        {
            url: boardUrl,
            method: "POST",
            data: requestData,
            headers: {
                'Accept': 'application/json'
            }
        }).then(function (r) {

            var json = JSON.parse(r); //文字列をJSONオブジェクトに変換

            var table = document.getElementById("boardTable");

            //引数1 : 表の1行目に追加
            var trId = table.insertRow(0);

            //thセルの追加
            var thId = document.createElement("th");

            var headCellId = trId.insertCell(0);
            var headCellWriter = trId.insertCell(1);
            var headCellTitle = trId.insertCell(2);
            var headCellDate = trId.insertCell(3);
            var headCellAllDelete = trId.insertCell(4);

            headCellId.textContent = "ID";
            headCellWriter.textContent = "Writer";
            headCellTitle.textContent = "Title";
            headCellDate.textContent = "UpdatedDate";
            headCellAllDelete.textContent = "AllDelete";

            trId.appendChild(thId);

            for (var i = 0; i < json.length; i++) {
                var trId = table.insertRow(i + 1);

                //tdセルの追加
                var tdId = document.createElement("td");
                trId.appendChild(tdId);
                var cellId = trId.insertCell(0);
                var cellWriter = trId.insertCell(1);
                var cellTitle = trId.insertCell(2);
                var cellDate = trId.insertCell(3);

                //textContentでもいいしinnnerHTMLでもいいし
                cellId.textContent = json[i].Id;
                cellWriter.textContent = json[i].Writer;
                cellTitle.textContent = json[i].Title;
                cellDate.textContent = json[i].UpdatedDate;
            }

        }, function (e) {
            alert("error: " + e);
        });
}
