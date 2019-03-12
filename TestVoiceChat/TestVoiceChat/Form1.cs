using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace TestVoiceChat
{
    public partial class Form1 : Form
    {
        static string remoteAddress;
        static int remotePort;

        static string localAddress;
        static int localPort;

        static Thread recieve_thread;
        static Byte[] incoming;
        static MemoryStream sound;
        static WaveIn waveIn;
        static WaveOut waveOut;
        static WaveFileWriter waveWriter;

        static UdpClient sendr = new UdpClient();
        static UdpClient receiver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void reAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void rePort_TextChanged(object sender, EventArgs e)
        {

        }

        private void loAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void loPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_button_Click(object sender, EventArgs e)
        {
            #region NAudio-staff
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 100;
            waveIn.NumberOfBuffers = 10;
            waveOut = new WaveOut();

            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new WaveFormat(44200, 2);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            sound = new MemoryStream();
            waveWriter = new WaveFileWriter(sound, waveIn.WaveFormat);
            #endregion


            remoteAddress = reAdd.Text;
            remotePort = Int32.Parse(rePort.Text);

            localAddress = loAdd.Text;
            localPort = Int32.Parse(loPort.Text);

            recieve_thread = new Thread(recv);
            recieve_thread.Start();
            
            waveIn.StartRecording();

        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            sendr.Send(e.Buffer, e.Buffer.Length, remoteAddress, remotePort);
        }
        void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
        }
        static void recv()
        {
            receiver = new UdpClient(localPort);
            IPEndPoint remoteIp = null;

            BufferedWaveProvider PlayBuffer = new BufferedWaveProvider(waveIn.WaveFormat);
            waveOut.Init(PlayBuffer);
            waveOut.Play();

            while (true)
            {
                incoming = receiver.Receive(ref remoteIp);
                PlayBuffer.AddSamples(incoming, 0, incoming.Length);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
