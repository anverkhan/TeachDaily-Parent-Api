using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class MarkInfo
    {

        public int? MARK_ID { get; set; }

        public int? ACCADEMIC_ID { get; set; }

        public int? CLASS_ID { get; set; }

        public int? EXAM_ID { get; set; }

        public int? SUBJECT_ID { get; set; }

        public int? STUDENT_ID { get; set; }

        public int? STUDENT_ROLL_NUMBER { get; set; }

        public string SCORED_MARK { get; set; }

        public string OUTOFF_MARK { get; set; }

        public string SHOW_MARK { get; set; }

        public string MARK_GRADE { get; set; }

        public string SUBJECT_NAME { get; set; }

        public string SUBJECT_ICON { get; set; } = "General.png";

        public decimal? SUBJECT_PERCENTAGE { get; set; }

        public string SUBJECT_RESULT { get; set; }

        public decimal? OVERALL_SCORED_MARK { get; set; }

        public decimal? OVERALL_OUTOFF_MARK { get; set; }

        public decimal? OVERALL_PERCENTAGE { get; set; }

        public string OVERALL_RESULT { get; set; }


    }
}
