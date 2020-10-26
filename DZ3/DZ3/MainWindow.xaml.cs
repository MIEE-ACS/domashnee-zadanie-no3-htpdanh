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

        public String exchangeStr(String s1,String Alphabet)
        {
            while(s1.LastIndexOf(",")==(s1.Length-1))
            {
                s1 = s1.Remove(s1.Length - 1, 1);
            }
            s1 = s1.Replace(" ", "");
            String[] s = s1.Split(",");
            String s0 = "";
            Char c;
            for (int i = 0; i < s.Length; i++)
            {
                c = Alphabet[Convert.ToByte(s[i])];
                s0 = (String)s0 + c;
            }
            return s0;
        }

        public String conduct(String s1,String s2,String Alphabet)
        {
            String result = "";
            Byte a, b;
            Char c;

            while (s2.Length < s1.Length)
            {
                for (int i = 0; i < s2.Length; i++)
                {
                    s2 = s2 + s2[i];
                    if (s2.Length == s1.Length)
                        break;
                }
            }

            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    a =(Byte) Alphabet.IndexOf(s1[i]);
                    b = (Byte)Alphabet.IndexOf(s2[i]);
                    c = Alphabet[((a + b) % Alphabet.Length)];
                    result = (String)(result + c);
                }
            }


            if (s1.Length < s2.Length)
            {
                String ss = String.Concat(s1, s2.Replace(" ", ""));
                int d = 0;
                for (int i = 0; i < s2.Length; i++)
                {
                    if (s2[i] != ' ')
                    {
                        result = result + ss[d];
                        d = d + 1;
                    }
                    else
                        result += " ";
                }
            }
            return result;
        }
        
        private void Buttonclick_Click(object sender, RoutedEventArgs e)
        {
            string RusAlphabet = "абвгдеёжзийклмнопрстуфкцчшщъыьэюя";
            string BigWordRusAlphabet = RusAlphabet.ToUpper();

            string LatinAlphabet = "abcdefghijklmnopqrstuvwxyz";
            string BigWordLatinAlphabet = LatinAlphabet.ToUpper();

            String Alphabet;

            String s1 = Input1.Text;
            String s2 = Input2.Text;

            s1 = s1.Replace(" ", "");
            
            s1 = s1.ToUpper();
            s2=s2.ToUpper();
            if ((Byte)s1[0] < 65)
                Alphabet = BigWordRusAlphabet;
            else
                Alphabet = BigWordLatinAlphabet;

            if (s1.IndexOf(",") != -1)
            {
                s1 = exchangeStr(s1,Alphabet);
            }

            if (s2.IndexOf(",") != -1)
            {
                s2 = exchangeStr(s2,Alphabet);
            }
           
            Output.Text =$"{conduct(s1,s2,Alphabet)}";
        }
    }
}
