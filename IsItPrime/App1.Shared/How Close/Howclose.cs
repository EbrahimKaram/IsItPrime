using System;
using System.Collections.Generic;
using System.Text;
using App1.Whats_Next;
using App1.Is_It_Prime;

namespace App1.How_Close
{
   public class Howclose
    {
       static int[] A = Whatsnext.ListofPrimes();

    public static int closestPrime(string input)
       {
           int number = Convert.ToInt32(input);
        if(number<=A[199])
        {
            int[] B = new int[200];
            for (int i = 0; i < 200; i++)
            {
                B[i] = Math.Abs(A[i] - number);
            }
            int k = 0;
            for (int i=0;i<200;i++)
            {
                if (B[i] < B[k])
                    k = i;
            }

            return A[k];
        }
        else
        {
            int test1 = number;
            while(true)
            {
                if (IsItprime.Primebility(test1.ToString()))
                {
                    break;
                }
                else
                    test1++;

            }
            int test2=number;
            while(test2>A[199])
            {
                if (IsItprime.Primebility(test2.ToString()))
                    break;
                else
                    test2--;
            }

            int diff1 = Math.Abs(number - test1);
            int diff2 = Math.Abs(number - test2);
            if (diff1 > diff2)
                return test2;
            else
                return test1;
        }
       }
    }
}
