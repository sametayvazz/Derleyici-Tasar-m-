using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace DerleyiciProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Gerekli tanýmlamalarýn yapýlmasý
        string[] dizin;
        string metin;
        string a;
        string[] d;
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"C:\Users\samet\OneDrive\masaüstü\oku.txt"); //Txt dosya okumasý
            metin = sr.ReadLine();
            while (metin != null)
            {
                dizin = metin.Split(',');
                metin = sr.ReadLine();
                for (int i = 0; i < dizin.Length; i++)
                {
                    textBox1.Text += dizin[i] + " " + " \n\r";
                    a = textBox1.Text;
                    d = a.Split();
                }
            }
        }
        // Düzenli ifadelerin tanýmlanmasý

        Regex RTanimlayici = new Regex("int|string|float|double");
        Regex RMatOperator = new Regex(@"[+|*|-]|%|/");
        Regex RSart = new Regex("if|else|else if");
        Regex RDonguler = new Regex(@"for|while|break");
        Regex RKarsilastirma = new Regex("==|!=|<|>|<=|>=");
        Regex Ryorum = new Regex("[/*|/*]");       

        int i1 = 0;
        int i2 = 0;
        double d1;
        double d2;
        float f1;
        float f2;


        public void Token()
        {
            for (int i = 0; i < d.Length; i++)
            {

                if (RTanimlayici.IsMatch(d[i])) //Tanýmlayýcý ifadelerin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : tanýmlayýcý");
                    listBox2.Items.Add(d[i + 1] + " : Deðiþken Adý ");
                    if (d[i + 2] == "=")
                    {
                        listBox2.Items.Add(d[i + 3] + " : deðer ");
                    }
                    if (d[i+4] == ";")
                    {
                        listBox1.Items.Add(d[i + 1] + " = " + d[i + 3]);

                    }

                }
                if (RMatOperator.IsMatch(d[i]))  //Matematiksel operatörlerin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Matematiksel operatör");
                    listBox2.Items.Add(d[i + 1] + " : Deðer");
                }

                if (RSart.IsMatch(d[i]))  //Þart ifadelerinin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Þart parametresi");
                }
                if (RDonguler.IsMatch(d[i]))  //Döngü olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Döngü parametresi");
                }
                if (RKarsilastirma.IsMatch(d[i]))  //Karþýlaþtýrma operatörlerinin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Karþýlaþtýrma operatörü");
                    listBox2.Items.Add(d[i - 1] + " : Deðiþken");
                    listBox2.Items.Add(d[i + 1] + " : Deðiþken");
                }

            }
        }
        public void Islemler()  //Matematiksel iþlemlerin yapýlmasý
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (RMatOperator.IsMatch(d[i]))  //Matematiksel operatörlerin olma durumu
                {
                    if (d[i - 4] == "int") //int
                    {
                        if (d[i] == "+")
                        {
                            i1 = Convert.ToInt32(d[i - 1]);
                            i2 = Convert.ToInt32(d[i + 1]);
                            listBox1.Items.Add(d[i - 3]+" = " +(i1 + i2));
                        }
                        else if (d[i] == "-")
                        {
                            i1 = Convert.ToInt32(d[i - 1]);
                            i2 = Convert.ToInt32(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (i1 - i2));
                        }
                        else if (d[i] == "*")
                        {
                            i1 = Convert.ToInt32(d[i - 1]);
                            i2 = Convert.ToInt32(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (i1 * i2));
                        }
                        else if (d[i] == "/")
                        {
                            i1 = Convert.ToInt32(d[i - 1]);
                            i2 = Convert.ToInt32(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (i1 / i2));
                        }
                    }
                    else if ((d[i - 4] == "double")) //double
                    {
                        if (d[i] == "+")
                        {
                            d1 = Convert.ToDouble(d[i - 1]);
                            d2 = Convert.ToDouble(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (d1 + d2));
                        }
                        else if ((d[i] == "-"))
                        {
                            d1 = Convert.ToDouble(d[i - 1]);
                            d2 = Convert.ToDouble(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (d1 - d2));
                        }
                        else if ((d[i] == "*"))
                        {
                            d1 = Convert.ToDouble(d[i - 1]);
                            d2 = Convert.ToDouble(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (d1 * d2));
                        }
                        else if ((d[i] == "/"))
                        {
                            d1 = Convert.ToDouble(d[i - 1]);
                            d2 = Convert.ToDouble(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (d1 / d2));
                        }
                    }
                    else if ((d[i - 4] == "float")) //float
                    {
                        if (d[i] == "+")
                        {
                            f1 = float.Parse(d[i - 1]);
                            f2 = float.Parse(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (f1 + f2));
                        }
                        else if ((d[i] == "-"))
                        {
                            f1 = float.Parse(d[i - 1]);
                            f2 = float.Parse(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (f1 - f2));
                        }
                        else if ((d[i] == "*"))
                        {
                            f1 = float.Parse(d[i - 1]);
                            f2 = float.Parse(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (f1 * f2));
                        }
                        else if ((d[i] == "/"))
                        {
                            f1 = float.Parse(d[i - 1]);
                            f2 = float.Parse(d[i + 1]);
                            listBox1.Items.Add(d[i - 3] + " = " + (f1 / f2));
                        }
                    }
                }
            }
        }
        public void Kontrol()  
        {
            listBox1.Items.Add("**************************************");
            for (int i = 0; i < d.Length; i++)
            {

                if (Ryorum.IsMatch(d[i])) // Yorum satýrý kontrolü
                {
                    if (d[i] == "/*")
                    {
                        if (d[i] == "*/")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (RDonguler.IsMatch(d[i]))  //Eðer yorum satýrý deðilse döngü olabilir
                    {
                        if (d[i] == "for") //for döngüsü
                        {
                            int c1 = Convert.ToInt32(d[i + 3]);
                            int c2 = Convert.ToInt32(d[i + 5]);
                            int c3 = Convert.ToInt32(d[i + 9]);

                            if (d[i + 8] == "<")
                            {
                                for (int a = c2; c1 < c3; Convert.ToInt32(d[i + 11]))
                                {


                                }
                            }
                            else if (d[i + 8] == ">")
                            {
                                for (int a = c2; c1 > c3; Convert.ToInt32(d[i + 11]))
                                {

                                }
                            }
                            else if (d[i + 8] == "<=")
                            {
                                for (int a = c2; c1 <= c3; Convert.ToInt32(d[i + 11]))
                                {

                                }
                            }
                            else if (d[i + 8] == ">=")
                            {
                                for (int a = c2; c1 >= c3; Convert.ToInt32(d[i + 11]))
                                {

                                }
                            }
                        }
                        else if (d[i] == "while") //while döngüsü
                        {
                            int c1 = Convert.ToInt32(d[i + 2]);
                            int c2 = Convert.ToInt32(d[i + 4]);
                            if (d[i + 3] == "<")
                            {
                                while (c1 < c2)
                                {
                                    listBox1.Items.Add("While Denemesi");
                                    c1++;
                                }
                            }
                            if (d[i + 3] == ">")
                            {
                                while (c1 > c2)
                                {
                                    listBox1.Items.Add("While Denemesi");
                                    c1--;
                                }
                            }
                            if (d[i + 3] == "<=")
                            {
                                while (c1 <= c2)
                                {
                                    listBox1.Items.Add("While Denemesi");
                                    c1++;
                                }
                            }
                            if (d[i + 3] == ">=")
                            {
                                while (c1 >= c2)
                                {
                                    listBox1.Items.Add("While Denemesi");
                                    c1--;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (RSart.IsMatch(d[i]))  //Þart ifadelerinin olma durumu
                        {
                            if (d[i] == "if" || d[i] == "else if")
                            {

                                if (d[i + 3] == ">") // büyük olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) > Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF koþulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "<") // küçük olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) < Convert.ToInt32(d[i + 4]))
                                    {

                                        listBox1.Items.Add("IF koþulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == ">=") // büyük eþit olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) >= Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF koþulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "<=") // küçük eþit olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) <= Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF koþulu denemesi");

                                    }
                                }
                                else if (d[i + 3] == "==") // eþit olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) == Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF koþulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "!=") // eþit olmama durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) != Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF koþulu denemesi");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            Token();
            Islemler();
            Kontrol();
        }
    }
}