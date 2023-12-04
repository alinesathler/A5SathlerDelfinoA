using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Aline Sathler Delfino - Assignment 5
//Name of Project: Employee List
//Purpose: C# console application that allows maintains an Employee List
//Revision History:
//REV00 - 2023/11/29 - Initial version, AddEmployee and DisplayEmployees methods
//REV01 - 2023/11/29 - Error handling
//REV02 - 2023/11/30 - EditEmployee
//REV03 - 2023/12/02 - Error handling, recall methods
//REV04 - 2023/12/03 - Test cases corrections

namespace A5SathlerDelfinoA {
    internal class Program {
        //List with all employees
        public static List<EmployeeRecord> employeeRecords = new List<EmployeeRecord>();
        static int id;
        static string name;
        static int salary;

        static void AddId() {
            try {
                string input;
                int employeeId;

                input = UserInput.ReadString("\nPlease, enter the new employee unique identifier: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {
                    employeeId = Convert.ToInt32(input);

                    if (EmployeeRecord.CheckId(employeeId) != -1) { //Call method CheckId to check if employee already exists
                        Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                        Console.WriteLine("\nEmployee already exists.\n"); //Show error message if already exists
                        Console.ResetColor(); //Reset color
                    } else {
                        Program.id = employeeId;
                    }
                }
            } catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nInput with invalid format. Let's try again.");
                Console.ResetColor(); //Reset color

                //Call method AddId again
                AddId();
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nSomething went wrong. Let's try again.");
                Console.ResetColor(); //Reset color

                //Call method AddId again
                AddId();
            }
        }

        //Method AddName to add the name of an employee in the list employeeRecords
        public static void AddName() {
            try {
                string input;
                string name;

                input = UserInput.ReadString("Please, enter the new employee name: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {
                    name = input;

                    //Call method CheckName to check if name is empty
                    EmployeeRecord.CheckName(name);

                    Program.name = name;
                }
            } catch (ArgumentNullException ex) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine(ex.ParamName);
                Console.ResetColor(); //Reset color

                //Call method AddName again
                AddName();
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nSomething went wrong. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method AddName again
                AddName();
            }
        }

        //Method AddSalary to add the salary of an employee in the list employeeRecords
        public static void AddSalary() {
            try {
                string input;
                int salary;

                input = UserInput.ReadString("Please, enter the new employee salary: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {

                    salary = Convert.ToInt32(input);

                    //Call method CheckSalary to check if salary is empty
                    EmployeeRecord.CheckSalary(salary);

                    Program.salary = salary;
                }
            } catch (ArgumentOutOfRangeException ex) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine(ex.ParamName);
                Console.ResetColor(); //Reset color

                //Call method AddSalary again
                AddSalary();
            } catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nInput with invalid format. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method AddSalary again
                AddSalary();
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nSomething went wrong. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method AddSalary again
                AddSalary();
            }
        }

        //Method AddEmployee to add a new employee to the list employeeRecords
        static void AddEmployee() {
            EmployeeRecord employee;

            Program.id = 0;
            Program.name = "";
            Program.salary = 0;

            //Call method AddId to add an unique identifier of an employee in the list employeeRecords
            AddId();

            if (Program.id != 0) {
                //Call method AddName to add a name of an employee in the list employeeRecords
                AddName();

                if(Program.name != "") {
                    //Call method AddSalary to add a salary of an employee in the list employeeRecords
                    AddSalary();

                    if (Program.salary != 0) {
                        employee = new EmployeeRecord(Program.id, Program.name, Program.salary); //Create a new instance of EmployeeRecord
                        employeeRecords.Add(employee); //Add employee in the list employeeRecords
                    }
                }
            }
        }

        static void DisplayEmployees() {
            if (employeeRecords.Count == 0) { //Check if there is any employee in the list
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nNo employee record exists.\n"); //Show error message for no record
                Console.ResetColor(); //Reset color
            } else {
                Console.WriteLine(EmployeeRecord.DisplayEmployeeInformation()); //Call DisplayEmployeeInformation to display list of employees in employeeRecords
            }
        }

        static void EditEmployee() {
            if (employeeRecords.Count == 0) { //Check if there is any employee in the list
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nNo employee record exists.\n"); //Show error message for no record
                Console.ResetColor(); //Reset color
            } else {
                EmployeeRecord.EditEmployeeInformation();  //Call EditEmployeeInformation to edit employee in employeeRecords
            }
        }

        static void Main(string[] args) {
            char menuChoice;

            try {
                do {
                    Console.WriteLine("Welcome to our Employee Record");
                    Console.WriteLine("-------------------------------------");

                    //Call method Menu to read a input as a menu choice (char)
                    menuChoice = UserInput.Menu("A. Add a new Employee\r\nB. Edit Employee Record\r\nC. Display Employess\r\nD. Exit\r\n\nEnter your choice: ");

                    switch (menuChoice.ToString().ToUpper()) {
                        case "A":
                            //Call method AddEmployee to add a new employee to the list employeeRecords
                            AddEmployee();
                            Console.ReadKey();
                            Console.Clear(); //Clear console
                            break;
                        case "B":
                            //Call method EditEmployee to edit an employee in the list employeeRecords
                            EditEmployee();
                            Console.ReadKey();
                            Console.Clear(); //Clear console
                            break;
                        case "C":
                            //Call method DisplayEmployees to display all employees in the list employeeRecords
                            DisplayEmployees();
                            Console.ReadKey();
                            Console.Clear(); //Clear console
                            break;
                        case "D":
                            Console.WriteLine("\nThe program will be closed now.");
                            break;
                        default:
                            Console.WriteLine("\nInvalid menu, please try again.\n");
                            break;
                    }
                } while (menuChoice.ToString().ToUpper() != "D");
            } catch (ArgumentNullException ex) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine(ex.ParamName);
                Console.ResetColor(); //Reset color
            } catch (IndexOutOfRangeException) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nInput cannot be empty");
                Console.ResetColor(); //Reset color
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nSomething went wrong.");
                Console.ResetColor(); //Reset color
            } finally {
                Console.WriteLine("\nThanks for using our application.");
                Console.ReadKey();
            }
        }
    }
}
