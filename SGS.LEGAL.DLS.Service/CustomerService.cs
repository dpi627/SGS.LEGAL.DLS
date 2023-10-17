using AutoMapper;
using SGS.LEGAL.DLS.Entity;
using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.Interface;
using SGS.LEGAL.DLS.Service.Mapping;
using SGS.LEGAL.DLS.Service.ResultModel;

namespace SGS.LEGAL.DLS.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        private SYS_USER? user;
        private readonly IMapper _mapper;

        public CustomerService(SYS_USER? user) : base(user)
        {
            this.user = user;

            var config = new MapperConfiguration(
                cfg => cfg.AddProfile<BankAccountMapping>()
                );
            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// 取得銀行帳號資訊
        /// </summary>
        /// <param name="info">銀行帳號資訊結構</param>
        /// <returns>銀行帳號資訊結果資料</returns>
        public BankAccountResultModel GetBankAccountInfo(BankAccountInfo info)
        {
            using CompanyService? svc = new CompanyService(user);
            COMPANY? com = svc.Get(info.COM_CODE!);
            BankAccountResultModel result = _mapper.Map<BankAccountResultModel>(com);
            result.BANK_ACT = GetBankAccount(info, result.BANK_ACT!);
            return result;
        }

        /// <summary>
        /// 取得(虛擬)匯款帳號
        /// </summary>
        /// <param name="info">銀行帳號資訊</param>
        /// <param name="BANK_ACT">銀行帳號(或企業代碼)</param>
        /// <returns>(虛擬)匯款帳號</returns>
        private static string GetBankAccount(BankAccountInfo info, string BANK_ACT)
        {
            // 遠東直接使用原本帳號，其他需要使用企業代碼組合
            if ("FET".Equals(info.COM_CODE))
                return BANK_ACT;
            // 如果統編空白，使用 企業代碼+1+BOSS_NO
            if (string.IsNullOrWhiteSpace(info.CST_NO))
                return $"{BANK_ACT}-1-{info.BOSS_NO?.PadLeft(8,'0')}";
            // 如果統編不是空白，使用 企業代碼+9+統編
            return $"{BANK_ACT}-9-{info.CST_NO}";
        }
    }
}
