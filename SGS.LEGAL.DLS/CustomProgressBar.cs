namespace SGS.LEGAL.DLS
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            base.Value = 100;
            SetStyle(ControlStyles.UserPaint, true);
        }

        // 複寫顏色為橘色
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            using (SolidBrush brushBackground = new(Color.LightGray))
            {
                e.Graphics.FillRectangle(brushBackground, rect);
            }

            using SolidBrush brushProgress = new(Color.Tomato);
            float width = rect.Width * ((float)Value / Maximum);
            Rectangle progressRect = new(rect.X, rect.Y, (int)width, rect.Height);
            e.Graphics.FillRectangle(brushProgress, progressRect);
        }
    }

}
