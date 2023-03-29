function deleteAlert() {
    var deleteAlert = window.confirm('テキストを削除しますか？');

    if (!deleteAlert) { return false; }
}

function home() {
    $(location).attr("href", "https://localhost:44342/Board");
}

function getitemId() {

    var tableGetId = document.getElementById("tableBody"), rIndex;
    for (var i = 0; i < tableGetId.rows.length; i++) {
        tableGetId.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            console.log(rIndex);
            document.getElementById("itemId").value = this.cells[0].innerHTML;
        };
    }
}

function getitemAll() {

    var tableGetId = document.getElementById("tableBody"), rIndex;
    for (var i = 0; i < tableGetId.rows.length; i++) {
        tableGetId.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            console.log(rIndex);
            document.getElementById("itemId").value = this.cells[0].innerHTML;
            document.getElementById("itemWriter").value = this.cells[1].innerHTML;
            document.getElementById("itemTitle").value = this.cells[2].innerHTML;
            document.getElementById("itemDate").value = this.cells[3].innerHTML;
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

            var tableBody = document.getElementById("tableBody");
            

            $("#tableBody tr").remove();

            for (var i = 0; i < json.length; i++) {

                var trId = tableBody.insertRow(i);

                //tdセルの追加
                var tdId = document.createElement("td");

                var button = document.createElement("button");
                var detailButton = document.createElement("button");

                button.innerHTML = "削除 ";
                button.formMethod = "post";
                button.type = "submit";
                button.formAction = 'Board/Delete';
                button.onclick = getitemId();

                trId.appendChild(tdId);
                var cellId = trId.insertCell(0);
                var cellWriter = trId.insertCell(1);
                var cellTitle = trId.insertCell(2);
                var cellDate = trId.insertCell(3);
                var cellDelete = trId.insertCell(4);

                cellTitle.appendChild(detailButton);
                cellDelete.appendChild(button);

                //textContent
                cellId.textContent = json[i].Id;
                cellWriter.textContent = json[i].Writer;

                detailButton.innerHTML = json[i].Title;
                detailButton.className = 'titleOpen';
                detailButton.formMethod = "post";
                detailButton.type = "submit";
                detailButton.formAction = 'Board/Detail';
                detailButton.onclick = getitemId();



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
        "UpdatedDate": Date.value
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

            JSON.parse(r); //文字列をJSONオブジェクトに変換

            $(location).attr("href", "https://localhost:44342/Board");

        }, function (e) {
            alert("error: " + e);
        });
}

function allDeleteJson() {
    
    var allDeleteButton = document.getElementById("button");
    allDeleteButton.type = "submit";
    button.formMethod = "post";
    allDeleteButton.formAction = 'Board/DeleteAll';
}

function updateJson() {

    var id = document.getElementById("id");
    var title = document.getElementById("title");
    var writer = document.getElementById("writer");
    var date = document.getElementById("date");
    var text = document.getElementById("text");

    var requestData = {
        "Id": id.value,
        "Title": title.value,
        "Writer": writer.value,
        "UpdatedDate": date.value,
        "Text": text.value
    }

    var boardUrl = 'Update';
    $.ajax(
        {
            url: boardUrl,
            method: "POST",
            data: requestData,
            headers: {
                'Accept': 'application/json'
            }
        }).then(function (r) {

            JSON.parse(r); //文字列をJSONオブジェクトに変換

            $(location).attr("href", "https://localhost:44342/Board");

        }, function (e) {
            alert("error: " + e);
        });
}
