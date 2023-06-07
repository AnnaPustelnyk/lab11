using System;

namespace lab11
{
    public partial class Form1 : Form
    {
        private List<string> talia;
        private Random random;
        private int sumaGracza1;
        private int sumaGracza2;
        public Form1()
        {
            InitializeComponent();
            talia = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            talia = GenerujTalie(talia);
            random = new Random();
            sumaGracza1 = 0;
            sumaGracza2 = 0;
        }

        private List<string> GenerujTalie(List<string> karty)
        {
            List<string> talia = new List<string>();
            foreach (string karta in karty)
            {
                talia.Add(karta + " ♠");
                talia.Add(karta + " ♣");
                talia.Add(karta + " ♦");
                talia.Add(karta + " ♥");
            }
            return talia;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}