namespace sys_exp_1
{
    public partial class mainForm : Form
    {
        public double interval = 100;
        //�ƶ��ķ���
        public int direction = 1;
        //�ƶ��Ĳ���
        public int step = 1;

        //����һ��timer
        System.Timers.Timer timer;

        //Timer����һ���������̣߳���������̵߳Ļ�����Ҫ�õ�ί��
        public delegate void SetControlValue(string value);

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            initTimer();
        }

        private void initTimer()
        {
            timer = new System.Timers.Timer(interval);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timerup);
        }

        private void Timerup(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(new SetControlValue(SetTextBoxText), interval.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ִ�ж�ʱ�����¼�ʧ��:" + ex.Message);
            }
        }
        private void SetTextBoxText(string strValue)
        {
            if (pictureCar.Right >= 475 || pictureCar.Left < 0)
            {
                direction = -direction;
            }
            pictureCar.Left += direction * step;
            pictureCar.Top += direction * step;
            this.textBox1.Text = strValue;
        }


        private void buttonStart(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void buttonStop(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void buttonSpeedUp(object sender, EventArgs e)
        {
            timer.Stop();
            interval /= 2;
            timer = new System.Timers.Timer(interval);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timerup);
        }

        private void buttonSpeedDown(object sender, EventArgs e)
        {
            timer.Stop();
            interval *= 2;
            timer = new System.Timers.Timer(interval);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timerup);
        }

        private void pictureCar_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon2.Visible = true;
                this.ShowInTaskbar = false;
            }

        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}