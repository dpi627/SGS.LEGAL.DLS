
namespace SGS.LEGAL.DLS.Model
{
    public record SysLogModel(
        int U_ID = 0, 
        string ACTION = "NON", 
        bool RESULT = false, 
        Ulid TF_ID = default, 
        string BAK_PATH = @"C:\")
    {
    }
    public record SysLogModel2(int U_ID = 0)
    {
    }
}
