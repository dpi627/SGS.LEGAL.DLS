using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Repository;
using SGS.LIB.Common;
using System.Data;

namespace SGS.LEGAL.DLS.Service
{
    public class SysParamService : BaseService
    {
        private readonly SYS_USER user;

        public SysParamService(SYS_USER? user) : base(user)
        {
            this.user = user ?? new SYS_USER();
        }

        /// <summary>
        /// 依照參數類別取得參數資料
        /// </summary>
        /// <param name="ParameterClass">參數類別</param>
        /// <returns></returns>
        public IList<SYS_PARAM>? Get(string ParameterClass)
        {
            using SysParamRepo repo = new(user);
            IList<SYS_PARAM>? data = repo.Read(ParameterClass);
            return data;
        }

        /// <summary>
        /// 取得幣別小數位數
        /// </summary>
        /// <param name="Currency">貨幣</param>
        /// <returns></returns>
        public string? GetPrecision(string Currency)
        {
            IList<SYS_PARAM>? data = this.Get("Currency");
            return data?.FirstOrDefault(x => x.P_VAL == Currency)?.EXT_1;
        }
    }
}
