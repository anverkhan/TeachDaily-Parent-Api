using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    
    public class AcademicInfo
    {
        
        public int ACCADEMIC_ID { get; set; }
        
        public int STUDENT_ROLL_NUMBER { get; set; }
        
        public int CLASS_ID { get; set; }
        
        public string ACCADEMIC_TIME { get; set; }
        
        public string CLASS_NAME { get; set; }

        public string YOUTUBE_LINK { get; set; } 


        //public string YOUTUBE_LINK { get; set; } = "https://youtube.com/watch?v=65lZnSP_u_M&feature=shared"; //Holy Angels

        //public string YOUTUBE_LINK { get; set; } = "https://www.youtube.com/watch?v=8XYcHF6pqPs";  //St Thomas

        //public string YOUTUBE_LINK { get; set; } = "https://youtube.com/@st.thereseconventhighschoo9509?si=au7r3PzYsnVhf8sJ";  // St Therese

        //public string YOUTUBE_LINK { get; set; } = "https://youtube.com/@carmelschoolkhopoli9133?si=8r-UCLTn70D6mEXV";  // Carmel

        //public string YOUTUBE_LINK { get; set; } = "https://youtube.com/@nirmalaconventschoolpune1521?si=s6oAMiI3wcH0iZMH"; // Nirmala

        //public string YOUTUBE_LINK { get; set; } = "https://www.youtube.com/channel/UC8wnPf4-ly7asUr88xxm7zw"; //Sunrise   

        //public string YOUTUBE_LINK { get; set; } = "https://www.youtube.com/watch?app=desktop&v=SpCpamOoGT0"; //Chandresh Lodha


    }
}
