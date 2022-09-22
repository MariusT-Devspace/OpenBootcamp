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

            // 1. SELECT * from cars
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

            // Know if any list is empty
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

        // Paging with Skip & Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables
        static public void LinqVariable()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine($"Average: {numbers.Average()}");

            foreach (int number in aboveAverage)
            {
                Console.WriteLine($"Query Number: {number} Square: {Math.Pow(number, 2)}");
            }
        }

        // ZIP 
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word); 
            // { "1=one", "2=two", ...}
        }

        // Repeat & Range
        static public void repeatRangeLinq()
        {
            // Range - Generate collection from 1 - 1000
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N times
            IEnumerable<string> fiveX = Enumerable.Repeat("X", 5); // { "X", "X", "X", "X", "X" }
        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Name = "Martín",
                    Id = 1,
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Name = "Juan",
                    Id = 2,
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Name = "Ana",
                    Id = 3,
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Name = "Álvaro",
                    Id = 4,
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Name = "Pedro",
                    Id = 5,
                    Grade = 50,
                    Certified = true
                }

            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var approvedStudentsNames = from student in classRoom
                                   where student.Grade >= 50 && student.Certified
                                   select student.Name;
        }

        // All
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerThan2 = numbers.All(x => x >= 2); // false

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true
        }

        // Agregate
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);
            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 3 => 6
            // etc.

            string[] words = { "hello,", "my", "name", "is", "Martín" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current + " ");
        }

        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> distinctValues = numbers.Distinct();
        }

        // GroupBy
        static public void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doesn't fit the condition
            // 2. The group that does fit the condition

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {   
                    Console.WriteLine(value);
                }
            }

            // Another example
           
            var classRoom = new[]
            {
                new Student
                {
                    Name = "Martín",
                    Id = 1,
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Name = "Juan",
                    Id = 2,
                    Grade = 50,
                    Certified = false
                },
                new Student
                {
                    Name = "Ana",
                    Id = 3,
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Name = "Álvaro",
                    Id = 4,
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Name = "Pedro",
                    Id = 5,
                    Grade = 50,
                    Certified = true
                }

            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified && student.Grade >= 50);
            
            // We obtain two groups
            // 1. Non certified students
            // 2. Certified students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine($"--------- {group.Key} ---------");
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }

        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "Mi first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "Mi second comment",
                            Content = "My other content"
                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "Mi other comment",
                            Content = "My new content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "Mi other new comment",
                            Content = "My other new content"
                        }
                    }
                }
            };

            var commentsContent = posts.SelectMany(post => post.Comments, 
                (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });
        }
    }
}