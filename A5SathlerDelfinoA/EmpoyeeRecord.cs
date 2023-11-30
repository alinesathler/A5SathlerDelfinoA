using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5SathlerDelfinoA {
    //Class to handle employee information
    internal class EmployeeRecord {
        public int id;
        private string name;
        private int salary;

        //Default Constructor
        public EmployeeRecord() {
            id = 0;
            name = string.Empty;
            salary = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nNew employee added.\n");
            Console.ResetColor();
        }

        //Non-default  Contructor
        public EmployeeRecord(int id, string name, int salary) {
            this.id = id;
            this.name = name;
            this.salary = salary;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nNew employee added.\n");
            Console.ResetColor(); //Reset color
        }

        public static string DisplayEmployeeInformation(List<EmployeeRecord> employeeRecords) {
            string information = "";

            foreach (EmployeeRecord employee in employeeRecords) {
                information += $"Name: {employee.name}, Salary: {employee.salary}\n";
            }

            return information;
        }

        //public string EditEmployeeInformation(List<EmployeeRecord> employeeRecords) {
        //    int employeeId = UserInput.ReadInt("Please, enter the unique identifier: ");

        //    for (int i = 0; i < employeeRecords.Count; i++) {
        //        if (employeeRecords.id[i] == employeeId) {

        //        }
        //    }

        //    return;
        //}
    }
}
