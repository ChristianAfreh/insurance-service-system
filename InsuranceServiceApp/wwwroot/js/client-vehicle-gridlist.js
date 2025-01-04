


function getDataForClientDataTable(url, method, tableSelector) {

    $(tableSelector).DataTable({
        processing: false, //Disable default "Processing..." message
        serverSide: true,
        ajax: {
            url: url,
            type: method,
            contentType: 'application/json',
            data: function (d) {
                return JSON.stringify(d);
            },
        },

        columns: [
            { data: 'othername', title: 'Othername' },
            { data: 'surname', title: 'Surname' },
            { data: 'cellphone', title: 'Phonenumber' },
            { data: 'email', title: 'Email' },
            { data: 'registrationNo', title: 'Car Plate' },
            { data: 'makeModel', title: 'Car Make/Model' },
            { data: 'zone', title: 'Zone' },
            {
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    //console.log(row);
                    return `<span class="dropdown">
                        <button id="btnSearchDrop2" type="button" data-toggle="dropdown" aria-haspopup="true"
                            aria-expanded="true" class="btn btn-primary dropdown-toggle dropdown-menu-right">
                            <i class="ft-settings"></i>
                        </button>
                        <span aria-labelledby="btnSearchDrop2" class="dropdown-menu mt-1 dropdown-menu-right">
                            <a href="/Client/Detail/${row.clientID}" class="dropdown-item"><i class="la la-eye"></i> View</a>
                            <a href="/Client/Edit/${row.clientID}" class="dropdown-item"><i class="la la-pencil"></i> Edit</a>
                            <a href="/Client/Delete/${row.clientID}" class="dropdown-item"><i class="la la-trash"></i> Delete</a>
                        </span>
                    </span>`;
                }
            }
        ]
    }).on('preXhr.dt', function () {
        //show the loading overlay before the AJAX request
        $('#loadingOverlay').show();
    }).on('xhr.dt', function () {
        //hide the loading overlay after the AJAX request completes
        $('#loadingOverlay').hide();
    });
}