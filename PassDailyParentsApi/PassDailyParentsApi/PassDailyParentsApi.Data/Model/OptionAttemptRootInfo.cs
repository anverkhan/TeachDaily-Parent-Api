using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class OptionAttemptRootInfo
    {
        public OptionsListInfo[] OptionList { get; set; }
        public OptionAttemptInfo[] AttemptedOption { get; set; }
    }
}
