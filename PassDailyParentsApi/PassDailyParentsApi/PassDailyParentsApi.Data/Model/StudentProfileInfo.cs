using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class StudentProfileInfo
    {

      
        public int? STUDENT_ID { get; set; }
        public string ADMISSION_NUMBER { get; set; }
        public DateTime? ADMISSION_DATE { get; set; }
        public string STUDENT_FNAME { get; set; }
        public string STUDENT_MNAME { get; set; }
        public string STUDENT_LNAME { get; set; }
        public byte? STUDENT_GENDER { get; set; }
        public DateTime? STUDENT_DOB { get; set; }
        public string STUDENT_BLOODGROUP { get; set; }
        public string STUDENT_BIRTHPLACE { get; set; }
        public string STUDENT_NATIONALITY { get; set; }
        public string STUDENT_MOTHERTONGUE { get; set; }
        public string STUDENT_RELIGION { get; set; }
        public string STUDENT_CASTE { get; set; }
        public string STUDENT_CAST_TYPE { get; set; }
        public string STUDENT_EMAIL_ID { get; set; }


        public string STUDENT_FATHER_NAME { get; set; }
        public string STUDENT_FATHER_QUALIFICATION { get; set; }
        public string STUDENT_GUARDIAN_NUMBER { get; set; }

        public string STUDENT_MOTHER_NAME { get; set; }        
        public string STUDENT_MOTHER_QUALIFICATION { get; set; }
        public string STUDENT_PHONE_NUMBER { get; set; }

        public string STUDENT_GUARDIAN_NAME { get; set; }
        
        public string STUDENT_PADDRESS { get; set; }
        public string STUDENT_CADDRESS { get; set; }
        
        
        public string STUDENT_IMAGE { get; set; }
        public string STUDENT_LAST_STUDIED { get; set; }
        public string STUDENT_ROLL_NUMBER { get; set; }
        
        
        public string STUDENT_FATHER_OCCUPATION { get; set; }
        public string STUDENT_MOTHER_OCCUPATION { get; set; }
        
        public string STUDENT_BIRTHPLACE_TALUK { get; set; }
        public string STUDENT_BIRTHPLACE_DISTRICT { get; set; }
        public string STUDENT_BIRTHPLACE_STATE { get; set; }
        public string STUDENT_SSLC_REG_NO { get; set; }
        public string STUDENT_SSLC_PASS_YEAR { get; set; }
        public string STUDENT_SSLC_PASS_MONTH { get; set; }
        public string STUDENT_LAST_MEDIUM { get; set; }
        public string STUDENT_TC_STATUS { get; set; }
        public string STUDENT_TC_NO { get; set; }
        
        public string STUDENT_AADHAR_NUMBER { get; set; }
        public string STUDENT_EXTRA { get; set; }
        public int? SCHOOL_ID { get; set; }
        public string STUDENT_HOUSE_NAME { get; set; }
        public string STUDENT_PHONE_NO { get; set; }
        public string STUDENT_OPTIONAL_SUBJECT { get; set; }

        public string FEE_ADMISSION_NUMBER { get; set; } = "STD-12345-6789";


    }
}
