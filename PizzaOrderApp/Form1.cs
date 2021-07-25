using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderApp
{
    public partial class Form1 : Form
    {

        string[] PizzaTypes = { "KLASİK", "KARIŞIK", "EXTRAVAGANZA", "ITALIANO", "TURKISH", "TUNA", "SEAFEED", "KASTAMONU", "CALYPSO", "AKDENİZ", "KARADENİZ" };
        int[] typeCosts = { 14, 17, 21, 20, 23, 18, 19, 20, 24, 21, 21 };
        string[] PizzaSizes = { "Küçük", "Orta", "Büyük", "Maxi" };
        double multiplier;
        double totalCost;
        double finalCost;
        double selectedPizzaCost;
        double numofPizzas;
        bool thickEdge = false;
        double orderFee;
        string tempString;

        ChosenPizza tempPizza = new ChosenPizza();

        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = PizzaTypes;
            comboBox1.DataSource = PizzaSizes;
            radioButton1.Checked = true;
            textBox1.Text = "1";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Küçük")
            {
                multiplier = 1;
                tempPizza._size = "Küçük";
            }

            else if (Convert.ToString(comboBox1.SelectedItem) == "Orta")
            {
                multiplier = 1.25;
                tempPizza._size = "Orta";
            }

            else if (Convert.ToString(comboBox1.SelectedItem) == "Büyük")
            {
                multiplier = 1.75;
                tempPizza._size = "Büyük";
            }

            else if (Convert.ToString(comboBox1.SelectedItem) == "Maxi")
            {
                multiplier = 2;
                tempPizza._size = "Maxi";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Toplam " + listBox2.Items.Count + " adet siparişiniz " + orderFee + " ₺ tutarındadır.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < PizzaTypes.Length; i++)
            {
                if (PizzaTypes[i] == Convert.ToString(listBox1.SelectedItem))
                {
                    selectedPizzaCost = typeCosts[i];
                    tempPizza._type = PizzaTypes[i];
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            thickEdge = false;
            tempPizza._side = "İnce Kenar";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            thickEdge = true;
            tempPizza._side = "Kalın Kenar";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tempPizza._extras = "";
            bool nopFlag = true;
            try
            {
                numofPizzas = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Lütfen adedi doğru giriniz.");
                nopFlag = false;
            }

            if (thickEdge)
                totalCost = selectedPizzaCost * multiplier + 2;
            else
                totalCost = selectedPizzaCost * multiplier;

            tempPizza._costofOne = totalCost;
            tempPizza._numofPizzas = numofPizzas;

            if (nopFlag)
            {
                finalCost = numofPizzas * totalCost;
                textBox2.Text = Convert.ToString(finalCost);
                tempPizza._costofAll = finalCost;

                if (checkBox1.Checked) { tempPizza._extras += checkBox1.Text + ", "; }
                if (checkBox2.Checked) { tempPizza._extras += checkBox2.Text + ", "; }
                if (checkBox3.Checked) { tempPizza._extras += checkBox3.Text + ", "; }
                if (checkBox4.Checked) { tempPizza._extras += checkBox4.Text + ", "; }
                if (checkBox5.Checked) { tempPizza._extras += checkBox5.Text + ", "; }
                if (checkBox6.Checked) { tempPizza._extras += checkBox6.Text + ", "; }
                if (checkBox7.Checked) { tempPizza._extras += checkBox7.Text + ", "; }
                if (checkBox8.Checked) { tempPizza._extras += checkBox8.Text + ", "; }
                if (checkBox9.Checked) { tempPizza._extras += checkBox9.Text + ", "; }
                if (checkBox10.Checked) { tempPizza._extras += checkBox10.Text + ", "; }

                tempString = tempPizza._size + ", " + tempPizza._type + ", " + tempPizza._side + ", " + tempPizza._extras + " ; " +
                    Convert.ToString(tempPizza._numofPizzas) + " x " + Convert.ToString(tempPizza._costofOne) + " = " + Convert.ToString(tempPizza._costofAll);
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            orderFee += finalCost;
            label4.Text = Convert.ToString(orderFee) + " ₺";
            listBox2.Items.Add(tempString);

        }

    }
}
