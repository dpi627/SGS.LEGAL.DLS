using SGS.LEGAL.DLS.Service.Info;
using SGS.LEGAL.DLS.Service.ResultModel;

namespace SGS.LEGAL.DLS.Service.Interface
{
    public interface ICustomerService
    {
        public BankAccountResultModel GetBankAccountInfo(BankAccountInfo info);
    }
}
