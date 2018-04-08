
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using System.Collections;
using System.Collections.Generic;
using MSNet.Common.Security;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserProfileRepository : SimpleRepositoryBase<UserProfile, long>, IUserProfileRepository
    {
        public override bool Save(UserProfile model)
        {
            ArgumentAssertion.IsNotNull(model, "model");

            var result = base.Save(model);

            return result;
        }

        public long FindPassportIdByMobile(string Mobile)
        {
            var sqlName = this.FormatSqlName("SelectPassportIdByMobile");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("Mobile", Mobile);

            var idValue = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return idValue.Convert<long>(0);
        }
    }
}