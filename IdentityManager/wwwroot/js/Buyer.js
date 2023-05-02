/*=============================================
ADD PRODUCT
=============================================*/
function insertBuyer() {    
    const URL = "https://localhost:5001/api/buyer";  

    let buyer = getbuyerInfo();
    console.log(buyer)

    $.ajax({
        url: URL,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(buyer)
    })
        .done(function (data) {
            console.log("buyer ADDED");
            console.log(data);
            Swal.fire({
                icon: 'success',
                title: 'Request Submitted Successfully, Wait for Text Message',
                showConfirmButton: true,
                timer: 1500
            });
           // location.reload();
        })
        .fail(function (error) {
            console.log(data);
            
        })
        .always(function () {
            console.log(buyer);
        });
}
