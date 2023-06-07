namespace Calculator
{
    public partial class CalculatorApp : Form
    {
        public CalculatorApp()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //var lblOwner = SynchronizationContext.Current;
            if (int.TryParse(txtA.Text, out int a) && int.TryParse(txtB.Text, out int b))
            {
                //Task.Run(() => LongAdd(a, b))
                //.ContinueWith(pTask => UpdateAnswer(pTask.Result));
                //.ContinueWith(pTask => lblOwner?.Post(UpdateAnswer!, pTask.Result));

                //int result = LongAdd(a, b);
                //UpdateAnswer(result);

                //int result =  await LongAddAsync(a, b);
                //UpdateAnswer(result);

                int result = DoeIets(a, b).Result;
                UpdateAnswer(result);

            }
        }

        private async Task<int> DoeIets(int a, int b)
        {
            return await LongAddAsync(a, b);//.ConfigureAwait(false);
        }

        private void UpdateAnswer(object result)
        {
            lblAnswer.Text = result.ToString();
        }
        private int LongAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        private Task<int> LongAddAsync(int a, int b)
        {
            return Task.Run<int>(() => LongAdd(a, b));
        }
    }
}