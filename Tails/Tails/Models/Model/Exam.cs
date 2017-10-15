﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tails.Models.Abstractions;

namespace Tails.Models.Model
{
    public class Exam : IExam
    {
                
        public Exam(int courseId, DateTime dateTime)
        {
            this.CourseId = courseId;
            this.DateTime = dateTime;
        }

        [Range(1, 1000)]
        public int CourseId { get; set; }
       
        public DateTime DateTime { get; set; }

    }
}
