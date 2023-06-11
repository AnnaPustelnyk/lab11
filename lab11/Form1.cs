using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace lab11
{
    public partial class Form1 : Form
    {
        private List<string> list, talia;
        private Random random;
        private int sumaG1;
        private int sumaG2;
        private List<string> kartyG1;
        private List<string> kartyG2;
        private bool czyG1 = true;
        public Form1()
        {
            InitializeComponent();
            list = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            kartyG1 = new List<string>();
            kartyG2 = new List<string>();
            random = new Random();
            sumaG1 = 0;
            sumaG2 = 0;
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

        private void LosujG1()
        {
            int i = random.Next(talia.Count);
            string kartaG1 = talia[i];
            if (radioButton2.Checked)
            {
                talia.RemoveAt(i);

                DodajG1(kartaG1);
            }
            else
            {
                kartyG1.Add(kartaG1);
                AktualizujG1();
            }
        }

        private void LosujG2()
        {
            int i = random.Next(talia.Count);
            string kartaG2 = talia[i];
            if (radioButton2.Checked)
            {
                talia.RemoveAt(i);

                DodajG2(kartaG2);
            }
            else
            {
                kartyG2.Add(kartaG2);
                AktualizujG2();
            }
        }

        private void DodajG1(string karta)
        {
            kartyG1.Add(karta);
            listBox1.Items.Add(karta);
            AktualizujG1();
        }

        private void DodajG2(string karta)
        {
            kartyG2.Add(karta);
            listBox2.Items.Add(karta);
            AktualizujG2();
        }

        private void AktualizujG1()
        {
            if (radioButton2.Checked)
            {
                int suma = ObliczSume(kartyG1);
                label3.Text = suma.ToString();
            }
            else
            {
                int suma = kartyG1.Count;
                label3.Text = suma.ToString();
            }
        }

        private void AktualizujG2()
        {
            if (radioButton2.Checked)
            {
                int suma = ObliczSume(kartyG2);
                label4.Text = suma.ToString();
            }
            else
            {
                int suma = kartyG2.Count;
                label4.Text = suma.ToString();
            }
        }

        private int ObliczSume(List<string> karty)
        {
            int suma = 0;
            int liczbaAs = 0;

            foreach (string karta in karty)
            {
                string wartosc = karta.Substring(0, karta.Length - 2);

                if (wartosc == "A")
                {
                    suma += 11;
                    liczbaAs++;
                }
                else if (wartosc == "K" || wartosc == "Q" || wartosc == "J")
                {
                    suma += 10;
                }
                else
                {
                    suma += int.Parse(wartosc);
                }
            }

            while (suma > 21 && liczbaAs > 0)
            {
                suma -= 10;
                liczbaAs--;
            }

            return suma;
        }

        private void SprawdzWynik()
        {
            if (radioButton2.Checked)
            {
                int sumaG1 = ObliczSume(kartyG1);
                int sumaG2 = ObliczSume(kartyG2);

                if (sumaG2 >= 22 || sumaG1 == 21)
                {
                    MessageBox.Show("Gracz 1 wygrywa!");
                    Koniec();
                }
                else if (sumaG1 >= 22 || sumaG2 == 21)
                {
                    MessageBox.Show("Gracz 2 wygrywa!");
                    Koniec();
                }
            }
            else if (radioButton1.Checked)
            {
                if (kartyG1.Count == 0)
                {
                    MessageBox.Show("Gracz 2 wygrał");
                }
                else if (kartyG2.Count == 0)
                {
                    MessageBox.Show("Gracz 1 wygrał");
                }
            }
        }

        private void Koniec()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            kartyG1.Clear();
            kartyG2.Clear();
            label3.Text = "0";
            label4.Text = "0";
            czyG1 = true;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                talia = GenerujTalie(list);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                kartyG1.Clear();
                kartyG2.Clear();

                label3.Text = "0";
                label4.Text = "0";

                button1.Visible = true;
                button2.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
                listBox1.Visible = true;
                listBox2.Visible = true;

                int liczbaKartNaGracza = talia.Count / 2;

                for (int i = 0; i < liczbaKartNaGracza; i++)
                {
                    LosujG1();
                    LosujG2();
                }

                AktualizujG1();
                AktualizujG2();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                talia = GenerujTalie(list);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                kartyG1.Clear();
                kartyG2.Clear();

                label3.Text = "0";
                label4.Text = "0";

                button1.Visible = true;
                button2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                listBox1.Visible = true;
                listBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (czyG1)
                {
                    LosujG1();
                    SprawdzWynik();

                    if (ObliczSume(kartyG1) < 21)
                    {
                        return;
                    }
                    else if (ObliczSume(kartyG1) >= 21)
                    {
                        czyG1 = false;
                        label5.Text = "Gracz 2";
                    }
                }
                else
                {
                    LosujG2();
                    SprawdzWynik();

                    if (ObliczSume(kartyG2) < 21)
                    {
                        return;
                    }
                    else if (ObliczSume(kartyG2) >= 21)
                    {
                        label5.Text = "Gracz 1";
                        czyG1 = true;
                    }
                }
            }
            else
            {
                PorownajKarty();
                SprawdzWynik();
            }
        }

        string secCardG1 = null, secCardG2 = null;
        private void PorownajKarty()
        {
            string lastCardG1 = null, lastCardG2 = null;
            if (kartyG1.Count > 0)
            {
                lastCardG1 = kartyG1[kartyG1.Count - 1];
                kartyG1.RemoveAt(kartyG1.Count - 1);
                listBox1.Items.Add(lastCardG1);
            }

            if (kartyG2.Count > 0)
            {
                lastCardG2 = kartyG2[kartyG2.Count - 1];
                kartyG2.RemoveAt(kartyG2.Count - 1);
                listBox2.Items.Add(lastCardG2);
            }

            int lastCardG1Value = ObliczWartoscKarty(lastCardG1);
            int lastCardG2Value = ObliczWartoscKarty(lastCardG2);

            if (lastCardG1Value > lastCardG2Value)
            {
                kartyG1.Insert(0, lastCardG1);
                kartyG1.Insert(0, lastCardG2);
                if (secCardG1 != null && secCardG2 != null)
                {
                    kartyG1.Insert(0, secCardG1);
                    kartyG1.Insert(0, secCardG2);
                }
                label3.Text = kartyG1.Count.ToString();
                label4.Text = kartyG2.Count.ToString();
            }
            else if (lastCardG2Value > lastCardG1Value)
            {
                kartyG2.Insert(0, lastCardG2);
                kartyG2.Insert(0, lastCardG1);
                if (secCardG1 != null && secCardG2 != null)
                {
                    kartyG1.Insert(0, secCardG1);
                    kartyG1.Insert(0, secCardG2);
                }
                label3.Text = kartyG1.Count.ToString();
                label4.Text = kartyG2.Count.ToString();
            }
            else if (lastCardG1Value == lastCardG2Value)
            {
                MessageBox.Show("Wojna!");


                if (kartyG1.Count > 0)
                {
                    secCardG1 = kartyG1[kartyG1.Count - 1];
                    kartyG1.RemoveAt(kartyG1.Count - 1);
                }

                if (kartyG2.Count > 0)
                {
                    secCardG2 = kartyG2[kartyG2.Count - 1];
                    kartyG2.RemoveAt(kartyG2.Count - 1);
                }

                listBox1.Items.Add("■");
                listBox2.Items.Add("■");

                PorownajKarty();
            }
        }
        private int ObliczWartoscKarty(string karta)
        {
            string wartosc = karta.Substring(0, karta.Length - 2);

            if (wartosc == "A")
            {
                return 11;
            }
            else if (wartosc == "K" || wartosc == "Q" || wartosc == "J")
            {
                return 10;
            }
            else
            {
                return int.Parse(wartosc);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (czyG1)
            {
                czyG1 = false;
                label5.Text = "Gracz 2";
                SprawdzWynik();
            }
            else
            {
                czyG1 = true;
                label5.Text = "Gracz 1";
                SprawdzWynik();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}