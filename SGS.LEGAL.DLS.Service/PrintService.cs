using SGS.LEGAL.DLS.Entity;
using System.Drawing.Printing;

namespace SGS.LEGAL.DLS.Service
{
    public class PrintService : BaseService
    {
        public PrintService(SYS_USER? user) : base(user)
        {
        }

        public static void PrintAll(params PrintDocument[] docs)
        {
            foreach (PrintDocument doc in docs)
                doc.Print();
        }

        public async Task PrintAllAsync(params PrintDocument[] docs)
        {
            foreach (PrintDocument doc in docs)
                await PrintAsync(doc);
        }

        public static async Task PrintAsync(PrintDocument doc)
        {
            await Task.Run(() => { doc.Print(); });
        }
    }
}
