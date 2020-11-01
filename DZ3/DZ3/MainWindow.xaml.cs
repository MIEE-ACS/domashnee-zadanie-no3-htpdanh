using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ss(ref String s1, ref String s2)
        {
            s1 = s1.Trim();
            s2 = s2.Trim();
            s1 = s1.ToUpper();
            s2 = s2.ToUpper();
            while (s2.Length < s1.Length)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    s2 = s2 + s2[i];
                    if (s2.Length == s1.Length)
                        break;
                }
            }
        }
       
        public String conduct(String s1,String s2,String Alphabet)
        {
            String result = "";
            int a, b;            
            Char c;
            Char h;
            if (s1.Length == s2.Length)
            {
                int k = 0;
                for (int i = 0; i < s1.Length; i++)
                {
                    a = Alphabet.IndexOf(s1[i]);
                    if (i == (s1.Length - 1))
                        h = s1[i];
                    else h = s1[i + 1];
                    if ((s1[i] == ' ' || s1[i]==',' || s1[i] =='.'))
                        if (s1[i]!=h)
                    {
                        result = result + s1[i];
                    }
                    if (a!=-1)
                    {    
                        b = Alphabet.IndexOf(s2[k]);
                        c = Alphabet[((a + b) % (Alphabet.Length))];
                        result = (String)(result + c);
                        k++;
                    }
                }
            }

            if (s1.Length < s2.Length)
            {
                String ss = String.Concat(s1, s2.Replace(" ", ""));
                int d = 0;
                for (int i = 0; i < s2.Length; i++)
                {
                    if ((s2[i] != ' ') || (s2[i] == ',') || (s2[i] == '.'))
                    {
                        result = result + ss[d];
                        d = d + 1;
                    }
                    else
                        result += s2[i];
                }
            }
            return result;
        }
        
        private void Buttonclick_Click(object sender, RoutedEventArgs e)
        {
            string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string BigWordRusAlphabet = RusAlphabet.ToUpper();

            string LatinAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string BigWordLatinAlphabet = LatinAlphabet.ToUpper();

            String Alphabet;

            String s1 = Input1.Text;
            String s2 = Input2.Text;

            ss(ref s1, ref s2);
            if ((Byte)s1[0] < 65)
                Alphabet = BigWordRusAlphabet;
            else
                Alphabet = BigWordLatinAlphabet;

            Output.Text =$"{conduct(s1,s2,Alphabet)}";
        }

        private void button2_Click(object sender1, RoutedEventArgs e1)
        {
            string Rus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string BigRus = Rus.ToUpper();

            string Latin = "abcdefghijklmnopqrstuvwxyz";
            string BigLatin = Latin.ToUpper();

            String Alphabe;

            String s3 = Input1.Text;
            String s4 = Input2.Text;

            ss(ref s3, ref s4);

           
                if ((Byte)s3[0] < 65)
                    Alphabe = BigRus;
                else
                    Alphabe = BigLatin;
            
            String result = "";
            int a, b;
            Char c;
            int d;
            Char h;
            if (s3.Length == s4.Length)
            {
                int k = 0;
                for (int i = 0; i < s3.Length; i++)
                {
                    a = Alphabe.IndexOf(s3[i]);
                    if (i == (s3.Length - 1))
                        h = s3[i];
                    else h = s3[i + 1];
                    if ((s3[i] == ' ' || s3[i] == ',' || s3[i] == '.'))
                        if (s3[i]!=h)
                    {
                        result = result + s3[i];
                    }
                    if (a != -1)
                    {
                        b = Alphabe.IndexOf(s4[k]);
                        d = (a - b);
                        if (d >= 0)
                        {
                            c = Alphabe[d];
                        }
                        else 
                        {
                            d = d + Alphabe.Length;
                            c = Alphabe[d];
                        }

                        result = (String)(result + c);
                        k++;
                    }
                }
            }
           
            Output.Text = $"{result}";          
        }
    }
}
