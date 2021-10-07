using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQ
{
    public static class LinqWithXml
    {

        public static void GetStudentsList()
        {
            try
            {
                XDocument document = XDocument.Load("Students.xml");

                var students = from student in document.Descendants("Student")
                    select new
                    {
                        Name = student.Element("Name")?.Value,
                        Surname = student.Element("Surname")?.Value,
                        Age = student.Element("Age")?.Value,
                        Gender = student.Element("Gender")?.Value,
                        University = student.Element("University")?.Value,
                        Semester = student.Element("Semester")?.Value
                    };

                //Order by descending
                students = from student in students orderby student.Age descending select student;

                foreach (var student in students)
                {
                    Console.WriteLine("Name: {0}\n" +
                                      "Surname: {1}\n" +
                                      "Age: {2}\n" +
                                      "Gender: {3}\n" +
                                      "University: {4}\n" +
                                      "Semester: {5}\n-----------", student.Name, student.Surname, student.Age, student.Gender, student.University, student.Semester);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }


}
