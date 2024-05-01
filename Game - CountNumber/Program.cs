using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___CountNumber
{
    internal class Program
    {
        // Написать игру, в которою могут играть два игрока.
        // При старте, игрокам предлагается ввести свои никнеймы.
        // Никнеймы хранятся до конца игры.
        // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
        // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
        // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
        // введенное число вычитается из gameNumber
        // Новое значение gameNumber показывается игрокам на экране.
        // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
        // Игра поздравляет победителя
        // 
        // * Бонус:
        // Подумать над возможностью реализации разных уровней сложности.
        // В качестве уровней сложности может выступать настраиваемое, в начале игры,
        // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

        //--Пока что не реализовано
        // *** Сложный бонус
        // Подумать над возможностью реализации однопользовательской игры
        // т е игрок должен играть с компьютером

        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя первого игрока:");
            string playerOne = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Введите имя второго игрока:");
            string playerTwo = Console.ReadLine();

            //Бонус! Усложнение игры
            Console.WriteLine();
            Console.WriteLine("Введите нижний порог шага хода игрока");
            int minStep = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите верхний порог шага хода игрока");
            int maxStep = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();

            int gameNumber = random.Next(12, 120);

            Console.WriteLine("\nНачинаем игру!!!");            

            //int currentNumber = gameNumber;
            string currentPlayer;

            do
            {
                int userTry;
                //Ходит игрок 1 и проводит проверка его хода
                currentPlayer = playerOne;
                Console.WriteLine();
                Console.WriteLine("Число {0} \nХодит игрок - {1}", gameNumber, currentPlayer);

                do
                {
                    Console.WriteLine("Введите число от {0} до {1}!", minStep, maxStep);
                    userTry = Convert.ToInt32(Console.ReadLine());
                } while (userTry >= minStep ^ userTry <= maxStep);

                gameNumber -= userTry;

                if (gameNumber <= 0)
                {
                    break;
                }

                //Ходит игрок 2 и проводит проверка его хода
                currentPlayer = playerTwo;
                Console.WriteLine("Число {0} \nХодит игрок - {1}", gameNumber, currentPlayer);

                do
                {
                    Console.WriteLine("Введите число от {0} до {1}!", minStep, maxStep);
                    userTry = Convert.ToInt32(Console.ReadLine());
                } while (userTry >= minStep ^ userTry <= maxStep);

                gameNumber -= userTry;

            } while (gameNumber > 0);

            Console.WriteLine("Игра окончена!!! \nПобедил игрок - {0}\nПоздравляем!!!", currentPlayer);
            Console.ReadKey();
        }
    }
}
