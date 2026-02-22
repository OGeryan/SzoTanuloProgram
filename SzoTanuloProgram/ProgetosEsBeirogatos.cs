using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SzoTanuloProgram
{
    public partial class ProgetosEsBeirogatos : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public static string valasztott = "";
        public static bool sajat = false;
        public static string[] beolvas;
        public static Color[,] ColorList = { 
            { Color.ForestGreen, Color.LimeGreen }, 
            { Color.MediumOrchid, Color.Plum },
            { Color.Firebrick, Color.IndianRed },
            { Color.SteelBlue, Color.CornflowerBlue },
            { Color.Goldenrod, Color.Yellow }, 
            { Color.DeepPink, Color.LightPink },
            { Color.Aqua, Color.LightBlue },
            { Color.MediumVioletRed, Color.PaleVioletRed}          
        };

        public ProgetosEsBeirogatos()
        {
            InitializeComponent();
            F_ListSzojegyzek();
            Constants.ReadConfigs(true, this);
        }

        private void Tipus_1_Magyar_Angol_Szavak_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            int _height = h / 5;
            sajat = false;

        }
        //----------------------------------------------------------------------------------------------------------------------
        //SAJÁT
        private void SajatSzojegyzek_Click(object sender, EventArgs e)
        {
            sajat = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string nev = openFile.FileName;
                bool text = nev.Contains(".txt");


                StreamReader sr = new StreamReader(openFile.FileName);
                bool jo = true;
                while (!sr.EndOfStream)
                {
                    bool tartalmaz = false;
                    string sor = sr.ReadLine();
                    if (sor.Contains("|"))
                    {
                        tartalmaz = true;
                    }

                    if (tartalmaz == false)
                    {
                        jo = false;
                    }

                }


                if (text == false)
                {
                    MessageBox.Show("Csak txt file okat tölthetsz be!");
                }

                if (jo == true && text == true)
                {
                    openFile.FileName = openFile.FileName.Remove(openFile.FileName.Length - 4, 4);
                    valasztott = openFile.FileName + ".txt";

                    if (FoMenu.tipus_1_magyar_angol == true)
                    {
                        Szavak_Magyar_Angol_Porgetos nyisd = new Szavak_Magyar_Angol_Porgetos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.tipus_1_angol_magyar == true)
                    {
                        Szavak_Angol_Magyar_Porgetos nyisd = new Szavak_Angol_Magyar_Porgetos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.beirogatos == true)
                    {
                        Beirogatos nyisd = new Beirogatos();
                        this.Hide();
                        nyisd.Show();
                    }
                    else if (FoMenu.minijatek == true)
                    {
                        Memoria_Jatek nyisd = new Memoria_Jatek();
                        nyisd.Show();
                        this.Close();
                    }
                }
                else if (jo != true && text == true)
                {
                    MessageBox.Show("Valami hiba van a txt fileodba, nézd át, hogy megfelelően van-e felbontva a szójegyzék: PLD: (  angolSZÓ|magyarMegfelelője  )");
                }



            }
        }

        private void F_ListSzojegyzek()
        {
            var Directories = Directory.GetDirectories("SzoJegyzekek\\");
            int Index = 0;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (Directories.Length)));
            foreach (var Dir in Directories)
            {
                if (!Dir.Contains("!NO"))
                {
                    Panel Parent = new Panel();
                    Parent.BackColor = Color.FromArgb(41, 44, 51);

                    var Name = Dir.Split('\\')[1];
                    int NR = 0;
                    while (NR < Name.Length && Char.IsDigit(Name[NR]))
                    {
                        NR++;
                    }
                    Name = Name.Substring(NR);

                    Parent.Name = Name;
                    //tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                    //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (Directories.Length)));
                    //tableLayoutPanel1.RowCount = tableLayoutPanel1.RowStyles.Count;
                    //tableLayoutPanel1.Controls.Add(Parent, 0, Index);
                    //tableLayoutPanel1.AutoScrollPosition = new Point(0, tableLayoutPanel1.VerticalScroll.Maximum);              
                    //tableLayoutPanel1.SetRowSpan(Parent, Math.Max((Directory.GetFiles(Dir).Length / 20) + 1, 1));
                    //Parent.Dock = DockStyle.Left;
                    //Parent.AutoSize = true;
                    //Parent.AutoScroll = true;
                    F_AddToLayout(Parent, Directories.Length, Index);

                    Button TitleButton = new Button();
                    TitleButton.Name = Dir.Split('\\')[1];
                    TitleButton.Text = Name.ToUpper();
                    Parent.Controls.Add(TitleButton);
                    TitleButton.Dock = DockStyle.Right;
                    TitleButton.Size = new Size(150, 115);
                    TitleButton.Margin = new Padding(2, 2, 2, 2);
                    TitleButton.Padding = new Padding(0, 0, 0, 0);
                    TitleButton.FlatStyle = FlatStyle.Flat;
                    var ColorIndex = Index;
                    if (Index >= ColorList.GetLength(0) - 1)
                    {
                        ColorIndex = new Random().Next(0, ColorList.GetLength(0) - 1);
                    }
                    TitleButton.BackColor = ColorList[ColorIndex, 0];
                    TitleButton.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    TitleButton.UseVisualStyleBackColor = false;
                    TitleButton.FlatAppearance.BorderSize = 0;

                    int btnIndex = 0;

                    int max = Constants.MaxInRow;
                    int rowIndex = 0;
                    Panel CurParent = Parent;
                    foreach (var item in Directory.GetFiles(Dir))
                    {
                        Button NewButton = new Button();
                        int n = (btnIndex + 1 + (rowIndex * max));
                        //MessageBox.Show("btn" + item.Split('\\')[1].Split('.')[0] + item.Split('_')[1]);
                        NewButton.Name = "btn" + item.Split('\\')[1] + "_" + (n).ToString();
                        NewButton.Dock = DockStyle.Right;
                        NewButton.Text = (n).ToString() + ".";
                        NewButton.Size = new Size(45, 115);
                        NewButton.Location = new Point(150 + ((btnIndex) * 45), 0);
                        NewButton.FlatStyle = FlatStyle.Flat;
                        NewButton.Cursor = Cursors.Hand;
                        NewButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                        NewButton.UseVisualStyleBackColor = false;
                        NewButton.Click += OpenSzojegyzek;
                        NewButton.BackColor = ColorList[ColorIndex, 1];
                        NewButton.FlatAppearance.BorderSize = 0;

                        if (btnIndex == max)
                        {
                            rowIndex += 1;
                            btnIndex = 0;
                            CurParent = new Panel();
                            CurParent.BackColor = Color.FromArgb(41, 44, 51);
                            CurParent.Name = Name;
                            F_AddToLayout(CurParent, Directories.Length, Index);

                        }
                        btnIndex++;

                        CurParent.Controls.Add(NewButton);

                    }

                    Index++;
                }
            }
            tableLayoutPanel1.SetRow(panel1, Index);
            tableLayoutPanel1.Refresh();
        }

        private void F_AddToLayout(Panel NewPanel, int Length, int Index)
        {
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (Length)));
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowStyles.Count;
            tableLayoutPanel1.Controls.Add(NewPanel, 0, Index);
            tableLayoutPanel1.AutoScrollPosition = new Point(0, tableLayoutPanel1.VerticalScroll.Maximum);
            //tableLayoutPanel1.SetRowSpan(Parent, Math.Max((Directory.GetFiles(Dir).Length / 20) + 1, 1));
            NewPanel.Dock = DockStyle.Left;
            NewPanel.AutoSize = true;
            NewPanel.AutoScroll = true;
        }

        private void OpenSzojegyzek(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            valasztott = (FoMenu.felelet) ? "Szojegyzek_FeleletValasztos" : "SzoJegyzekek";
            string ClickedName = _btn.Name.Replace("btn", "");
            int NR = 0;
            while (NR < ClickedName.Length && Char.IsDigit(ClickedName[NR]))
            {
                NR++;
            }
            string DirName = ClickedName;
            ClickedName = ClickedName.Substring(NR);
            valasztott += "\\" + DirName.Split('_')[0] + "\\" + ClickedName.Split('_')[0]+"_Unit" + ClickedName.Split('_')[1] + ".txt";

            beolvas = File.ReadAllLines(valasztott);

            if (FoMenu.tipus_1_magyar_angol == true)
            {
                Szavak_Magyar_Angol_Porgetos nyisd = new Szavak_Magyar_Angol_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.tipus_1_angol_magyar == true)
            {
                Szavak_Angol_Magyar_Porgetos nyisd = new Szavak_Angol_Magyar_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.beirogatos == true)
            {
                Beirogatos nyisd = new Beirogatos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.minijatek == true)
            {
                Memoria_Jatek nyisd = new Memoria_Jatek();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.felelet == true)
            {
                Quiz nyisd = new Quiz();
                nyisd.Show();
                this.Close();
            }
        }
        private void OsszesSzojegyzekGombKattintas(object sender, EventArgs e)
        {
            Button _btn = (Button)sender;

            valasztott = (FoMenu.felelet) ? "Szojegyzek_FeleletValasztos" : "SzoJegyzekek";
            MessageBox.Show(_btn.Name);
            if (_btn.Name.Contains("btnElementary"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Elementary" + "\\" + "Elementary_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnIntermedate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Intermediate" + "\\" + "Intermediate_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnPreIntermediate"))
            {
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "PreIntermediate" + "\\" + "Pre_Intermediate_Unit" + darabolt[1] + ".txt";
            }
            else if (_btn.Name.Contains("btnProficiency"))
            {
                
                string[] darabolt = _btn.Name.Split('_');
                int szojegyzekSzama = int.Parse(darabolt[1]);
                valasztott += "\\" + "Proficiency" + "\\" + "Proficiency_Unit" + darabolt[1] + ".txt";
            }

            beolvas = File.ReadAllLines(valasztott);


            if (FoMenu.tipus_1_magyar_angol == true)
            {
                Szavak_Magyar_Angol_Porgetos nyisd = new Szavak_Magyar_Angol_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.tipus_1_angol_magyar == true)
            {
                Szavak_Angol_Magyar_Porgetos nyisd = new Szavak_Angol_Magyar_Porgetos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.beirogatos == true)
            {
                Beirogatos nyisd = new Beirogatos();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.minijatek == true)
            {
                Memoria_Jatek nyisd = new Memoria_Jatek();
                nyisd.Show();
                this.Close();
            }
            else if (FoMenu.felelet == true)
            {
                Quiz nyisd = new Quiz();
                nyisd.Show();
                this.Close();
            }


        }
    }
}
