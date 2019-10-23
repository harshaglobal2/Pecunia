var employees = [
    { empID: 101, empName: "Scott", salary: 5000 },
    { empID: 102, empName: "Smith", salary: 6540 },
    { empID: 103, empName: "Allen", salary: 9400 },
    { empID: 104, empName: "Jones", salary: 2240 }
];

$(document).ready(function ()
{
    for (let emp of employees)
    {
        var htmlString = `<tr> 
        <td>${emp.empID}</td> 
        <td>${emp.empName}</td> 
        <td>${emp.salary}</td>
        <td><button type="button" class='editbtn'>Edit</button></td>
    </tr>`;
        $("#employeesTbody").append(htmlString);
    }
});

$(document).on("click", '.editbtn', function (event)
{
    var currentTr = $(event.target).parent().parent();
    var currentEmpID = currentTr.find("td:first").html();

    var emp = employees.filter(function (e)
    {
        return e.empID == currentEmpID;
    });
    //console.log(emp[0].empID);
    //console.log(emp[0].empName);
    //console.log(emp[0].salary);

    $("#txtEmpID").val(emp[0].empID);
    $("#txtEmpName").val(emp[0].empName);
    $("#txtSalary").val(emp[0].salary);
});
