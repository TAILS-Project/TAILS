using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tails.Models.Model;
using YAXLib;

namespace Tails
{
    public class Startup
    {
        static void Main()
        {
            //List<Course> courses = new List<Course>();
            //XmlDocument doc = new XmlDocument();
            //doc.Load("../../App_Data/Courses.xml");
            //XmlNode rootNode = doc.DocumentElement;
            //foreach (XmlNode child in rootNode.ChildNodes)
            //{
            //    courses.Add(new Course { CourseName = child.InnerText });
            //}
            //Console.WriteLine(courses[3].CourseName);

            //List<Course> courses = new List<Course>();
            //using (StreamReader r = new StreamReader("../../App_Data/Courses.json"))
            //{
            //    string json = r.ReadToEnd();
            //    courses = JsonConvert.DeserializeObject<List<Course>>(json);
            //}
            //Console.WriteLine(courses[3].CourseName);

            string pattern = @"<courseId>[\s\S]*?<\/courseId>";
            string pattern1 = @"<dateTime>[\s\S]*?<\/dateTime>";
            List<Exam> exams = new List<Exam>();
            XmlDocument doc = new XmlDocument();
            doc.Load("../../App_Data/Exams.xml");
            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode child in rootNode.ChildNodes)
            {
                Match match = Regex.Match(child.InnerXml, pattern);
                int courseId = int.Parse(match.Value.Replace("<courseId>", "").Replace(@"</courseId>", ""));
                Match match1 = Regex.Match(child.InnerXml, pattern1);
                DateTime dateTime = DateTime.Parse(match1.Value.Replace("<dateTime>", "").Replace(@"</dateTime>", ""));
                exams.Add(new Exam
                {
                    CourseId = courseId,
                    DateTime = dateTime
                });
            }

            //List<Exam> exams = new List<Exam>();
            //using (StreamReader r = new StreamReader("../../App_Data/Exams.json"))
            //{
            //    string json = r.ReadToEnd();
            //    exams = JsonConvert.DeserializeObject<List<Exam>>(json);
            //}
            //Console.WriteLine(exams[0].DateTime);


            //List<Hall> halls = new List<Hall>();
            //using (StreamReader r = new StreamReader("../../App_Data/Halls.json"))
            //{
            //    string json = r.ReadToEnd();
            //    halls = JsonConvert.DeserializeObject<List<Hall>>(json);
            //}
            //Console.WriteLine(halls[1].Capacity);


            //List<Seat> seats = new List<Seat>();
            //using (StreamReader r = new StreamReader("../../App_Data/Seats.json"))
            //{
            //    string json = r.ReadToEnd();
            //    seats = JsonConvert.DeserializeObject<List<Seat>>(json);
            //}
            //Console.WriteLine(seats[150].X);


            //List<Student> students = new List<Student>();
            //using (StreamReader r = new StreamReader("../../App_Data/Students.json"))
            //{
            //    string json = r.ReadToEnd();
            //    students = JsonConvert.DeserializeObject<List<Student>>(json);
            //}
            //Console.WriteLine(students[25].FirstName);
        }
    }
}
    