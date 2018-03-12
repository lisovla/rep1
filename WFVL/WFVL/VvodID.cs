using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFVL
{
    //=====================================================
    //Ввод исходных данных
    //=====================================================

    public class clVvodID //класс Ввод ИД. Создание всех объектов исходных данных.
    {

        public List<clTokaTabDan> listTabDan = new List<clTokaTabDan>();
        public void AddList(double L, double Vel, enTabDan priznak) //конструктор класса clTokaTabDan
        {
            listTabDan.Add(new clTokaTabDan(L, Vel, priznak));
        }
        public void AddList(clTokaTabDan cTabDan) //конструктор класса clTokaTabDan
        {
            listTabDan.Add(cTabDan);
        }

        public clVvodID() //конструктор класса clVvodID
        {
            string sVvod; //string значение вводимого параметра (для последующего преобразования в double величину)
            string s = ""; 

            //===================================================================================
            //  ввод отдельных параметров ветви (выработки )
            //===================================================================================
                        
            //????  sVvod = M_F.textBoxDlina.Text; отложено до Зорина
            sVvod = "1111"; // ???  как сделать видимым здесь M_F.textBoxDlina.Text;
            
            clDlina obDlina = new clDlina("1111");
            s = "Работает clVvodID() Параметр Dlina = " + obDlina.Dlina; 
            clSoob.ZapToVLfile(s);

            clPerim obPerim = new clPerim("0,99");
            s = "Работает clVvodID() Параметр Perim = " + obPerim.Perim;
            clSoob.ZapToVLfile(s);

            clSps obSps = new clSps("0,99");
            s = "Работает clVvodID() Параметр Sps = " + obSps.Sps;
            clSoob.ZapToVLfile(s);


            //место ввода остальных параметров (после Dlina)

            //===================================================================================
            //  ввод параметров ветви, представленной таблицей данных TabDan
            //===================================================================================
            //16.02.18 проба ввода TabDan с использованием массивов L, P
            // данные для получения T(L)
            //1702 double[] LT = {0.0,  500.0,  1000.0 };  // длины
            //1702 double[] T = {20.0, 21.0,   22.0 };    // температуры
            // вариант данных для опробования
            double[] LT = { 0.0, 500.0, 1000.0, 2000.0, 3000.0 };  // длины
            double[] T  = { 20.0, 21.0, 22.0, 23.0, 25.0 };        // температуры
            clTabDan TL = new clTabDan(LT, T, enTabDan.TL);
            TL.RezTabDan(1111);
            
            // данные для получения F(L)
            double[] LF = { 0.0, 500.0, 1000.0 };  // длины
            double[] F  = { 0.5, 0.9, 0.99 };      // влажность 
            clTabDan FL = new clTabDan(LF, F, enTabDan.FL);

            {//Этот блок вводит данные в List 
                //___Console.WriteLine("Работает clVvodID(); //конструктор класса clVvodID ");
                s = "Работает clVvodID(); //конструктор класса clVvodID ";
                clSoob.ZapToVLfile(s); 
                AddList(new clTokaTabDan(25.4D, 77d, enTabDan.FL)); //добавление элемента
                AddList(new clTokaTabDan(26.4D, 77d, enTabDan.FL)); //добавление элемента 08.02.18
                AddList(new clTokaTabDan(27.4D, 77d, enTabDan.FL)); //добавление элемента 08.02.18

                //вывод элементов списка в файл
                //___Console.WriteLine("Работает clVvodID() Список: ListTabDan (элементов: " + listTabDan.Count + ")\n");
                s = "Работает clVvodID() Список: ListTabDan (элементов: " + listTabDan.Count;
                foreach (var item in listTabDan)
                {
                    Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
                }
                Console.WriteLine();

                //___Console.WriteLine("Работает clVvodID(); clTabDan D = new clTabDan() ");
                s = "Работает clVvodID(); clTabDan D = new clTabDan() ";
                clSoob.ZapToVLfile(s);
                //Опробование класса clTabDan //класс табличные данные
                clTabDan D = new clTabDan();  //класс табличные данные 

                //___Console.WriteLine(" D.TabDanMax = {0}", D.TabDanMax);
                s = " D.TabDanMax = " + D.TabDanMax;
                clSoob.ZapToVLfile(s);

                D.ShowListTabDan();
                D.ExpListTabDan();
                D.RezTabDan(750.0);

            }//Этот блок вводит данные в List                         
        }//конструктор класса clVvodID
    }//класс Ввод ИД  

    public class z_clVvodID //класс Ввод ИД. Создание всех объектов исходных данных.
    {

        public List<clTokaTabDan> listTabDan = new List<clTokaTabDan>();
        public void AddList(double L, double Vel, enTabDan priznak) //конструктор класса clTokaTabDan
        {
            listTabDan.Add(new clTokaTabDan(L, Vel, priznak));
        }
        public void AddList(clTokaTabDan cTabDan) //конструктор класса clTokaTabDan
        {
            listTabDan.Add(cTabDan);
        }

        public z_clVvodID() //конструктор класса clVvodID
        {
            string sVvod; //string значение вводимого параметра (для последующего преобразования в double величину)

            //===================================================================================
            //  ввод отдельных параметров ветви
            //===================================================================================
            //Ввод данного VL-dlina, теперь clDlina.
            Console.WriteLine("Работает clVvodID() Ввести значение параметра Dlina");
            sVvod = Console.ReadLine();
            clDlina obDlina = new clDlina(sVvod);
            Console.WriteLine("Работает clVvodID() Параметр Dlina = {0}", obDlina.Dlina);


            //===================================================================================
            //  ввод параметров ветви, представленной таблицей данных TabDan
            //===================================================================================
            //16.02.18 проба ввода TabDan с использованием массивов L, P
            // данные для получения T(L)
            //1702 double[] LT = {0.0,  500.0,  1000.0 };  // длины
            //1702 double[] T = {20.0, 21.0,   22.0 };    // температуры
            // вариант данных для опробования
            double[] LT = { 0.0, 500.0, 1000.0, 2000.0, 3000.0 };  // длины
            double[] T = { 20.0, 21.0, 22.0, 23.0, 25.0 };    // температуры

            clTabDan TL = new clTabDan(LT, T, enTabDan.TL);
            TL.RezTabDan(1111);
            //public clTabDan TL = new clTabDan(LT, T, enTabDan.TL);


            // данные для получения F(L)
            double[] LF = { 0.0, 500.0, 1000.0 };  // длины
            double[] F = { 0.5, 0.9, 0.99 };    // влажность 
            clTabDan FL = new clTabDan(LF, F, enTabDan.FL);

            {//Этот блок вводит данные в List 
                Console.WriteLine("Работает clVvodID(); //конструктор класса clVvodID ");

                AddList(new clTokaTabDan(25.4D, 77d, enTabDan.FL)); //добавление элемента
                AddList(new clTokaTabDan(26.4D, 77d, enTabDan.FL)); //добавление элемента 08.02.18
                AddList(new clTokaTabDan(27.4D, 77d, enTabDan.FL)); //добавление элемента 08.02.18

                //вывод элементов списка на консоль
                Console.WriteLine("Работает clVvodID() Список: ListTabDan (элементов: " + listTabDan.Count + ")\n");
                foreach (var item in listTabDan)
                {
                    Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
                }
                Console.WriteLine();

                Console.WriteLine("Работает clVvodID(); clTabDan D = new clTabDan() ");
                //Опробование класса clTabDan //класс табличные данные
                clTabDan D = new clTabDan();  //класс табличные данные 

                Console.WriteLine(" D.TabDanMax = {0}", D.TabDanMax);
                D.ShowListTabDan();
                D.ExpListTabDan();
                D.RezTabDan(750.0);

            }//Этот блок вводит данные в List                         
        }//конструктор класса clVvodID
    }//класс Ввод ИД  
}
