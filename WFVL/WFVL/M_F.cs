using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WFVL
{
    public partial class M_F : Form
    {
        public M_F()
        {
            InitializeComponent();
            message.Text = "Приложение загружено";
            
            //опробование разовой записи в специально создаваемый файл
            //string file = clSoob.LVtext.path + "M_F.txt";//местоположение и имя файла для вывода отдельного сообщений             
            string file = clSoob.LVtext;  //местоположение и имя файла для вывода отдельного сообщений             
            File.WriteAllText(file, "дата + время отдельного сообщения");

            //открыть файл VLfile.txt в потоке для записи всех сообщений из VL1
            FileStream swFile = new FileStream(clSoob.LVfile, FileMode.Create);
            StreamWriter sw = new StreamWriter(swFile);
            sw.WriteLine("1-я запись в файл VLfile.txt через StreamWriter sw сразу после FileMode.Create - опробование записи. ");
            //sw.WriteLine();
            sw.Close();

            //открыть файл "ЗамечанияВводаДанных.txt" в потоке для записи всех сообщений из VL1
            FileStream svFile = new FileStream(clSoob.Vvod, FileMode.Create);
            StreamWriter sv = new StreamWriter(svFile);
            sv.WriteLine("1-я запись в файл  ЗамечанияВводаДанных.txt через StreamWriter sw сразу после FileMode.Create - опробование записи. ");
            //sw.WriteLine();
            sv.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("TTT");
        }

        private void buttonExperim_Click(object sender, EventArgs e)
        {     
            
        }

        private void buttonExpT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка Эксперимент с Т");
                        
            string strTL = textBoxT.Text; 
            double TL = Convert.ToDouble(strTL);
            //070318 15-16 clProbaKodaWFVL.zMain(TL);
            clProbaKodaWFVL.Proba_clConstDan(TL);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void M_F_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonVvodID_Click(object sender, EventArgs e)
        {
            //ввод всех ИД VL1
            string s = " Нажата кнопка Ввода ИД";
            string file = clSoob.path + "Отдельная порция.txt";//местоположение и имя файла для вывода отдельного сообщений             
            File.WriteAllText(file, s);    //вывод в файл "Отдельная порция.txt" (отдельная порция текста)          
            MessageBox.Show(s);            //вывод в MessageBox
            File.AppendAllText(file, s);   //вывод в файл "Отдельная порция.txt" (добавление к существующему тексту)
            message.Text = s;              //вывод в строку состояния, а не в MessageBox
            
            s = "опробование записи в файл через метод ";
            clSoob.ZapToVLfile(s);
           

            clVvodID el_clVvodID = new clVvodID();
            //15-39  el_clVvodID.clVvodID(); 


        }

        private void buttonExperim_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("нажата кнопка buttonExperim_Click");

            clPrimer obPrimer = new clPrimer();
            obPrimer.sD = textBoxVvod.Text; //  Console.ReadLine();
            obPrimer.iD = Int32.Parse(obPrimer.sD);
            obPrimer.Rachet();
            
            textBoxRezalt.Text = Convert.ToString(obPrimer.Rez);
            
            string s = "запись в файл LVfile.txt из buttonExperim_Clic через метод ";
            clSoob.ZapToVLfile(s);            
        }

        private void buttonExpT_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка Эксперимент с Т  buttonExpT_Click_1 ");

            string strTL = textBoxT.Text;
            double TL = Convert.ToDouble(strTL);
            //070318 15-16 clProbaKodaWFVL.zMain(TL);
            clProbaKodaWFVL.Proba_clConstDan(TL);
        }

        private void textBoxDlina_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажата кнопка Расчет ");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
