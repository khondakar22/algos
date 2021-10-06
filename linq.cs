using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            //OddNumber(numbers);
            UniversityManager um = new UniversityManager();
            //um.MaleStudents();
            //um.FeMaleStudents();
            //um.SortStudentsByAge();
            //um.AllStudentsFromBeijingTech();
            //um.AllStudentsFromThatUni();

            //int[] someInt = { 30, 12, 4, 3, 12 };
            //IEnumerable<int> sortedInts = from i in someInt orderby i select i;
            //IEnumerable<int> reversedInts = sortedInts.Reverse();

            //foreach (int reversedInt in reversedInts)
            //{
            //    Console.WriteLine(reversedInt);
            //}

            //IEnumerable<int> reversedSortedInt = from i in someInt orderby i descending select i;
            um.StudentAndUniversityNameCollection();
            Console.ReadKey();
        }

        static void OddNumber(int[] numbers)
        {
            Console.WriteLine("Odd Numbers:");

            IEnumerable<int> oddNumbers = from number in numbers
                                          where number % 2 != 0
                                          select number;

            Console.WriteLine(oddNumbers);

            foreach (int oddNumber in oddNumbers)
            {
                Console.WriteLine(oddNumber);
            }

        }
    }

    class UniversityManager
    {
        public List<University> Universities;
        public List<Student> Students;

        // Constructor
        public UniversityManager()
        {
            Universities = new List<University>();
            Students = new List<Student>();

            // Let's add some Universities
            Universities.Add(new University { Id = 1, Name = "Yale" });
            Universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            // Let's add some Students
            Students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 19, UniversityId = 1 });
            Students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 2 });
            Students.Add(new Student { Id = 3, Name = "Stark", Gender = "female", Age = 25, UniversityId = 1 });
            Students.Add(new Student { Id = 4, Name = "Captain", Gender = "trans-gender", Age = 35, UniversityId = 2 });
            Students.Add(new Student { Id = 5, Name = "America", Gender = "female", Age = 27, UniversityId = 2 });
            Students.Add(new Student { Id = 6, Name = "John", Gender = "male", Age = 22, UniversityId = 1 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in Students
                                                where student.Gender == "male"
                                                select student;
            Console.WriteLine("Male- Students:");

            foreach (Student maleStudent in maleStudents)
            {
                maleStudent.Print();
            }
        }

        public void FeMaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in Students
                                                  where student.Gender == "female"
                                                  select student;
            Console.WriteLine("Female- Students:");

            foreach (Student femaleStudent in femaleStudents)
            {
                femaleStudent.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in Students
                                 orderby student.Age
                                 select student;
            Console.WriteLine("Students sorted by Age:");
            foreach (Student sortedStudent in sortedStudents)
            {
                sortedStudent.Print();
            }
        }

        public void AllStudentsFromBeijingTech()
        {
            IEnumerable<Student> bjtStudents = from student in Students
                                               join university in Universities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;
            Console.WriteLine("Students from Beijing Tech");
            foreach (Student bjtStudent in bjtStudents)
            {
                bjtStudent.Print();
            }
        }

        public void TakeUserInputToShowStudent()
        {
            Console.WriteLine("Please Enter the University Id");
            int uniId = Convert.ToInt32(Console.ReadLine() ?? throw new InvalidOperationException());

            IEnumerable<Student> cStudents = from student in Students
                                             where student.UniversityId == uniId
                                             select student;
            var enumerable = cStudents as Student[] ?? cStudents.ToArray();
            if (enumerable.Any())
            {
                Console.WriteLine("Finds the students list");
                foreach (Student cStudent in enumerable)
                {
                    cStudent.Print();
                }
            }
            else
            {
                Console.WriteLine("Sorry!!! Your given Id {0} Doesn't exist", uniId);
            }
        }

        public void AllStudentsFromThatUni()
        {
            Console.WriteLine("Please Enter the University Id");
            int uniId = Convert.ToInt32(Console.ReadLine() ?? throw new InvalidOperationException());
            IEnumerable<Student> bjtStudents = from student in Students
                                               join university in Universities on student.UniversityId equals university.Id
                                               where university.Id == uniId
                                               select student;
            var enumerable = bjtStudents as Student[] ?? bjtStudents.ToArray();
            if (enumerable.Any())
            {
                Console.WriteLine("Finds the students list of uni id {0}", uniId);
                foreach (Student cStudent in enumerable)
                {
                    cStudent.Print();
                }
            }
            else
            {
                Console.WriteLine("Sorry!!! Your given Id {0} Doesn't exist", uniId);
            }
        }


        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in Students
                                join university in Universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");

            foreach (var col in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }
        }

    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }


        //Foreign Key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine("Student {0} with Id {1}, Gender {2} and Age {3} " +
                              "from University with the Id {4}", Name, Id, Gender, Age, UniversityId);
        }
    }

}
