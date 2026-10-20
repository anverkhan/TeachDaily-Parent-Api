using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassDailyParentsApi.Data.Model
{
    public class AppInboxInfoNewRoot
    {
        public AppInboxInfo InboxDetails { get; set; }

        public InboxFileDetailsInfo[] FileDetails { get; set; }

        public InboxReplyFileDetailsInfo[] ReplyFileDetails { get; set; }
    }
}
