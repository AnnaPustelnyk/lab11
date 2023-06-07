using System;

namespace lab11
{
    public partial class Form1 : Form
    {
        private List<string> talia;
        private Random random;
        private int sumaGracza1;
        private int sumaGracza2;
        private List<string> kartyG1;
        private List<string> kartyG2;
        private bool czyG1;
        public Form1()
        {
            InitializeComponent();
            talia = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            talia = GenerujTalie(talia);
            kartyG1 = new List<string>();
            kartyG2 = new List<string>();
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

        private void LosujKarteG1()
        {
            int indeks = random.Next(talia.Count);
            string kartaGracza1 = talia[indeks];
            talia.RemoveAt(indeks);

            DodajKarteG1(kartaGracza1);
        }

        private void LosujKarteG2()
        {
            int indeks = random.Next(talia.Count);
            string kartaGracza2 = talia[indeks];
            talia.RemoveAt(indeks);

            DodajKarteG2(kartaGracza2);
        }

        private void DodajKarteG1(string karta)
        {
            kartyG1.Add(karta);
            listBox1.Items.Add(karta);
            AktualizujSumęPunktówG1();
        }

        private void DodajKarteG2(string karta)
        {
            kartyG2.Add(karta);
            listBox2.Items.Add(karta);
            AktualizujSumęPunktówG2();
        }

        private void AktualizujSumęPunktówG1()
        {
            int suma = ObliczSumęPunktów(kartyG1);
            label3.Text = suma.ToString();
        }

        private void AktualizujSumęPunktówG2()
        {
            int suma = ObliczSumęPunktów(kartyG2);
            label4.Text = suma.ToString();
        }

        private int ObliczSumęPunktów(List<string> karty)
        {
            int suma = 0;
            int liczbaAsów = 0;

            foreach (string karta in karty)
            {
                string wartośćKarty = karta.Substring(0, karta.Length - 2);

                if (wartośćKarty == "A")
                {
                    suma += 11;
                    liczbaAsów++;
                }
                else if (wartośćKarty == "K" || wartośćKarty == "Q" || wartośćKarty == "J")
                {
                    suma += 10;
                }
                else
                {
                    suma += int.Parse(wartośćKarty);
                }
            }

            while (suma > 21 && liczbaAsów > 0)
            {
                suma -= 10;
                liczbaAsów--;
            }

            return suma;
        }

        private void SprawdzWynik()
        {
            int sumaGracza1 = ObliczSumęPunktów(kartyG1);
            int sumaGracza2 = ObliczSumęPunktów(kartyG2);

            if (sumaGracza1 >= 22)
            {
                MessageBox.Show("Gracz 2 przegrał!");
                Koniec();
            }
            else if (sumaGracza2 >= 22)
            {
                MessageBox.Show("Gracz 1 przegrał!");
                Koniec();
            }
            else if (sumaGracza1 == 21)
            {
                MessageBox.Show("Gracz 1 wygrywa!");
                Koniec();
            }
            else if (sumaGracza2 == 21)
            {
                MessageBox.Show("Gracz 2 wygrywa!");
                Koniec();
            }
        }

        private void Koniec()
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!czyG1)
            {
                label5.Text = "Gracz 1";
            }
            else
            {
                label5.Text = "Gracz 2";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button1.Visible = true;
                button2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                listBox1.Visible = true;
                listBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                LosujKarteG1();
                SprawdzWynik();

                if (ObliczSumęPunktów(kartyG1) < 21)
                {
                    return;
                }

            czyG1 = true;
            
            SprawdzWynik();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                czyG1 = false;
                LosujKarteG2();
                SprawdzWynik();
        }
    }
}