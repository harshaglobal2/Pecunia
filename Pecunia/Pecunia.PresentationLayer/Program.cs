using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.Exceptions;
using Pecunia.Entities;
using Pecunia.BusinessLayer;

namespace Pecunia.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice,choiceAdmin,choiceEmployee;
            do
            {
                PrintSelectionList();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AdminLogIn();
                        choiceAdmin = Convert.ToInt32(Console.ReadLine());
                        switch (choiceAdmin)
                        {
                            case 1:
                                AddEmployee();
                                break;
                            case 2:
                                GetAllEmployees();
                                break;
                            case 3:
                                SearchEmployee();
                                break;
                            case 4:
                                GetEmployeesByName();
                                break;
                            case 5:
                                UpdateEmployee();
                                break;
                            case 6:
                                DeleteEmployee();
                                break;
                            case 7:
                                ViewCustomerDetails();
                                break;
                            case 8:
                                ApproveLoan();
                                break;
                            case 9:
                                ViewTransactionReport();
                                break;
                            case 10:
                                return;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case 2:
                        EmployeeLogIn();
                        choiceEmployee = Convert.ToInt32(Console.ReadLine());
                        switch (choiceEmployee)
                        {
                            case 1:
                                //Customer
                                break;
                            case 2:
                                //Transaction
                                break;
                            case 3:
                                //Loan
                                break;
                            case 4:
                                //Account
                                break;
                            case 5:
                                return;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            }
            while (choice != -1);
        }

        private static void AdminLogIn()
        {
            Console.WriteLine("Enter Admin ID and Password to log in");
            try
            {
                Admin admin = new Admin();
                Console.WriteLine("Enter Admin Id");
                admin.AdminID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Password");
                admin.AdminPassword = Console.ReadLine();

                bool adminLoggedin = AdminBL.AdminLogInBL(admin);
                if (adminLoggedin)
                    Console.WriteLine("Admin Logged In");
                else
                    Console.WriteLine("Admin not Logged In");
            }
            catch (PecuniaException)
            {

                Console.WriteLine("Cannot Login");
            }
        }

        private static void EmployeeLogIn()
        {
            Console.WriteLine("Enter Employee ID, Password and Employee Code to log in");
            try
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter Employee Id");
                employee.EmployeeID = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                employee.EmployeePassword = Console.ReadLine();
                Console.WriteLine("Enter Employee Code");
                employee.EmployeeCode = Console.ReadLine();

                bool employeeLoggedin = EmployeeBL.EmployeeLogInBL(employee);
                if (employeeLoggedin)
                    Console.WriteLine("Employee Logged In");
                else
                    Console.WriteLine("Employee not Logged In");
            }
            catch (PecuniaException)
            {

                Console.WriteLine("Cannot Login");
            }
        }

        private static void AddEmployee()
        {
            try
            {
                Employee newEmployee = new Employee();
                Console.WriteLine("Enter Employee Name");
                newEmployee.EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter Employee Email");
                newEmployee.EmployeeEmail = Console.ReadLine();
                Console.WriteLine("Enter Employee Password");
                newEmployee.EmployeePassword = Console.ReadLine();
                Console.WriteLine("Enter Employee Mobile");
                newEmployee.EmployeeMobile = Console.ReadLine();

                bool employeeAdded = EmployeeBL.AddEmployeeBL(newEmployee);
                if (employeeAdded)
                    Console.WriteLine("Employee Added");
                else
                    Console.WriteLine("Employee not Added");

            }
            catch (PecuniaException)
            {
                Console.WriteLine("Employee cannot be added");
            }
        }

        private static void GetAllEmployees()
        {
            try
            {
                List<IEmployee> employeeList = EmployeeBL.GetAllEmployeesBL();
            }
            catch (PecuniaException)
            {

                Console.WriteLine("Employee List cannot be shown");
            }
        }

        private static void SearchEmployee()
        {
            try
            {
                string searchEmployeeID;
                Console.WriteLine("Enter Employee ID to Search:");
                searchEmployeeID = Console.ReadLine();
                Employee searchEmployee = EmployeeBL.SearchEmployeeBL(searchEmployeeID);
                if (searchEmployee != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("EmployeeID\t\tName\t\tEmail\t\tMobile");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", searchEmployee.EmployeeID, searchEmployee.EmployeeName, searchEmployee.EmployeeEmail, searchEmployee.EmployeeMobile);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (PecuniaException)
            {

                Console.WriteLine("Employee details cannot be shown");
            }
        }

        private static void GetEmployeesByName()
        {
            List<Employee> employeeList = new List<Employee>();
            try
            {
                string searchEmployeeName;
                Console.WriteLine("Enter Employee Name to search");
                searchEmployeeName = Console.ReadLine();
                employeeList = EmployeeBL.GetEmployeesByNameBL(searchEmployeeName);
                foreach(Employee item in employeeList)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("EmployeeID\t\tName\t\tEmail\t\tMobile");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}",item.EmployeeID,item.EmployeeName, item.EmployeeEmail, item.EmployeeMobile);
                    Console.WriteLine("******************************************************************************");
                }
            }
            catch (PecuniaException)
            {

                Console.WriteLine("Employee list cannot be shown");
            }            
        }

        private static void UpdateEmployee()
        {
            try
            {
                string updateEmployeeID;
                Console.WriteLine("Enter EmployeeID to Update Details:");
                updateEmployeeID = Console.ReadLine();
                Employee updatedEmployee = EmployeeBL.UpdateEmployeeBL(updateEmployeeID);
                if (updatedEmployee != null)
                {
                    Console.WriteLine("Update Employee Name :");
                    updatedEmployee.EmployeeName = Console.ReadLine();
                    Console.WriteLine("Update Email :");
                    updatedEmployee.EmployeeEmail = Console.ReadLine();
                    Console.WriteLine("Update Password : ");
                    updatedEmployee.EmployeePassword = Console.ReadLine();
                    Console.WriteLine("Update Mobile");
                    updatedEmployee.EmployeeMobile = Console.ReadLine();
                    bool employeeUpdated = EmployeeBL.UpdateEmployeeBL(updatedEmployee);
                    if (employeeUpdated)
                        Console.WriteLine("Employee Details Updated");
                    else
                        Console.WriteLine("Employee Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (PecuniaException)
            {
                Console.WriteLine("Employee Details cannot be updated");
            }           
        }

        private static void DeleteEmployee()
        {
            try
            {
                string deleteEmployeeID;
                Console.WriteLine("Enter Employee ID to delete:");
                deleteEmployeeID = Console.ReadLine();
                Employee deleteEmployee = EmployeeBL.SearchEmployeeBL(deleteEmployeeID);
                if (deleteEmployee != null)
                {
                    bool employeeDeleted = EmployeeBL.DeleteEmployeeBL(deleteEmployeeID);
                    if (employeeDeleted)
                        Console.WriteLine("Employee Deleted");
                    else
                        Console.WriteLine("Employee not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Employee Details Available");
                }
            }
            catch (PecuniaException)
            {
                Console.WriteLine("Employee could not be deleted");
            }
        }

        private static void ViewCustomerDetails()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ApproveLoan()
        {
            try
            {
                string loanID;
                Console.WriteLine("Enter LoanID to Approve");
                loanID = Console.ReadLine();
                if (loanID.Contains("EDU"))
                {
                    EduLoan eduLoan = new EduLoan();
                    
                }
                if (loanID.Contains("HOME"))
                {

                }
                if (loanID.Contains("CAR"))
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ViewTransactionReport()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void PrintSelectionList()
        {
            Console.WriteLine("************Admin/Employee**************");
            Console.WriteLine("1.Admin Log In");
            Console.WriteLine("2.Employee Log In");
            Console.WriteLine("3.Exit");
           


            Console.WriteLine("********************************\n");
        }
    }
}
