using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWord
{
    internal class Program
    {
         /// <summary>
         /// Поиск минимального количества букв в тексте
         /// </summary>
         /// <param name="Str">Входной текст</param>
         /// <returns>Слово с минимальным количеством букв</returns>
        static string FindMinWord(string Str)
        {
            if (Str == null) { return "Введена пустая строка"; }

            string[] strArr = Str.Split(' ', ',', '.');

            var length = strArr[0].Length;
            var word = strArr[0];

            foreach (string str in strArr)
            {
                length = str.Length;

                if (length <= word.Length) { word = str; }
            }

            var r = strArr.Min();

            return string.IsNullOrEmpty(word) ? "Ни одного слова не найдено" : word;
        }

        /// <summary>
        /// Поиск максимального количества букв в тексте
        /// </summary>
        /// <param name="Str">Входной текст</param>
        /// <returns>Слово с максимальным количеством букв, если слов с максимальным количеством будет несколько, то возвращает все</returns>
        static string FindMaxWord(string Str)
        {
            if (Str == null) { return "Введена пустая строка"; }

            char[] seporateChars = { ' ', ',', '.' };
            string[] strArr = Str.Split(seporateChars, StringSplitOptions.RemoveEmptyEntries);

            var maxlength = strArr[0].Length;

            //вычисление максимальной длинны
            foreach (string str in strArr)
            {
                if (maxlength < str.Length) { maxlength = str.Length; }
            }

            List<string> maxWords = new List<string>();

            //поиск слов
            foreach (var word in strArr)
            {
                if (word.Length == maxlength) { maxWords.Add(word); }
            }           

            return string.Join(", ", maxWords);
        }

        /// <summary>
        /// Исключение повторяющихся букв в тексте
        /// </summary>
        /// <param name="Str">Входной текст</param>
        /// <returns>Отредактированный текст</returns>
        static string ShrinkString(string Str)
        {
            if (Str == null) { return "Введена пустая строка"; }

            string lowerString = Str.ToLower();

            StringBuilder shrinkString = new StringBuilder();

            foreach (var ch in lowerString)
            {
                if (!string.IsNullOrEmpty(shrinkString.ToString()))
                {
                    if (shrinkString.ToString().Last() != ch)
                    {
                        shrinkString.Append(ch);
                    }
                }
                else
                {
                    shrinkString.Append(ch);
                }
            }

            return shrinkString.ToString();
        }


        static void Main(string[] args)
        {
            string textForFindWord = "A ББ,ВВВ.ГГГГ ДДДД,ДД.ЕЕ ЖЖ,ЗЗЗ";

            Console.WriteLine("Надо найти слова в тексте c МИНИМАЛЬНЫМ и МАКСИМАЛЬНЫМ количеством букв: " + textForFindWord);
            Console.WriteLine("Минимальное: " + FindMinWord(textForFindWord));
            Console.WriteLine("Максимальные: " + FindMaxWord(textForFindWord));
            Console.WriteLine();
            Console.WriteLine("Удаление дублей букв в строке");
            string textForShrinkString = "ПППОООГГГООООДДДААА";
            Console.WriteLine(textForShrinkString + ">>>" + ShrinkString(textForShrinkString));
            string textForShrinkString2 = "Ххххоооорррооошшшиий деееннннь";
            Console.WriteLine(textForShrinkString2 + ">>>" + ShrinkString(textForShrinkString2));
            Console.ReadKey();

        }
    }
}
