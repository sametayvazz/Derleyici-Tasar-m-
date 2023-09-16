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
        // Gerekli tan�mlamalar�n yap�lmas�
        string[] dizin;
        string metin;
        string a;
        string[] d;
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"C:\Users\samet\OneDrive\masa�st�\oku.txt"); //Txt dosya okumas�
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
        // D�zenli ifadelerin tan�mlanmas�

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

                if (RTanimlayici.IsMatch(d[i])) //Tan�mlay�c� ifadelerin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : tan�mlay�c�");
                    listBox2.Items.Add(d[i + 1] + " : De�i�ken Ad� ");
                    if (d[i + 2] == "=")
                    {
                        listBox2.Items.Add(d[i + 3] + " : de�er ");
                    }
                    if (d[i+4] == ";")
                    {
                        listBox1.Items.Add(d[i + 1] + " = " + d[i + 3]);

                    }

                }
                if (RMatOperator.IsMatch(d[i]))  //Matematiksel operat�rlerin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Matematiksel operat�r");
                    listBox2.Items.Add(d[i + 1] + " : De�er");
                }

                if (RSart.IsMatch(d[i]))  //�art ifadelerinin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : �art parametresi");
                }
                if (RDonguler.IsMatch(d[i]))  //D�ng� olma durumu
                {
                    listBox2.Items.Add(d[i] + " : D�ng� parametresi");
                }
                if (RKarsilastirma.IsMatch(d[i]))  //Kar��la�t�rma operat�rlerinin olma durumu
                {
                    listBox2.Items.Add(d[i] + " : Kar��la�t�rma operat�r�");
                    listBox2.Items.Add(d[i - 1] + " : De�i�ken");
                    listBox2.Items.Add(d[i + 1] + " : De�i�ken");
                }

            }
        }
        public void Islemler()  //Matematiksel i�lemlerin yap�lmas�
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (RMatOperator.IsMatch(d[i]))  //Matematiksel operat�rlerin olma durumu
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

                if (Ryorum.IsMatch(d[i])) // Yorum sat�r� kontrol�
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
                    if (RDonguler.IsMatch(d[i]))  //E�er yorum sat�r� de�ilse d�ng� olabilir
                    {
                        if (d[i] == "for") //for d�ng�s�
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
                        else if (d[i] == "while") //while d�ng�s�
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
                        if (RSart.IsMatch(d[i]))  //�art ifadelerinin olma durumu
                        {
                            if (d[i] == "if" || d[i] == "else if")
                            {

                                if (d[i + 3] == ">") // b�y�k olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) > Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF ko�ulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "<") // k���k olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) < Convert.ToInt32(d[i + 4]))
                                    {

                                        listBox1.Items.Add("IF ko�ulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == ">=") // b�y�k e�it olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) >= Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF ko�ulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "<=") // k���k e�it olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) <= Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF ko�ulu denemesi");

                                    }
                                }
                                else if (d[i + 3] == "==") // e�it olma durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) == Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF ko�ulu denemesi");
                                    }
                                }
                                else if (d[i + 3] == "!=") // e�it olmama durumu
                                {
                                    if (Convert.ToInt32(d[i + 2]) != Convert.ToInt32(d[i + 4]))
                                    {
                                        listBox1.Items.Add("IF ko�ulu denemesi");
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