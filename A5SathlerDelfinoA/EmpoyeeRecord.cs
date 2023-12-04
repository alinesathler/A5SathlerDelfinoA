using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5SathlerDelfinoA {
    //Class to handle employee information
    internal class EmployeeRecord {
        private int id;
        private string name;
        private int salary;

        //Default Constructor
        public EmployeeRecord() {
            id = 0;
            name = string.Empty;
            salary = 0;

            Console.ForegroundColor = ConsoleColor.Green;   //Change color to green
            Console.WriteLine("\nNew employee added.\n");
            Console.ResetColor(); //Reset color
        }

        //Overloaded  Contructor
        public EmployeeRecord(int id, string name, int salary) {
            this.id = id;
            this.name = name;
            this.salary = salary;

            Console.ForegroundColor = ConsoleColor.Green;   //Change color to green
            Console.WriteLine("\nNew employee added.\n");
            Console.ResetColor(); //Reset color
        }

        //Auxiliar Methods

        //Overrride ToString
        public override string ToString() {
            return $"ID: {this.id}, Name: {this.name}, Salary: {this.salary}";
        }

        //Method CheckId to check if employee already exists. If yes, it returns the index, if no it returns -1
        public static int CheckId(int employeeId) {
            int index = -1;

            for (int i = 0; i < Program.employeeRecords.Count; i++) {
                if (Program.employeeRecords[i].id == employeeId) {
                    index = i;
                }
            }

            return index;
        }

        //Method CheckName to check if name is empty
        public static void CheckName(string name) {
            if (string.IsNullOrEmpty(name)) { //If name is empty, throw error
                throw new ArgumentNullException("\nThe input cannot be empty. Let's try again.\n");
            }
        }

        //Method CheckSalary to check if salary is negative or equal to 0
        public static void CheckSalary(int salary) {
            if (salary <= 0) { //If salary is invalid, throw error
                throw new ArgumentOutOfRangeException("\nSalary cannot be negative or equal to 0. Let's try again.\n");
            }
        }

        //Method EditId to edit the unique identifier of an employee in the list employeeRecords
        static void EditId(int index) {
            try {
                string input;
                int employeeId;

                input = UserInput.ReadString("\nPlease, enter the employee new unique identifier: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {
                    employeeId = Convert.ToInt32(input);

                    if (CheckId(employeeId) != -1) { //Call method CheckId to check if employee already exists
                        Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                        Console.WriteLine("\nEmployee already exists.\n"); //Show error message if already exists
                        Console.ResetColor(); //Reset color
                    } else {
                        Program.employeeRecords[index].id = employeeId; //Change the unique identifier

                        //Confirmation
                        Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                        Console.WriteLine("\nThe unique identifier of the employee has been changed.");
                        Console.ResetColor();   //Reset color
                    }
                }
            } catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nInput with invalid format. Let's try again.");
                Console.ResetColor(); //Reset color

                //Call method EditId again
                EditId(index);
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nSomething went wrong. Let's try again.");
                Console.ResetColor(); //Reset color

                //Call method EditId again
                EditId(index);
            }
        }

        //Method EditName to edit the name of an employee in the list employeeRecords
        static void EditName(int index) {
            try {
                string input;
                string name;

                input = UserInput.ReadString("Please, enter the new employee name: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {
                    name = input;

                    //Call method CheckName to check if name is empty
                    CheckName(name);

                    Program.employeeRecords[index].name = name; //Change name

                    //Confirmation
                    Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                    Console.WriteLine("\nThe name of the employee has been changed.");
                    Console.ResetColor();   //Reset color
                }
            } catch (ArgumentNullException ex) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine(ex.ParamName);
                Console.ResetColor(); //Reset color

                //Call method EditName again
                EditName(index);
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("Something went wrong. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method EditName again
                EditName(index);
            }
        }

        //Method EditSalary to edit the salary of an employee in the list employeeRecords
        static void EditSalary(int index) {
            try {
                string input;
                int salary;

                input = UserInput.ReadString("Please, enter the new employee salary: ");  //Call method ReadString to read a string

                //Check if input is quit if yes, return to main menu if no, continue the program
                if (!UserInput.Quit(input)) {

                    salary = Convert.ToInt32(input);

                    //Call method CheckSalary to check if salary is empty
                    CheckSalary(salary);

                    Program.employeeRecords[index].salary = salary; //Change salary

                    //Confirmation
                    Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                    Console.WriteLine("\nThe salary of the employee has been changed.");
                    Console.ResetColor();   //Reset color
                }
            } catch (ArgumentOutOfRangeException ex) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine(ex.ParamName);
                Console.ResetColor(); //Reset color

                //Call method EditSalary again
                EditSalary(index);
            } catch (FormatException) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("\nInput with invalid format. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method EditSalary again
                EditSalary(index);
            } catch (Exception) {
                Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                Console.WriteLine("Something went wrong. Let's try again.\n");
                Console.ResetColor(); //Reset color

                //Call method EditSalary again
                EditSalary(index);
            }
        }

        //Main methods

        //Method DisplayEmployeeInformation to display the information of all employess in the list employeeRecords
        public static string DisplayEmployeeInformation() {
            string information = "\n";

            foreach (EmployeeRecord employee in Program.employeeRecords) {
                information += employee.ToString() + "\n";
            }

            return information;
        }

        //Method EditEmployee to edit an employee in the list employeeRecords
        public static void EditEmployeeInformation() {
            string input;
            int employeeId, index;
            char menuChoice;

            Console.WriteLine(DisplayEmployeeInformation()); //Display the full list of employees

            input = UserInput.ReadString("Please, enter the employee unique identifier you would like to edit: ");  //Call method ReadString to read a string

            //Check if input is quit if yes, return to main menu if no, continue the program
            if (!UserInput.Quit(input)) {
                employeeId = Convert.ToInt32(input);

                //Call method CheckId to check if employee already exists
                index = CheckId(employeeId);

                if (index == -1) {
                    Console.ForegroundColor = ConsoleColor.Red; //Change color to red
                    Console.WriteLine("\nEmployee not found. Please try again.\n"); //Show error message if employee not found
                    Console.ResetColor(); //Reset color

                    EditEmployeeInformation();
                } else { //If found, display enployee data and ask which information they want to edit
                    do {
                        Console.WriteLine($"\n{Program.employeeRecords[index].ToString()}"); //Display enployee data

                        //Call method Menu to read a input as a menu choice (char)
                        menuChoice = UserInput.Menu("\nA. Edit Employee Identifier\r\nB. Edit Employee Name\r\nC. Edit Employee Salary\r\nD. Exit\r\n\nEnter your choice: ");

                        switch (menuChoice.ToString().ToUpper()) {
                            case "A":
                                //Call method EditId to edit employee unique identifier in the list employeeRecords
                                EditId(index);
                                Console.ReadKey();
                                Console.Clear(); //Clear console
                                break;
                            case "B":
                                //Call method EditName to edit employee name in the list employeeRecords
                                EditName(index);
                                Console.ReadKey();
                                Console.Clear(); //Clear console
                                break;
                            case "C":
                                //Call method EditSalary to edit employee salary in the list employeeRecords
                                EditSalary(index);
                                Console.ReadKey();
                                Console.Clear(); //Clear console
                                break;
                            case "D":
                                Console.WriteLine("\nYou're leaving edition menu.\n");
                                break;
                            default:
                                Console.WriteLine("\nInvalid menu, please try again.\n");
                                break;
                        }
                    } while (menuChoice.ToString().ToUpper() != "D");
                }
            }
        }
    }
}
