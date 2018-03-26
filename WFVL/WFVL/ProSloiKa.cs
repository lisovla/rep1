using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace WFVL
{
    //=====================================================
    //"Прослойка" при вводе исходных данных и, наверно, выводе результатов.
    //=====================================================
    class ProSloiKa
    {
    }

    public class clPrimer  //опробование расчетной операции, связанной с вводом через компоненты формы
    {
        public string sD;
        public int iD = 0;
        public int Rez = 0;

        public void Rachet()
        {
            Rez = iD * iD;
            //return Rez;
            //Комментарий
        }
    }


    class clProbaKodaWFVL //класс, аккумулирующий опробование всей классов из WPFVL1
    {       
        //070318 15-12 static public void zMain(
        static public void Proba_clConstDan(
            double zadTL // заданная TL
            )
        {           
            //опробование определения парциального давления методом clConstDan.ps(Trab)                        
            FileStream swFile = new FileStream(clSoob.LVfile, FileMode.Append);
            StreamWriter sw = new StreamWriter(swFile);         
            sw.WriteLine(" Опробование файла clProSloika  класс clProbaKodaWFVL  метод Proba_clConstDan ");

            double PsRab = clConstDan.ps(zadTL);

            MessageBox.Show("нажата кнопка ");
            string ss = "Result" +  Convert.ToString(PsRab);
            MessageBox.Show(" ss = " + ss);
            sw.WriteLine("PsRab = {0} для clConstDan.ps(Trab) Trab={1}", PsRab, zadTL);
            sw.Close();
        }
    }
}

