using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoOnmyoji
{
    public partial class MainForm : Form
    {
        public bool IsStop { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            getOnmyojiHandle();
            Global.isStop = false;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Explore.checkFoodFullExp();
        }


        private void stopButton_Click(object sender, EventArgs e)
        {
            Global.isStop = true;
        }

        #region methods        

        void getOnmyojiHandle()
        {
            Global.mainHandle = AutoControl.FindWindowHandle(null, "Onmyoji");
            if (Global.mainHandle == IntPtr.Zero)
            {
                GameHelper.Log("Khong tim thay cua so game. Vui long mo game truoc khi tiep tuc");
                return;
            }
            else
            {
                GameHelper.Log("Da tim thay cua so game");
            }
        }

        #endregion

        private void explore_button_Click(object sender, EventArgs e)
        {
            Explore.setFoodType(cbxFoodType.SelectedIndex);
            Global.isStop = false;
            Task t = new Task(() =>
            {
                while (!Global.isStop)
                {
                    Explore.ExploreAction();
                }
                GameHelper.Log("Explore Finish");
            });
            t.Start();
        }

        private void cbxFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Explore.setFoodType(cb.SelectedIndex);
        }

        private void numericTurnTotalExplore_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nb = sender as NumericUpDown;
            Explore.setTotalTurnFight((int)nb.Value);
        }

        private void autoCloseGame_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox nb = sender as CheckBox;
            Global.autoClose = nb.Checked;
            GameHelper.Log("Tự động tắt game" + nb.Checked.ToString());
        }
    }
}
