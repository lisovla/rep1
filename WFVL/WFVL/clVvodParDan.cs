using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFVL
{
    public class clVvodParDan
    {//класс ввода данного, представленного одним параметром (например, Dlina)
     /*введенное string значение анализируется, выдаются необходимые сообщения, выполняются проверки, 
       окончательно принимаемое значение сохраняется в поле ParDan, а код его ввода - в поле kodVvod */
        public double ParDan = -1.0; //окончательно принимаемое значение параметра
        public bool kodVvod = false; //код ввода значения параметра (true - параметр определен, т.е. введен)
        private string srab = "";    //рабочая
        private bool kdSoob = true;  //код выдачи сообщений в конструктрое этого класса 

        public clVvodParDan(  //конструктор класса
            string NamePar,   //наименование анализируемого параметра
            string s,         //string представление заданной величины анализируемого параметра
            double Um, double Max, double Min)// значения параметра умолчальное, Max, Min
        {
            if (s.Length == 0) //принимается значение по умолчанию.
            { 
                ParDan = Um; kodVvod = true;
                // сообщение о принятии значения по умолчанию и возможности его изменения
                srab = " Параметр " + NamePar + " не задан, поэтому принимается значение по умолчанию равное " + ParDan + 
                       " При необходимости его изменения прервите ввод и укажите необходимое новое значение ";
                if ( clSoob.kdVseOtlSoob && kdSoob)  { clSoob.ZapToVLfile(srab);    MessageBox.Show(srab);  }                
                return;
            }
            {//проверка корректного преобразования s в double
                try
                {
                    ParDan = double.Parse(s);                   
                    srab = " Моя Отладка: Параметр " + NamePar + " задано s= " + s + " преобразовано к ParDan =" + ParDan;
                    if (clSoob.kdVseOtlSoob && kdSoob) { clSoob.ZapToVLfile(srab); MessageBox.Show(srab); }
                    kodVvod = true;
                }
                catch (OverflowException)
                {                    
                    srab = " Не удается преобразовать заданное s = "+ s +" в тип double.Укажите правильное значение параметра";
                    if (clSoob.kdVseOtlSoob && kdSoob) { clSoob.ZapToVLfile(srab); MessageBox.Show(srab); }
                    clSoob.ZapVvodDan(srab);
                    return;
                }
            }
            {//проверка невыхода на Min и Max значения, выдать предупреждающие сообщения
                if (ParDan > Max)
                {                    
                    srab = " Заданное значение параметра " + NamePar + "=" + ParDan +" превышает предусмотренное Max значение = " + Max;
                    if (clSoob.kdVseOtlSoob && kdSoob) { clSoob.ZapToVLfile(srab); MessageBox.Show(srab); }
                    clSoob.ZapVvodDan(srab);
                }                   

                if (ParDan < Min)
                {                 
                    srab = " Заданное значение параметра " + NamePar + "=" + ParDan + " менее предусмотренного Min значения = " + Min;
                    if (clSoob.kdVseOtlSoob && kdSoob) { clSoob.ZapToVLfile(srab); MessageBox.Show(srab); }
                    clSoob.ZapVvodDan(srab);
                }                    
            }
            return;
        }
    }//public class clVvodParDan 
}
