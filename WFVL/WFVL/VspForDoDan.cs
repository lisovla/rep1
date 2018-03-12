using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFVL
{ 
    //Классы Вспомогательные для "Делания" данных 
    class VspForDoDan
    {
    }
    public class clTokaTabDan //класс точка табличных данных
    {
        public double L;
        public double Vel;
        //clConstDan.enTabDan priznak;
        public enTabDan priznak;

        public clTokaTabDan(double L, double Vel, enTabDan priznak) //конструктор класса clTokaTabDan
        {
            this.L = L;
            this.Vel = Vel;
            this.priznak = priznak;
        }

    }//public class clTokaTabDan //класс точка табличных данных

    public class clTabDan //класс табличные данные
    {
        bool kdSoob = true; //код вывода отладочных сообщений из этого класса
        public double TabDanMax = -11111; //максимальное значение данного в таблице
        public double TabDanMin = 11111; //минимальное  значение данного в таблице

        public List<clTokaTabDan> listTabDan = new List<clTokaTabDan>();
        public void AddList(double L, double Vel, enTabDan priznak)
        {
            listTabDan.Add(new clTokaTabDan(L, Vel, priznak)); //используя конструктор класса clTokaTabDan
        }
        public void AddList(clTokaTabDan cTabDan)
        {
            listTabDan.Add(cTabDan); //используя экземпляр класса clTokaTabDan
        }

        public clTabDan()  //конструктор clTabDan
        {
            string s = "";
            //пока задаются 4 произвольные точки, не соответствующие умолчальным значениям из VL
            AddList(new clTokaTabDan(0.0D, 20.0d, enTabDan.TL)); //добавление элемента
            AddList(new clTokaTabDan(500.0D, 21.0d, enTabDan.TL)); //добавление элемента 08.02.18
            AddList(new clTokaTabDan(1000.0D, 22.0d, enTabDan.TL)); //добавление элемента 08.02.18
            AddList(new clTokaTabDan(2000.0D, 25.0d, enTabDan.TL)); //добавление элемента 08.02.18

            //вывод элементов списка на консоль
            //Console.WriteLine("Работает clTabDan() Список: ListTabDan (элементов: " + listTabDan.Count + ")\n");
            clSoob.ZapToVLfile("Работает clTabDan() Список: ListTabDan (элементов: " + listTabDan.Count);
            
            foreach (var item in listTabDan)
            {
                //___Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
                if (kdSoob) clSoob.ZapToVLfile($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
            }
            //Console.WriteLine();
            //16-31Console.ReadKey();
        }//public clTabDan() 

        //конструктор, создающий объект по данным: массивы L, D, признак параметра            
        public clTabDan(double[] L, double[] P, enTabDan Pr)  //конструктор clTabDan
        {
            if (L.Length == 0) //массив L пустой - 
            {
                //___Console.WriteLine(clSoob.SoobVvod_1);
                if (kdSoob) clSoob.ZapToVLfile(clSoob.SoobVvod_1);
            }
            if (P.Length == 0) //массив P пустой - 
            {
                //___Console.WriteLine(clSoob.SoobVvod_2);
                if (kdSoob) clSoob.ZapToVLfile(clSoob.SoobVvod_2);
            }
            if (L.Length != P.Length) //массивы L и P разной длины 
            {
                //___Console.WriteLine(clSoob.SoobVvod_3);
                if (kdSoob) clSoob.ZapToVLfile(clSoob.SoobVvod_3);
            }
            //16.02.18 остальные проверки пока пропускаю для скорейшего получения этого конструктора
            // далее исходные данные массивов L,P принимаю правильными
            for (int i = 0; i <= L.Length - 1; i++)
            {
                AddList(new clTokaTabDan(L[i], P[i], Pr)); //добавление элемента
            }
            ShowListTabDan(); //показать на консоль все элементы списка TabDan
        }


        public void ShowListTabDan() //метод показа на консоль всех элементов списка TabDan
        {
            Console.WriteLine("Работает ShowListTabDan()  класса clTabDan ");
            foreach (var item in listTabDan)
            {
                //___Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
                if (kdSoob) clSoob.ZapToVLfile($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}");
            }            
        }

        public void ExpListTabDan() //эксперименты с ListDan
        {
            int i = -1;  //индексная            
            Console.WriteLine("Работает ExpListTabDan()  класса clTabDan ");
            foreach (var item in listTabDan)
            {
                i = i + 1;
                Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}" + " i={0}", i);
            }            
        }
        public double RezTabDan(double Lz) //получение результата по TabDan (величину параметра, заданную в TabDan)
        {
            int i = 0;      //индексная            
            double Ln = 0;  //L начальная 
            double Lk = 0;  //L конечная
            double Pn = 0;  //P начальное 
            double Pk = 0;  //P конечное 
            bool kd = false;  //код нахождения нужного интервала для определения результата
            double Rez = -9;//результат - конечное значение 
            //___Console.WriteLine("Работает RezTabDan()  класса clTabDan ");
            if (kdSoob) clSoob.ZapToVLfile("Работает RezTabDan()  класса clTabDan ");

            foreach (var item in listTabDan) //цикл перебора всех элементов коллекции для поиска нужного диапазона
            {
                if (i == 0) //1-е значение, сравнение с предыдущим невомзожно, только запомнить
                { Ln = item.L; Pn = item.Vel; }

                if (i > 0)  //2-е и все последующие значения коллекции
                {
                    Lk = item.L; Pk = item.Vel;
                    if ((Lz >= Ln) & (Lz <= Lk)) //найден подходящий диапазон   
                    { kd = true; break; }   //диапазон найден, выход из цикла foreach 
                    Ln = Lk; Pn = Pk;           //конечные значения принять начальными для следующего диапазона
                }
                //___Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}" + " i={0}", i);
                if (kdSoob) clSoob.ZapToVLfile($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}, i={i}");
                i = i + 1;
            }
            if (kd = false) //если подходящий диапазон в цикле не найден 
            {
                //___Console.WriteLine(" RezTabDan()  класса clTabDan: Подходящий интервал не найден. Нужна отладка.  " +
                //___" Поставить здесь аварийное сообщение. ");
                string s = " RezTabDan()  класса clTabDan: Подходящий интервал не найден. Нужна отладка.  " +
                " Поставить здесь аварийное сообщение. ";
                if (kdSoob) clSoob.ZapToVLfile(s);
                return Rez;  //пока выдается условное недопустимое значение
            }
            //Tl:= Tn + (Tk - Tn) / (Lk - Ln) * (L - Ln);  оператор из VL сравнения
            Rez = Pn + (Pk - Pn) / (Lk - Ln) * (Lz - Ln);  //результирующее значение в найденном диапазоне 
            //___Console.WriteLine(" Класс clTabDan. Lz= {0} RezTabDan = {1}", Lz, Rez);
            if (kdSoob) clSoob.ZapToVLfile($" Класс clTabDan. Lz= {Lz} RezTabDan = {Rez}");
            return Rez;
        }

        public void ContrTabDan(double Vmin, double Vmax, clTabDan ob) //контроль данных класса clTabDan
           /*16.02.18 задуманный контроль решил осуществлять в класса clVvodID до создания объекта clTabDan.
             Поэтому пока дальнейшую разработку этого метода приостановил.
           */
        {
            int i = 0;      //  индексная            
            double Ln = 0;  //L начальная 
            double Lk = 0;  //L конечная
            double Pn = 0;  //P начальное 
            double Pk = 0;  //P конечное 
                            //bool   kd = false;  //код нахождения нужного интервала для определения результата

            foreach (var item in ob.listTabDan) //цикл перебора всех элементов коллекции для поиска нужного диапазона
            {
                if (i == 0) //1-е значение, сравнение с предыдущим невомзожно, только запомнить
                { Ln = item.L; Pn = item.Vel; }

                //проверка наличия в коллекции более 1-го элемента. Если только один элемент, то контроль 
                //не имеет смысла,  дать об этом соответствующее сообщение

                if (i > 0)  //2-е и все последующие значения коллекции
                {
                    Lk = item.L; Pk = item.Vel;
                    Ln = Lk;     Pn = Pk;           //конечные значения принять начальными для следующего диапазона
                }
                //___Console.WriteLine($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}" + " i={0}", i);
                if (kdSoob) clSoob.ZapToVLfile($"L={item.L}, Vel ={item.Vel}, priznak={item.priznak}, i={i}");
                i = i + 1;
            }
        }
    }//clTabDan 
}
