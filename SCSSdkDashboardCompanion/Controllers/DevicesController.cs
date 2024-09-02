using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SCSSdkDashboardCompanion
{
    internal class DevicesController
    {
        private List<UsbDevice> _devicesList = new List<UsbDevice>();

        private int _selectedDevice = -1;
        private int _baudRate = 115200;
        private SerialPort _connectionPort = new SerialPort();

        public DevicesController() { }

        public List<UsbDevice> DevicesList => _devicesList;
        public int BaudRate { get => _baudRate; set => _baudRate = value; }
        public int SelectedDevice { get => _selectedDevice; set => _selectedDevice = value; }
        public bool IsConnected => _connectionPort.IsOpen;

        public void LoadDevices()
        {
            _devicesList.Clear();
            _selectedDevice = -1;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'");
            var foundDevices = searcher.Get();
            if (foundDevices.Count == 0)
            {
                Debug.WriteLine("No devices found");

                var dialogResponse = MessageBox.Show(
                    "Check the device connection with the computer and retry", 
                    "No devices found", 
                    MessageBoxButtons.RetryCancel, 
                    MessageBoxIcon.Warning
                );

                if (dialogResponse == DialogResult.Retry)
                {
                    Debug.WriteLine("Retrying...");
                    LoadDevices();
                }
                return;
            }

            foreach (var device in foundDevices)
                _devicesList.Add(new UsbDevice(device["DeviceID"].ToString(), device["Caption"].ToString()));

            Debug.WriteLine("Done getting devices");
        }

        public bool ConnectDevice()
        {
            if (!ValidateConnectionParams())
            {
                return false;
            }

            if (_connectionPort.IsOpen)
            {
                Debug.WriteLine("A device is already connected, disconnecting it...");
                DisconnectDevice();
            }

            _connectionPort.BaudRate = BaudRate;
            _connectionPort.PortName = DevicesList[SelectedDevice].Port;
            try
            {
                _connectionPort.Open();                
            }
            catch (System.Exception err)
            {
                Debug.WriteLine($"Connection error: {err.ToString()}");

                var dialogResponse = MessageBox.Show(
                    "Check if the connection port is being used by any other application and close it", 
                    "Failed to connect to device", 
                    MessageBoxButtons.RetryCancel, 
                    MessageBoxIcon.Error
                );
                
                if (dialogResponse == DialogResult.Retry)
                {
                    Debug.WriteLine("Retrying...");
                    return ConnectDevice();
                }
                return false;
            }

            Debug.WriteLine("Device connected");
            return true;

        }

        public bool DisconnectDevice() {
            if (!_connectionPort.IsOpen)
            {
                Debug.WriteLine("No device connected");
                return true;
            }

            try
            {
                _connectionPort.Close();
                Debug.WriteLine("Device disconnected");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error disconnecting device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateConnectionParams()
        {
            if (_selectedDevice == -1)
            {
                MessageBox.Show("No device selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (BaudRate != 9600 && BaudRate != 115200)
            {
                MessageBox.Show("Invalid connection Baud rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void SendData(string str)
        {
            if (!IsConnected) return;

            //Debug.WriteLine($"Sending data: {str}");
            _connectionPort.WriteLine(str);
        }

    }

    internal class UsbDevice
    {
        private string _deviceId;
        private string _caption;

        public UsbDevice(string deviceId, string caption)
        {
            DeviceId = deviceId;
            Caption = caption;
        }

        public string DeviceId { get => _deviceId; set => _deviceId = value; }
        public string Caption { get => _caption; set => _caption = value; }

        public string ProductId => Regex.Replace(DeviceId, ".*PID_([A-Z0-9]{4}).*", "$1");
        public string VendorId => Regex.Replace(DeviceId, ".*VID_([A-Z0-9]{4}).*", "$1");
        public string Port => Regex.Replace(Caption, @".*\((COM.+)\)$", "$1");
        
        public string Description => VendorId.Equals("2E8A") ? RaspberryPiDecription : Caption;


        private string RaspberryPiDecription
        {
            /**
            * Raspberry Pi PID allocation list
            * https://github.com/raspberrypi/usb-pid
            */
            get
            {
                switch (ProductId)
                {
                    case "0003":
                        return "Raspberry Pi RP2040 boot";
                    case "0004":
                        return "Raspberry Pi PicoProbe";
                    case "0005":
                        return "Raspberry Pi Pico MicroPython firmware (CDC)";
                    case "0009":
                        return "Raspberry Pi Pico SDK CDC UART";
                    case "000A":
                        return "Raspberry Pi Pico SDK CDC UART (RP2040)";
                    case "000B":
                        return "Raspberry Pi Pico CircuitPython firmware";
                    case "000C":
                        return "Raspberry Pi RP2040 CMSIS-DAP debug adapter";
                    case "000D":
                        return "Raspberry Pi USB3HUB (USB2 hub part)";
                    case "000E":
                        return "Raspberry Pi USB3HUB (USB3 hub part)";
                    case "000F":
                        return "Raspberry Pi RP2350 boot";
                    default:
                        return Caption;
                }

            }
        }
    }

}
//uint16 Availability;
//string Caption;
//string ClassGuid;
//string CompatibleID[];
//uint32 ConfigManagerErrorCode;
//boolean ConfigManagerUserConfig;
//string CreationClassName;
//string Description;
//string DeviceID;
//boolean ErrorCleared;
//string ErrorDescription;
//string HardwareID[];
//datetime InstallDate;
//uint32 LastErrorCode;
//string Manufacturer;
//string Name;
//string PNPClass;
//string PNPDeviceID;
//uint16 PowerManagementCapabilities[];
//boolean PowerManagementSupported;
//boolean Present;
//string Service;
//string Status;
//uint16 StatusInfo;
//string SystemCreationClassName;
//string SystemName;