using System;
using System.Collections.Generic;

namespace cw8.Models;

public class Primes
{
    public static bool isPrime(int number) {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    }
    
    public static List<int> GetPrimes(int count) {
        List<int> primes = new();
        int number = 2;
        while (primes.Count < count) {
            if (isPrime(number)) {
                primes.Add(number);
            }
            number++;
        }
        return primes;
    }
}