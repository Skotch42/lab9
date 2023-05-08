using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        double[] prob = new double[5];
        double[] count_prob = new double[5];
        double[] eProb = new double[5];
        double avg, var, eAvg = 0, eVar = 0, errAvg, errVar, chisq = 0;

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            Random generator = new Random();
            double[] number = new double[(int)numericUpDown5.Value];

            for (int j = 0; j < (int)numericUpDown5.Value; j++)
            {
                number[j] = generator.Next(1, 100);
            }

            for (int j = 0; j < (int)numericUpDown5.Value; j++)
            {
                int i = 0;
                prob[0] = (int)numericUpDown1.Value;
                prob[1] = (int)numericUpDown2.Value;
                prob[2] = (int)numericUpDown3.Value;
                prob[3] = (int)numericUpDown4.Value;
                prob[4] = 100 - prob[0] - prob[1] - prob[2] - prob[3];
                label17.Visible = true;
                label17.Text = " ( = " + prob[4].ToString("0") + " )";

                do
                {
                    number[j] -= prob[i];
                    i++;

                } while (number[j] > 0);

                i--;
                count_prob[i]++;
            }

            for (int j = 0; j < 5; j++)
            {
                eProb[j] = count_prob[j] / (int)numericUpDown5.Value;
            }

            for (int j = 0; j < 5; j++)
            {
                avg += ((j + 1) * (prob[j] / 100));
                eAvg += ((j + 1) * eProb[j]);
            }

            errAvg = Math.Abs((eAvg - avg)) / Math.Abs(avg) * 100;

            for (int j = 0; j < 5; j++)
            {
                var += (j + 1) * (j + 1) * (prob[j] / 100);
                eVar += (j + 1) * (j + 1) * eProb[j];
            }

            var -= avg * avg;
            eVar -= eAvg * eAvg;
            errVar = Math.Abs((eVar - var)) / Math.Abs(var) * 100;

            for (int j = 0; j < 5; j++)
            {
                chisq += count_prob[j] * count_prob[j] / ((int)numericUpDown5.Value * (prob[j] / 100));
            }

            chisq -= (int)numericUpDown5.Value;

            for (int j = 0; j < 5; j++)
            {
                count_prob[j] = count_prob[j] / (int)numericUpDown5.Value * 100;
                count_prob[j].ToString("0");
            }

            chart1.Series[0].Points.AddXY("Prob1", count_prob[0]);
            chart1.Series[0].Points.AddXY("Prob2", count_prob[1]);
            chart1.Series[0].Points.AddXY("Prob3", count_prob[2]);
            chart1.Series[0].Points.AddXY("Prob4", count_prob[3]);
            chart1.Series[0].Points.AddXY("Prob5", count_prob[4]);

            label11.Text = avg.ToString() + " ( error = " + errAvg.ToString("0") + "% )";
            label12.Text = var.ToString() + " ( error = " + errVar.ToString("0") + "% )";
            label13.Text = chisq.ToString("0.00");

            if (chisq > 9.488)
            {
                label15.ForeColor = Color.IndianRed;
                label15.Text = "true";
            }
            else
            {
                label15.ForeColor = Color.Green;
                label15.Text = "false";
            }

            for (int j = 0; j < 5; j++)
            {
                count_prob[j] = 0;
            }

            for (int j = 0; j < 5; j++)
            {
                eProb[j] = 0;
            }

            avg = 0; var = 0; eAvg = 0; eVar = 0; errAvg = 0; errVar = 0; chisq = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
