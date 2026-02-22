using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class Konfig : Form
    {
        
        public Konfig()
        {
            InitializeComponent();
            Constants.ReadConfigs(true, this);
            fullscreenBox.Checked = !Constants.IsWindowed;
            trackBar1.Value = (int)Constants.LoadingTime;
            trackBar2.Value = (int)Constants.MaxInRow;
            label4.Text = Constants.MaxInRow.ToString();
            foreach (var item in Constants.TTS.GetInstalledVoices())
            {
                voiceBox.Items.Add(item.VoiceInfo.Name);
            }
            voiceBox.SelectedIndex = Constants.Narrator;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var menu = new FoMenu();
            menu.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Constants.IsWindowed = !fullscreenBox.Checked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Constants.WriteConfigs();
            Constants.ApplyConfigs(this);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Constants.LoadingTime = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Constants.MaxInRow = trackBar2.Value;
            label4.Text = Constants.MaxInRow.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Constants.MaxInRow = this.Width / 45;
            trackBar2.Value = Constants.MaxInRow;
            label4.Text = Constants.MaxInRow.ToString();
        }

        private void voiceButton_Click(object sender, EventArgs e)
        {
            Constants.Say(voiceText.Text);
        }

        private void voiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Constants.Narrator = voiceBox.SelectedIndex;
            Constants.TTS.SelectVoice(Constants.TTS.GetInstalledVoices()[voiceBox.SelectedIndex].VoiceInfo.Name);
        }
    }
}

