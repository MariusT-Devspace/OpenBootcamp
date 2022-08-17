using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * of cars
            var carList = from car in cars select car;
            
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;
            
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each number multiplied by 3
            // take all numbers, but 9
            // Order numbers by ascending value

            var processedNumberList = numbers
                .Select(x => x * 3) 
                .Where(x => x != 9)
                .OrderBy(x => x);
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First element
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. Last element that contains "z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single values
            var uniqueTexts = textList.Single();
            var uniqueOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martín",
                            Email = "martin@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 1,
                            Name = "Pepe",
                            Email = "pepe@imaginagroup.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 1,
                            Name = "Juanjo",
                            Email = "juanjo@imaginagroup.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@imaginagroup.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@imaginagroup.com",
                            Salary = 4000
                        }
                    }
                }
            };

            // Obtain all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if ana list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployee = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All enterprises employees with at least 1000€ of salary
            bool hasEmployeeWithSalaryMoreOrEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));
        }
        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGHT
            var righttOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // UNION 
            var unionList = leftOuterJoin.Union(righttOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                };

            // SKIP
            var skipFirstTwoValues = myList.Skip(2); // { 3, 4, 5, 6, 7, 8, 9, 10 }
            var skipLastTwoValues = myList.SkipLast(2); // { 1, 2, 3, 4, 5, 6, 7, 8 }
            var skipWhile = myList.SkipWhile(n => n < 4); // { 5, 6, 7, 8, 9, 10 }

            // TAKE
            var takeFirstTwoValues = myList.Take(2); // { 1, 2 }
            var takeLastTwoValues = myList.TakeLast(2); // { 9, 10 }
            var takeWhileSmallerThan4 = myList.TakeWhile(n => n < 4); // { 1, 2, 3, 4 }
        }   
    }
}