using System;
using System.Collections.Generic;

namespace cw7.Models;

public class PrimesModel
{
    public static bool IsPrime(int number)
    {
        if (number < 2)
            return false;
        if (number == 2)
            return true;
        if (number % 2 == 0)
            return false;
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // Zwraca określoną ilość liczb pierwszych
    public static List<int> GetPrime(int count)
    {
        if (count < 1) 
            throw new ArgumentException("Liczba liczb pierwszych musi być większa od zera.");

        List<int> primes = new();
        int i = 2;
        while (primes.Count < count)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
            i++;
        }
        return primes;
    }
}
