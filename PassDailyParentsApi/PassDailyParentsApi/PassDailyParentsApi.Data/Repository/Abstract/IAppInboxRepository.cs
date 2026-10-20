using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IAppInboxRepository
    {
        AppInboxInfoRoot AppInboxGet(AppInboxRequestInfo inbox);
        AppInboxInfoRoot AppInboxGetById(string Inbox_Id);
        DbResultInfo AppInboxReadById(string StudentId, string InboxId);
        AppInboxInfoRootNew AppInboxGetNew(AppInboxRequestInfo inbox);
        AppInboxInfoNewRoot AppInboxGetByIdNew(string Inbox_Id,string StudentId);
    }
}
