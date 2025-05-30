namespace Car
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();

            List<Avto> Cars = new List<Avto>();



            int num;
            int ras;
           



            Console.WriteLine("Ввидите количество машин");
            string countCar = Console.ReadLine();

            while (IsValidNumber(countCar) == false || int.Parse(countCar) < 0 || int.Parse(countCar) > 100)
            {
                if (IsValidNumber(countCar) == false)
                {
                    Console.WriteLine("Ввидите число");
                }else if (int.Parse(countCar) < 0 || int.Parse(countCar) > 100)
                {
                    Console.WriteLine("Число не должно быть меньше 0 и больше 100");
                }

                countCar = Console.ReadLine();

            }

            for (int i = 0; i < int.Parse(countCar); i++)
            {
                num = i + 1;
                ras = rnd.Next(10, 31);

                Console.WriteLine($"Ввидите объём бака для машины N{i+1}");
                string bak = Console.ReadLine();

                while (IsValidNumber(bak) == false || int.Parse(bak) < 0)
                {
                    if (IsValidNumber(countCar) == false)
                    {
                        Console.WriteLine("Ввидите число");
                    }else if (int.Parse(bak) < 0)
                    {
                        Console.WriteLine("Число не должно быть меньше 0");
                    }
                    
                    bak = Console.ReadLine();
                }




                Console.WriteLine($"Ввидите количество топлива для машины N{i+1}");
                string top = Console.ReadLine();

                while (IsValidNumberFloat(top) == false || int.Parse(top) < 0 || int.Parse(top) > int.Parse(bak) )
                {
                    if (IsValidNumber(countCar) == false)
                    {
                        Console.WriteLine("Ввидите число");
                    }else if (int.Parse(top) < 0 || int.Parse(top) > int.Parse(bak))
                    {
                        Console.WriteLine("Число не должно быть меньше 0 или больше объёма бака");
                    }
                    
                    top = Console.ReadLine();
                }

                Avto myCar = new Avto(num, int.Parse(bak), float.Parse(top), ras);
                Cars.Add(myCar);

            }

            Console.WriteLine("----------------------------------------------------------------------------------------");

            while (true)
            {

                foreach (Avto avto in Cars)
                {
                    avto.Out();
                }


                Console.WriteLine("Ввидите число машины на которой будете ехать либо введите -1 что бы завершить работу");
                string chos = Console.ReadLine();

                while (IsValidNumber(chos) == false)
                {
                    Console.WriteLine("Ввидите число");
                    chos = Console.ReadLine();
                }

                if (int.Parse(chos) == -1)
                {
                    Environment.Exit(0);
                }

                var curAvto = Cars.FirstOrDefault(X => X.Number == int.Parse(chos));

                while (IsValidNumber(chos) == false || curAvto == null)
                {
                    if (curAvto == null)
                    {
                        Console.WriteLine("Машины не сущетвует");
                    }
                    Console.WriteLine("Ввидите число");
                    chos = Console.ReadLine();
                    curAvto = Cars.FirstOrDefault(X => X.Number == int.Parse(chos));
                }
                bool end = true;
                while (end == true)
                {
                    Console.WriteLine("Выберите  действие:\n1. Вывести ифнормацию о машине\n2. Ехать\n3. Заправится\n4. Разогнаться\n5. Тормозить\n6. Авария\n7. Завершить поездку");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Введите номер действия: ");
                    Console.ResetColor();
                    string chose = Console.ReadLine()!;

                    while (IsValidNumber(chose) == false || (int.Parse(chose) < 1) || (int.Parse(chose) > 7))
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пожалуйста, введите что то из выше указаного");
                        Console.ResetColor();

                        chose = Console.ReadLine();
                    }


                    switch (int.Parse(chose))
                    {
                        case 1:
                            curAvto.Out();
                            break;
                        case 2:
                            int km = rnd.Next(0, 2000);
                            curAvto.Move();
                            break;
                        case 3:
                            Console.WriteLine("Введите количество топлива");

                            string top = Console.ReadLine()!;

                            while (IsValidNumber(top) == false || int.Parse(top) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пожалуйста, введите число или не вводите число меньше 0");
                                Console.ResetColor();
                                top = Console.ReadLine();
                            }

                            curAvto.Zapravka(int.Parse(top));
                            break;
                        case 4:
                            Console.WriteLine("Введите на сколько км/ч разогнаться");

                            string speed = Console.ReadLine()!;

                            while (IsValidNumber(speed) == false || int.Parse(speed) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пожалуйста, введите число или не вводите число меньше 0");
                                Console.ResetColor();
                                speed = Console.ReadLine();
                            }

                            curAvto.Gaz(int.Parse(speed));
                            break;
                        case 5:
                            Console.WriteLine("Введите на сколько км/ч тормозить");

                            string stop = Console.ReadLine()!;

                            while (IsValidNumber(stop) == false || int.Parse(stop) == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пожалуйста, введите число или не вводите число меньше 0");
                                Console.ResetColor();
                                stop = Console.ReadLine();
                            }

                            curAvto.Brake(int.Parse(stop));
                            break;
                        case 6:
                            if(Cars.Count() == 1)
                            {
                                Console.WriteLine("Нет машин с которыми может произоти ДТП");
                                break;
                            }

                            int dtp = rnd.Next(1, Cars.Count()+1);

                            while (dtp == curAvto.Number)
                            {
                                dtp = rnd.Next(1, Cars.Count() + 1);
                            }

                            var dtpCar = Cars.FirstOrDefault(X => X.Number == dtp);

                            curAvto.Crash(dtpCar);


                            break;
                        case 7:
                            end = false;
                            break;
                    }

                }





            }
        }
        public static bool IsValidNumber(string number)
        {
            int juk;
            if (int.TryParse(number, out juk))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public static bool IsValidNumberFloat(string number)
        {
            float juk;
            if (float.TryParse(number, out juk))
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }
}
