using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eseFunzioniBasket
{
    public struct giocatori
    {
        public string Id;
        public string CFiscale;
        public string Cognome;
        public string Nome;
        public string Nazionalità;
        public DateTime DataNascita;
        public string Ruolo;
        public decimal Prezzo;
        public bool Titolare;
    }

    public static class LibFunctions
    {
        public static int cerca(giocatori[] ele, int n, string dato)
        {
            int x = 0;
            while (x < n)//Cicla tutti i dati.
           
            {
                if (ele[x].Id == dato)
                {
                    return x; //Trovato alla posizione X.
                }
                x++;//Passa al dato successivo.
            }
            return -1; //Non trovato.
        }

        //----------------------------------------------------------------------------------

        public static int cancellaId(giocatori[] ele, ref int n, string dato)
        {
            //Cancella il dato cercato e restituisce il numero di dati cancellati.
            int x = 0;//Contatore dei dati.
            int c = 0;//Contatore dei dati cancellati.
            int nDatiCanc = 0;
            while (x < n)//Cicla tutti i dati.
            {
                if (ele[x].Id == dato)
                {
                    ele[x] = ele[n - 1]; //Sposta l'ultimo dato al posto di quello da cancellare.
                    n = n - 1; //Riduce il numero di dati.
                    c = c + 1;//Aumenta il numero di dati cancellati.
                    x = x - 1;//Ripete il ciclo per controllare il dato che è stato spostato.
                }
                x++;//Passa al dato successivo.
            }
            // c = numero deii dati cancellati
            nDatiCanc = c;
            return nDatiCanc;//Restituisce il numero di dati cancellati.
        }

        //----------------------------------------------------------------------------------

        public static void Ordina(giocatori[] ele, ref int n, int c)
        {
            
            giocatori tmp;//Variabile temporanea per lo scambio.
            int x;//Contatore dei dati.
            int y;//Contatore dei dati successivi.
            x = 0;//Inizializza il contatore.

            while (x < n)//Cicla tutti i dati.
            {
                y = x + 1; //Inizializza il contatore dei dati successivi.
                while (y < n)//Cicla tutti i dati successivi.
                {
                    if (c == 1) 
                    {
                        if (string.Compare(ele[x].Ruolo, ele[y].Ruolo) > 0)
                        {
                            tmp = ele[x];
                            ele[x] = ele[y];
                            ele[y] = tmp;    
                        }
                        y = y + 1;
                    }
                    if (c == 2)
                    {
                        if (ele[x].Prezzo > ele[y].Prezzo)
                        {
                            tmp = ele[x];
                            ele[x] = ele[y];
                            ele[y] = tmp;
                        }
                        y = y + 1;
                    }
                }
                x = x + 1;
            }
            x = x + 1;
        }

        //----------------------------------------------------------------------------------

        public static void BubbleSort(giocatori[] arr, int upper, int c)
        {
            giocatori temp;
            bool flag = true;
            int outer = upper;
            while (flag && outer >=1)
            {
                flag = false;
                for (int inner = 0; inner < outer -1; inner++)
                {
                    if (string.Compare(arr[inner].Ruolo, arr[inner+1].Ruolo) > 0)
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner+1];
                        arr[inner+1] = temp;
                        flag = true;
                    }

                    if (arr[inner + 1].Prezzo > arr[inner].Prezzo)
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                        flag = true;
                    }
                }
                outer = outer - 1;
            }
        }

        //----------------------------------------------------------------------------------
        public static void QuickSort(giocatori[] ele, int inizio, int fine)
        {
            string centro = default;
            int sinistra = default;
            int destra = default;

            if (fine > inizio) 
            {
                centro = ele[inizio].Id;
                sinistra = inizio + 1;
                destra = fine + 1;

                while (sinistra < destra)
                {
                    if (string.Compare(ele[sinistra].Id, centro) < 0)
                        sinistra++;



                    else
                    {
                        destra--;
                        swap(ref ele[sinistra], ref ele[destra]);
                    }
                }
                sinistra--;

                swap(ref ele[inizio], ref ele[sinistra]);
                QuickSort(ele, inizio, sinistra);
                QuickSort(ele, destra, fine);

            }

        }

        public static void swap(ref giocatori x, ref giocatori y)
        {
            giocatori temp = x;
            x = y;
            y = temp;
        }
    }
}