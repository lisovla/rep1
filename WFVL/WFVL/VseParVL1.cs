using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WFVL
{
    class VseParVL1
    {
    }
    // Все параметры (данные по аналогии с классом clDlina) проекта VL1

    public class clDlina //класс параметра Dlina (в VL - dlina) 
    {
        private string NamePar = "Dlina";   //наименование параметра 
        private double _Dlina = -11.1;      //длина ветви(выработки/воздуховода. Первоначальное абсурдное значение.        
        private double DlinaUm = 1000.0;    //значение по умолчанию 
        private double DlinaMax = 10000.0;  //значение максимальное разумное
        private double DlinaMin = 10.0;     //значение минимальное  разумное        
        private bool   KodGot_Dlina = false; //код готовности (значение введено)
        /* фрагмент кода VL - для проверки согласованности алгоритмов VL и VL1
        V_dlina  : extended;                  {длина ветви(выработки/воздуховода}
        dlinaUm  : extended = 1000.0;         {условное значение по умолчанию}
        dlinaMax : extended = 10000.0;        {разумное максимальное}
        dlinaMin : extended = 10.0;           {разумное ммнимальное }
        KodGot_Vdlina : boolean = false;      {код готовности(значение введено)}
        */
        public clDlina(string sPar)
        {
            clVvodParDan ob = new clVvodParDan(NamePar, sPar, DlinaUm, DlinaMax, DlinaMin);
            _Dlina = ob.ParDan;         //длина ветви(выработки/воздуховода
            KodGot_Dlina = ob.kodVvod;  //код готовности(значение введено)
        }

        public double Dlina  //свойства
        { 
            get { return this._Dlina; }            
            set {
                string s = " Поле Dlina " + clSoob.SoobVvod_4; //Попытка определения поля через свойсво set. Этого не должно быть. Необходима отладка
                MessageBox.Show(s);   clSoob.ZapVvodDan(s);
                return; }
        }
                        
        public double gsDlina  //080318 первоначальные решения по созданию свойств. Оставлены "на всякий случай", как напоминание
        { 
            get
            {
                if (KodGot_Dlina == true)
                    return Dlina;
                else
                    //дать сообщение об отсутствии данного параметра
                    Console.WriteLine(" clDlina: Значение параметра " + NamePar + " не определено. Ошибка алгоритма. " +
                        " Исправить код. Дальнейший расчет невозможен. ");
                //пока, на время обучения-разработки, вместо аварийного завершения проги выдаю 
                return Dlina;
            }
            set
            {
                if (KodGot_Dlina == false)
                {
                    Console.WriteLine(" clDlina: " + "Попытка переопределить величину параметра " + NamePar +
                        " Ошибка алгоритма. Исправить алгоритм и код.");
                }
            }
        }
    }


    public class cop_clDlina
    {//класс параметра Dlina (в VL - dlina) 
     // privat class clDlina {//класс параметра Dlina (в VL - dlina) 

        public string NamePar = "Dlina";  //наименование параметра 
        public double Dlina = -11.1;    //длина ветви(выработки/воздуховода. Первоначальное абсурдное значение.
        // privat double Dlina = -11.1;    //длина ветви(выработки/воздуховода. Первоначальное абсурдное значение.
        public double DlinaUm = 1000.0;   //значение по умолчанию 
        public double DlinaMax = 10000.0;  //значение максимальное разумное
        public double DlinaMin = 10.0;     //значение минимальное  разумное        
        public bool KodGot_VDlina = false; //код готовности (значение введено)
        /* фрагмент кода VL - для проверки согласованности алгоритмов VL и VL1
        V_dlina  : extended;                  {длина ветви(выработки/воздуховода}
        dlinaUm  : extended = 1000.0;         {условное значение по умолчанию}
        dlinaMax : extended = 10000.0;        {разумное максимальное}
        dlinaMin : extended = 10.0;           {разумное ммнимальное }
        KodGot_Vdlina : boolean = false;      {код готовности(значение введено)}
        */
        public cop_clDlina(string sPar)
        {
            clVvodParDan ob = new clVvodParDan(NamePar, sPar, DlinaUm, DlinaMax, DlinaMin);
            Dlina = ob.ParDan;           //длина ветви(выработки/воздуховода
            KodGot_VDlina = ob.kodVvod;  //код готовности(значение введено)
        }
        public double gsDlina
        { //  get  set
            get
            {
                if (KodGot_VDlina == true)
                    return Dlina;
                else
                    //дать сообщение об отсутствии данного параметра
                    Console.WriteLine(" clDlina: Значение параметра " + NamePar + " не определено. Ошибка алгоритма. " +
                        " Исправить код. Дальнейший расчет невозможен. ");
                //пока, на время обучения-разработки, вместо аварийного завершения проги выдаю 
                return Dlina;
            }
            set
            {
                if (KodGot_VDlina == false)
                {
                    Console.WriteLine(" clDlina: " + "Попытка переопределить величину параметра " + NamePar +
                        " Ошибка алгоритма. Исправить алгоритм и код.");
                }
            }
        }//public  double gsDlina {
    }//public class clDlina  //класс параметра Dlina (в VL - dlina)  

   
    public class clPerim //класс параметра Perim (в VL - Perim) 
    {
        private string NamePar = "Perim";  //наименование параметра 
        private double _Perim = -11.1;     //перимерт ветви(выработки/воздуховода. Первоначальное абсурдное значение.        
        private double PerimUm = 10.0;     //значение по умолчанию 
        private double PerimMax = 100.0;   //значение максимальное разумное
        private double PerimMin = 1.0;     //значение минимальное  разумное        
        private bool KodGot_Perim = false; //код готовности (значение введено)
        /* фрагмент кода VL - для проверки согласованности алгоритмов VL и VL1
        V_perim   : extended;                {периметр(выработки/воздуховода}
        perimUm  : extended = 10.0;          {условное значение по умолчанию}
        perimMax : extended = 100.0;         {разумное максимальное}
        perimMin : extended = 1.0;           {разумное ммнимальное }
        KodGot_Vperim : boolean = false;     {код готовности(значение введено)}        
        */
        public clPerim(string sPar)
        {
            clVvodParDan ob = new clVvodParDan(NamePar, sPar, PerimUm, PerimMax, PerimMin);
            _Perim = ob.ParDan;         //Perim ветви(выработки/воздуховода
            KodGot_Perim = ob.kodVvod;  //код готовности(значение введено)
        }

        public double Perim  //свойства
        {
            get { return this._Perim; }
            set
            {
                string s = " Поле Perim " + clSoob.SoobVvod_4; //Попытка определения поля через свойсво set. Этого не должно быть. Необходима отладка
                MessageBox.Show(s); clSoob.ZapVvodDan(s);
                return;
            }
        }        
    }

    /*
      V_beta     : extended;                  {betta ветви ыработки}
     betaUm   : extended = 1.6{0.001 обеспечивается при 1.6};{условное значение по умолчанию}
     betaMax  : extended = 1.0;            {разумное максимальное}
     betaMin  : extended = 0.0000001;      {разумное ммнимальное }
     KodGot_Vbeta : boolean = false;      {код готовности (значение введено)}

   V_perim    : extended;                  {периметр (выработки/воздуховода}
     perimUm  : extended = 10.0;           {условное значение по умолчанию}
     perimMax : extended = 100.0;          {разумное максимальное}
     perimMin : extended = 1.0;            {разумное ммнимальное }
     KodGot_Vperim : boolean = false;     {код готовности (значение введено)}

   V_sps      : extended;                  {площадь поперечного сечения }
     spsUm    : extended = 20.0;           {условное значение по умолчанию}
     spsMax   : extended = 100.0;          {разумное максимальное}
     spsMin   : extended = 1.0;            {разумное ммнимальное }
     KodGot_Vsps : boolean = false;       {код готовности (значение введено)}

   V_udkt     : extended;                  {удельный коэффициент трения }
     udktUm   : extended = 0.001;          {условное значение по умолчанию}
     udktMax  : extended = 1.0;            {разумное максимальное}
     udktMin  : extended = 0.0000001;      {разумное ммнимальное }
     KodGot_Vudkt : boolean = false;      {код готовности (значение введено)}

   V_urv     : extended;            {условие расчета (расположения) воздуховода }
     urvUm   : extended = 1.0;
     urvMax  : extended = 1.0;
     urvMin  : extended =-1.0;
     KodGot_Vurv : boolean = false;

   V_rasmo    : extended;                        {расход массовый сухого воздуха}
     rasmoUm  : extended = 100.0;
     rasmoMax : extended = 10000.0;
     rasmoMin : extended = 1.0;
     KodGot_Vrasmo : boolean = false;

    */
    public class clSps //класс параметра Sps (в VL - Sps) 
    {
        private string NamePar = "Sps";  //наименование параметра 
        private double _Sps = -11.1;   //перимерт ветви(выработки/воздуховода. Первоначальное абсурдное значение.        
        private double SpsUm = 20.0;    //значение по умолчанию 
        private double SpsMax = 100.0;   //значение максимальное разумное
        private double SpsMin = 1.0;     //значение минимальное  разумное        
        private bool KodGot_Sps = false; //код готовности (значение введено)
        /* фрагмент кода VL - для проверки согласованности алгоритмов VL и VL1
         V_sps      : extended;                  {площадь поперечного сечения }
         spsUm    : extended = 20.0;           {условное значение по умолчанию}
         spsMax   : extended = 100.0;          {разумное максимальное}
         spsMin   : extended = 1.0;            {разумное ммнимальное }
         KodGot_Vsps : boolean = false;       {код готовности (значение введено)}
        */
        public clSps(string sPar)
        {
            clVvodParDan ob = new clVvodParDan(NamePar, sPar, SpsUm, SpsMax, SpsMin);
            _Sps = ob.ParDan;         //Sps ветви(выработки/воздуховода
            KodGot_Sps = ob.kodVvod;  //код готовности(значение введено)
        }

        public double Sps  //свойства
        {
            get { return this._Sps; }
            set
            {
                string s = " Поле Sps " + clSoob.SoobVvod_4; //Попытка определения поля через свойсво set. Этого не должно быть. Необходима отладка
                MessageBox.Show(s); clSoob.ZapVvodDan(s);
                return;
            }
        }

        public class clBeta //класс параметра Beta (в VL - Beta) 
        {
            private string NamePar = "Beta";  //наименование параметра 
            private double _Beta = -11.1;     //beta ветви(выработки/воздуховода. Первоначальное абсурдное значение.        
            private double BetaUm = 1, б;      //значение по умолчанию 
            private double BetaMax = 1.0;     //значение максимальное разумное
            private double BetaMin = 0.00000001; //значение минимальное  разумное        
            private bool KodGot_Beta = false; //код готовности (значение введено)
            /*Фагмент кода VL - для проверки согласованности алгоритмов VL и VL1
            V_beta   : extended;                {betta ветви ыработки}
            betaUm   : extended = 1.6{0.001 обеспечивается при 1.6};{условное значение по умолчанию}
            betaMax  : extended = 1.0;            {разумное максимальное}
            betaMin  : extended = 0.0000001;      {разумное ммнимальное }
            KodGot_Vbeta : boolean = false;      {код готовности (значение введено)}о)}
            */
            public clBeta(string sPar)
            {
                clVvodParDan ob = new clVvodParDan(NamePar, sPar, BetaUm, BetaMax, BetaMin);
                _Beta = ob.ParDan;         //Beta ветви(выработки/воздуховода
                KodGot_Beta = ob.kodVvod;  //код готовности(значение введено)
            }

            public double Beta  //свойства
            {
                get { return this._Beta; }
                set
                {
                    string s = " Поле Beta " + clSoob.SoobVvod_4; //Попытка определения поля через свойсво set. Этого не должно быть. Необходима отладка
                    MessageBox.Show(s); clSoob.ZapVvodDan(s);
                    return;
                }
            }
        }

    }
}

