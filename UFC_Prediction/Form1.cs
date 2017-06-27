using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace UFC_Prediction
{

    public partial class Form1 : Form
    {
        List<string> fighterList = new List<string>();
        string[][] fighterData,fighterInfo;
        double money = 1000;
        string bettingHorse;

        public Form1()
        {
            InitializeComponent();
            startFightBtn.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            winningLabel.Visible = false;
            percentLbl.Visible = false;

            using (var fs = File.OpenRead(@"../../DataFiles/fighters.csv"))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    fighterList.Add(line);
                }
            }

            foreach (string fighter in fighterList)
            {
                blueFighterCbx.Items.Add(fighter);
                redFighterCbx.Items.Add(fighter);
            }

            var filePath = @"../../DataFiles/fighter_data.csv";
            fighterData = File.ReadLines(filePath).Select(x => x.Split(';')).ToArray();

            filePath = @"../../DataFiles/ufc_fighters_info.csv";
            fighterInfo = File.ReadLines(filePath).Select(x => x.Split(',')).ToArray();
        }

        private void startFightBtn_Click(object sender, EventArgs e)
        {
            string winner = "";
            bettingBox.Enabled = false;
            setBet();
            winningLabel.Text = "Fighting...";
            winningLabel.Visible = true;
            startFightBtn.Enabled = false;
            StringTable inputValues = new StringTable()
            {
                ColumnNames = new string[] { "BPrev", "BStreak", "B_Age", "B_Height", "B_Name", "B_Weight", "B__Round1_Grappling_Reversals_Landed", "B__Round1_Grappling_Standups_Landed", "B__Round1_Grappling_Submissions_Attempts", "B__Round1_Grappling_Takedowns_Attempts", "B__Round1_Grappling_Takedowns_Landed", "B__Round1_Strikes_Body Significant Strikes_Attempts", "B__Round1_Strikes_Body Significant Strikes_Landed", "B__Round1_Strikes_Body Total Strikes_Attempts", "B__Round1_Strikes_Body Total Strikes_Landed", "B__Round1_Strikes_Clinch Body Strikes_Attempts", "B__Round1_Strikes_Clinch Body Strikes_Landed", "B__Round1_Strikes_Clinch Head Strikes_Attempts", "B__Round1_Strikes_Clinch Head Strikes_Landed", "B__Round1_Strikes_Clinch Leg Strikes_Attempts", "B__Round1_Strikes_Clinch Leg Strikes_Landed", "B__Round1_Strikes_Clinch Significant Kicks_Attempts", "B__Round1_Strikes_Clinch Significant Kicks_Landed", "B__Round1_Strikes_Clinch Significant Punches_Attempts", "B__Round1_Strikes_Clinch Significant Punches_Landed", "B__Round1_Strikes_Clinch Significant Strikes_Attempts", "B__Round1_Strikes_Clinch Significant Strikes_Landed", "B__Round1_Strikes_Clinch Total Strikes_Attempts", "B__Round1_Strikes_Clinch Total Strikes_Landed", "B__Round1_Strikes_Distance Body Kicks_Attempts", "B__Round1_Strikes_Distance Body Kicks_Landed", "B__Round1_Strikes_Distance Body Punches_Attempts", "B__Round1_Strikes_Distance Body Punches_Landed", "B__Round1_Strikes_Distance Body Strikes_Attempts", "B__Round1_Strikes_Distance Body Strikes_Landed", "B__Round1_Strikes_Distance Head Kicks_Attempts", "B__Round1_Strikes_Distance Head Kicks_Landed", "B__Round1_Strikes_Distance Head Punches_Attempts", "B__Round1_Strikes_Distance Head Punches_Landed", "B__Round1_Strikes_Distance Head Strikes_Attempts", "B__Round1_Strikes_Distance Head Strikes_Landed", "B__Round1_Strikes_Distance Leg Kicks_Attempts", "B__Round1_Strikes_Distance Leg Kicks_Landed", "B__Round1_Strikes_Distance Leg Strikes_Attempts", "B__Round1_Strikes_Distance Leg Strikes_Landed", "B__Round1_Strikes_Distance Strikes_Attempts", "B__Round1_Strikes_Distance Strikes_Landed", "B__Round1_Strikes_Ground Body Strikes_Attempts", "B__Round1_Strikes_Ground Body Strikes_Landed", "B__Round1_Strikes_Ground Head Strikes_Attempts", "B__Round1_Strikes_Ground Head Strikes_Landed", "B__Round1_Strikes_Ground Leg Strikes_Attempts", "B__Round1_Strikes_Ground Leg Strikes_Landed", "B__Round1_Strikes_Ground Significant Kicks_Attempts", "B__Round1_Strikes_Ground Significant Kicks_Landed", "B__Round1_Strikes_Ground Significant Punches_Attempts", "B__Round1_Strikes_Ground Significant Punches_Landed", "B__Round1_Strikes_Ground Significant Strikes_Attempts", "B__Round1_Strikes_Ground Significant Strikes_Landed", "B__Round1_Strikes_Ground Total Strikes_Attempts", "B__Round1_Strikes_Ground Total Strikes_Landed", "B__Round1_Strikes_Head Significant Strikes_Attempts", "B__Round1_Strikes_Head Significant Strikes_Landed", "B__Round1_Strikes_Head Total Strikes_Attempts", "B__Round1_Strikes_Head Total Strikes_Landed", "B__Round1_Strikes_Kicks_Attempts", "B__Round1_Strikes_Kicks_Landed", "B__Round1_Strikes_Knock Down_Landed", "B__Round1_Strikes_Leg Total Strikes_Attempts", "B__Round1_Strikes_Leg Total Strikes_Landed", "B__Round1_Strikes_Legs Significant Strikes_Attempts", "B__Round1_Strikes_Legs Significant Strikes_Landed", "B__Round1_Strikes_Legs Total Strikes_Attempts", "B__Round1_Strikes_Legs Total Strikes_Landed", "B__Round1_Strikes_Punches_Attempts", "B__Round1_Strikes_Punches_Landed", "B__Round1_Strikes_Significant Strikes_Attempts", "B__Round1_Strikes_Significant Strikes_Landed", "B__Round1_Strikes_Total Strikes_Attempts", "B__Round1_Strikes_Total Strikes_Landed", "B__Round1_TIP_Back Control Time", "B__Round1_TIP_Clinch Time", "B__Round1_TIP_Control Time", "B__Round1_TIP_Distance Time", "B__Round1_TIP_Ground Control Time", "B__Round1_TIP_Ground Time", "B__Round1_TIP_Guard Control Time", "B__Round1_TIP_Half Guard Control Time", "B__Round1_TIP_Misc. Ground Control Time", "B__Round1_TIP_Mount Control Time", "B__Round1_TIP_Neutral Time", "B__Round1_TIP_Side Control Time", "B__Round1_TIP_Standing Time", "B__Round2_Grappling_Reversals_Landed", "B__Round2_Grappling_Standups_Landed", "B__Round2_Grappling_Submissions_Attempts", "B__Round2_Grappling_Takedowns_Attempts", "B__Round2_Grappling_Takedowns_Landed", "B__Round2_Strikes_Body Significant Strikes_Attempts", "B__Round2_Strikes_Body Significant Strikes_Landed", "B__Round2_Strikes_Body Total Strikes_Attempts", "B__Round2_Strikes_Body Total Strikes_Landed", "B__Round2_Strikes_Clinch Body Strikes_Attempts", "B__Round2_Strikes_Clinch Body Strikes_Landed", "B__Round2_Strikes_Clinch Head Strikes_Attempts", "B__Round2_Strikes_Clinch Head Strikes_Landed", "B__Round2_Strikes_Clinch Leg Strikes_Attempts", "B__Round2_Strikes_Clinch Leg Strikes_Landed", "B__Round2_Strikes_Clinch Significant Kicks_Attempts", "B__Round2_Strikes_Clinch Significant Kicks_Landed", "B__Round2_Strikes_Clinch Significant Punches_Attempts", "B__Round2_Strikes_Clinch Significant Punches_Landed", "B__Round2_Strikes_Clinch Significant Strikes_Attempts", "B__Round2_Strikes_Clinch Significant Strikes_Landed", "B__Round2_Strikes_Clinch Total Strikes_Attempts", "B__Round2_Strikes_Clinch Total Strikes_Landed", "B__Round2_Strikes_Distance Body Kicks_Attempts", "B__Round2_Strikes_Distance Body Kicks_Landed", "B__Round2_Strikes_Distance Body Punches_Attempts", "B__Round2_Strikes_Distance Body Punches_Landed", "B__Round2_Strikes_Distance Body Strikes_Attempts", "B__Round2_Strikes_Distance Body Strikes_Landed", "B__Round2_Strikes_Distance Head Kicks_Attempts", "B__Round2_Strikes_Distance Head Kicks_Landed", "B__Round2_Strikes_Distance Head Punches_Attempts", "B__Round2_Strikes_Distance Head Punches_Landed", "B__Round2_Strikes_Distance Head Strikes_Attempts", "B__Round2_Strikes_Distance Head Strikes_Landed", "B__Round2_Strikes_Distance Leg Kicks_Attempts", "B__Round2_Strikes_Distance Leg Kicks_Landed", "B__Round2_Strikes_Distance Leg Strikes_Attempts", "B__Round2_Strikes_Distance Leg Strikes_Landed", "B__Round2_Strikes_Distance Strikes_Attempts", "B__Round2_Strikes_Distance Strikes_Landed", "B__Round2_Strikes_Ground Body Strikes_Attempts", "B__Round2_Strikes_Ground Body Strikes_Landed", "B__Round2_Strikes_Ground Head Strikes_Attempts", "B__Round2_Strikes_Ground Head Strikes_Landed", "B__Round2_Strikes_Ground Leg Strikes_Attempts", "B__Round2_Strikes_Ground Leg Strikes_Landed", "B__Round2_Strikes_Ground Significant Kicks_Attempts", "B__Round2_Strikes_Ground Significant Kicks_Landed", "B__Round2_Strikes_Ground Significant Punches_Attempts", "B__Round2_Strikes_Ground Significant Punches_Landed", "B__Round2_Strikes_Ground Significant Strikes_Attempts", "B__Round2_Strikes_Ground Significant Strikes_Landed", "B__Round2_Strikes_Ground Total Strikes_Attempts", "B__Round2_Strikes_Ground Total Strikes_Landed", "B__Round2_Strikes_Head Significant Strikes_Attempts", "B__Round2_Strikes_Head Significant Strikes_Landed", "B__Round2_Strikes_Head Total Strikes_Attempts", "B__Round2_Strikes_Head Total Strikes_Landed", "B__Round2_Strikes_Kicks_Attempts", "B__Round2_Strikes_Kicks_Landed", "B__Round2_Strikes_Knock Down_Landed", "B__Round2_Strikes_Leg Total Strikes_Attempts", "B__Round2_Strikes_Leg Total Strikes_Landed", "B__Round2_Strikes_Legs Significant Strikes_Attempts", "B__Round2_Strikes_Legs Significant Strikes_Landed", "B__Round2_Strikes_Legs Total Strikes_Attempts", "B__Round2_Strikes_Legs Total Strikes_Landed", "B__Round2_Strikes_Punches_Attempts", "B__Round2_Strikes_Punches_Landed", "B__Round2_Strikes_Significant Strikes_Attempts", "B__Round2_Strikes_Significant Strikes_Landed", "B__Round2_Strikes_Total Strikes_Attempts", "B__Round2_Strikes_Total Strikes_Landed", "B__Round2_TIP_Back Control Time", "B__Round2_TIP_Clinch Time", "B__Round2_TIP_Control Time", "B__Round2_TIP_Distance Time", "B__Round2_TIP_Ground Control Time", "B__Round2_TIP_Ground Time", "B__Round2_TIP_Guard Control Time", "B__Round2_TIP_Half Guard Control Time", "B__Round2_TIP_Misc. Ground Control Time", "B__Round2_TIP_Mount Control Time", "B__Round2_TIP_Neutral Time", "B__Round2_TIP_Side Control Time", "B__Round2_TIP_Standing Time", "B__Round3_Grappling_Reversals_Landed", "B__Round3_Grappling_Standups_Landed", "B__Round3_Grappling_Submissions_Attempts", "B__Round3_Grappling_Takedowns_Attempts", "B__Round3_Grappling_Takedowns_Landed", "B__Round3_Strikes_Body Significant Strikes_Attempts", "B__Round3_Strikes_Body Significant Strikes_Landed", "B__Round3_Strikes_Body Total Strikes_Attempts", "B__Round3_Strikes_Body Total Strikes_Landed", "B__Round3_Strikes_Clinch Body Strikes_Attempts", "B__Round3_Strikes_Clinch Body Strikes_Landed", "B__Round3_Strikes_Clinch Head Strikes_Attempts", "B__Round3_Strikes_Clinch Head Strikes_Landed", "B__Round3_Strikes_Clinch Leg Strikes_Attempts", "B__Round3_Strikes_Clinch Leg Strikes_Landed", "B__Round3_Strikes_Clinch Significant Kicks_Attempts", "B__Round3_Strikes_Clinch Significant Kicks_Landed", "B__Round3_Strikes_Clinch Significant Punches_Attempts", "B__Round3_Strikes_Clinch Significant Punches_Landed", "B__Round3_Strikes_Clinch Significant Strikes_Attempts", "B__Round3_Strikes_Clinch Significant Strikes_Landed", "B__Round3_Strikes_Clinch Total Strikes_Attempts", "B__Round3_Strikes_Clinch Total Strikes_Landed", "B__Round3_Strikes_Distance Body Kicks_Attempts", "B__Round3_Strikes_Distance Body Kicks_Landed", "B__Round3_Strikes_Distance Body Punches_Attempts", "B__Round3_Strikes_Distance Body Punches_Landed", "B__Round3_Strikes_Distance Body Strikes_Attempts", "B__Round3_Strikes_Distance Body Strikes_Landed", "B__Round3_Strikes_Distance Head Kicks_Attempts", "B__Round3_Strikes_Distance Head Kicks_Landed", "B__Round3_Strikes_Distance Head Punches_Attempts", "B__Round3_Strikes_Distance Head Punches_Landed", "B__Round3_Strikes_Distance Head Strikes_Attempts", "B__Round3_Strikes_Distance Head Strikes_Landed", "B__Round3_Strikes_Distance Leg Kicks_Attempts", "B__Round3_Strikes_Distance Leg Kicks_Landed", "B__Round3_Strikes_Distance Leg Strikes_Attempts", "B__Round3_Strikes_Distance Leg Strikes_Landed", "B__Round3_Strikes_Distance Strikes_Attempts", "B__Round3_Strikes_Distance Strikes_Landed", "B__Round3_Strikes_Ground Body Strikes_Attempts", "B__Round3_Strikes_Ground Body Strikes_Landed", "B__Round3_Strikes_Ground Head Strikes_Attempts", "B__Round3_Strikes_Ground Head Strikes_Landed", "B__Round3_Strikes_Ground Leg Strikes_Attempts", "B__Round3_Strikes_Ground Leg Strikes_Landed", "B__Round3_Strikes_Ground Significant Kicks_Attempts", "B__Round3_Strikes_Ground Significant Kicks_Landed", "B__Round3_Strikes_Ground Significant Punches_Attempts", "B__Round3_Strikes_Ground Significant Punches_Landed", "B__Round3_Strikes_Ground Significant Strikes_Attempts", "B__Round3_Strikes_Ground Significant Strikes_Landed", "B__Round3_Strikes_Ground Total Strikes_Attempts", "B__Round3_Strikes_Ground Total Strikes_Landed", "B__Round3_Strikes_Head Significant Strikes_Attempts", "B__Round3_Strikes_Head Significant Strikes_Landed", "B__Round3_Strikes_Head Total Strikes_Attempts", "B__Round3_Strikes_Head Total Strikes_Landed", "B__Round3_Strikes_Kicks_Attempts", "B__Round3_Strikes_Kicks_Landed", "B__Round3_Strikes_Knock Down_Landed", "B__Round3_Strikes_Leg Total Strikes_Attempts", "B__Round3_Strikes_Leg Total Strikes_Landed", "B__Round3_Strikes_Legs Significant Strikes_Attempts", "B__Round3_Strikes_Legs Significant Strikes_Landed", "B__Round3_Strikes_Legs Total Strikes_Attempts", "B__Round3_Strikes_Legs Total Strikes_Landed", "B__Round3_Strikes_Punches_Attempts", "B__Round3_Strikes_Punches_Landed", "B__Round3_Strikes_Significant Strikes_Attempts", "B__Round3_Strikes_Significant Strikes_Landed", "B__Round3_Strikes_Total Strikes_Attempts", "B__Round3_Strikes_Total Strikes_Landed", "B__Round3_TIP_Back Control Time", "B__Round3_TIP_Clinch Time", "B__Round3_TIP_Control Time", "B__Round3_TIP_Distance Time", "B__Round3_TIP_Ground Control Time", "B__Round3_TIP_Ground Time", "B__Round3_TIP_Guard Control Time", "B__Round3_TIP_Half Guard Control Time", "B__Round3_TIP_Misc. Ground Control Time", "B__Round3_TIP_Mount Control Time", "B__Round3_TIP_Neutral Time", "B__Round3_TIP_Side Control Time", "B__Round3_TIP_Standing Time", "B__Round4_Grappling_Reversals_Landed", "B__Round4_Grappling_Standups_Landed", "B__Round4_Grappling_Submissions_Attempts", "B__Round4_Grappling_Takedowns_Attempts", "B__Round4_Grappling_Takedowns_Landed", "B__Round4_Strikes_Body Significant Strikes_Attempts", "B__Round4_Strikes_Body Significant Strikes_Landed", "B__Round4_Strikes_Body Total Strikes_Attempts", "B__Round4_Strikes_Body Total Strikes_Landed", "B__Round4_Strikes_Clinch Body Strikes_Attempts", "B__Round4_Strikes_Clinch Body Strikes_Landed", "B__Round4_Strikes_Clinch Head Strikes_Attempts", "B__Round4_Strikes_Clinch Head Strikes_Landed", "B__Round4_Strikes_Clinch Leg Strikes_Attempts", "B__Round4_Strikes_Clinch Leg Strikes_Landed", "B__Round4_Strikes_Clinch Significant Kicks_Attempts", "B__Round4_Strikes_Clinch Significant Kicks_Landed", "B__Round4_Strikes_Clinch Significant Punches_Attempts", "B__Round4_Strikes_Clinch Significant Punches_Landed", "B__Round4_Strikes_Clinch Significant Strikes_Attempts", "B__Round4_Strikes_Clinch Significant Strikes_Landed", "B__Round4_Strikes_Clinch Total Strikes_Attempts", "B__Round4_Strikes_Clinch Total Strikes_Landed", "B__Round4_Strikes_Distance Body Kicks_Attempts", "B__Round4_Strikes_Distance Body Kicks_Landed", "B__Round4_Strikes_Distance Body Punches_Attempts", "B__Round4_Strikes_Distance Body Punches_Landed", "B__Round4_Strikes_Distance Body Strikes_Attempts", "B__Round4_Strikes_Distance Body Strikes_Landed", "B__Round4_Strikes_Distance Head Kicks_Attempts", "B__Round4_Strikes_Distance Head Kicks_Landed", "B__Round4_Strikes_Distance Head Punches_Attempts", "B__Round4_Strikes_Distance Head Punches_Landed", "B__Round4_Strikes_Distance Head Strikes_Attempts", "B__Round4_Strikes_Distance Head Strikes_Landed", "B__Round4_Strikes_Distance Leg Kicks_Attempts", "B__Round4_Strikes_Distance Leg Kicks_Landed", "B__Round4_Strikes_Distance Leg Strikes_Attempts", "B__Round4_Strikes_Distance Leg Strikes_Landed", "B__Round4_Strikes_Distance Strikes_Attempts", "B__Round4_Strikes_Distance Strikes_Landed", "B__Round4_Strikes_Ground Body Strikes_Attempts", "B__Round4_Strikes_Ground Body Strikes_Landed", "B__Round4_Strikes_Ground Head Strikes_Attempts", "B__Round4_Strikes_Ground Head Strikes_Landed", "B__Round4_Strikes_Ground Leg Strikes_Attempts", "B__Round4_Strikes_Ground Leg Strikes_Landed", "B__Round4_Strikes_Ground Significant Kicks_Attempts", "B__Round4_Strikes_Ground Significant Kicks_Landed", "B__Round4_Strikes_Ground Significant Punches_Attempts", "B__Round4_Strikes_Ground Significant Punches_Landed", "B__Round4_Strikes_Ground Significant Strikes_Attempts", "B__Round4_Strikes_Ground Significant Strikes_Landed", "B__Round4_Strikes_Ground Total Strikes_Attempts", "B__Round4_Strikes_Ground Total Strikes_Landed", "B__Round4_Strikes_Head Significant Strikes_Attempts", "B__Round4_Strikes_Head Significant Strikes_Landed", "B__Round4_Strikes_Head Total Strikes_Attempts", "B__Round4_Strikes_Head Total Strikes_Landed", "B__Round4_Strikes_Kicks_Attempts", "B__Round4_Strikes_Kicks_Landed", "B__Round4_Strikes_Knock Down_Landed", "B__Round4_Strikes_Leg Total Strikes_Attempts", "B__Round4_Strikes_Leg Total Strikes_Landed", "B__Round4_Strikes_Legs Significant Strikes_Attempts", "B__Round4_Strikes_Legs Significant Strikes_Landed", "B__Round4_Strikes_Legs Total Strikes_Attempts", "B__Round4_Strikes_Legs Total Strikes_Landed", "B__Round4_Strikes_Punches_Attempts", "B__Round4_Strikes_Punches_Landed", "B__Round4_Strikes_Significant Strikes_Attempts", "B__Round4_Strikes_Significant Strikes_Landed", "B__Round4_Strikes_Total Strikes_Attempts", "B__Round4_Strikes_Total Strikes_Landed", "B__Round4_TIP_Back Control Time", "B__Round4_TIP_Clinch Time", "B__Round4_TIP_Control Time", "B__Round4_TIP_Distance Time", "B__Round4_TIP_Ground Control Time", "B__Round4_TIP_Ground Time", "B__Round4_TIP_Guard Control Time", "B__Round4_TIP_Half Guard Control Time", "B__Round4_TIP_Misc. Ground Control Time", "B__Round4_TIP_Mount Control Time", "B__Round4_TIP_Neutral Time", "B__Round4_TIP_Side Control Time", "B__Round4_TIP_Standing Time", "B__Round5_Grappling_Reversals_Landed", "B__Round5_Grappling_Standups_Landed", "B__Round5_Grappling_Submissions_Attempts", "B__Round5_Grappling_Takedowns_Attempts", "B__Round5_Grappling_Takedowns_Landed", "B__Round5_Strikes_Body Significant Strikes_Attempts", "B__Round5_Strikes_Body Significant Strikes_Landed", "B__Round5_Strikes_Body Total Strikes_Attempts", "B__Round5_Strikes_Body Total Strikes_Landed", "B__Round5_Strikes_Clinch Body Strikes_Attempts", "B__Round5_Strikes_Clinch Body Strikes_Landed", "B__Round5_Strikes_Clinch Head Strikes_Attempts", "B__Round5_Strikes_Clinch Head Strikes_Landed", "B__Round5_Strikes_Clinch Leg Strikes_Attempts", "B__Round5_Strikes_Clinch Leg Strikes_Landed", "B__Round5_Strikes_Clinch Significant Kicks_Attempts", "B__Round5_Strikes_Clinch Significant Kicks_Landed", "B__Round5_Strikes_Clinch Significant Punches_Attempts", "B__Round5_Strikes_Clinch Significant Punches_Landed", "B__Round5_Strikes_Clinch Significant Strikes_Attempts", "B__Round5_Strikes_Clinch Significant Strikes_Landed", "B__Round5_Strikes_Clinch Total Strikes_Attempts", "B__Round5_Strikes_Clinch Total Strikes_Landed", "B__Round5_Strikes_Distance Body Kicks_Attempts", "B__Round5_Strikes_Distance Body Kicks_Landed", "B__Round5_Strikes_Distance Body Punches_Attempts", "B__Round5_Strikes_Distance Body Punches_Landed", "B__Round5_Strikes_Distance Body Strikes_Attempts", "B__Round5_Strikes_Distance Body Strikes_Landed", "B__Round5_Strikes_Distance Head Kicks_Attempts", "B__Round5_Strikes_Distance Head Kicks_Landed", "B__Round5_Strikes_Distance Head Punches_Attempts", "B__Round5_Strikes_Distance Head Punches_Landed", "B__Round5_Strikes_Distance Head Strikes_Attempts", "B__Round5_Strikes_Distance Head Strikes_Landed", "B__Round5_Strikes_Distance Leg Kicks_Attempts", "B__Round5_Strikes_Distance Leg Kicks_Landed", "B__Round5_Strikes_Distance Leg Strikes_Attempts", "B__Round5_Strikes_Distance Leg Strikes_Landed", "B__Round5_Strikes_Distance Strikes_Attempts", "B__Round5_Strikes_Distance Strikes_Landed", "B__Round5_Strikes_Ground Body Strikes_Attempts", "B__Round5_Strikes_Ground Body Strikes_Landed", "B__Round5_Strikes_Ground Head Strikes_Attempts", "B__Round5_Strikes_Ground Head Strikes_Landed", "B__Round5_Strikes_Ground Leg Strikes_Attempts", "B__Round5_Strikes_Ground Leg Strikes_Landed", "B__Round5_Strikes_Ground Significant Kicks_Attempts", "B__Round5_Strikes_Ground Significant Kicks_Landed", "B__Round5_Strikes_Ground Significant Punches_Attempts", "B__Round5_Strikes_Ground Significant Punches_Landed", "B__Round5_Strikes_Ground Significant Strikes_Attempts", "B__Round5_Strikes_Ground Significant Strikes_Landed", "B__Round5_Strikes_Ground Total Strikes_Attempts", "B__Round5_Strikes_Ground Total Strikes_Landed", "B__Round5_Strikes_Head Significant Strikes_Attempts", "B__Round5_Strikes_Head Significant Strikes_Landed", "B__Round5_Strikes_Head Total Strikes_Attempts", "B__Round5_Strikes_Head Total Strikes_Landed", "B__Round5_Strikes_Kicks_Attempts", "B__Round5_Strikes_Kicks_Landed", "B__Round5_Strikes_Knock Down_Landed", "B__Round5_Strikes_Leg Total Strikes_Attempts", "B__Round5_Strikes_Leg Total Strikes_Landed", "B__Round5_Strikes_Legs Significant Strikes_Attempts", "B__Round5_Strikes_Legs Significant Strikes_Landed", "B__Round5_Strikes_Legs Total Strikes_Attempts", "B__Round5_Strikes_Legs Total Strikes_Landed", "B__Round5_Strikes_Punches_Attempts", "B__Round5_Strikes_Punches_Landed", "B__Round5_Strikes_Significant Strikes_Attempts", "B__Round5_Strikes_Significant Strikes_Landed", "B__Round5_Strikes_Total Strikes_Attempts", "B__Round5_Strikes_Total Strikes_Landed", "B__Round5_TIP_Back Control Time", "B__Round5_TIP_Clinch Time", "B__Round5_TIP_Control Time", "B__Round5_TIP_Distance Time", "B__Round5_TIP_Ground Control Time", "B__Round5_TIP_Ground Time", "B__Round5_TIP_Guard Control Time", "B__Round5_TIP_Half Guard Control Time", "B__Round5_TIP_Misc. Ground Control Time", "B__Round5_TIP_Mount Control Time", "B__Round5_TIP_Neutral Time", "B__Round5_TIP_Side Control Time", "B__Round5_TIP_Standing Time", "RPrev", "RStreak", "R_Age", "R_Height", "R_Name", "R_Weight", "R__Round1_Grappling_Reversals_Landed", "R__Round1_Grappling_Standups_Landed", "R__Round1_Grappling_Submissions_Attempts", "R__Round1_Grappling_Takedowns_Attempts", "R__Round1_Grappling_Takedowns_Landed", "R__Round1_Strikes_Body Significant Strikes_Attempts", "R__Round1_Strikes_Body Significant Strikes_Landed", "R__Round1_Strikes_Body Total Strikes_Attempts", "R__Round1_Strikes_Body Total Strikes_Landed", "R__Round1_Strikes_Clinch Body Strikes_Attempts", "R__Round1_Strikes_Clinch Body Strikes_Landed", "R__Round1_Strikes_Clinch Head Strikes_Attempts", "R__Round1_Strikes_Clinch Head Strikes_Landed", "R__Round1_Strikes_Clinch Leg Strikes_Attempts", "R__Round1_Strikes_Clinch Leg Strikes_Landed", "R__Round1_Strikes_Clinch Significant Kicks_Attempts", "R__Round1_Strikes_Clinch Significant Kicks_Landed", "R__Round1_Strikes_Clinch Significant Punches_Attempts", "R__Round1_Strikes_Clinch Significant Punches_Landed", "R__Round1_Strikes_Clinch Significant Strikes_Attempts", "R__Round1_Strikes_Clinch Significant Strikes_Landed", "R__Round1_Strikes_Clinch Total Strikes_Attempts", "R__Round1_Strikes_Clinch Total Strikes_Landed", "R__Round1_Strikes_Distance Body Kicks_Attempts", "R__Round1_Strikes_Distance Body Kicks_Landed", "R__Round1_Strikes_Distance Body Punches_Attempts", "R__Round1_Strikes_Distance Body Punches_Landed", "R__Round1_Strikes_Distance Body Strikes_Attempts", "R__Round1_Strikes_Distance Body Strikes_Landed", "R__Round1_Strikes_Distance Head Kicks_Attempts", "R__Round1_Strikes_Distance Head Kicks_Landed", "R__Round1_Strikes_Distance Head Punches_Attempts", "R__Round1_Strikes_Distance Head Punches_Landed", "R__Round1_Strikes_Distance Head Strikes_Attempts", "R__Round1_Strikes_Distance Head Strikes_Landed", "R__Round1_Strikes_Distance Leg Kicks_Attempts", "R__Round1_Strikes_Distance Leg Kicks_Landed", "R__Round1_Strikes_Distance Leg Strikes_Attempts", "R__Round1_Strikes_Distance Leg Strikes_Landed", "R__Round1_Strikes_Distance Strikes_Attempts", "R__Round1_Strikes_Distance Strikes_Landed", "R__Round1_Strikes_Ground Body Strikes_Attempts", "R__Round1_Strikes_Ground Body Strikes_Landed", "R__Round1_Strikes_Ground Head Strikes_Attempts", "R__Round1_Strikes_Ground Head Strikes_Landed", "R__Round1_Strikes_Ground Leg Strikes_Attempts", "R__Round1_Strikes_Ground Leg Strikes_Landed", "R__Round1_Strikes_Ground Significant Kicks_Attempts", "R__Round1_Strikes_Ground Significant Kicks_Landed", "R__Round1_Strikes_Ground Significant Punches_Attempts", "R__Round1_Strikes_Ground Significant Punches_Landed", "R__Round1_Strikes_Ground Significant Strikes_Attempts", "R__Round1_Strikes_Ground Significant Strikes_Landed", "R__Round1_Strikes_Ground Total Strikes_Attempts", "R__Round1_Strikes_Ground Total Strikes_Landed", "R__Round1_Strikes_Head Significant Strikes_Attempts", "R__Round1_Strikes_Head Significant Strikes_Landed", "R__Round1_Strikes_Head Total Strikes_Attempts", "R__Round1_Strikes_Head Total Strikes_Landed", "R__Round1_Strikes_Kicks_Attempts", "R__Round1_Strikes_Kicks_Landed", "R__Round1_Strikes_Knock Down_Landed", "R__Round1_Strikes_Leg Total Strikes_Attempts", "R__Round1_Strikes_Leg Total Strikes_Landed", "R__Round1_Strikes_Legs Significant Strikes_Attempts", "R__Round1_Strikes_Legs Significant Strikes_Landed", "R__Round1_Strikes_Legs Total Strikes_Attempts", "R__Round1_Strikes_Legs Total Strikes_Landed", "R__Round1_Strikes_Punches_Attempts", "R__Round1_Strikes_Punches_Landed", "R__Round1_Strikes_Significant Strikes_Attempts", "R__Round1_Strikes_Significant Strikes_Landed", "R__Round1_Strikes_Total Strikes_Attempts", "R__Round1_Strikes_Total Strikes_Landed", "R__Round1_TIP_Back Control Time", "R__Round1_TIP_Clinch Time", "R__Round1_TIP_Control Time", "R__Round1_TIP_Distance Time", "R__Round1_TIP_Ground Control Time", "R__Round1_TIP_Ground Time", "R__Round1_TIP_Guard Control Time", "R__Round1_TIP_Half Guard Control Time", "R__Round1_TIP_Misc. Ground Control Time", "R__Round1_TIP_Mount Control Time", "R__Round1_TIP_Neutral Time", "R__Round1_TIP_Side Control Time", "R__Round1_TIP_Standing Time", "R__Round2_Grappling_Reversals_Landed", "R__Round2_Grappling_Standups_Landed", "R__Round2_Grappling_Submissions_Attempts", "R__Round2_Grappling_Takedowns_Attempts", "R__Round2_Grappling_Takedowns_Landed", "R__Round2_Strikes_Body Significant Strikes_Attempts", "R__Round2_Strikes_Body Significant Strikes_Landed", "R__Round2_Strikes_Body Total Strikes_Attempts", "R__Round2_Strikes_Body Total Strikes_Landed", "R__Round2_Strikes_Clinch Body Strikes_Attempts", "R__Round2_Strikes_Clinch Body Strikes_Landed", "R__Round2_Strikes_Clinch Head Strikes_Attempts", "R__Round2_Strikes_Clinch Head Strikes_Landed", "R__Round2_Strikes_Clinch Leg Strikes_Attempts", "R__Round2_Strikes_Clinch Leg Strikes_Landed", "R__Round2_Strikes_Clinch Significant Kicks_Attempts", "R__Round2_Strikes_Clinch Significant Kicks_Landed", "R__Round2_Strikes_Clinch Significant Punches_Attempts", "R__Round2_Strikes_Clinch Significant Punches_Landed", "R__Round2_Strikes_Clinch Significant Strikes_Attempts", "R__Round2_Strikes_Clinch Significant Strikes_Landed", "R__Round2_Strikes_Clinch Total Strikes_Attempts", "R__Round2_Strikes_Clinch Total Strikes_Landed", "R__Round2_Strikes_Distance Body Kicks_Attempts", "R__Round2_Strikes_Distance Body Kicks_Landed", "R__Round2_Strikes_Distance Body Punches_Attempts", "R__Round2_Strikes_Distance Body Punches_Landed", "R__Round2_Strikes_Distance Body Strikes_Attempts", "R__Round2_Strikes_Distance Body Strikes_Landed", "R__Round2_Strikes_Distance Head Kicks_Attempts", "R__Round2_Strikes_Distance Head Kicks_Landed", "R__Round2_Strikes_Distance Head Punches_Attempts", "R__Round2_Strikes_Distance Head Punches_Landed", "R__Round2_Strikes_Distance Head Strikes_Attempts", "R__Round2_Strikes_Distance Head Strikes_Landed", "R__Round2_Strikes_Distance Leg Kicks_Attempts", "R__Round2_Strikes_Distance Leg Kicks_Landed", "R__Round2_Strikes_Distance Leg Strikes_Attempts", "R__Round2_Strikes_Distance Leg Strikes_Landed", "R__Round2_Strikes_Distance Strikes_Attempts", "R__Round2_Strikes_Distance Strikes_Landed", "R__Round2_Strikes_Ground Body Strikes_Attempts", "R__Round2_Strikes_Ground Body Strikes_Landed", "R__Round2_Strikes_Ground Head Strikes_Attempts", "R__Round2_Strikes_Ground Head Strikes_Landed", "R__Round2_Strikes_Ground Leg Strikes_Attempts", "R__Round2_Strikes_Ground Leg Strikes_Landed", "R__Round2_Strikes_Ground Significant Kicks_Attempts", "R__Round2_Strikes_Ground Significant Kicks_Landed", "R__Round2_Strikes_Ground Significant Punches_Attempts", "R__Round2_Strikes_Ground Significant Punches_Landed", "R__Round2_Strikes_Ground Significant Strikes_Attempts", "R__Round2_Strikes_Ground Significant Strikes_Landed", "R__Round2_Strikes_Ground Total Strikes_Attempts", "R__Round2_Strikes_Ground Total Strikes_Landed", "R__Round2_Strikes_Head Significant Strikes_Attempts", "R__Round2_Strikes_Head Significant Strikes_Landed", "R__Round2_Strikes_Head Total Strikes_Attempts", "R__Round2_Strikes_Head Total Strikes_Landed", "R__Round2_Strikes_Kicks_Attempts", "R__Round2_Strikes_Kicks_Landed", "R__Round2_Strikes_Knock Down_Landed", "R__Round2_Strikes_Leg Total Strikes_Attempts", "R__Round2_Strikes_Leg Total Strikes_Landed", "R__Round2_Strikes_Legs Significant Strikes_Attempts", "R__Round2_Strikes_Legs Significant Strikes_Landed", "R__Round2_Strikes_Legs Total Strikes_Attempts", "R__Round2_Strikes_Legs Total Strikes_Landed", "R__Round2_Strikes_Punches_Attempts", "R__Round2_Strikes_Punches_Landed", "R__Round2_Strikes_Significant Strikes_Attempts", "R__Round2_Strikes_Significant Strikes_Landed", "R__Round2_Strikes_Total Strikes_Attempts", "R__Round2_Strikes_Total Strikes_Landed", "R__Round2_TIP_Back Control Time", "R__Round2_TIP_Clinch Time", "R__Round2_TIP_Control Time", "R__Round2_TIP_Distance Time", "R__Round2_TIP_Ground Control Time", "R__Round2_TIP_Ground Time", "R__Round2_TIP_Guard Control Time", "R__Round2_TIP_Half Guard Control Time", "R__Round2_TIP_Misc. Ground Control Time", "R__Round2_TIP_Mount Control Time", "R__Round2_TIP_Neutral Time", "R__Round2_TIP_Side Control Time", "R__Round2_TIP_Standing Time", "R__Round3_Grappling_Reversals_Landed", "R__Round3_Grappling_Standups_Landed", "R__Round3_Grappling_Submissions_Attempts", "R__Round3_Grappling_Takedowns_Attempts", "R__Round3_Grappling_Takedowns_Landed", "R__Round3_Strikes_Body Significant Strikes_Attempts", "R__Round3_Strikes_Body Significant Strikes_Landed", "R__Round3_Strikes_Body Total Strikes_Attempts", "R__Round3_Strikes_Body Total Strikes_Landed", "R__Round3_Strikes_Clinch Body Strikes_Attempts", "R__Round3_Strikes_Clinch Body Strikes_Landed", "R__Round3_Strikes_Clinch Head Strikes_Attempts", "R__Round3_Strikes_Clinch Head Strikes_Landed", "R__Round3_Strikes_Clinch Leg Strikes_Attempts", "R__Round3_Strikes_Clinch Leg Strikes_Landed", "R__Round3_Strikes_Clinch Significant Kicks_Attempts", "R__Round3_Strikes_Clinch Significant Kicks_Landed", "R__Round3_Strikes_Clinch Significant Punches_Attempts", "R__Round3_Strikes_Clinch Significant Punches_Landed", "R__Round3_Strikes_Clinch Significant Strikes_Attempts", "R__Round3_Strikes_Clinch Significant Strikes_Landed", "R__Round3_Strikes_Clinch Total Strikes_Attempts", "R__Round3_Strikes_Clinch Total Strikes_Landed", "R__Round3_Strikes_Distance Body Kicks_Attempts", "R__Round3_Strikes_Distance Body Kicks_Landed", "R__Round3_Strikes_Distance Body Punches_Attempts", "R__Round3_Strikes_Distance Body Punches_Landed", "R__Round3_Strikes_Distance Body Strikes_Attempts", "R__Round3_Strikes_Distance Body Strikes_Landed", "R__Round3_Strikes_Distance Head Kicks_Attempts", "R__Round3_Strikes_Distance Head Kicks_Landed", "R__Round3_Strikes_Distance Head Punches_Attempts", "R__Round3_Strikes_Distance Head Punches_Landed", "R__Round3_Strikes_Distance Head Strikes_Attempts", "R__Round3_Strikes_Distance Head Strikes_Landed", "R__Round3_Strikes_Distance Leg Kicks_Attempts", "R__Round3_Strikes_Distance Leg Kicks_Landed", "R__Round3_Strikes_Distance Leg Strikes_Attempts", "R__Round3_Strikes_Distance Leg Strikes_Landed", "R__Round3_Strikes_Distance Strikes_Attempts", "R__Round3_Strikes_Distance Strikes_Landed", "R__Round3_Strikes_Ground Body Strikes_Attempts", "R__Round3_Strikes_Ground Body Strikes_Landed", "R__Round3_Strikes_Ground Head Strikes_Attempts", "R__Round3_Strikes_Ground Head Strikes_Landed", "R__Round3_Strikes_Ground Leg Strikes_Attempts", "R__Round3_Strikes_Ground Leg Strikes_Landed", "R__Round3_Strikes_Ground Significant Kicks_Attempts", "R__Round3_Strikes_Ground Significant Kicks_Landed", "R__Round3_Strikes_Ground Significant Punches_Attempts", "R__Round3_Strikes_Ground Significant Punches_Landed", "R__Round3_Strikes_Ground Significant Strikes_Attempts", "R__Round3_Strikes_Ground Significant Strikes_Landed", "R__Round3_Strikes_Ground Total Strikes_Attempts", "R__Round3_Strikes_Ground Total Strikes_Landed", "R__Round3_Strikes_Head Significant Strikes_Attempts", "R__Round3_Strikes_Head Significant Strikes_Landed", "R__Round3_Strikes_Head Total Strikes_Attempts", "R__Round3_Strikes_Head Total Strikes_Landed", "R__Round3_Strikes_Kicks_Attempts", "R__Round3_Strikes_Kicks_Landed", "R__Round3_Strikes_Knock Down_Landed", "R__Round3_Strikes_Leg Total Strikes_Attempts", "R__Round3_Strikes_Leg Total Strikes_Landed", "R__Round3_Strikes_Legs Significant Strikes_Attempts", "R__Round3_Strikes_Legs Significant Strikes_Landed", "R__Round3_Strikes_Legs Total Strikes_Attempts", "R__Round3_Strikes_Legs Total Strikes_Landed", "R__Round3_Strikes_Punches_Attempts", "R__Round3_Strikes_Punches_Landed", "R__Round3_Strikes_Significant Strikes_Attempts", "R__Round3_Strikes_Significant Strikes_Landed", "R__Round3_Strikes_Total Strikes_Attempts", "R__Round3_Strikes_Total Strikes_Landed", "R__Round3_TIP_Back Control Time", "R__Round3_TIP_Clinch Time", "R__Round3_TIP_Control Time", "R__Round3_TIP_Distance Time", "R__Round3_TIP_Ground Control Time", "R__Round3_TIP_Ground Time", "R__Round3_TIP_Guard Control Time", "R__Round3_TIP_Half Guard Control Time", "R__Round3_TIP_Misc. Ground Control Time", "R__Round3_TIP_Mount Control Time", "R__Round3_TIP_Neutral Time", "R__Round3_TIP_Side Control Time", "R__Round3_TIP_Standing Time", "R__Round4_Grappling_Reversals_Landed", "R__Round4_Grappling_Standups_Landed", "R__Round4_Grappling_Submissions_Attempts", "R__Round4_Grappling_Takedowns_Attempts", "R__Round4_Grappling_Takedowns_Landed", "R__Round4_Strikes_Body Significant Strikes_Attempts", "R__Round4_Strikes_Body Significant Strikes_Landed", "R__Round4_Strikes_Body Total Strikes_Attempts", "R__Round4_Strikes_Body Total Strikes_Landed", "R__Round4_Strikes_Clinch Body Strikes_Attempts", "R__Round4_Strikes_Clinch Body Strikes_Landed", "R__Round4_Strikes_Clinch Head Strikes_Attempts", "R__Round4_Strikes_Clinch Head Strikes_Landed", "R__Round4_Strikes_Clinch Leg Strikes_Attempts", "R__Round4_Strikes_Clinch Leg Strikes_Landed", "R__Round4_Strikes_Clinch Significant Kicks_Attempts", "R__Round4_Strikes_Clinch Significant Kicks_Landed", "R__Round4_Strikes_Clinch Significant Punches_Attempts", "R__Round4_Strikes_Clinch Significant Punches_Landed", "R__Round4_Strikes_Clinch Significant Strikes_Attempts", "R__Round4_Strikes_Clinch Significant Strikes_Landed", "R__Round4_Strikes_Clinch Total Strikes_Attempts", "R__Round4_Strikes_Clinch Total Strikes_Landed", "R__Round4_Strikes_Distance Body Kicks_Attempts", "R__Round4_Strikes_Distance Body Kicks_Landed", "R__Round4_Strikes_Distance Body Punches_Attempts", "R__Round4_Strikes_Distance Body Punches_Landed", "R__Round4_Strikes_Distance Body Strikes_Attempts", "R__Round4_Strikes_Distance Body Strikes_Landed", "R__Round4_Strikes_Distance Head Kicks_Attempts", "R__Round4_Strikes_Distance Head Kicks_Landed", "R__Round4_Strikes_Distance Head Punches_Attempts", "R__Round4_Strikes_Distance Head Punches_Landed", "R__Round4_Strikes_Distance Head Strikes_Attempts", "R__Round4_Strikes_Distance Head Strikes_Landed", "R__Round4_Strikes_Distance Leg Kicks_Attempts", "R__Round4_Strikes_Distance Leg Kicks_Landed", "R__Round4_Strikes_Distance Leg Strikes_Attempts", "R__Round4_Strikes_Distance Leg Strikes_Landed", "R__Round4_Strikes_Distance Strikes_Attempts", "R__Round4_Strikes_Distance Strikes_Landed", "R__Round4_Strikes_Ground Body Strikes_Attempts", "R__Round4_Strikes_Ground Body Strikes_Landed", "R__Round4_Strikes_Ground Head Strikes_Attempts", "R__Round4_Strikes_Ground Head Strikes_Landed", "R__Round4_Strikes_Ground Leg Strikes_Attempts", "R__Round4_Strikes_Ground Leg Strikes_Landed", "R__Round4_Strikes_Ground Significant Kicks_Attempts", "R__Round4_Strikes_Ground Significant Kicks_Landed", "R__Round4_Strikes_Ground Significant Punches_Attempts", "R__Round4_Strikes_Ground Significant Punches_Landed", "R__Round4_Strikes_Ground Significant Strikes_Attempts", "R__Round4_Strikes_Ground Significant Strikes_Landed", "R__Round4_Strikes_Ground Total Strikes_Attempts", "R__Round4_Strikes_Ground Total Strikes_Landed", "R__Round4_Strikes_Head Significant Strikes_Attempts", "R__Round4_Strikes_Head Significant Strikes_Landed", "R__Round4_Strikes_Head Total Strikes_Attempts", "R__Round4_Strikes_Head Total Strikes_Landed", "R__Round4_Strikes_Kicks_Attempts", "R__Round4_Strikes_Kicks_Landed", "R__Round4_Strikes_Knock Down_Landed", "R__Round4_Strikes_Leg Total Strikes_Attempts", "R__Round4_Strikes_Leg Total Strikes_Landed", "R__Round4_Strikes_Legs Significant Strikes_Attempts", "R__Round4_Strikes_Legs Significant Strikes_Landed", "R__Round4_Strikes_Legs Total Strikes_Attempts", "R__Round4_Strikes_Legs Total Strikes_Landed", "R__Round4_Strikes_Punches_Attempts", "R__Round4_Strikes_Punches_Landed", "R__Round4_Strikes_Significant Strikes_Attempts", "R__Round4_Strikes_Significant Strikes_Landed", "R__Round4_Strikes_Total Strikes_Attempts", "R__Round4_Strikes_Total Strikes_Landed", "R__Round4_TIP_Back Control Time", "R__Round4_TIP_Clinch Time", "R__Round4_TIP_Control Time", "R__Round4_TIP_Distance Time", "R__Round4_TIP_Ground Control Time", "R__Round4_TIP_Ground Time", "R__Round4_TIP_Guard Control Time", "R__Round4_TIP_Half Guard Control Time", "R__Round4_TIP_Misc. Ground Control Time", "R__Round4_TIP_Mount Control Time", "R__Round4_TIP_Neutral Time", "R__Round4_TIP_Side Control Time", "R__Round4_TIP_Standing Time", "R__Round5_Grappling_Reversals_Landed", "R__Round5_Grappling_Standups_Landed", "R__Round5_Grappling_Submissions_Attempts", "R__Round5_Grappling_Takedowns_Attempts", "R__Round5_Grappling_Takedowns_Landed", "R__Round5_Strikes_Body Significant Strikes_Attempts", "R__Round5_Strikes_Body Significant Strikes_Landed", "R__Round5_Strikes_Body Total Strikes_Attempts", "R__Round5_Strikes_Body Total Strikes_Landed", "R__Round5_Strikes_Clinch Body Strikes_Attempts", "R__Round5_Strikes_Clinch Body Strikes_Landed", "R__Round5_Strikes_Clinch Head Strikes_Attempts", "R__Round5_Strikes_Clinch Head Strikes_Landed", "R__Round5_Strikes_Clinch Leg Strikes_Attempts", "R__Round5_Strikes_Clinch Leg Strikes_Landed", "R__Round5_Strikes_Clinch Significant Kicks_Attempts", "R__Round5_Strikes_Clinch Significant Kicks_Landed", "R__Round5_Strikes_Clinch Significant Punches_Attempts", "R__Round5_Strikes_Clinch Significant Punches_Landed", "R__Round5_Strikes_Clinch Significant Strikes_Attempts", "R__Round5_Strikes_Clinch Significant Strikes_Landed", "R__Round5_Strikes_Clinch Total Strikes_Attempts", "R__Round5_Strikes_Clinch Total Strikes_Landed", "R__Round5_Strikes_Distance Body Kicks_Attempts", "R__Round5_Strikes_Distance Body Kicks_Landed", "R__Round5_Strikes_Distance Body Punches_Attempts", "R__Round5_Strikes_Distance Body Punches_Landed", "R__Round5_Strikes_Distance Body Strikes_Attempts", "R__Round5_Strikes_Distance Body Strikes_Landed", "R__Round5_Strikes_Distance Head Kicks_Attempts", "R__Round5_Strikes_Distance Head Kicks_Landed", "R__Round5_Strikes_Distance Head Punches_Attempts", "R__Round5_Strikes_Distance Head Punches_Landed", "R__Round5_Strikes_Distance Head Strikes_Attempts", "R__Round5_Strikes_Distance Head Strikes_Landed", "R__Round5_Strikes_Distance Leg Kicks_Attempts", "R__Round5_Strikes_Distance Leg Kicks_Landed", "R__Round5_Strikes_Distance Leg Strikes_Attempts", "R__Round5_Strikes_Distance Leg Strikes_Landed", "R__Round5_Strikes_Distance Strikes_Attempts", "R__Round5_Strikes_Distance Strikes_Landed", "R__Round5_Strikes_Ground Body Strikes_Attempts", "R__Round5_Strikes_Ground Body Strikes_Landed", "R__Round5_Strikes_Ground Head Strikes_Attempts", "R__Round5_Strikes_Ground Head Strikes_Landed", "R__Round5_Strikes_Ground Leg Strikes_Attempts", "R__Round5_Strikes_Ground Leg Strikes_Landed", "R__Round5_Strikes_Ground Significant Kicks_Attempts", "R__Round5_Strikes_Ground Significant Kicks_Landed", "R__Round5_Strikes_Ground Significant Punches_Attempts", "R__Round5_Strikes_Ground Significant Punches_Landed", "R__Round5_Strikes_Ground Significant Strikes_Attempts", "R__Round5_Strikes_Ground Significant Strikes_Landed", "R__Round5_Strikes_Ground Total Strikes_Attempts", "R__Round5_Strikes_Ground Total Strikes_Landed", "R__Round5_Strikes_Head Significant Strikes_Attempts", "R__Round5_Strikes_Head Significant Strikes_Landed", "R__Round5_Strikes_Head Total Strikes_Attempts", "R__Round5_Strikes_Head Total Strikes_Landed", "R__Round5_Strikes_Kicks_Attempts", "R__Round5_Strikes_Kicks_Landed", "R__Round5_Strikes_Knock Down_Landed", "R__Round5_Strikes_Leg Total Strikes_Attempts", "R__Round5_Strikes_Leg Total Strikes_Landed", "R__Round5_Strikes_Legs Significant Strikes_Attempts", "R__Round5_Strikes_Legs Significant Strikes_Landed", "R__Round5_Strikes_Legs Total Strikes_Attempts", "R__Round5_Strikes_Legs Total Strikes_Landed", "R__Round5_Strikes_Punches_Attempts", "R__Round5_Strikes_Punches_Landed", "R__Round5_Strikes_Significant Strikes_Attempts", "R__Round5_Strikes_Significant Strikes_Landed", "R__Round5_Strikes_Total Strikes_Attempts", "R__Round5_Strikes_Total Strikes_Landed", "R__Round5_TIP_Back Control Time", "R__Round5_TIP_Clinch Time", "R__Round5_TIP_Control Time", "R__Round5_TIP_Distance Time", "R__Round5_TIP_Ground Control Time", "R__Round5_TIP_Ground Time", "R__Round5_TIP_Guard Control Time", "R__Round5_TIP_Half Guard Control Time", "R__Round5_TIP_Misc. Ground Control Time", "R__Round5_TIP_Mount Control Time", "R__Round5_TIP_Neutral Time", "R__Round5_TIP_Side Control Time", "R__Round5_TIP_Standing Time", "winner" },
                Values = new string[,] { { "0", "0", "0", "0", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "value", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "value" }, }
            };
            int blueFighterRow=0, redFighterRow=0;
            while (!fighterData[blueFighterRow][4].Contains(blueFighterCbx.Text) && !fighterData[blueFighterRow][0].Contains(blueFightNm.Text))
            {
                blueFighterRow++;
            }
            Console.WriteLine(inputValues.Values.Length);
            Console.WriteLine(fighterData[blueFighterRow].Length);

            int blueFightNumber,redFightNumber;

            Int32.TryParse(blueFightNm.Text, out blueFightNumber);
            Int32.TryParse(redFightNm.Text, out redFightNumber);

            redFightNumber--;
            blueFightNumber--;

            for (int i = 0; i < fighterData.GetLength(0); i++)
            {
                if ((fighterData[i][4].Contains(redFighterCbx.Text)) && (fighterData[i][0].Contains(redFightNumber.ToString())))
                {
                    redFighterRow = i;
                }
                else if ((fighterData[i][4].Contains(blueFighterCbx.Text)) && (fighterData[i][0].Contains(blueFightNumber.ToString())))
                {
                    blueFighterRow = i;
                }               
            }

            Console.WriteLine(fighterData[redFighterRow].Length);

            var dataToSend = new string[fighterData[blueFighterRow].Length*2];
            var dataInDataToSend = 0;

            for (int i = 0; i < fighterData[blueFighterRow].Length; i++)
            {
                dataToSend[i] = fighterData[blueFighterRow][i];
                dataInDataToSend++;
            }

            for (int i = 0; i < fighterData[redFighterRow].Length; i++)
            {
                dataToSend[dataInDataToSend+i] = fighterData[redFighterRow][i];
            }

            for (int i = 0; i < dataToSend.Length; i++)
            {
                inputValues.Values[0, i] = dataToSend[i];
            }

            Console.WriteLine(fighterData.Length);
            Console.WriteLine("dataToSend Size:" + dataToSend.Length);
            foreach (string element in inputValues.Values)
            {
                Console.Write(element + " ");
            }

            string[] fightResult = InvokeRequestResponseService(inputValues).Result;

            if (fightResult[fightResult.Length - 2].Contains("red"))
            {
                winningLabel.Text = "Red Player Wins";
                winner = "red";
            }
            else if (fightResult[fightResult.Length - 2].Contains("blue"))
            {
                winningLabel.Text = "Blue Player Wins";
                winner = "blue";
            }
            var percentageFight = Regex.Match(fightResult[fightResult.Length - 1], @"([-+]?[0-9]*\.?[0-9]+)").Value;
            percentageFight = percentageFight.Substring(0, 5);
            float percentageFightFloat;
            float.TryParse(percentageFight, out percentageFightFloat);
            percentageFightFloat /= 10;
            if (percentageFightFloat < 50)
            {
                percentageFightFloat = 100 - percentageFightFloat;
            }
            percentLbl.Text = percentageFightFloat.ToString() + "%";
            percentLbl.Visible = true;
            startFightBtn.Enabled = true;
            getBet(winner, percentageFightFloat);
            bettingBox.Enabled = true;
        }

        private void setBet()
        {
            money = money - (double)fighterBetBox.Value;
            moneyBox.Text = money.ToString() + "$";
            if (blueFighterRadio.Checked)
            {
                bettingHorse = "blue";
            }
            else if (redFighterRadio.Checked)
            {
                bettingHorse = "red";
            }
        }

        private void getBet(string winner, float coefficient)
        {
            double moneyWon = 0;
            if(winner == "blue" && bettingHorse == "blue")
            {
                moneyWon = (double)fighterBetBox.Value*(100/coefficient);
            }
            else if(winner == "red" && bettingHorse == "red")
            {
                moneyWon = (double)fighterBetBox.Value * (100 / coefficient);
            }
            money = money + moneyWon;
            moneyBox.Text = money.ToString(".0") + "$";
            fighterBetBox.Maximum = (decimal)money;
        }

        private void blueFighterCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            winningLabel.Visible = false;
            percentLbl.Visible = false;
            blueFightNm.Items.Clear();
            string BlueFighter = blueFighterCbx.Text;
            string[] blueFighterName = BlueFighter.Split(' ');
            string url = "http://media.ufc.tv/fighter_images/" + blueFighterName[0] + "_" + blueFighterName[1] + "/" + blueFighterName[0] + blueFighterName[1] + "_Headshot.png";
            blueFighterPic.BackColor = System.Drawing.Color.Black;
            try
            {
                blueFighterPic.Load(url);
            }
            catch
            {
                url = "http://media.ufc.tv/fighter_images/" + blueFighterName[0] + "_" + blueFighterName[1] + "/" + blueFighterName[1].ToUpper() + "_" + blueFighterName[0].ToUpper() + ".png";
            }
            try
            {
                blueFighterPic.Load(url);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                blueFighterPic.Load("http://www.clker.com/cliparts/U/s/X/0/7/h/white-silhouette-hi.png");
                blueFighterPic.BackColor = System.Drawing.Color.Blue;
            }
            var blueFighterFights = 0;
            for(int i=0;i<fighterData.GetLength(0);i++)
            {
                if (fighterData[i][4].Contains(blueFighterCbx.Text))
                {
                    blueFighterFights++;
                    blueFightNm.Items.Add(blueFighterFights.ToString());
                }
            }
            blueFighterInfo.Clear();
            for (int i = 0; i < fighterInfo.GetLength(0); i++)
            {
                if (fighterInfo[i][2].Contains(BlueFighter))
                {
                    blueFighterInfo.AppendText("Nickname: " + fighterInfo[i][3] + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Birth: " + fighterInfo[i][4] + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Height: " + fighterInfo[i][5] + " in" + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Weight: " + fighterInfo[i][6] + " lbs" + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Association: " + fighterInfo[i][7] + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Class: " + fighterInfo[i][8] + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Locality: " + fighterInfo[i][9] + System.Environment.NewLine);
                    blueFighterInfo.AppendText("Country: " + fighterInfo[i][10] + System.Environment.NewLine);
                }
            }
            blueFightNm.Enabled = true;
            blueFightNm.SelectedIndex = 0;
            if (redFighterCbx.Text != "")
            {
                startFightBtn.Enabled = true;
            }
        }

        private void blueFighterCbx_Click(object sender, EventArgs e)
        {
        }

        static public async Task<string[]> InvokeRequestResponseService(StringTable input)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            input
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "FsV6rOdchVMe4RKpBC3b6Z71dhhe93ZRHkSyPAfLz5a7ZRHfelFSDwxx009PSSyBrPd9z/lhbjWt9tAz2jJ6tg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/c94741a71fa04f8cbacf633756db6c41/services/58be69c488af45a9b5ab6d5a7b1de255/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    string[] resultArray = result.Split(',');
                    Console.WriteLine("Result: {0}", result);
                    return resultArray;                                        
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                    string[] resultArray = responseContent.Split(',');
                    return resultArray;
                }
            }
        }

        public class StringTable
        {
            public string[] ColumnNames { get; set; }
            public string[,] Values { get; set; }
        }

        private void fighterBetBox_ValueChanged(object sender, EventArgs e)
        {
            fighterBetBox.Maximum = (decimal)money;
        }

        private void redFighterCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            winningLabel.Visible = false;
            percentLbl.Visible = false;
            redFightNm.Items.Clear();
            string RedFighter = redFighterCbx.Text;
            string[] redFighterName = RedFighter.Split(' ');
            string url = "http://media.ufc.tv/fighter_images/" + redFighterName[0] + "_" + redFighterName[1] + "/" + redFighterName[0] + redFighterName[1] + "_Headshot.png";
            redFighterPic.BackColor = System.Drawing.Color.Black;
            try
            {
                redFighterPic.Load(url);
            }
            catch
            {
                url = "http://media.ufc.tv/fighter_images/" + redFighterName[0] + "_" + redFighterName[1] + "/" + redFighterName[1].ToUpper() + "_" + redFighterName[0].ToUpper() + ".png";
            }
            try
            {
                redFighterPic.Load(url);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                redFighterPic.Load("http://www.clker.com/cliparts/U/s/X/0/7/h/white-silhouette-hi.png");
                redFighterPic.BackColor = System.Drawing.Color.Red;
            }
            var redFighterFights = 0;
            redFighterInfo.Clear();
            for (int i = 0; i < fighterInfo.GetLength(0); i++)
            {
                if (fighterInfo[i][2].Contains(RedFighter))
                {
                    redFighterInfo.AppendText("Nickname: " + fighterInfo[i][3] + System.Environment.NewLine);
                    redFighterInfo.AppendText("Birth: " + fighterInfo[i][4] + System.Environment.NewLine);
                    redFighterInfo.AppendText("Height: " + fighterInfo[i][5] + " in" + System.Environment.NewLine);
                    redFighterInfo.AppendText("Weight: " + fighterInfo[i][6] + " lbs" + System.Environment.NewLine);
                    redFighterInfo.AppendText("Association: " + fighterInfo[i][7] + System.Environment.NewLine);
                    redFighterInfo.AppendText("Class: " + fighterInfo[i][8] + System.Environment.NewLine);
                    redFighterInfo.AppendText("Locality: " + fighterInfo[i][9] + System.Environment.NewLine);
                    redFighterInfo.AppendText("Country: " + fighterInfo[i][10] + System.Environment.NewLine);
                }
            }
            for (int i = 0; i < fighterData.GetLength(0); i++)
            {
                if (fighterData[i][4].Contains(RedFighter))
                {
                    redFighterFights++;
                    redFightNm.Items.Add(redFighterFights.ToString());
                }
            }
            if (redFighterFights > 0)
            {
                redFightNm.Enabled = true;
                redFightNm.SelectedIndex = 0;
            }
            if(blueFighterCbx.Text != "")
            {
                startFightBtn.Enabled = true;
            }
        }
    }
}
