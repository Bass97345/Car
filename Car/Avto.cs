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
        private double Probeg = 0;
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


            Console.WriteLine($"Номер машины: {Number}\nОбъём бака: {Bak}л\nТопливо: {Top}л\nРасход: {Ras} л/100км\nПробег: {Math.Round(Probeg, 2)}км");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

        }


        public virtual void Zapravka(float top)
        {
            if (Top < 0 || Top <= 0) Top = 0;

            while (top < 0 || top > Bak || top > (Bak - Top))
            {
                if (Top == Bak)
                {
                    Console.WriteLine("Ваш бак полон");
                    return;
                }
                
                if (top < 0) Console.WriteLine("Число топлива не может быть меньше 0\nВведите число");
                if (top > Bak || top > (Bak - Top)) Console.WriteLine("Вы не можете залить топлива больше чем объём бака\nВведите число");

                top = int.Parse(Console.ReadLine());
            }
        
            Top += top;

            
            Console.WriteLine($"Вы заправились! Топлива в баке: {Top}л");

        }


        public virtual void Move()
        {
            Console.WriteLine("Введите начальную координату X");
            double startx = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите начальную координату Y");
            double starty = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную координату X");
            double endx = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную координату Y");
            double endy = double.Parse(Console.ReadLine());

            double dx = endx - startx;
            double dy = endy - starty;
            double way = Math.Sqrt(dx * dx + dy * dy);
            

            

            double resultKm = 0;

            for (double i = 0; i < way; i += 0.1)
            {
                if (Top <= 0)
                {
                    Console.WriteLine($"Вы проехали: {Math.Round(resultKm, 2)}км и топливо кончилось, дозаправится?\n1.Да\n2.Нет(завершить поездку)");
                    float zap = float.Parse(Console.ReadLine());

                    if (zap == 1)
                    {
                        Console.WriteLine("Введите количество топлива");
                        float top = float.Parse(Console.ReadLine())!;
                        Zapravka(top);
                    } else if (zap == 2)
                    {
                        break;
                    }

                }

                Top -= ras1km *0.1f;
                resultKm += 0.1;
            }

            Console.WriteLine($"Машина проехала: {Math.Round(resultKm, 2)}км");
            Ostatok();
            WholeProber(resultKm);

        }




        private void WholeProber(double amount) 
        {
            Probeg += amount;
            Console.WriteLine($"Общий пробег автомобиля: {Math.Round(Probeg, 2)}км");
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

