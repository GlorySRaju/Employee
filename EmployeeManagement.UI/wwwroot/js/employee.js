$(document).ready(function () {
    displayEmployee();
});

function displayEmployee() {
    $(".employeeDetails").on("click", function (event) {

        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:6001/api/employees/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#displayname").html("<br><br><b>NAME:</b>  "+result.name);
                $("#displaydepartment").html("<b>DEPARTMENT:</b>   "+result.department);
                $("#displayage").html("<b>AGE:</b>    "+result.age);
                $("#displayaddress").html("<b>ADDRESS:</b>   "+result.address);
            },
            error: function (error) {
                console.log(error);
            }
        });

    });


    $("#createform").submit(function (event) {


        var employeeDetailedView = {};

        employeeDetailedView.Name = $("#name").val();
        employeeDetailedView.Department = $("#department").val();
        employeeDetailedView.Age = Number($("#age").val());
        employeeDetailedView.Address = $("#address").val();

        var data = JSON.stringify(employeeDetailedView);

        $.ajax({
            url: 'https://localhost:6001/api/employees',
            type: 'POST',
            datatype: "application/json; charset=utf-8 ",
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload();
            },

            error: function (error) {
                console.log(error);
            }
        });

        alert("INSERTED SUCCESSFULLY");

    });


    $(".employeeEdit").on("click", function (event) {

        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:6001/api/employees/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#updatename").val(result.name)
                $("#updatedepartment").val(result.department)
                $("#updateage").val(result.age)
                $("#updateaddress").val(result.address)
            },
            error: function (error) {
                console.log(error);
            }
        });

   
        $("#updateform").submit(function (event) {

        var employeeDetailedView = {};

        employeeDetailedView.Name = $("#updatename").val();
        employeeDetailedView.Department = $("#updatedepartment").val();
        employeeDetailedView.Age = Number($("#updateage").val());
        employeeDetailedView.Address = $("#updateaddress").val();

        var data = JSON.stringify(employeeDetailedView);

        $.ajax({
            url: 'https://localhost:6001/api/employees/' + employeeId,
            type: 'PUT',
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload();
            },

            error: function (error) {
                console.log(error);
            }
        });
        alert("UPDATED SUCCESSFULLY");

        });
    });


    $(".employeeDelete").on("click", function (event) {

        var employeeId = event.currentTarget.getAttribute("data-id");

        var confirmbutton = confirm("ARE YOU SURE TO CONFIRM DELETE");

        if (confirmbutton) {
            $.ajax({
                url: 'https://localhost:6001/api/employees/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    location.reload();
                },

                error: function (error) {
                    console.log(error);
                }
            });

            alert("DELETED SUCCESSFULLY");
        }
    });
}
