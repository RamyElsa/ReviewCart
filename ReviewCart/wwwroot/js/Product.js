﻿var dtable;
$(document).ready(function () {
   dtable= $('#Table').DataTable({
        "ajax": { "url": "/Admin/Product/AllProducts" },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Admin/Product/CreateUpdate?id=${data}"><i class="fa fa-edit"></i></i></a>
                        <a inclick=RemoveProduct("/Admin/Product/Delete/${data}")><i class="fa fa-trash"></i></i>
                    `
                }
            }
        ]
        });
});

Swal.fire({
    title: 'Are you sure?',
    text: "You won't be able to revert this!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Yes, delete it!'
}).then((result) => {
    if (result.isConfirmed) {
        $.ajax({
            url: url,
            type: 'DELETE',
            success: function (data) {
                if (data.success) {
                    dtable.ajax.reload();
                    toastr.success(data.message);
                }
                else {
                    toastr.error(data.message);
                }
            }
        });

    }
    
});



