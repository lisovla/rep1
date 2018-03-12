using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFVL
{
    //=====================================================
    //Все опробования классов при разработке VL1
    //=====================================================
   
    class clProba_class
    {

        static void z_Main() //static void Main(string[] args)//"Заменитель" Main консольного приложения
        {
            double T;
            do
            {
                Console.WriteLine("proba VL1 Введите температуру в град.С");

                string srab = Console.ReadLine();
                T = Convert.ToDouble(srab);
                Console.WriteLine("Введена Т={0}", T);

                double PsRab = clConstDan.ps(T);

                Console.WriteLine("PsRab ={0} ", PsRab);
                /*26.01.18   фрагмент перенес в класс clVvodID
               //Работа со списками от СЭМа
               clVvodID L = new clVvodID();
               L.AddList(new clTokaTabDan(25.4D, 77d, enTabDan.FL)); //добавление элемента
               L.AddList(29.4, 71.7, enTabDan.TL); //добавление элемента

               //вывод элементов списка на консоль
               Console.WriteLine("Список: L.ListTabDan (элементов -" + L.listTabDan.Count + ")\n");
               foreach(var item in L.listTabDan)
               {
                   Console.WriteLine($"L={item.L}, Veb ={item.Vel}, priznak={item.priznak}");
               }
               Console.WriteLine();              
               */

            }//do {
            while (T >= 0.0);

            //Работа со списками от СЭМа
            Console.WriteLine();
            clVvodID L = new clVvodID();
            

            //clTabDan TL1 = new clTabDan(LT, T, enTabDan.TL);
            clTabDan TL1 = new clTabDan();
            TL1.RezTabDan(11);
            TL1.ShowListTabDan();
        }
    }//class clProba_class

    /*040318 
    public class clPrimer  //опробование расчетной операции, связанной с вводом через компоненты формы
    {
        public string sD;
        public int iD;
        public int Rez;

        public void Rachet()
        {
            Rez = iD * iD;
        }
    }
    */
}
