using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio_1___windows_form
{

    public class FileGenerico
    {
        string[] vocali = { "a", "e", "i", "o", "u" };
        public string nome { get; set; }
        public string ext { get; set; }
        public int numvocali 
        { get 
            {
                int numerovocali = 0;
                foreach(string v in vocali)
                {
                    if (this.nome.Contains(v)) numerovocali++;
                    if (this.ext.Contains(v)) numerovocali++;
                    
                }

                return numerovocali;
            }
            private set { } 
        }

        public FileGenerico(string nome, string ext)
        {
            this.nome = nome;
            this.ext = ext;
        }

        public virtual bool vocale 
        { get
            {
                return this.numvocali > 0;
                
            }
            private set { } 
        }

        public string RitornaNomeANDvoc()
        {
            return this.ToString() + " = " + numvocali.ToString() + "\r\n";
        }

        public override string ToString()
        {
            return nome + "." + ext;
        }
    }

    public class FileConVocali : FileGenerico
    {
        public FileConVocali(string nome, string ext) : base(nome, ext)
        {
        }
    }

    public class FileSenzaVocali : FileGenerico
    {
        public FileSenzaVocali(string nome, string ext) : base(nome, ext)
        {
        }
    }
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
