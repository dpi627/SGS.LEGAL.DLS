using SGS.LEGAL.DLS.Entity;

namespace SGS.LEGAL.DLS.Repository.DataModel
{
    public record DataImportDataModel : DATA_IMPORT
    {
        public string EMP_ID { get; set; }
        public string USER_NM { get; set; }
    }
}
