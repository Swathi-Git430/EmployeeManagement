$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});

function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:6001/api/internal/employee/get-employees/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $(".employeeDelete").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");
        var response = confirm('ARE YOU SURE WANT TO DELETE THE EMPLOYEE!!!')
        if (response) {
            $.ajax({
                url: 'https://localhost:6001/api/internal/employee/delete/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {                   
                    location.reload();
                },
                error: function (error) {
                    console.log(error);
                }
            });
            alert("Deleted Successfully")
        }
        else {
            alert("Deletion cancelled successfully")
        }
    });

    $("#createform").submit(function (event) {

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Name = $("#name").val();
        employeeDetailedViewModel.Department = $("#dept").val();
        employeeDetailedViewModel.Age = Number($("#age").val());
        employeeDetailedViewModel.Address = $("#address").val();

        var data = JSON.stringify(employeeDetailedViewModel);

        $.ajax({
            url: 'https://localhost:6001/api/internal/employee/insert',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {

                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $("#updateform").submit(function (event) {

        var employeeDetailedViewModel = {};

        employeeDetailedViewModel.Id = Number$("#updateId").val();
        employeeDetailedViewModel.Name = $("#updateName").val();
        employeeDetailedViewModel.Department = $("#updateDept").val();
        employeeDetailedViewModel.Age = Number($("#updateAge").val());
        employeeDetailedViewModel.Address = $("#updateAddress").val();

        var data = JSON.stringify(employeeDetailedViewModel);

        $.ajax({
            url: "https://localhost:6001/api/internal/employee/update",
            type: 'PUT',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {

                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });    
}



function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();
}
