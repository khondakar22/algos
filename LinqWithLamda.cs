using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqToSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager
                .ConnectionStrings["LinqToSql.Properties.Settings.RiyadTutorialDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            //InsertUniversities();
            InsertStudents();
        }

        public void InsertUniversities()
        {

            dataContext.ExecuteCommand("delete from University");

            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            dataContext.Universities.InsertOnSubmit(beijingTech);


            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }

        public void InsertStudents()
        {
            dataContext.ExecuteCommand("delete from Student");
            University yale = dataContext.Universities.FirstOrDefault(un => un.Name.Equals("Yale"));
            University beijingTech = dataContext.Universities.FirstOrDefault(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            if (yale == null) return;
            students.Add(new Student { Name = "Carla", Gender = "Female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Toni", Gender = "Male", UniversityId = yale.Id });
            students.Add(new Student { Name = "Leyla", Gender = "Female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Jame", Gender = "Male", UniversityId = yale.Id });
            students.Add(new Student { Name = "Sarah", Gender = "Female", UniversityId = yale.Id });
            if (beijingTech == null) return;
            students.Add(new Student { Name = "Riyad", Gender = "Male", UniversityId = beijingTech.Id });
            students.Add(new Student { Name = "Saad", Gender = "Male", UniversityId = beijingTech.Id });
            students.Add(new Student { Name = "Sumaiya", Gender = "Female", UniversityId = beijingTech.Id });
            students.Add(new Student { Name = "Munia", Gender = "FMale", UniversityId = beijingTech.Id });
            students.Add(new Student { Name = "Promy", Gender = "Female", UniversityId = beijingTech.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
