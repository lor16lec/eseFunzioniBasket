using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eseFunzioniBasket;
using Bogus;
using System.Drawing;
using System.Windows.Forms;

namespace servizi
{
    public class services
    {
        public static string getLineWord(System.Windows.Forms.Form actForm, int line)
        {
            string outString = default;

            for (int i = 1; i <= 6; i++)
            {
                outString += actForm.Controls[$"textBoxL{line}C{i}"].Text;
            }
            return outString; //ritorna la parola intera ciclando le colonne, sapendo la riga
        }
    }
}
