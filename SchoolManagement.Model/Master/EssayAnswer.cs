﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Master
{
   public  class EssayAnswer
    {
        public int EssayAnswerId { get; set; }
        public int? QuestionId { get; set; }
        public string AnswerText { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Question QuestionID { get; set; }
        

        public virtual Question Questions { get; set; }







    }
}
