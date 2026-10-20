using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PassDailyParentsApi.Data.Model;
using System.Data.SqlClient;
using PassDailyParentsApi.Data.Extensions;
using PassDailyParentsApi.Data.Repository.Abstract;
using System.Data.Entity.Infrastructure;
using System.Data.Common;

namespace PassDailyParentsApi.Data.Repository.Impl
{
    public class ParentLoginRepository : IParentLoginRepository
    {
        public ChildInfoRoot GetChildrenDetails(int parentId)
        {
            ChildInfoRoot result = new ChildInfoRoot();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("PLOGIN_ID", DbType.Int32, parentId);

                    var ChildrensDetails = context.Database.SqlQuery<ChildInfo>("dbo.sms_app_STUDENT_DETAILS_GET_BY_PARENT_ID @PLOGIN_ID", parameters);
                    result.Childrens = ChildrensDetails.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public ParentLoginResponse Login(string Username, string Password, string SchoolCode)
        {
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[3];

                    parameters[0] = DataHelper.CreateSqlParameter("@PARENT_LOGIN_NAME", DbType.String, Username);
                    parameters[1] = DataHelper.CreateSqlParameter("@PARENT_PASSWORD", DbType.String, Password);
                    parameters[2] = DataHelper.CreateSqlParameter("@SCHOOL_CODE", DbType.String, SchoolCode);


                    var result = context.Database.SqlQuery<ParentLoginResponse>("dbo.sms_app_VALIDATE_PARENT_LOGIN @PARENT_LOGIN_NAME, @PARENT_PASSWORD,@SCHOOL_CODE", parameters);
                    return result.FirstOrDefault();
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public AboutusInfoRoot AboutUs(string StudentId, string AboutType)
        {
            AboutusInfoRoot result = new AboutusInfoRoot();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@ABT_FAQ_TYPE", DbType.String, AboutType);
                    var About = context.Database.SqlQuery<AboutusInfo>("dbo.sms_app_ABOUTUS_FAQ_DETAILS_LIST @ABT_FAQ_TYPE", parameters);
                    result.AboutusList = About.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public ContactUsRootInfo ContactUs(string StudentId)
        {
            ContactUsRootInfo result = new ContactUsRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    //SqlParameter[] parameters = new SqlParameter[1];

                    //parameters[0] = DataHelper.CreateSqlParameter("@ABT_FAQ_TYPE", DbType.String, AboutType);
                    var Contact = context.Database.SqlQuery<ContactUsInfo>("dbo.sms_CONTACT_US_DETAILS_GET_ALL");
                    result.ContactusList = Contact.ToArray();
                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public DistrictClassListRootInfo DistrictClassList()
        {
            DistrictClassListRootInfo result = new DistrictClassListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                // Create a SQL command to execute the sproc 
                DbCommand cmd = context.Database.Connection.CreateCommand();
                cmd.CommandText = "dbo.sms_app_CDL_DISTRICT_CLASS_GETALL";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.AddParameter("@ACCADEMIC_ID", DbType.Int32, 7);
                
                try
                {
                    context.Database.Connection.Open();
                    // Run the sproc  
                    var reader = cmd.ExecuteReader();

                    var classlist = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<ClassListInfo>(reader);


                    result.ClassList = classlist.ToArray();

                    // Move to second result set and read Posts 
                    reader.NextResult();

                    var District = ((IObjectContextAdapter)context)
                        .ObjectContext
                        .Translate<DistrictListInfo>(reader);

                    result.DistrictList = District.ToArray();


                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public ParentAccountInfo Registration(RegistrationInfo Rginfo)
        {
            ParentAccountInfo result = new ParentAccountInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_FNAME", DbType.String, Rginfo.STUDENT_FNAME);
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_GENDER", DbType.String, Rginfo.STUDENT_GENDER);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_GUARDIAN_NUMBER", DbType.String, Rginfo.STUDENT_GUARDIAN_NUMBER);
                    parameters[3] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, Rginfo.CLASS_ID);
                    parameters[4] = DataHelper.CreateSqlParameter("@CLASS_NAME", DbType.String, Rginfo.CLASS_NAME);
                    parameters[5] = DataHelper.CreateSqlParameter("@DISTRICT_ID", DbType.String, Rginfo.DISTRICT_ID);
                    var res = context.Database.SqlQuery<ParentAccountInfo>("dbo.sms_app_CDL_STUDENT_REGISTRATION @STUDENT_FNAME,@STUDENT_GENDER,@STUDENT_GUARDIAN_NUMBER,@CLASS_ID,@CLASS_NAME,@DISTRICT_ID", parameters);
                    result = res.FirstOrDefault();
                    
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public DbResultInfo Logout(int parentId)
        {
            DbResultInfo result = new DbResultInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("PLOGIN_ID", DbType.Int32, parentId);

                    var result1 = context.Database.SqlQuery<DbResultInfo>("dbo.sms_app_VALIDATE_PARENT_LOGOUT @PLOGIN_ID", parameters);
                    result = result1.FirstOrDefault();
                    
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public LandingPageRootInfo LandingPage()
        {
            LandingPageRootInfo result = new LandingPageRootInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    //SqlParameter[] parameters = new SqlParameter[1];

                    //parameters[0] = DataHelper.CreateSqlParameter("PLOGIN_ID", DbType.Int32, parentId);

                    var Page = context.Database.SqlQuery<LandingPageInfo>("dbo.sms_app_LANDING_PAGE_LIST");
                    result.LandingPageList = Page.ToArray();
                    
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public DbResultInfo SibilingsAdd(RegistrationInfo Rginfo)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_FNAME", DbType.String, Rginfo.STUDENT_FNAME);
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_GENDER", DbType.String, Rginfo.STUDENT_GENDER);
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, Rginfo.CLASS_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@CLASS_NAME", DbType.String, Rginfo.CLASS_NAME);
                    parameters[4] = DataHelper.CreateSqlParameter("@DISTRICT_ID", DbType.String, Rginfo.DISTRICT_ID);
                    parameters[5] = DataHelper.CreateSqlParameter("@MAIN_STUDENT_ID", DbType.String, Rginfo.STUDENT_ID);

                    var res = context.Database.SqlQuery<DbResultInfo>("dbo.sms_app_CDL_STUDENT_SIBLINGS_ADD @STUDENT_FNAME,@STUDENT_GENDER,@CLASS_ID,@CLASS_NAME,@DISTRICT_ID,@MAIN_STUDENT_ID", parameters);
                    result = res.FirstOrDefault();

                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public SyllabusRootInfo GetSyllabus()
        {
            SyllabusRootInfo result = new SyllabusRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    //SqlParameter[] parameters = new SqlParameter[1];

                    //parameters[0] = DataHelper.CreateSqlParameter("PLOGIN_ID", DbType.Int32, parentId);

                    var Syllabus = context.Database.SqlQuery<SyllabusInfo>("dbo.sms_CLASS_CATEGORY_GETALL");
                    result.SyllabusList = Syllabus.ToArray();

                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }

        public ClassListRootInfo GetClassListBySyllabus(string ClassCategoryId)
        {
            ClassListRootInfo result = new ClassListRootInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("@CLASS_CAT_ID", DbType.String, System.Convert.ToInt32(ClassCategoryId));

                    var classdetails = context.Database.SqlQuery<ClassListInfo>("dbo.sms_CLASS_DETAILS_GETALL_BY_CAT_ID @CLASS_CAT_ID", parameters);
                    result.ClassList = classdetails.ToArray();

                    return result;
                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
        }

        public ParentAccountInfo RegistrationNew(RegistrationInfo Rginfo)
        {
            ParentAccountInfo result = new ParentAccountInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_FNAME", DbType.String, Rginfo.STUDENT_FNAME);
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_GENDER", DbType.String, Rginfo.STUDENT_GENDER);
                    parameters[2] = DataHelper.CreateSqlParameter("@STUDENT_GUARDIAN_NUMBER", DbType.String, Rginfo.STUDENT_GUARDIAN_NUMBER);
                    parameters[3] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, Rginfo.CLASS_ID);
                    parameters[4] = DataHelper.CreateSqlParameter("@CLASS_NAME", DbType.String, Rginfo.CLASS_NAME);
                    parameters[5] = DataHelper.CreateSqlParameter("@DISTRICT_ID", DbType.String, "-1");
                    var res = context.Database.SqlQuery<ParentAccountInfo>("dbo.sms_app_CDL_STUDENT_REGISTRATION @STUDENT_FNAME,@STUDENT_GENDER,@STUDENT_GUARDIAN_NUMBER,@CLASS_ID,@CLASS_NAME,@DISTRICT_ID", parameters);
                    result = res.FirstOrDefault();

                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public DbResultInfo SibilingsAddNew(RegistrationInfo Rginfo)
        {
            DbResultInfo result = new DbResultInfo();

            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = DataHelper.CreateSqlParameter("@STUDENT_FNAME", DbType.String, Rginfo.STUDENT_FNAME);
                    parameters[1] = DataHelper.CreateSqlParameter("@STUDENT_GENDER", DbType.String, Rginfo.STUDENT_GENDER);
                    parameters[2] = DataHelper.CreateSqlParameter("@CLASS_ID", DbType.String, Rginfo.CLASS_ID);
                    parameters[3] = DataHelper.CreateSqlParameter("@CLASS_NAME", DbType.String, Rginfo.CLASS_NAME);
                    parameters[4] = DataHelper.CreateSqlParameter("@DISTRICT_ID", DbType.String, "-1");
                    parameters[5] = DataHelper.CreateSqlParameter("@MAIN_STUDENT_ID", DbType.String, Rginfo.STUDENT_ID);

                    var res = context.Database.SqlQuery<DbResultInfo>("dbo.sms_app_CDL_STUDENT_SIBLINGS_ADD @STUDENT_FNAME,@STUDENT_GENDER,@CLASS_ID,@CLASS_NAME,@DISTRICT_ID,@MAIN_STUDENT_ID", parameters);
                    result = res.FirstOrDefault();

                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }

            return result;
        }

        public DbResultInfo DeleteAccount(int parentId)
        {
            DbResultInfo result = new DbResultInfo();
            using (var context = new PassDailyDataModel())
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[1];

                    parameters[0] = DataHelper.CreateSqlParameter("PLOGIN_ID", DbType.Int32, parentId);

                    var result1 = context.Database.SqlQuery<DbResultInfo>("dbo.sms_PARENT_ACCOUNT_DETAILS_DROP_BY_PLOGIN_ID @PLOGIN_ID", parameters);
                    result = result1.FirstOrDefault();

                }
                finally
                {
                    context.Database.Connection.Close();
                }
            }
            return result;
        }


    }
}
