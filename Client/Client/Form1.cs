using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        string selectedFilePath; 
        public Form1()
        {
            InitializeComponent();
        }

        private async void Connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 5000);
            stream = client.GetStream();
            Logs.Items.Add("Connected!");
        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = dialog.FileName;
                Logs.Items.Add("Selected: " + selectedFilePath);
            }
        }

        private async void Send_Click(object sender, EventArgs e)
        {
            // قرا الملف من الديسك
            byte[] fileBytes = File.ReadAllBytes(selectedFilePath);
            Logs.Items.Add($"Sending: {fileBytes.Length} bytes");

            // ابعت الحجم أولاً (4 bytes)
            byte[] sizeBytes = BitConverter.GetBytes(fileBytes.Length);
            await stream.WriteAsync(sizeBytes, 0, 4);

            // ابعت الملف
            await stream.WriteAsync(fileBytes, 0, fileBytes.Length);
            Logs.Items.Add("File sent!");

            // استقبل حجم الملف المضغوط (4 bytes)
            byte[] compSizeBuffer = new byte[4];
            await stream.ReadAsync(compSizeBuffer, 0, 4);
            int compSize = BitConverter.ToInt32(compSizeBuffer, 0);
            Logs.Items.Add($"Receiving compressed: {compSize} bytes");

            // استقبل الملف المضغوط
            byte[] compBytes = new byte[compSize];
            int totalRead = 0;
            while (totalRead < compSize)
            {
                int read = await stream.ReadAsync(compBytes, totalRead, compSize - totalRead);
                if (read == 0) break;
                totalRead += read;
            }

            // احفظ الملف المضغوط
            string savePath = selectedFilePath + ".gz";
            File.WriteAllBytes(savePath, compBytes);
            Logs.Items.Add($"Saved to: {savePath}");
        }
    }
}
