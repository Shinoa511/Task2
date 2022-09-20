using System;
using System.Collections.Generic;


namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,] { { 2, 1, 5, 7, 3, 4, 6 },
                                      { 5, 9, 5, 8, 6, 8, 2 },
                                      { 5, 1, 7, 2, 9, 4, 6 }};

            //int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 6 }, { 3, 6, 5 } };

            int[,] result_arr;

            int i = 1;

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n//  " + i + "  -----------------------------------------");

                Console.WriteLine("Выберите метод сортировки массива:");
                Console.WriteLine("1 - В порядке возрастания (убывания) сумм элементов строк матрицы\n" +
                                  "2 - По возрастанию (убыванию) максимального элемента в строке матрицы;\n" +
                                  "3 - В порядке возрастания (убывания) минимального элемента в строке матрицы;\n" +
                                  "0 - Выход из программы");

                char typeSort = char.ToLower(Console.ReadKey(false).KeyChar);

                char subtypeSort = 'a';
                if (typeSort != '0')
                {
                    Console.WriteLine("\n\nВыберите тип сортировки:");
                    Console.WriteLine("a - по возрастанию\n" +
                                      "d - по убыванию");

                    subtypeSort = char.ToLower(Console.ReadKey(false).KeyChar);
                    Console.WriteLine();
                }

                Context context = new Context();

                switch (typeSort, subtypeSort)
                {
                    case ('1', 'a'):
                        context.SetSortType(new Sort_SumLines());
                        result_arr = context.ExecuteSortingASC(arr);
                        Print(result_arr);
                        break;
                    case ('1', 'd'):
                        context.SetSortType(new Sort_SumLines());
                        result_arr = context.ExecuteSortingDESC(arr);
                        Print(result_arr);
                        break;
                    case ('2', 'a'):
                        context.SetSortType(new Sort_MaxElement());
                        result_arr = context.ExecuteSortingASC(arr);
                        Print(result_arr);
                        break;
                    case ('2', 'd'):
                        context.SetSortType(new Sort_MaxElement());
                        result_arr = context.ExecuteSortingDESC(arr);
                        Print(result_arr);
                        break;
                    case ('3', 'a'):
                        context.SetSortType(new Sort_MinElement());
                        result_arr = context.ExecuteSortingASC(arr);
                        Print(result_arr);
                        break;
                    case ('3', 'd'):
                        context.SetSortType(new Sort_MinElement());
                        result_arr = context.ExecuteSortingDESC(arr);
                        Print(result_arr);
                        break;
                    case ('0', 'a'): flag = false; break;
                    default: break;
                }

                i++;
            }


        }

        static void Print(int[,] result_arr)
        {
            Console.WriteLine();
            for (int i = 0; i != result_arr.GetLength(0); i++)
            {
                for (int j = 0; j != result_arr.GetLength(1); j++)
                {
                    Console.Write("{0} ", result_arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    public class Context
    {
        private Sort type;

        public Context() { }

        // Обычно Контекст принимает стратегию через конструктор, а также
        // предоставляет сеттер для её изменения во время выполнения.
        public Context(Sort type)
        {
            this.type = type;
        }

        // Обычно Контекст позволяет заменить объект Стратегии во время выполнения
        public void SetSortType(Sort type)
        {
            this.type = type;
        }

        public int[,] ExecuteSortingASC(int[,] arr)
        {
            int[,] interimArr = this.type.SortingAsc(arr);
            int[,] result_arr = FormResult(arr, interimArr);

            return result_arr;
        }

        public int[,] ExecuteSortingDESC(int[,] arr)
        {
            int[,] interimArr = this.type.SortingDesc(arr);
            int[,] result_arr = FormResult(arr, interimArr);

            return result_arr;
        }

        private int[,] FormResult(int[,] arr, int[,] interimArr)
        {
            int[,] result_arr = new int[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0; i != interimArr.GetLength(0); i++)
            {
                for (int j = 0; j != arr.GetLength(1); j++)
                {
                    result_arr[i, j] = arr[interimArr[i, 0], j];
                }
            }
            return result_arr;
        }
    }
    public interface Sort
    {
        int[,] SortingAsc(int[,] arr);
        int[,] SortingDesc(int[,] arr);
    }

    public class Sort_SumLines : Sort
    {
        public int[,] SortingAsc(int[,] arr)
        {
            //Суммируем строки матрицы
            int[,] sumArr;
            sumArr = SumStr(arr);

            // Сортировка
            for (int i = 0; i != sumArr.GetLength(0); i++)
                for (int j = i + 1; j != sumArr.GetLength(0); j++)
                {
                    if (sumArr[j, 1] < sumArr[i, 1])
                    {
                        int t = sumArr[i, 1];
                        int ind = sumArr[i, 0];
                        sumArr[i, 1] = sumArr[j, 1];
                        sumArr[i, 0] = sumArr[j, 0];
                        sumArr[j, 1] = t;
                        sumArr[j, 0] = ind;
                    }
                }

            return sumArr;
        }

        public int[,] SortingDesc(int[,] arr)
        {
            //Суммируем строки матрицы
            int[,] sumArr;
            sumArr = SumStr(arr);

            // Сортировка
            for (int i = 0; i != sumArr.GetLength(0); i++)
                for (int j = i + 1; j != sumArr.GetLength(0); j++)
                {
                    if (sumArr[j, 1] > sumArr[i, 1])
                    {
                        int t = sumArr[i, 1];
                        int ind = sumArr[i, 0];
                        sumArr[i, 1] = sumArr[j, 1];
                        sumArr[i, 0] = sumArr[j, 0];
                        sumArr[j, 1] = t;
                        sumArr[j, 0] = ind;
                    }
                }

            return sumArr;
        }

        private int[,] SumStr(int[,] arr)
        {
            //Суммируем строки матрицы
            int[,] sumArr = new int[arr.GetLength(0), 2];
            for (int i = 0; i != arr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j != arr.GetLength(1); j++)
                    sum += arr[i, j];
                sumArr[i, 1] = sum;// сумма
                sumArr[i, 0] = i;// индекс элемента
            }
            return sumArr;
        }
    }

    public class Sort_MaxElement : Sort
    {
        public int[,] SortingAsc(int[,] arr)
        {
            //Ищем максимальный элемент в строке матрицы
            int[,] maxArr;
            maxArr = MaxInStr(arr);

            // Сортировка
            for (int i = 0; i != maxArr.GetLength(0); i++)
                for (int j = i + 1; j != maxArr.GetLength(0); j++)
                {
                    if (maxArr[j, 1] < maxArr[i, 1])
                    {
                        int t = maxArr[i, 1];
                        int ind = maxArr[i, 0];
                        maxArr[i, 1] = maxArr[j, 1];
                        maxArr[i, 0] = maxArr[j, 0];
                        maxArr[j, 1] = t;
                        maxArr[j, 0] = ind;
                    }
                }

            return maxArr;
        }

        public int[,] SortingDesc(int[,] arr)
        {
            //Ищем максимальный элемент в строке матрицы
            int[,] maxArr;
            maxArr = MaxInStr(arr);

            // Сортировка
            for (int i = 0; i != maxArr.GetLength(0); i++)
                for (int j = i + 1; j != maxArr.GetLength(0); j++)
                {
                    if (maxArr[j, 1] > maxArr[i, 1])
                    {
                        int t = maxArr[i, 1];
                        int ind = maxArr[i, 0];
                        maxArr[i, 1] = maxArr[j, 1];
                        maxArr[i, 0] = maxArr[j, 0];
                        maxArr[j, 1] = t;
                        maxArr[j, 0] = ind;
                    }
                }

            return maxArr;
        }

        private int[,] MaxInStr(int[,] arr)
        {
            //Ищем максимальный элемент в строке матрицы
            int[,] maxArr = new int[arr.GetLength(0), 2];
            for (int i = 0; i != arr.GetLength(0); i++)
            {
                int max = arr[i, 0];
                for (int j = 1; j != arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }

                maxArr[i, 1] = max;// максимальное значение
                maxArr[i, 0] = i;// индекс элемента
            }
            return maxArr;
        }
    }

    public class Sort_MinElement : Sort
    {
        public int[,] SortingAsc(int[,] arr)
        {
            //Ищем минимальный элемент в строке матрицы
            int[,] minArr;
            minArr = MinInStr(arr);

            // Сортировка
            for (int i = 0; i != minArr.GetLength(0); i++)
                for (int j = i + 1; j != minArr.GetLength(0); j++)
                {
                    if (minArr[j, 1] < minArr[i, 1])
                    {
                        int t = minArr[i, 1];
                        int ind = minArr[i, 0];
                        minArr[i, 1] = minArr[j, 1];
                        minArr[i, 0] = minArr[j, 0];
                        minArr[j, 1] = t;
                        minArr[j, 0] = ind;
                    }
                }

            return minArr;
        }

        public int[,] SortingDesc(int[,] arr)
        {
            //Ищем минимальный элемент в строке матрицы
            int[,] minArr;
            minArr = MinInStr(arr);

            // Сортировка
            for (int i = 0; i != minArr.GetLength(0); i++)
                for (int j = i + 1; j != minArr.GetLength(0); j++)
                {
                    if (minArr[j, 1] > minArr[i, 1])
                    {
                        int t = minArr[i, 1];
                        int ind = minArr[i, 0];
                        minArr[i, 1] = minArr[j, 1];
                        minArr[i, 0] = minArr[j, 0];
                        minArr[j, 1] = t;
                        minArr[j, 0] = ind;
                    }
                }

            return minArr;
        }

        private int[,] MinInStr(int[,] arr)
        {
            //Ищем минимальный элемент в строке матрицы
            int[,] minArr = new int[arr.GetLength(0), 2];
            for (int i = 0; i != arr.GetLength(0); i++)
            {
                int min = arr[i, 0];
                for (int j = 1; j != arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }

                minArr[i, 1] = min;// максимальное значение
                minArr[i, 0] = i;// индекс элемента
            }
            return minArr;
        }
    }
}
