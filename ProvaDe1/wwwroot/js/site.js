function insertFrase() {
    var body = {};
    body.Testo = $('#fraseTesto').val();    
    $.ajax({
        method: "POST",
        url: "/api/Frase/InsertFrase",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
};

function deleteFraseById(id) {
    var body = {};
    body.ID = id;
    $.ajax({
        method: "POST",
        url: "/api/Frase/DeleteFrase",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
            window.location = window.location;
        }
    });
};

function updateFraseById(id) {
    nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'Nome';
    document.getElementById("modal-body").appendChild(nameP);
    nameTextArea = document.createElement("input");
    nameP.appendChild(nameTextArea);    

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.id = "modalOKButton";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.ID = id;
        body.Testo = nameTextArea.value;
        
        $.ajax({
            method: "POST",
            url: "/api/Person/UpdatePerson",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
                window.location = window.location;
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.id = "modalCancelButton";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    document.getElementById("modal").style.display = "block";
};

function hideModal() {
    document.getElementById("modal-header").innerText = "";
    $(".modal-body").empty();
    $(".modal-footer").empty();
    document.getElementById("modal").style.display = "none";
}


