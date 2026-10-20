using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;

namespace PassDailyParentsApi.Data.Repository.Abstract
{
    public interface IParentLoginRepository
    {
        ParentLoginResponse Login(string Username, string Password, string SchoolCode);
        ChildInfoRoot GetChildrenDetails(int parentId);

        AboutusInfoRoot AboutUs(string StudentId, string AboutType);

        ContactUsRootInfo ContactUs(string StudentId);

        DistrictClassListRootInfo DistrictClassList();

        ParentAccountInfo Registration(RegistrationInfo Rginfo);

        DbResultInfo Logout(int parentId);
        LandingPageRootInfo LandingPage();

        DbResultInfo SibilingsAdd(RegistrationInfo Rginfo);

        SyllabusRootInfo GetSyllabus();

        ClassListRootInfo GetClassListBySyllabus(string ClassCategoryId);

        ParentAccountInfo RegistrationNew(RegistrationInfo Rginfo);

        DbResultInfo SibilingsAddNew(RegistrationInfo Rginfo);

        DbResultInfo DeleteAccount(int parentId);
    }
}
