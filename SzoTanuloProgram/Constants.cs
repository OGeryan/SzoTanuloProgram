using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzoTanuloProgram
{

    public static class Constants
    {
        public static bool IsWindowed = true;
        public static float LoadingTime = 5;
        public static int MaxInRow = 30;
        public static int Narrator = 0;

        public static SpeechSynthesizer TTS = new SpeechSynthesizer();


        public static void ReadConfigs(bool Apply, Form CurrentForm)
        {
            if(!File.Exists("CONFIG.TXT"))
            {
                File.Create("CONFIG.TXT");
            }
            if (File.Exists("CONFIG.TXT"))
            { 
                string[] Lines = File.ReadAllLines("CONFIG.TXT");

                foreach (string Line in Lines)
	            {
                    if (Line.Split('=')[0] == "Windowed")
                    {
                        IsWindowed = bool.Parse(Line.Split('=')[1]);
                    }
                    if (Line.Split('=')[0] == "LoadingTime")
                    {
                        LoadingTime = float.Parse(Line.Split('=')[1]);
                    }
                    if (Line.Split('=')[0] == "MaxInRow")
                    {
                        MaxInRow = int.Parse(Line.Split('=')[1]);
                    }
                    if(Line.Split('=')[0] == "Narrator")
                    {
                        Narrator = int.Parse(Line.Split('=')[1]);
                    }
                }

                if (Apply)
                {
                    ApplyConfigs(CurrentForm);            
                }            
            }
        }

        public static void ApplyConfigs(Form CurrentForm)
        {
            if (IsWindowed)
            {
                F_Windowed(CurrentForm);
            }
            else
            {
                F_Fullscreen(CurrentForm);
            }
            TTS.SelectVoice(TTS.GetInstalledVoices()[Narrator].VoiceInfo.Name);
        }

        public static void WriteConfigs()
        {
            string Data = "";
            Data += "Windowed=" + IsWindowed.ToString() + "\n";
            Data += "LoadingTime=" + LoadingTime.ToString() + "\n";
            Data += "MaxInRow=" + MaxInRow.ToString() + "\n";
            Data += "Narrator=" + Narrator.ToString() + "\n";
            File.WriteAllText("CONFIG.TXT", Data);        
        }

        

        public static void F_Fullscreen(Form Ref)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            Ref.Size = new Size(w, h);
            Ref.FormBorderStyle = FormBorderStyle.None;
            Ref.WindowState = FormWindowState.Maximized;
        }
        public static void F_Windowed(Form Ref) 
        {
            int w = Screen.PrimaryScreen.Bounds.Width / 2;
            int h = Screen.PrimaryScreen.Bounds.Height / 2;
            Ref.Size = new Size(w, h);
            Ref.FormBorderStyle = FormBorderStyle.Sizable;
            Ref.WindowState = FormWindowState.Normal;
        }

        public static void Say(string text)
        {
            TTS.SpeakAsyncCancelAll();
            TTS.SpeakAsync(text);
        }
    }
}
