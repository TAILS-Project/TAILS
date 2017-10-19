using System;
using System.IO;
using TAILS.Data;
using System.Linq;
using TAILS.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Bytes2you.Validation;
using TAILS.Commands.Contracts;
using System.Collections.Generic;

namespace TAILS.Commands
{
    public class GenerateSeatsMappingCommand : ICommand
    {
        private readonly ITAILSEntities context;

        public GenerateSeatsMappingCommand(ITAILSEntities context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int examId = int.Parse(parameters[0]);
            int hallId = int.Parse(parameters[1]);
            string hallName = context.Halls.Find(hallId).Name;

            FileStream fs = new FileStream("result.pdf", FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfContentByte cb = writer.DirectContent;
            Image img;
            BaseFont bf;

            switch (hallId)
            {
                case 1:
                    img = Image.GetInstance("../../App_Data/Images/community.jpg");
                    img.ScalePercent(31f, 24f);
                    img.SetAbsolutePosition(-3, -24);
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
                    cb.SetFontAndSize(bf, 10);
                    cb.AddImage(img);
                    break;
                case 2:
                    img = Image.GetInstance("../../App_Data/Images/enterprise.jpg");
                    img.ScalePercent(24f, 25f);
                    img.SetAbsolutePosition(3, -60);
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
                    cb.SetFontAndSize(bf, 7);
                    cb.AddImage(img);
                    break;
            }
            cb.SetColorFill(BaseColor.GREEN);
            cb.BeginText();

            List<Seat> seats = new List<Seat>();
            seats = context.Seats.Where(s => s.HallId == hallId).ToList();
            List<Student> students = new List<Student>();
            students = context.Courses.Where(c => c.Id == examId).Single().Students.ToList();
            if (students.Count() > seats.Count())
            {
                throw new ArgumentException($"Can't fit students for exam with id {examId} in {hallName} hall.");
            }
            ShuffleStudents(students);
            int curSeat = 1;
            switch (hallId)
            {
                case 1:
                    foreach (Student student in students)
                    {
                        Seat seat = context.Seats.Find(curSeat);
                        curSeat++;
                        if (seat.Id < 37)
                        {
                            cb.SetTextMatrix(seat.X, seat.Y);
                            cb.ShowText($"{student.Username}");
                        }
                        else
                        {
                            cb.ShowTextAligned(Element.ALIGN_LEFT, $"{student.Username}", seat.X, seat.Y, 60);
                        }
                    }
                    break;
                case 2:
                    curSeat += 41;
                    foreach (Student student in students)
                    {
                        Seat seat = context.Seats.Find(curSeat);
                        curSeat++;
                        cb.ShowTextAligned(Element.ALIGN_LEFT, $"{student.Username}", seat.X, seat.Y, 69);
                    }
                    break;
            }

            cb.EndText();
            document.Close();
            writer.Close();
            fs.Close();

            int numOfFreeSeatsLeft = hallId == 1 ? 41 - students.Count() : 160 - students.Count();
            return $"PDF file generated successfully: {students.Count()} students placed in {hallName} hall for the {context.Courses.Where(c => c.Id == examId).Single().CourseName}'s exam. There are {numOfFreeSeatsLeft} free seats left.";
        }

        private void ShuffleStudents(List<Student> students)
        {
            Random rng = new Random();
            int n = students.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Student value = students[k];
                students[k] = students[n];
                students[n] = value;
            }
        }
    }
}
