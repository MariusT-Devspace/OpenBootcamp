namespace QueriesExercise
{
    public class Services
    {
        // Create Users
        public static User[] users =
        {
            new User
            {
                FirstName = "María Jesús",
                LastName = "Vela",
                Email = "mariajesus@example.com",
                Password = "52368534"
            },
            new User
            {
                FirstName = "Leopoldo",
                LastName = "Benítez",
                Email = "leopoldobenitez@example.com",
                Password = "76478345"
            },
            new User
            {
                FirstName = "Mauro",
                LastName = "Otero",
                Email = "mauroot@example.com",
                Password = "75584905"
            },
            new User 
            {
                FirstName = "Lucrecia",
                LastName = "Torres",
                Email = "luc3344@example.com",
                Password = "57483395"
            },
            new User
            {
                FirstName = "Mercedes",
                LastName = "Vega",
                Email = "merceveg@example,com",
                Password = "95883745"
            }
        };

        // Categories
        public static Category[] categories = {
            new Category { Name = "Computer Science" },
            new Category { Name = "Mobile and Web Development" },
            new Category { Name = "Data Science" },
            new Category { Name = "Machine Learning" },
            new Category { Name = "Business Strategy" }
        };


        // Create Courses
        public static Course[] courses =
            {
            new Course
            {
                Name = "Introduction to Back-End Development",
                ShortDescription = "Welcome to Introduction to Back-End Development, the first course in the Meta Back-End Developer program.  ",
                LongDescription = "This course is a good place to start if you want to become a web developer. You will learn about the day-to-day responsibilities of a web developer and get a general understanding of the core and underlying technologies that power the internet. You will learn how front-end developers create websites and applications that work well and are easy to maintain. ",
                Goals = "Launch your career as a back-end developer. Build job-ready skills for an in-demand career and earn a credential from Meta.",
                Requirements = "No degree or prior experience required to get started.",
                Level = Course.CourseLevel.Basic,
                Categories = new List<Category>()
                {
                    categories[0],
                    categories[1]
                },
                Students = new List<Student>()
                {
                    new Student
                    {
                        FirstName = "Eduardo",
                        LastName = "Alonso",
                        Dob = new DateTime(1988, 06, 13),
                    }
                }
            },
            new Course
            {
                Name = "Introduction to Statistics",
                ShortDescription = "Stanford's \"Introduction to Statistics\" teaches you statistical thinking concepts that are essential for learning from data and communicating insights. ",
                Goals = "By the end of the course, you will be able to perform exploratory data analysis, understand key principles of sampling, and select appropriate tests of significance for multiple contexts. You will gain the foundational skills that prepare you to pursue more advanced topics in statistical thinking and machine learning.",
                Requirements = "Basic familiarity with computers and productivity software. No calculus required",
                Level = Course.CourseLevel.Basic,
                Categories = new List<Category>()
                {
                    categories[2]
                },
                Students = new List<Student>()
                {
                    new Student
                    {
                        FirstName = "Eduardo",
                        LastName = "Alonso",
                        Dob = new DateTime(1988, 06, 13),
                    },
                    new Student
                    {
                        FirstName = "Antonio",
                        LastName = "Barros",
                        Dob = new DateTime(1993, 04, 25),
                    }
                }
            },
            new Course
            {
                Name = "DeepLearning.AI TensorFlow Developer Professional Certificate",
                LongDescription = "TensorFlow is one of the most in-demand and popular open-source deep learning frameworks available today. The DeepLearning.AI TensorFlow Developer Professional Certificate program teaches you applied machine learning skills with TensorFlow so you can build and train powerful models. In this hands-on, four-course Professional Certificate program, you’ll learn the necessary tools to build scalable AI-powered applications with TensorFlow. ",
                Goals = " After finishing this program, you’ll be able to apply your new TensorFlow skills to a wide range of problems and projects. This program can help you prepare for the Google TensorFlow Certificate exam and bring you one step closer to achieving the Google TensorFlow Certificate.",
                Requirements = "",
                Level = Course.CourseLevel.Medium,
                Categories = new List<Category>()
                {
                    categories[2],
                    categories[3]
                },
                Students = new List<Student>()
                {
                    new Student
                    {
                        FirstName = "Juan Carlos",
                        LastName = "Borja",
                        Dob = new DateTime(1976, 09, 17),
                    }
                }
            },
            new Course
            {
                Name = "Strategic Business Analytics Specialization",
                ShortDescription = "Unveil Critical Insights. Start making efficient, profitable, data-driven business decisions.",
                LongDescription = "You’ll engage in hands-on case studies in real business contexts: examples include predicting and forecasting events, statistical customer segmentation, and calculating customer scores and lifetime value. We’ll also teach you how to take these analyses and effectively present them to stakeholders so your business can take action. The third course and the Capstone Project are designed in partnership with Accenture, one of the world’s best-known consulting, technology services, and outsourcing companies. You’ll learn about applications in a wide variety of sectors, including media, communications, public service,etc. ",
                Goals = "By the end of this specialization, you’ll be able to use statistical techniques in R to develop business intelligence insights, and present them in a compelling way to enable smart and sustainable business decisions. You’ll earn a Specialization Certificate from one of the world’s leading business schools and learn from two of Europe’s leading professors in business analytics and marketing.",
                Requirements = "We recommend that you have some background in statistics, R or another programming language, and familiarity with databases and data analysis techniques such as regression, classification, and clustering.We’ll cover a wide variety of analytics approaches in different industry domains.",
                Level = Course.CourseLevel.Expert,
                Categories = new List<Category>()
                {
                    categories[4]
                }
            }
        };

        // Create Students
        public static Student[] students =
        {
            new Student
            {
                FirstName = "Eduardo",
                LastName = "Alonso",
                Dob = new DateTime(1988, 06, 13),
                Courses = new List<Course>()
                {
                    courses[0],
                    courses[1]
                }
            },

            new Student
            {
                FirstName = "Antonio",
                LastName = "Barros",
                Dob = new DateTime(1993, 04, 25),
                Courses = new List<Course>()
                {
                    courses[1]
                }
            },

            new Student
            {
                FirstName = "Juan Carlos",
                LastName = "Borja",
                Dob = new DateTime(1976, 09, 17),
                Courses = new List<Course>()
                {
                    courses[2]
                }
            },

            new Student
            {
                FirstName = "Kiko",
                LastName = "Gómez",
                Dob = new DateTime(2005, 12, 02),
            }

        };

        // Search functions

        // Buscar usuarios por email
        public static User getUserByEmail(string email)
        {
            var user = from u in users
                       where u.Email == email
                       select u;
            return user.ElementAt(0);
        }

        // Buscar alumnos mayores de edad
        public static IEnumerable<Student> getStudentsOfLegalAge()
        {
            var today = DateTime.Today;
            return from s in students
                   where today.Subtract(s.Dob).TotalDays / 365 >= 18
                   select s;
        }

        // Buscar alumnos que tengan al menos un curso
        public static IEnumerable<Student> getStudentsEnrolled()
        {
            return from s in students
                   where s.Courses.Count() > 0
                   select s;
        }

        // Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        public static IEnumerable<Course> getCoursesHasStudentsByLevel(Course.CourseLevel level)
        {
            return courses.Where(course => course.Level.Equals(level) && course.Students.Any());
        }

        // Buscar cursos de un nivel determinado que sean de una categoría determinada
        public static IEnumerable<Course> getCoursesByLevelAndCategory(Course.CourseLevel level, Category category)
        {
            return courses.Where(course => course.Level.Equals(level) &&
                                           course.Categories.Contains(category));
        }

        // Buscar cursos sin alumnos
        public static IEnumerable<Course> getCoursesNoStudents()
        {
            return courses.Where(course => !course.Students.Any());
        }
    }
}