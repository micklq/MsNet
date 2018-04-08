using System;
using System.Collections.Generic;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using MSNet.Common.Security;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserPassportRepository : SimpleRepositoryBase<UserPassport, long>, IUserPassportRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public long FindPassportIdByEmail(string email)
        {
            var sqlName = this.FormatSqlName("SelectPassportIdByEmail");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Email", email);

            var idValue = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return idValue.Convert<long>(0);
        }

        public long FindPassportIdByMobile(string mobile)
        {
            var sqlName = this.FormatSqlName("SelectPassportIdByMobile");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Mobile", mobile);

            var idValue = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return idValue.Convert<long>(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public long FindPassportIdByUserName(string userName)
        {
            var sqlName = this.FormatSqlName("SelectPassportIdByUserName");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("UserName", userName);

            var idValue = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return idValue.Convert<long>(0);
        }

        public IList<UserPassport> FindWithAdminPage(string keyword, IList<long> exceptIds, Pagination page)
        {
            var sqlName = this.FormatSqlName("SelectWithAdminPage");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Keyword", string.IsNullOrEmpty(keyword) ? null : keyword);
            sqlParams.Add("ExceptIds", exceptIds);    
            var datatable = SqlHelper.ExecutePaginationTable(sqlName, sqlParams, page);
            IList<UserPassport> list = null;
            if (datatable.Rows.Count > 0)
            {
                list = this.Convert(datatable);
            }
            return list;
        }

        public UserPassport FindByKeyword(string keyword)
        {
            var sqlName = this.FormatSqlName("SelectByKeyword");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Keyword", keyword);
            UserPassport model = null;
            var dataset = SqlHelper.ExecuteDataSet(sqlName, sqlParams);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                model = this.Convert(dataset.Tables[0].Rows[0]);
            }

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns></returns>
        public UserPassport FindUserSecurityById(long passportId)
        {
            var sqlName = this.FormatSqlName("SelectUserSecurityById");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Id", passportId);

            return FindUserSecurityFromDb(sqlName, sqlParams);
        }


        private UserPassport FindUserSecurityFromDb(string sqlName, IDictionary<string, object> sqlParams)
        {
            var dataset = SqlHelper.ExecuteDataSet(sqlName, sqlParams);

            UserPassport userPassport = null;
            if (dataset.Tables.Count > 1 && dataset.Tables[0].Rows.Count == 1 && dataset.Tables[1].Rows.Count == 1)
            {
                userPassport = this.Convert(dataset.Tables[0].Rows[0]);
                var userSecurity = dataset.Tables[1].Rows[0].Serialize<UserSecurity>();
                userPassport.UserSecurity = userSecurity;
            }

            return userPassport;
        }
    }
}