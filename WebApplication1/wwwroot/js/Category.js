var dataTable;

$(document).ready(function () {
    loadTable();
});

function Delete(id) {
    var url = "/Admin/Category/Delete/" + id;

    swal({
        title: "Delete operation",
        text: "Estas seguro que quiere borrar este registro?",
        icon: "warning",
        buttons: true
    })
        .then((deleted) => {
            if (deleted) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (result) {
                        if (result.success) {
                            toastr.success(result.message);
                        } else {
                            toastr.error(result.message);
                        }
                        dataTable.ajax.reload();
                    }
                });
            }
        })
}

function loadTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `

                        <div class="text-center">
                            <a href="/Admin/Category/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
                            </a>

                            <a onClick=Delete(${data}) class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i>
                            </a>
                        </div>


`;
                },
                "width": "40%"
            }
        ]
    })
}