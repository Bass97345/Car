using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Avto
    {
        public int Number;
        
        private int Bak;
        private float Top;
        private float Ras;
        private int Probeg = 0;
        private float ras1km;
        private float speed;
        public Avto(int number, int bak, float top, float ras)
        {
            Number = number;
            Bak = bak;
            Top = top;
            Ras = ras;
            ras1km = ras / 100;
        }


        public void Gaz(float amount)
        {
            speed += amount;
            Console.WriteLine($"Машина разогналась до {speed}км/ч");
        }


        public void Brake(float amount)
        {
            speed -= amount;
            if (speed < 0) speed = 0;
            Console.WriteLine($"Машина снизила скорость до {speed}км/ч");
        }

        public virtual void Out()
        {


            Console.WriteLine($"Номер машины: {Number}\nОбъём бака: {Bak}л\nТопливо: {Top}\nРасход: {Ras} л/100км\nПробег: {Probeg}км");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

        }


        public virtual void Zapravka(float top)
        {
            if (top > Bak)
            {
                Console.WriteLine("Вы не можете залить топлива больше чем объём бака, теперь ваш бак полон");
                Top = Bak;
            }


            Top += top;
            Console.WriteLine($"Вы заправились! Топлива в баке: {Bak}л");

        }


        public virtual void Move()
        {
            Console.WriteLine("Введите начальную координату X");
            int startx = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите начальную координату Y");
            int starty = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную координату X");
            int endx = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную координату Y");
            int endy = int.Parse(Console.ReadLine());

            int dx = endx - startx;
            int dy = endy - starty;
            double way = Math.Sqrt(dx * dx + dy * dy);




            int resultKm = 0;

            for (int i = 0; i < way; i++)
            {
                if (Top <= 0)
                {
                    Console.WriteLine($"Вы проехали: {resultKm}км и топливо кончилось, дозаправится?\n1.Да\n2.Нет(завершить поездку)");
                    int zap = int.Parse(Console.ReadLine());

                    if (zap == 1)
                    {
                        Console.WriteLine("Введите количество топлива");
                        int top = int.Parse(Console.ReadLine())!;
                        Zapravka(top);
                    }else if (zap == 2)
                    {
                        break;
                    }

                }

                Top -= ras1km;
                resultKm += 1;
            }

            Console.WriteLine($"Машина проехала: {resultKm}км");
            Ostatok();
            WholeProber(resultKm);

        }




        private void WholeProber(int amount) 
        {
            Probeg += amount;
            Console.WriteLine($"Общий пробег автомобиля: {Probeg}км");
        }


        private void Ostatok()
        {
            if (Top < 0) Top = 0;
            Console.WriteLine($"Остаток топлива: {Top}л");
        }



        public void Crash(Avto car2)
        {
            Console.WriteLine($"Машина с номером: {Number} врезалась в машину с номером: {car2.Number}");
        }

    } 
}

