using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NPlot;

namespace StatInspection
{
    public partial class MainForm : Form
    {
        string[] arrStr;
        int[] arrN, arrAc;
        public MainForm()
        {
            InitializeComponent();
        }
        void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GenForm gf = new GenForm();
                if (gf.ShowDialog() != DialogResult.OK)
                    return;
                int smpCount = int.Parse(gf.tbSmpCount.Text);
                double mN = double.Parse(gf.tbMN.Text), sN = double.Parse(gf.tbSN.Text);
                double mQ = double.Parse(gf.tbMQ.Text), sQ = double.Parse(gf.tbSQ.Text);
                double AQL = double.Parse(gf.tbAQL.Text);
                int[] arrQ;
                string[] arrCT;
                Result[] arrRes;
                arrStr = StatInspection.Inspect(smpCount, mN, sN, mQ, sQ, AQL, gf.cbCT.Text, gf.cbCL.Text,
                    out arrN, out arrAc, out arrQ, out arrCT, out arrRes);
                lv.Items.Clear();
                for (int i = 0; i < arrN.Length; i++)
                {
                    lv.Items.Add(new ListViewItem(new string[] {
                        string.Format("{0}", i + 1), arrN[i].ToString(), arrAc[i].ToString(),
                        arrQ[i].ToString(), arrRes[i].ToString(), arrCT[i]
                    }));
                }
            }
            catch
            {
                MessageBox.Show("Ошибочные исходные данные");
            }
        }
        void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = lv.SelectedIndices[0];
                wb.DocumentText = arrStr[i];
                ps.Clear();
                double[] arrP, arrL;
                arrL = StatInspection.GetL(arrN[i], arrAc[i], out arrP);

                LinePlot lp = new LinePlot(arrL, arrP);
                lp.Color = Color.Red;
                ps.Add(lp);
                ps.Title = "Оперативная характеристика (по закону Пуассона)";
                ps.XAxis1.Label = "Уровень качества, q";
                ps.YAxis1.Label = "Оперативная характеристика, L";
                ps.Refresh();
            }
            catch { }
        }
        void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил Кондауров А.С.");
        }
    }
}