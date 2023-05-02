/*=============================================
UPDATE PRODUCT
=============================================*/
const URL = "https://localhost:5001/api/product";
$(".tables").on("click", ".editProduct", function () {
    var theid = $(this).attr("theid");
    $.ajax(URL + "/" + theid)
        .done(function (data) {
            console.log(data);
            setInput(data);
        })
        .fail(function (error) {
            // handleAjaxError(error);
            console.log("Product Not Found");
        })
       
})
function updateProduct() {

    let product = getFromInput();

    $.ajax({
        url: URL + "/" + product.Id,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(product)
    })
        .done(function (data) {
            console.log("Product Updated");
            console.log(data);
            location.reload();
        })
        .fail(function (error) {
            console.log(error);
        })
        .always(function () {

        });
}

// function LoginRefresh() {

//     $.ajax({
//         url: "https://localhost:44347/api/roles",
//         type: "POST",
//         contentType: "application/json",
//     })
//         .always(function () {
//             location.reload();
//         });
// }

/*=============================================
DELETE PRODUCT
=============================================*/
$(".tables").on("click", ".deleteProduct", function () {

    var theid = $(this).attr("theid");

    if (confirm("Do you want to Delete this Product?") == true) {
       
        $.ajax({
            url: URL + "/" + theid,
            type: "DELETE"
        })
            .done(function (data) {
                location.reload();
            })
            .fail(function (error) {
                console.log(error);
            })
           
    } else {
        console.log("FAILED");
        
    }
})
/*=============================================
ADD PRODUCT
=============================================*/
function insertProduct() {      

    let productz = getFromInputforPost();
    console.log(productz)

    $.ajax({
        url: URL,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(productz)
    })
        .done(function (data) {
            console.log("Product ADDED");
            console.log(data);
           // location.reload();
        })
        .fail(function (error) {
            console.log(data);
            
        })
        .always(function () {
            console.log(productz);
        });
}


//var dataTable;

// $(document).ready(function () {
//     loadDataTable();
// });

// function loadDataTable() {

//     dataTable = $('#tblData').DataTable({

//         "ajax": {
//             "url": 'http://localhost:5000/api/product',
//             "type": "GET",
//             "datatype": "json"
            
//         },

//         "columns": [
//              { "data": "Id" },
//              { "data": "Name" },
//              { "data": "Price" },
//              { "data": "CategoryId" },
//              { "data": "Unit" },
//              { "data": "Brand" },
//              { "data": "Image" },
//              {
//                  "data": "ProductID",
//                  "render": function (data) {
//                      return ` <div class="d-flex align-items-center list-action">
//          <button class="badge bg-success mr-2 editProduct" theid="${data}" data-toggle="modal" data-target="#editProducts"><i class="ri-eye-line mr-0"></i></button>
//          <button class="badge bg-warning mr-2 deleteProduct" theid="${data}" ><i class="fa fa-times"></i></button>
//           </div>`;

//                  }
//              }

//         ],
//     });
  
// }

