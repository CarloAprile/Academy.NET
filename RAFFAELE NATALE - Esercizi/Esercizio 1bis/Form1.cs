using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;


/*
 * Realizzare un'applicazione Windows Forms che generi un file di testo contenente un elenco di 100 nomi di file casuali e lo visualizzi all'interno di una TextBox nella seguente forma:



5eap4ynd.zlo
k545vlsq.g0n
zret4ryv.k1n
...



Quindi sempre nella stessa applicazione realizzare una funzionalità che legga il file precedentemente generato e aggiunga in corrispondenza di ciascun nome il numero di vocali contenute in esso nella seguente forma:



5eap4ynd.zlo = 3
k545vlsq.g0n = 0
zret4ryv.k1n = 1
...



visualizzando anche questa elaborazione in una seconda TextBox.



**********




1) Implementare una classe base (Es: FileGenerico) che rappresenti un generico FILE. Questa classe dovrà avere quattro proprietà ed un metodo.



Le proprietà dovranno fornire:
- Solo il nome del file
- Solo l'estensione del file
- Il numero di vocali contenute nel nome
- Presenza di vocali nel nome (true/false)



Il metodo deve ritornare il nome completo del file, incluso il conteggio delle vocali nella forma: 5eap4ynd.zlo = 3



2) Successivamente implementare due classi derivate dalla prima (Es: FileConVocali, FileSenzaVocali) che rappresentino rispettivamente:
- un file avente numero di vocali > 0
- un file avente nome senza vocali



3) Realizzare una funzionalità che sulla base della discriminante vocali > 0 o vocali = 0 istanzi la classe relativa ed inserisca queste istanze in una collection idonea a contenerle



4) Realizzare quindi una funzionalità che legga la collection precedentemente popolata e visualizzi a video in due TextBox differenti l'elenco dei nomi file senza vocali e quelli con vocali separatamente
*/
//L'esercizio è in realtà un misto tra il primo ed il secondo dato. 

namespace Esercizio_1___windows_form
{


    public partial class Form1 : Form
    {

        List<FileGenerico> filelist = new List<FileGenerico>();

        public Form1()
        {
            InitializeComponent();
            File.WriteAllText("ElencoFile.txt", ""); //cancello il contenuto del file
            //creazione lista nomi random
            for (int i=0; i<100; i++) 
            { 
                string nomeFileConExt = Path.GetRandomFileName();
                FileGenerico tempfile = new FileGenerico(nomeFileConExt.Substring(0, 8), nomeFileConExt.Substring(9, 3));
                    //ho utilizzato le substring per dividere ciò che viene ottenuto dalla funzione random
                File.AppendAllText("ElencoFile.txt", nomeFileConExt + "\r\n");
                filelist.Add(tempfile);
            }
        }

        
        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            textBox1.Text = "Ecco i file: \r\n\r\n";

            foreach (FileGenerico element in filelist) 
            { 

            textBox1.Text += element.ToString() + "\r\n";
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "Ecco i file con il conteggio delle vocali:\r\n\r\n";
            foreach (FileGenerico element in filelist)
            {
                textBox2.Text += element.RitornaNomeANDvoc();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Ecco i file con vocali:\r\n\r\n";
            textBox2.Text = "Ecco i file senza vocali:\r\n\r\n";
            foreach (FileGenerico element in filelist)
            {
                if (element.vocale)
                {
                    
                    textBox1.Text += element.ToString() + "\r\n";
                }
                else
                {
                    
                    textBox2.Text += element.ToString() + "\r\n";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Realizzare un'applicazione Windows Forms che generi un file di testo contenente un elenco di 100 nomi di file casuali e lo visualizzi all'interno di una TextBox nella seguente forma:\r\n5eap4ynd.zlo\r\nk545vlsq.g0n\r\nzret4ryv.k1n\r\n\r\n\r\n\r\nQuindi sempre nella stessa applicazione realizzare una funzionalità che legga il file precedentemente generato e aggiunga in corrispondenza di ciascun nome il numero di vocali contenute in esso nella seguente forma:\r\n\r\n\r\n5eap4ynd.zlo = 3\r\nk545vlsq.g0n = 0\r\nzret4ryv.k1n = 1...\r\n\r\n\r\n\r\nvisualizzando anche questa elaborazione in una seconda TextBox.\r\n\r\n**********\r\n\r\n1) Implementare una classe base(Es: FileGenerico) che rappresenti un generico FILE.Questa classe dovrà avere quattro proprietà ed un metodo.\r\n\r\nLe proprietà dovranno fornire:\r\n\r\t- Solo il nome del file\r\n\r\t-Solo l'estensione del file\r\n\r\t- Il numero di vocali contenute nel nome\r\n\r\t-Presenza di vocali nel nome(true / false)\r\n\r\nIl metodo deve ritornare il nome completo del file, incluso il conteggio delle vocali nella forma: 5eap4ynd.zlo = 3\r\n\r\n2) Successivamente implementare due classi derivate dalla prima(Es: FileConVocali, FileSenzaVocali) che rappresentino rispettivamente:\r\n\r\t- un file avente numero di vocali > 0\r\n\r\t- un file avente nome senza vocali\r\n\r\n3) Realizzare una funzionalità che sulla base della discriminante vocali > 0 o vocali = 0 istanzi la classe relativa ed inserisca queste istanze in una collection idonea a contenerle \r\n\r\n4) Realizzare quindi una funzionalità che legga la collection precedentemente popolata e visualizzi a video in due TextBox differenti l elenco dei nomi file senza vocali e quelli con vocali separatamente";

        }
    }
}
