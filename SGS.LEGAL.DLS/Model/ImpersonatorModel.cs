
namespace SGS.LEGAL.DLS.Model
{
    public record ImpersonatorModel()
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Domain { get; set; } = "APAC";
    }
}
