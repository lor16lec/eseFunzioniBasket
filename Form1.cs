using Bogus;
using servizi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eseFunzioniBasket
{
    public partial class Form1 : Form
    {
        private string Nations;
        private int l = 1;
        int punteggio = 0;

        private bool Bogus()
        {
            var faker = new Faker();

            // Generate a random country name
            var randomCountryNames = GenerateRandomCountryNames(faker, 1);

            // Print the country name
            foreach (var countryName in randomCountryNames)
            {

                if (countryName == "Russian Federation")
                {
                    Nations = "Russia";
                    return true;
                }

                if (countryName.Length == 6)
                {
                    Nations = countryName;
                    return true;
                }
            }

            return false;

        }

        public static List<string> GenerateRandomCountryNames(Faker faker, int count)
        {
            var countryNames = new List<string>();
            for (int i = 0; i < count; i++)
            {
                countryNames.Add(faker.Address.Country());
            }
            return countryNames;
        }

        //BOGUS

        private struct TextBox
        {
            public string Name;
            public Point Location;
            public Size Size;
        }

        public void textBoxLxCy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                //var k = "mammababbo";
                //var z = k.IndexOf("babbo");
                //var m = k[z + 1];
                var mioNome = (sender as System.Windows.Forms.TextBox).Name;

                var riga = mioNome.IndexOf("L");
                var colonna = mioNome.IndexOf("C");
                var r = int.Parse(mioNome[riga + 1].ToString());
                var c = int.Parse(mioNome[colonna + 1].ToString());

                //var a = r;
                //var b = c;

                var a1 = r;
                var b1 = c - 1;

                var nomeDaCercare = $"textBoxL{a1}C{b1}";
                var prevTB = default(System.Windows.Forms.Control);

                try
                {
                    prevTB = this.Controls.Find(nomeDaCercare, true)[0];
                }
                catch
                {
                    (sender as System.Windows.Forms.TextBox).TextChanged -= textBoxLxCy_TextChanged;
                    return;
                }

                (sender as System.Windows.Forms.TextBox).Text ="";
                if (e.KeyData == Keys.Back)
                {
                    (prevTB as System.Windows.Forms.TextBox).Focus();
                }
                (sender as System.Windows.Forms.TextBox).TextChanged += textBoxLxCy_TextChanged;
            }
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public Form1()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    var actTextBox = item as System.Windows.Forms.TextBox;
                    if (actTextBox.Name.StartsWith("textBoxL"))
                    {
                        actTextBox.KeyDown += textBoxLxCy_KeyDown;
                    }
                }
            }

            foreach (var item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    var Enter = item as System.Windows.Forms.TextBox;
                    Enter.KeyDown += new KeyEventHandler(Send_KeyDown);
                }
            }

            foreach (var item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    var Forward = item as System.Windows.Forms.TextBox;
                    if (Forward.Name.StartsWith("textBoxL"))
                    { 
                        Forward.TextChanged += textBoxLxCy_TextChanged;
                        Forward.KeyPress += new KeyPressEventHandler(KeyPress_Char);
                    }
                }
            }

            foreach (var item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    var Forward = item as System.Windows.Forms.TextBox;

                    if (Forward.Name.StartsWith("textBoxL"))
                    {
                        Forward.KeyDown += new KeyEventHandler(RightArrowMovement);
                    }
                }
            }

            foreach (var item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    var Backwards = item as System.Windows.Forms.TextBox;

                    if (Backwards.Name.StartsWith("textBoxL"))
                    {
                        Backwards.KeyDown += new KeyEventHandler(LeftArrowMovement);
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (Bogus() == false)
            { }
                // Supponiamo che tu abbia già creato una PictureBox chiamata "pictureBox2" nella tua form.
                // URL dell'immagine da Internet
                string nazioni = Nations.ToLower();
                string imageUrl = $"https://www.countryflags.com/wp-content/uploads/{nazioni}-flag-png-large.png";

                // Caricare l'immagine nell'oggetto PictureBox
                try
                {
                    pictureBox2.Image = Image.FromStream(new System.Net.WebClient().OpenRead(imageUrl));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Errore nel caricamento dell'immagine: {ex.Message}");
                     System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();
                }
        }

        public void Send_KeyDown(object sender, KeyEventArgs e)
        {
            string Nation = Nations.ToLower();

            //  string a = Parola.Substring(0, 1);
            // string b = Parola.Substring(1, 1);

            string WORD = services.getLineWord(this, l);

            WORD = WORD.ToLower();


            if (e.KeyData == Keys.Enter)
            {
                //l += r;

                ////if (WORD == Nation)
                //{
                //    for (int i = 1; i <= 6; i++)
                //    {
                //        Controls[$"textBoxL{l}C{i}"].BackColor = Color.Green;
                //    }

                //    textBoxL2C1.Focus();
                //}
                //MessageBox.Show(WORD);

                for (int i = 1; i <= 6; i++)
                {
                    string letterainserita = WORD.Substring(i - 1, 1);
                    string letterascelta = Nation.Substring(i - 1, 1);
                    if (letterainserita.Equals(letterascelta))
                    {
                        Controls[$"textBoxL{l}C{i}"].BackColor = Color.Green;


                       

                    }
                    else if (Nation.Contains(letterainserita))

                    {
                        Controls[$"textBoxL{l}C{i}"].BackColor = Color.Yellow;
                       

                    }
                    else
                    {
                        Controls[$"textBoxL{l}C{i}"].BackColor = Color.Red;
                        
                    }
                }
               
                l = l + 1;

                if (WORD==Nation && l==2)
                {
                    punteggio = punteggio + 100;
                    MessageBox.Show($"COMPLIMENTI! HAI INDOVINATO LA NAZIONE CORRETTA! MA COME DIAMINE HAI FATTO BRO? il tuo punteggio è   {punteggio}");
                  


                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();

                    //while (Bogus() == false)
                    //{
                    //}
                }
                if (WORD == Nation && l == 3)
                {
                    punteggio = punteggio + 50;
                    MessageBox.Show($"COMPLIMENTI! HAI INDOVINATO LA NAZIONE CORRETTA! MA COME DIAMINE HAI FATTO BRO? il tuo punteggio è  {punteggio}");

                   

                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();

                    //while (Bogus() == false)
                    //{
                    //}
                }
                if (WORD == Nation && l == 4)
                {
                    punteggio = punteggio + 25;
                    MessageBox.Show($"COMPLIMENTI! HAI INDOVINATO LA NAZIONE CORRETTA! MA COME DIAMINE HAI FATTO BRO? il tuo punteggio è   {punteggio}");

                   


                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();

                    //while (Bogus() == false)
                    //{
                    //}
                }
                if (WORD == Nation && l == 5)
                {
                    punteggio = punteggio + 13;
                    MessageBox.Show($"COMPLIMENTI! HAI INDOVINATO LA NAZIONE CORRETTA! MA COME DIAMINE HAI FATTO BRO? il tuo punteggio è   {punteggio}");

                   


                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();

                    //while (Bogus() == false)
                    //{
                    //}
                }
                if (WORD == Nation && l == 6)
                {
                    punteggio = punteggio + 6;
                    MessageBox.Show($"COMPLIMENTI! HAI INDOVINATO LA NAZIONE CORRETTA! MA COME DIAMINE HAI FATTO BRO? il tuo punteggio è  {punteggio}");

                   


                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.Restart();

                    //while (Bogus() == false)
                    //{
                    //}
                }
                


                
               
            }

            if (l >= 6 && WORD != Nation)
            {
                MessageBox.Show($"la nazione corretta era {Nation}");
                System.Windows.Forms.Application.Exit();
                System.Windows.Forms.Application.Restart();
            }

          

        }

        private void textBoxLxCy_TextChanged(object sender, EventArgs e)
        {
            var mioNome = (sender as System.Windows.Forms.TextBox).Name;

            var riga = mioNome.IndexOf("L");
            var colonna = mioNome.IndexOf("C");
            var r = int.Parse(mioNome[riga + 1].ToString());
            var c = int.Parse(mioNome[colonna + 1].ToString());

            var a1 = r;
            var b1 = c + 1;

            var nomeDaCercare = $"textBoxL{a1}C{b1}";
            var forwardTB = default(System.Windows.Forms.Control);
            try
            {
                forwardTB = this.Controls.Find(nomeDaCercare, true)[0];
            }
            catch
            {
                foreach (var item in this.Controls)
                {
                    if (item is System.Windows.Forms.TextBox)
                    {
                        var Line = item as System.Windows.Forms.TextBox;

                        if (Line.Name.StartsWith("textBoxL") && Line.Text != "")
                        {
                            Line.KeyDown += new KeyEventHandler(textBoxLine_TextChanged);
                        }
                    }
                }
                return;
            }

            (forwardTB as System.Windows.Forms.TextBox).Focus();
        }

        private void KeyPress_Char(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a valid character (e.g., alphanumeric)
            if (char.IsLetter(e.KeyChar))
            {
                var mioNome = (sender as System.Windows.Forms.TextBox).Name;

                var riga = mioNome.IndexOf("L");
                var colonna = mioNome.IndexOf("C");
                var r = int.Parse(mioNome[riga + 1].ToString());
                var c = int.Parse(mioNome[colonna + 1].ToString());

                var a1 = r;
                var b1 = c + 1;

                var nomeDaCercare = $"textBoxL{a1}C{b1}";
                var forwardTB = default(System.Windows.Forms.Control);

                try
                {
                    forwardTB = this.Controls.Find(nomeDaCercare, true)[0];
                }
                catch
                {
                    return;
                 }

                if ((sender as System.Windows.Forms.TextBox).Text != "")
                {
                    (forwardTB as System.Windows.Forms.TextBox).Focus();
                    if((forwardTB as System.Windows.Forms.TextBox).Text == "")
                    {
                        (forwardTB as System.Windows.Forms.TextBox).Text += e.KeyChar.ToString();
                    }
                }

            }
        }


        private void RightArrowMovement(object sender, KeyEventArgs e)
        {
            {
                var mioNome = (sender as System.Windows.Forms.TextBox).Name;

                var riga = mioNome.IndexOf("L");
                var colonna = mioNome.IndexOf("C");
                var r = int.Parse(mioNome[riga + 1].ToString());
                var c = int.Parse(mioNome[colonna + 1].ToString());

                var a1 = r;
                var b1 = c + 1;

                var nomeDaCercare = $"textBoxL{a1}C{b1}";
                var forwardTB = default(System.Windows.Forms.Control);
                try
                {
                 forwardTB = this.Controls.Find(nomeDaCercare, true)[0];
                }
                catch
                {
                return;
                }
               
                (forwardTB as System.Windows.Forms.TextBox).Focus();
            }
        }

        private void LeftArrowMovement(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                var mioNome = (sender as System.Windows.Forms.TextBox).Name;

                var riga = mioNome.IndexOf("L");
                var colonna = mioNome.IndexOf("C");
                var r = int.Parse(mioNome[riga + 1].ToString());
                var c = int.Parse(mioNome[colonna + 1].ToString());

                var a1 = r;
                var b1 = c - 1;

                var nomeDaCercare = $"textBoxL{a1}C{b1}";
                var forwardTB = default(System.Windows.Forms.Control);
                try
                {
                    forwardTB = this.Controls.Find(nomeDaCercare, true)[0];
                }
                catch
                {
                    return;
                }

                (forwardTB as System.Windows.Forms.TextBox).Focus();
            }
        }

        private void textBoxLine_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var mioNome = (sender as System.Windows.Forms.TextBox).Name;

                var riga = mioNome.IndexOf("L");
                var colonna = mioNome.IndexOf("C");
                var r = int.Parse(mioNome[riga + 1].ToString());
                var c = int.Parse(mioNome[colonna + 1].ToString());

                if (c == 6 && (sender as System.Windows.Forms.TextBox).Text == "")
                {
                    return;
                }

                var a1 = r + 1;
                var b1 = c - 5;

                var nomeDaCercare = $"textBoxL{a1}C{b1}";
                var forwardLine = default(System.Windows.Forms.Control);

                try
                {
                    forwardLine = this.Controls.Find(nomeDaCercare, true)[0];
                }
                catch
                {
                    return;
                }

            (forwardLine as System.Windows.Forms.TextBox).Focus();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
