
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using M2SA.AppGenome.Reflection;
using System.Collections;
using System.Collections.Generic;
using MSNet.Common.Passports;
namespace MSNet.Common.DataRepositories
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserProfileRepository : SimpleRepositoryBase<UserProfile, long>, IUserProfileRepository
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override bool Save(UserProfile model)
        {
            ArgumentAssertion.IsNotNull(model, "model");

            var isSignUp = model.PersistentState == PersistentState.Transient;
            var result = base.Save(model);           
            return result;
        }


        public long FindUserIdByMobilePhone(string MobilePhone)
        {
            var sqlName = this.FormatSqlName("SelectPassportIdByMobilePhone");
            var sqlParams = new Dictionary<string, object>(1);
            sqlParams.Add("MobilePhone", MobilePhone);

            var idValue = SqlHelper.ExecuteScalar(sqlName, sqlParams);
            return idValue.Convert<long>(0);
        }
    }
}