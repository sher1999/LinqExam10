using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
    class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
    class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }

    }

    class CustomerDto{
         public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            void Task1()
            {
                int x;
                x = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[x];
                for (int i = 0; i < x; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                var test = from n in numbers
                            where n > 10
                            select n;
                foreach (var n in test)
                    Console.Write(n+" ");
            }
          
            int Task2()
            {
                int x;
                x = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[x];
                for (int i = 0; i < x; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                var test = (from n in numbers
                           where n % 2 != 0
                           select n).Sum();
                return test;
               
            }
         
            void Task3()
            {
                string[] names = { "Alice", "Anny", "Amy", "Dave", "Alex" };

                var test = from n in names
                            where n.ToUpper().StartsWith("A") && n.ToUpper().EndsWith("A")
                            select n;              
                foreach (var n in test)
                    Console.WriteLine(n);

            }

            void Task4()
            {
                int x;
                x = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[x];
                for (int i = 0; i < x; i++)
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                }
                var test = (from n in numbers
                            orderby n descending
                            select n).Take(3);

                foreach (var n in test)
                    Console.Write(n + " ");
            }
            
            void Task5()
            {
                string[] words = { "apple", "banana", "cherry", "date", "elderberry" };
                var test = (from n in words
                            orderby n descending
                            select n);

                foreach (var n in test)
                    Console.Write(n + " ");
            }

            void Task6()
            {
                List<Employee> employees = new List<Employee>
{
new Employee { Name = "Alice", Department = "Sales", Salary = 50000
},
new Employee { Name = "Bob", Department = "IT", Salary = 60000 },
new Employee { Name = "Charlie", Department = "Sales", Salary =
55000 },
new Employee { Name = "Dave", Department = "IT", Salary = 65000 },
new Employee { Name = "Eve", Department = "HR", Salary = 45000 }
};
                var group = from emp in employees
                            group emp by emp.Department into g
                            select new
                            {
                                Department = g.Key,
                                Salary = g.Average(x => x.Salary),
                                Name = from n in g select n.Name
                            };
                foreach (var t in group)
                {
                    Console.WriteLine($"{t.Department}");
                    foreach (var em in t.Name)
                    {
                        Console.WriteLine($"{em} = {t.Salary}"  );
                    }
                    Console.WriteLine();
                }
                }
           
            void Task7()
            {
                List<Person> people = new List<Person>
                {
                    new Person { Name = "Alice", Age = 20 },
                    new Person { Name = "Bob", Age = 30 },
                    new Person { Name = "Charlie", Age = 20 },
                    new Person { Name = "Dave", Age = 30 },
                    new Person { Name = "Eve", Age = 20 }
                };

                var group = (from p in people
                             group p by p.Age);
                foreach (var age in group)
                {
                    Console.WriteLine(age.Key);

                    foreach (var p in age)
                    {
                        Console.WriteLine(p.Name );
                    }
                    Console.WriteLine();


                }

            }
        
            void Task8()
            {

                var customers = new List<Customer>
{
new Customer { Id = 1, Name = "Alice" },
new Customer { Id = 2, Name = "Bob" },
new Customer { Id = 3, Name = "Charlie" },
};
                var orders = new List<Order>
{
new Order { Id = 1, CustomerId = 1, Amount = 10 },
new Order { Id = 2, CustomerId = 2, Amount = 20 },
new Order { Id = 3, CustomerId = 1, Amount = 30 },
new Order { Id = 4, CustomerId = 3, Amount = 40 },
new Order { Id = 5, CustomerId = 2, Amount = 50 },
new Order { Id = 6, CustomerId = 1, Amount = 60 },
};

                var customerOrderSums = from o in orders
                                        join c in customers
                                        on o.CustomerId equals c.Id
                                        group o by c.Name into g
                                        orderby g.Sum(o => o.Amount) descending
                                        select new 
                                        {
                                           
                                           CustomerName = g.Key,
                                           TotalAmount = g.Sum(o => o.Amount)
                                        };
                int cnt = 0;
                foreach (var item in customerOrderSums)
                {
                    Console.WriteLine(item);
                    cnt++;
                    if (cnt == 2)
                        return;
                }
            }


        }
    }
}
