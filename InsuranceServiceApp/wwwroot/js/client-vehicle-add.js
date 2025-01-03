

$(document).ready(function () {
    $('#client-vehicle-form').on('submit', function (event) {
        event.preventDefault(); // prevent default form submission

        let redirectUrl = `${window.baseUrl}Client/Index`;

        let formEl = $('#client-vehicle-form');

        let formData = formEl.serialize();
        //console.log(formData);

        let url = `${window.baseUrl}Client/AddClient`;
        //alert('Form submitted');

        if (!url || !formData) {
            toastr.error("Invalid form submission data.", "Error");
            return;
        }

        $.ajax({
            url: url,
            method: formEl.attr('method'),
            data: formData,
            success: function (response) {
                if (response.success) {
                    toastr.success(`${response.message}`, 'Success');

                    // Delay the redirect to allow time for the message to be visible
                    setTimeout(() => {
                            window.location.href = redirectUrl;
                    }, 3000); // Adjust the delay time as needed (e.g., 3000ms = 3 seconds)
                    
                }
                else {
                    toastr.error(`${response.message}`,'Error');
                }

            },
            error: function (xhr, status, error) {
                let errorMessage = xhr.responseJSON?.message || error || "An unexpected error occurred.";
                toastr.error(`Error ${xhr.status}: ${errorMessage}`, "Error");
                console.error(`Error details: ${status} - ${error}`);
            }
        });
    });


    $('#cancel-button').on('click', function () {
        history.back();
    });
});