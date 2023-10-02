namespace SGS.LEGAL.DLS.Model
{
    public record ComboBoxItem
    {
        public int IDX { get; set; }
        public string VAL { get; set; }
        public string TXT { get; set; }

        /// <summary>
        /// 自訂 ComboBoxItem
        /// </summary>
        /// <param name="val">選項值</param>
        /// <param name="txt">選項文字</param>
        public ComboBoxItem(int idx, string val, string txt)
        {
            IDX = idx;
            VAL = val;
            TXT = txt;
        }

        public override string ToString()
        {
            return VAL;
        }
    }
}
