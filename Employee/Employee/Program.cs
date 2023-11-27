
//namespace EmployeeDetails
//{

//    class Employee
//    {
//        private string fname;
//        string lname;
//        bool isAdult;
//        int yob;
//        public void setFname(string fname)
//        {
//            this.fname = fname;
//        }
//        public void setLname(string lname)
//        {
//            this.lname = lname;
//        }
//        public void setYob(int yob)
//        {
//            this.yob = yob;
//        }

//        private int calcAge()
//        {
//            return 2023 - this.yob;
//        }

//        private bool setIsAdult()
//        {
//            if (this.calcAge() > 18)
//            {
//                this.isAdult = true;
//            }
//            else
//            { this.isAdult = false; }

//            return this.isAdult;
//        }

//        public void getEmployeeDetails()
//        {
//            this.setIsAdult();
//            Console.WriteLine("Fullname: {0} {1}", this.fname, this.lname);
//            Console.WriteLine("Is Adult: {0}", this.isAdult);
//        }
//        public string getEmployeeDetails(string filter)
//        {
//            return "Fullname: " + this.fname + " " + this.lname;
//        }
//        public string getEmployeeDetails(int filter)
//        {
//            this.yob = filter;
//            return "Age: " + this.calcAge();

//        }
//    }

//    class Program
//    {
//        private static void Main(string[] args)
//        {
//            Employee e = new Employee();
//            e.setFname("Parag");
//            e.setLname("Joshi");
//            e.setYob(1985);
//            e.getEmployeeDetails();
//            Console.WriteLine(e.getEmployeeDetails("Name"));
//            Console.WriteLine(e.getEmployeeDetails(2000));

//        }
//    }

//}