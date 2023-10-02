using System.ComponentModel.DataAnnotations;

namespace SGS.LEGAL.DLS.Model
{
    public record BaseModel
    {
        public string? ErrorMsg { get; set; }
        public List<ValidationResult> vResults = new();
        ValidationContext? vContext;

        /// <summary>
        /// 執行 Attribute Validation 並取得結果
        /// </summary>
        public bool IsValid()
        {
            vResults = new List<ValidationResult>();
            vContext = new ValidationContext(this, serviceProvider: null, items: null);
            
            // 執行 Attribute Validation 並取得結果
            bool isValid = Validator.TryValidateObject(this, vContext, vResults, validateAllProperties: true);
            // 如果有錯誤，將錯誤訊息串接起來
            if (!isValid)
                SetErrorMessages();

            return isValid;
        }

        /// <summary>
        /// 將錯誤訊息串接起來，使用換行符號隔開
        /// </summary>
        private void SetErrorMessages()
        {
            ErrorMsg = string.Join(
                Environment.NewLine, 
                vResults.Select(x => x.ErrorMessage).Where(msg => !string.IsNullOrEmpty(msg))
                );
        }
    }
}
