using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Aline Sathler Delfino - Assignment 5
//Name of Project: Employee List
//Purpose: C# console application that allows maintains an Employee List
//Revision History:
//REV00 - 2023/11/29 - Initial version, AddEmployee and DisplayEmployees methods

namespace A5SathlerDelfinoA {
    internal class Program {
        //List with all employees
        public static List<EmployeeRecord> employeeRecords = new List<EmployeeRecord>();

        //Method CheckId to check if employee already exists. If yes, it returns the index, if no it returns -1
        static int CheckId(int employeeId) {
            int index = -1;

            for (int i = 0; i < employeeRecords.Count; i++) {
                if (employeeRecords[i].id == employeeId) {
                    index = i;
                }
            }

            return index;
        }

        //Method AddEmployee to add a new employee to the list employeeRecords
        static void AddEmployee() {
            string name;
            int employeeId, salary;
            EmployeeRecord employee;

            employeeId = UserInput.ReadInt("Please, enter the employee unique identifier: "); //Call method ReadInt to read an int

            if (CheckId(employeeId) != -1) { //Call method CheckId to check if employee already exists
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nEmployee already exists.\n"); //Show error message if already exists
                Console.ResetColor(); //Reset color
            } else { //If not, ask for name and salary
                name = UserInput.ReadString("Please, enter the employee name: ");  //Call method ReadInt to read a string
                salary = UserInput.ReadInt("Please, enter the employee monthly salary: ");  //Call method ReadInt to read an int

                employee = new EmployeeRecord(employeeId, name, salary); //Create a new instance of EmployeeRecord
                employeeRecords.Add(employee); //Add employee in the list employeeRecords
            }
        }

        static void DisplayEmployees() {
            if (employeeRecords.Count == 0) { //Check if there is any employee in the list
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nNo employee record exists.\n"); //Show error message for no record
                Console.ResetColor(); //Reset color
            } else {
                Console.WriteLine(EmployeeRecord.DisplayEmployeeInformation(employeeRecords)); //Display list of employees in employeeRecords
            }
        }
        static void Main(string[] args) {
            char menuChoice;

            try {
                do {
                    Console.WriteLine("Welcome to our Employee Record");
                    Console.WriteLine("-------------------------------------");
                    //Call method Menu to read a input as a menu choice (char)
                    menuChoice = UserInput.Menu("A. Add a new Employee\r\nB. Edit Employee Record\r\nC. Display Employess\r\nD. Exit\r\nEnter your choice: ");

                    switch (menuChoice.ToString().ToUpper()) {
                        case "A":
                            Console.Clear(); //Clear console

                            //Call method AddEmployee to add a new employee to the list employeeRecords
                            AddEmployee();
                            break;
                        case "B":
                            break;
                        case "C":
                            Console.Clear(); //Clear console

                            //Call method DisplayEmployees to display all employees in the list employeeRecords
                            DisplayEmployees();
                            break;
                        case "D":
                            Console.WriteLine("\nThe program will be closed now.");
                            break;
                        default:
                            Console.WriteLine("\nInvalid menu, please try again.\n");
                            break;
                    }
                } while (menuChoice.ToString().ToUpper() != "D");
            } catch (FormatException) {
                Console.ResetColor(); //Reset color
                Console.WriteLine("\nInput with invalid format.");
            } finally {
                Console.WriteLine("\nThanks for using our application.");
                Console.ReadKey();
            }
        }
    }
}
