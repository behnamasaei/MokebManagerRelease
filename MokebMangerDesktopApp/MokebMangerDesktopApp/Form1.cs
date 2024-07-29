using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MokebMangerDesktopApp
{
    public partial class Form1 : Form
    {
        DashboardPanel dashboardDotnet;
        DashboardPanel dashboardAngular;

        public Form1()
        {
            InitializeComponent();
            this.lblWait.Hide();
            dashboardDotnet = new DashboardPanel();
            dashboardAngular = new DashboardPanel();
            this.panel1.Hide();
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!dashboardDotnet.IsProcessNull())
                dashboardDotnet.KillProcess();

            if (!dashboardAngular.IsProcessNull())
                dashboardAngular.KillProcess();
        }

        private async void btnRunDotnet_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                // به‌روزرسانی کنترل UI از Thread اصلی
                this.Invoke(new Action(async () =>
                {
                    this.lblWait.Show();
                }));
                
                await RunHostDotnet();
            });

        }



        private async Task RunHostDotnet()
        {
            // اجرای دستور به صورت غیرهمزمان
            bool status = await Task.Run(() => dashboardDotnet.RunCmdFile(
                @"cd .\release_v1\dotnetapp && dotnet MokebManagerNg.HttpApi.Host.dll --urls=https://0.0.0.0:44355"
                , "https://0.0.0.0:44355"));

            // به‌روزرسانی کنترل UI از Thread اصلی
            this.Invoke(new Action(async () =>
            {
                if (status == true)
                {
                    await RunHostAngular();
                }
                else
                {
                    MessageBox.Show("Failed to start the Dotnet server.");
                }
            }));
        }



        private async Task RunHostAngular()
        {
            // اجرای دستور به صورت غیرهمزمان
            bool status = await Task.Run(() => dashboardAngular.RunCmdFile(
                @"cd .\release_v1\angularapp && npm start",
                "Compiled successfully"));

            // به‌روزرسانی کنترل UI از Thread اصلی
            this.Invoke(new Action(() =>
            {
                if (status)
                {
                    this.lblWait.Hide();
                    string ip = dashboardAngular.SetLocalIp();
                    this.lblDotnetIp.Text = $"https://{ip}:44355";
                    this.lblAngularIp.Text = $"https://{ip}:4200";
                    this.panel1.Show();
                }
                else
                {
                    MessageBox.Show("Failed to start the Angular server.");
                }
            }));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sourceFile = @"./release_v1/dotnetapp/MokebManagerNg.db";
            string destinationFile = 
                $@"./Database_Backup/MokebManagerNg__{DateTime.Now.ToString("yy-MM-dd-HH-mm-ss")}.db";
            File.Copy(sourceFile, destinationFile);
            MessageBox.Show("با موفقیت ذخیره شد.");
        }
    }
}
