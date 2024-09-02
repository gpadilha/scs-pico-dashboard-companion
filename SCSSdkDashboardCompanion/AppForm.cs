using SCSSdkClient;
using System;
using System.Drawing;
using System.Dynamic;
using System.Windows.Forms;
using Newtonsoft.Json;
using SCSSdkClient.Object;
using System.Runtime.InteropServices;

namespace SCSSdkDashboardCompanion
{
    public partial class AppForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private DevicesController _devicesController = new DevicesController();
        private SCSSdkTelemetry Telemetry;

        public AppForm()
        {
            InitializeComponent();
        }

        private void InitializeTelemetry()
        {
            Telemetry = new SCSSdkTelemetry();
            Telemetry.DataUpdated += TelemetryOnDataUpdated;

            Telemetry.JobStarted += TelemetryOnJobStarted;
            Telemetry.JobCancelled += TelemetryOnJobCancelled;
            Telemetry.JobDelivered += TelemetryOnJobDelivered;
            Telemetry.Fined += TelemetryOnFined;
            Telemetry.Tollgate += TelemetryOnTollgate;
            Telemetry.Ferry += TelemetryOnFerry;
            Telemetry.Train += TelemetryOnTrain;
            Telemetry.RefuelStart += TelemetryOnRefuel;
            Telemetry.RefuelEnd += TelemetryOnRefuelEnd;
            Telemetry.RefuelPayed += TelemetryOnRefuelPayed;
        }

        private void TelemetryOnDataUpdated(object sender, DataUpdatedEventArgs e)
        {
            if (!_devicesController.IsConnected)
                return;

            try
            {
                var dashboard = e.Data.TruckValues.CurrentValues.DashboardValues;
                dynamic streamData = new ExpandoObject();
                streamData.speedMph = (int)Math.Round(dashboard.Speed.Mph, 0);
                streamData.speedKph = (int)Math.Round(dashboard.Speed.Kph, 0);
                streamData.cruiseSpeedMph = (int)Math.Round(dashboard.CruiseControlSpeed.Mph, 0);
                streamData.cruiseSpeedKph = (int)Math.Round(dashboard.CruiseControlSpeed.Kph, 0);
                streamData.cruiseControl = dashboard.CruiseControl;
                streamData.gear = dashboard.GearDashboards;
                streamData.fuelPercentage = (int)Math.Round(dashboard.FuelValue.Amount / e.Data.TruckValues.ConstantsValues.CapacityValues.Fuel * 100);

                streamData.engineOn = e.Data.TruckValues.CurrentValues.EngineEnabled;
                streamData.electricOn = e.Data.TruckValues.CurrentValues.ElectricEnabled;
                streamData.parkingBreakOn = e.Data.TruckValues.CurrentValues.MotorValues.BrakeValues.ParkingBrake;

                _devicesController.SendData(JsonConvert.SerializeObject(streamData, Formatting.None));
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error submitting data: {err}");
            }
        }

        private void TelemetryOnFerry(object sender, EventArgs e) =>
           Console.WriteLine("Ferry");

        private void TelemetryOnFined(object sender, EventArgs e) =>
            Console.WriteLine("Fined");

        private void TelemetryOnJobCancelled(object sender, EventArgs e) =>
            Console.WriteLine("Job cancelled");

        private void TelemetryOnJobDelivered(object sender, EventArgs e) =>
            Console.WriteLine("Job delivered");

        private void TelemetryOnJobStarted(object sender, EventArgs e) =>
            Console.WriteLine("Just started job or loaded game with active job");

        private void TelemetryOnRefuel(object sender, EventArgs e) => Console.WriteLine("Refuel start");

        private void TelemetryOnRefuelEnd(object sender, EventArgs e) => Console.WriteLine("Refuel end");

        private void TelemetryOnRefuelPayed(object sender, EventArgs e) =>
            Console.WriteLine("Fuel payed");

        private void TelemetryOnTollgate(object sender, EventArgs e) =>
            Console.WriteLine("Tollgate");

        private void TelemetryOnTrain(object sender, EventArgs e) =>
            Console.WriteLine("Train");


        private void RefreshDevicesListBox()
        {

            SetStatusRefreshing();
            _devicesController.LoadDevices();
            devicesList.Items.Clear();

            foreach (var device in _devicesController.DevicesList)
                devicesList.Items.Add(device.Description);

            if (_devicesController.IsConnected)
                SetStatusConnected();
            else SetStatusDisconnected();
        }

        private void SetStatusConnected() {
            messageLabel.ForeColor = Color.Green;
            messageLabel.Text = "Connected!";
        }
        private void SetStatusDisconnected() {
            messageLabel.ForeColor = Color.Gray;
            messageLabel.Text = "Disconected";
        }
        private void SetStatusRefreshing() {
            messageLabel.ForeColor = Color.SteelBlue;
            messageLabel.Text = "Fetching devices...";
        }

        private void AppForm_Shown(Object sender, EventArgs e)
        {
            RefreshDevicesListBox();
            InitializeTelemetry();
        }

        private void refreshDevicesBttn_Click(object sender, EventArgs e)
        {
            RefreshDevicesListBox();
        }

        private void useDeviceBtn_Click(object sender, EventArgs e)
        {
            if (_devicesController.ConnectDevice())
            {
                SetStatusConnected();
                Telemetry.Resume();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if(_devicesController.DisconnectDevice())
                SetStatusDisconnected();

            Telemetry.Pause();
            Telemetry.Dispose();
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void baud115200_CheckedChanged(object sender, EventArgs e)
        {
            _devicesController.BaudRate = 115200;
        }

        private void baud9600_CheckedChanged(object sender, EventArgs e)
        {
            _devicesController.BaudRate = 9600;
        }

        private void devicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _devicesController.SelectedDevice = ((ListBox) sender).SelectedIndex;
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            if (_devicesController.DisconnectDevice())
            {
                SetStatusDisconnected();
                Telemetry.Pause();
            }
        }

        private void AppForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

}
