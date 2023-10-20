using chernovik2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chernovik2
{
    internal class Program
    {

        private int month;
        private int a;
        private int vibor;
        private int[,] nastr_avg = new int[31, 2];
        private int[,] nastr_sen = new int[31, 2];
        private int[,] nastr_okt = new int[31, 2];
        private int vibor_2;
        private int c = 0;
        private float ch;
        private float sr_diap;
        private int count;
        private int count_2;
        private int count_3;
        private int count_4;
        private string[] week = new string[7];
        private float d_1;
        private float d_2;
        private int d2;
        private int i;
        private int q;

        public void Ned()
        {
            foreach (string i in week)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        public int Cc(int b)
        {
            int[,] data_av = new int[6, 7];
            int a = 1;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (b = b; b < 7; b++)
                    {
                        data_av[i, b] = a;
                        a++;
                    }
                }
            }
            for (int i = 1; i < 6; i++)
            {
                for (int j = 0; j < 7 && a < 32; j++)
                {
                    data_av[i, j] = a;
                    a++;
                }
            }
            Console.WriteLine();
            Ned();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{data_av[i, j]} \t");
                }
                Console.WriteLine();
            }
            return b;
        }
        public void Ccalendar()
        {
            Console.WriteLine("Дневник настроения");
            Console.WriteLine("Календарь");
            Console.WriteLine("Август");
            week = new string[7] { "ПН\t", "ВТ\t", "СР\t", "ЧТ\t", "ПТ\t", "СБ\t", "ВС\t" };  
            Cc(1);
            Console.WriteLine("Сентябрь");
            Cc(4);
            Console.WriteLine("Октябрь");
            Cc(0);
            N();
            Nastr_3();
            Console.WriteLine("Напишитие за какой месяц хотите посмотреть настроение");
            Console.WriteLine("Подсказка: 1 - Август, 2 - Сентябрь, 3 - Октябрь");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Vibor();
        }
        public void N()
        {
            Random rand = new Random();
            a = 1;
            while (c < 1)
            {
                for (int i = 0; i < 31 && a <= 31; i++)
                {
                    for (int q = 0; q < 1; q++)
                    {
                        nastr_avg[i, q] = a;
                        nastr_sen[i, q] = a;
                        nastr_okt[i, q] = a;
                        a++;
                    }
                }
                for (int i = 0; i < 31; i++)
                {
                    for (int q = 1; q < 2; q++)
                    {
                        nastr_avg[i, q] = rand.Next(1, 6);
                        nastr_sen[i, q] = rand.Next(1, 6);
                        nastr_okt[i, q] = rand.Next(1, 6);
                    }
                }
                c++;
            }    
        }
        public void Nastr_3()
        {
            int sum_avg = 0;
            int sum_sen = 0;
            int sum_okt = 0;
            for (int i = 0; i < 31; i++)
            {
                for (int q = 1; q < 2; q++)
                {
                    sum_avg = nastr_avg[i, q] + sum_avg;
                    sum_sen = nastr_sen[i, q] + sum_sen;
                    sum_okt = nastr_okt[i, q] + sum_okt;
                }
            }
            double max_sr = ((sum_avg / 31.0) + (sum_sen / 31.0) + (sum_okt / 31.0)) / 3.0;
            Console.WriteLine($"Среднее настроение за 3 месяца: {max_sr}");
        }
        public void Vibor()
        {
            for (int i = 0; i < 31; i++)
            {
                for (int q = 0; q < 2; q++)
                {
                    if (month == 3)
                        Console.Write($"{nastr_okt[i, q]} \t");
                    if (month == 2)
                        Console.Write($"{nastr_sen[i, q]} \t");
                    if (month == 1)
                        Console.Write($"{nastr_avg[i, q]} \t");
                }
                Console.WriteLine();
            }
            Vopros();
        }
        public void Vopros()
        {
            Console.WriteLine("Укажите, что вы хотели бы сделать:");
            Console.WriteLine("1. Среднее настроение за последнюю неделю;\n2. Среднее настроение за определенный диапазон;\n3. Количество дней хорошего/отличного настроения;\n4. Количество дней плохого/ужасного настроения. ");
            Console.WriteLine("Если хотите вернуться в главное меню, нажмите: 0");
            vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 0)
            {
                Ccalendar();
            }
            if (vibor == 1)
            {
                Sr_ned();
            }
            if (vibor == 2)
            {
                Sr_diap();
            }
            if (vibor == 3)
            {
                Best();
            }
            if (vibor == 4)
            {
                Terrible();
            }
        }
        public double Sr(double sum_m)
        {
            double sr_ned = sum_m / 7.0;
            Console.WriteLine($"Среднее настроение за последнюю неделю: {sr_ned}");
            Vibbor_2();
            return sum_m;
        }
        public void Sr_ned()
        {
            double sum_avg_2 = 0, sum_okt_2 = 0, sum_sen_2 = 0;
            for (int i = 24; i < 31; i++)
            {
                for (int q = 1; q < 2; q++)
                {
                    sum_avg_2 = nastr_avg[i, q] + sum_avg_2;
                    sum_sen_2 = nastr_sen[i, q] + sum_sen_2;
                    sum_okt_2 = nastr_okt[i, q] + sum_okt_2;
                }
            }
            if (month == 1) { Sr(sum_avg_2); }
            if (month == 2) { Sr(sum_sen_2); }
            if (month == 3) { Sr(sum_okt_2); }
        }
        public void Vibbor_2()
        {
            count = 0;
            count_2 = 0;
            count_3 = 0;
            count_4 = 0;
            Console.WriteLine("Чтобы вернуться назад, нажмите 9");
            vibor_2 = Convert.ToInt32(Console.ReadLine());
            if (vibor_2 == 9)
            {
                Vopros();
            }
        }
        public double Sr_r(float sum_mm)
        {
            ch = d_2 - d_1;
            sr_diap = sum_mm / ch;
            Console.WriteLine($"Среднее настроение с {d_1} по {d2}: {sr_diap}");
            Vibbor_2();
            return sum_mm;
        }
        public void Sr_diap()
        {
            int sum_diap = 0, sum_diap_2 = 0, sum_diap_3 = 0;
            Console.Write("Введите начальную дату, с которой будет начинаться отсчет(Например: 5): ");
            int date_1 = Convert.ToInt32(Console.ReadLine());
            d_1 = date_1;
            date_1 = date_1 - 1;
            Console.Write("Введите конечную дату, до которой будет идти отсчет(Например: 20): ");
            int date_2 = Convert.ToInt32(Console.ReadLine());
            d2 = date_2;
            date_2 = date_2 + 1;
            d_2 = date_2;
            for (int i = date_1; date_1 + 1 < date_2; date_1++)
            {
                for (int q = 1; q < 2; q++)
                {
                    sum_diap = sum_diap + nastr_avg[date_1, q];
                    sum_diap_2 = sum_diap_2 + nastr_sen[date_1, q];
                    sum_diap_3 = sum_diap_3 + nastr_okt[date_1, q];
                }
            }
            if (month == 1)
            {
                Sr_r(sum_diap);
            }
            if (month == 2)
            {
                Sr_r(sum_diap_2);
            }
            if (month == 3)
            {
                Sr_r(sum_diap_3);
            }
        }
        public int M(int[,] nas)
        {
            if (nas[i, q] > 3)
            {
                count++;
            }
            if (nas[i, q] == 4)
            {
                count_2++;
            }
            if (nas[i, q] == 5)
            {
                count_3++;
            }
            return nas[i,q];
        }
        public void Best()
        {
            for (int i = 0; i < 31; i++)
            {
                for (int q = 1; q < 2; q++)
                {
                    if (month == 1)
                    {
                        M(nastr_avg[i,q]);
                    }
                    if (month == 2)
                    {
                        M(nastr_sen);
                    }
                    if (month == 3)
                    {
                        M(nastr_okt);
                    }
                }
            }
            Vivod();
            Vibbor_2();
        }
        public void Vivod()
        {
            Console.WriteLine($"Количество хороших дней: {count}");
            Console.WriteLine($"Дней с настроением 4: {count_2}");
            Console.WriteLine($"Дней с настроением 5: {count_3}");
        }
        public void Terrible()
        {
            for (int i = 0; i < 31; i++)
            {
                for (int q = 1; q < 2; q++)
                {
                    if (month == 1)
                    {
                        if (nastr_avg[i, q] < 4)
                        {
                            count++;
                        }
                        if (nastr_avg[i, q] == 3)
                        {
                            count_2++;
                        }
                        if (nastr_avg[i, q] == 2)
                        {
                            count_3++;
                        }
                        if (nastr_avg[i, q] == 1)
                        {
                            count_4++;
                        }
                    }
                    if (month == 2)
                    {
                        if (nastr_sen[i, q] < 4)
                        {
                            count++;
                        }
                        if (nastr_sen[i, q] == 3)
                        {
                            count_2++;
                        }
                        if (nastr_sen[i, q] == 2)
                        {
                            count_3++;
                        }
                        if (nastr_sen[i, q] == 1)
                        {
                            count_4++;
                        }
                    }
                    if (month == 3)
                    {
                        if (nastr_okt[i, q] < 4)
                        {
                            count++;
                        }
                        if (nastr_okt[i, q] == 3)
                        {
                            count_2++;
                        }
                        if (nastr_okt[i, q] == 2)
                        {
                            count_3++;
                        }
                        if (nastr_okt[i, q] == 1)
                        {
                            count_4++;
                        }
                    }
                }
            }
            Vivod_2();
            Vibbor_2();
        }
        public void Vivod_2()
        {
            Console.WriteLine($"Количество плохих дней: {count}");
            Console.WriteLine($"Дней с настроением 3: {count_2}");
            Console.WriteLine($"Дней с настроением 2: {count_3}");
            Console.WriteLine($"Дней с настроением 1: {count_4}");
        }
        static void Main(string[] args)
        {
            Program pol = new Program();
            pol.Ccalendar();
        }
    }
}