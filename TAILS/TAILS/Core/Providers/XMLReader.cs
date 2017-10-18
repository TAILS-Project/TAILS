using System;
using System.Xml;
using TAILS.Models;
using System.Collections.Generic;

namespace TAILS.Core.Providers
{
    public class XMLReader<T> : IFileReader<T>
    {
        public List<T> ReadFile(string fileName)
        {
            List<T> listT = new List<T>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode child in rootNode.ChildNodes)
            {
                switch (rootNode.Name)
                {
                    case "coursesArray":
                        string courseName = child["courseName"].InnerText;
                        listT.Add((T)(object)new Course
                        {
                            CourseName = courseName
                        });
                        break;
                    case "examsArray":
                        int id = int.Parse(child["id"].InnerText);
                        DateTime dateTime = DateTime.Parse(child["dateTime"].InnerText);
                        listT.Add((T)(object)new Exam
                        {
                            Id = id,
                            DateTime = dateTime
                        });
                        break;
                }
            }
            return listT;
        }
    }
}
