using System;

class Program
{
    static void Main(string[] args)
    {
        // Generowanie tablicy
        Random rand = new Random();
        int[] numbers = GenerTab(20);

        // Wyświetlanie tablicy
        showTable(numbers);

        // Znajdowanie największej, najmniejszej liczby i różnicy
        int max = getMax(numbers);
        int min = getMin(numbers);
        int difference = getDifference(max, min);

        Console.WriteLine("\nNajwiększa liczba: " + max);
        Console.WriteLine("Najmniejsza liczba: " + min);
        Console.WriteLine("Różnica: " + difference);
    }

    // Funkcja zwracająca największą liczbę z tablicy
    static int getMax(int[] tab)
    {
        int max = tab[0];
        foreach (int num in tab)
        {
            if (num > max)
            {
                max = num;
            }
        }
        return max;
    }

    // Funkcja zwracająca najmniejszą liczbę z tablicy
    static int getMin(int[] tab)
    {
        int min = tab[0];
        foreach (int num in tab)
        {
            if (num < min)
            {
                min = num;
            }
        }
        return min;
    }

    // Funkcja zwracająca różnicę między największą a najmniejszą liczbą
    static int getDifference(int max, int min)
    {
        return max - min;
    }

    // Funkcja do generowania tablicy losowych liczb
    static int[] GenerTab(int size)
    {
        Random rand = new Random();
        int[] result = new int[size];
        for (int i = 0; i < size; i++)
        {
            result[i] = rand.Next(100);
        }
        return result;
    }

    static void showTable(int[] tab)
    {
        foreach (int item in tab)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    // Funkcja zwracająca sumę liczb z tablicy
    static int getSum(int[] tab)
    {
        int sum = 0;
        foreach (int num in tab)
        {
            sum += num;
        }
        return sum;
    }

    // Funkcja zwracająca średnią liczbę z tablicy
    static double getAverage(int[] tab)
    {
        int sum = getSum(tab);
        return (double)sum / tab.Length;
    }

    
}


