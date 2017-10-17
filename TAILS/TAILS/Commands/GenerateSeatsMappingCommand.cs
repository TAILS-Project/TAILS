using System;
using System.IO;
using TAILS.Data;
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
            //parse parameters (don't forget hallName!)
            string hallName = "Community";

            FileStream fs = new FileStream("result.pdf", FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            PdfContentByte cb = writer.DirectContent;
            Image img;
            BaseFont bf;
            switch(hallName)
            {
                case "Community":
                    img = Image.GetInstance("../../App_Data/Images/community.jpg");
                    img.ScalePercent(31f, 24f);
                    img.SetAbsolutePosition(-3, -24);
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
                    cb.SetFontAndSize(bf, 10);
                    cb.AddImage(img);
                    break;
                case "Enterprise":
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
            //switch hallName
            //get seats
            //get students from course
            //if students.count > seats.count => throw exception
            //else shuffle students & type students username @(x, y) in order until all students are placed
            //for community - don't forget last 5 seats have angle
            //for enterprise - use angle for all seats
            cb.EndText();
            document.Close();
            writer.Close();
            fs.Close();
            return $"PDF file generated successfully.";
        }

        public void ShuffleStudents(List<Student> students)
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
