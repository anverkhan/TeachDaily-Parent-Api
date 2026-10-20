using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class ContactUsInfo
    {
        public int CONTACT_US_ID { get; set; }
       
        public string CONTACT_US_ADDRESS { get; set; }
        
	    public string CONTACT_US_PHONE { get; set; }
        
	    public string CONTACT_US_EMAIL { get; set; }
        
	    public string LONGITUDE { get; set; }
        
	    public string LATTITUDE { get; set; }
       
	    public DateTime? CONTACT_US_DATE { get; set; }
       
	    public byte? CONTACT_US_STATUS { get; set; }
       
    }
}
