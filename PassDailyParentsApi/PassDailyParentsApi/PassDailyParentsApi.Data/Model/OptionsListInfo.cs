using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OptionsListInfo
    {
        public int? OPTION_ID { get; set; }
		public string OPTION_KEY { get; set; }
        public int? QUESTION_ID { get; set; }
        public string OPTION_TEXT { get; set; }
        public int? IS_RIGHT_OPTION { get; set; }
    }
}
