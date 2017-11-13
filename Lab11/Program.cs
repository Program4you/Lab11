using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11 {
    class A { // собственно класс
        int[] array; // массив одномерный
        readonly int min, max; // поля только для чтения (минимум и максимум)

        // конструктор с параметрами в виде массивов по ссылке
        public A(ref int[] x, ref int[] y) {
            array = new int[Math.Max(x.Length, y.Length)]; // выделяем память под максимальную из длин массивов
            int i = 0; // начинаем идти с нулевого элемента
            max = x[0]; // инициализируем значения максимума
            min = y[0]; // инициализируем значения минимума

            // идём до минимальной длины массивов и честно сравниваем элементы
            while (i < Math.Min(x.Length, y.Length)) {
                array[i] = Math.Min(x[i], y[i]);

                // а также обновляем значения минимума/максимума
                if (array[i] < min)
                    min = array[i];
                else if (array[i] > max)
                    max = array[i];

                i++;
            }

            // теперь сравниваем оставшиеся элементы одного из массивов с нулём
            while (i < array.Length) {
                if (i < x.Length)
                    array[i++] = Math.Min(0, x[i]);
                else
                    array[i++] = Math.Min(0, y[i]);
            }
        }

        // выводим на экран значения элементов массива
        public void Print() {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);
            Console.WriteLine();
        }

        // возвращаем значение минимума
        public int getMin() {
            return min;
        }

        // возвращаем значение максимума
        public int getMax() {
            return max;
        }
    }

    class Program {
        static void Main(string[] args) {
            int n, m; // длины массивов для создания класса

            Console.Write("Enter n: ");
            n = int.Parse(Console.ReadLine());
            int[] x = new int[n];

            // ввод массива Х
            for (int i = 0; i < n; i++) {
                Console.Write("Enter x[{0}]: ", i);
                x[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("\nEnter m: ");
            m = int.Parse(Console.ReadLine());
            int[] y = new int[m];

            // ввод массива У
            for (int i = 0; i < m; i++) {
                Console.Write("Enter y[{0}]: ", i);
                y[i] = int.Parse(Console.ReadLine());
            }

            // вывод массива Х
            Console.Write("\nArray x: ");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", x[i]);

            // вывод массива У
            Console.Write("\nArray y: ");
            for (int i = 0; i < m; i++)
                Console.Write("{0} ", y[i]);

            A a = new A(ref x, ref y); // создаём класс
            Console.Write("\nArray of class: "); 
            a.Print(); // выводим массив

            Console.WriteLine("Min: {0}, max: {1}", a.getMin(), a.getMax()); // выводим минимум и максимум
            Console.ReadKey();
        }
    }
}
