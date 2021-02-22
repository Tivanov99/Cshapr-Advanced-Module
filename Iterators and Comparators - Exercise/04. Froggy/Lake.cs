using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Lake : IEnumerable<int>
    {
        int[] stones;
        public Lake(int[] input)
        {
            stones = new int[input.Length];
            stones = input;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int EvenCount = 0;
            int OddCount = 0;
            for (int i = 0; i < stones.Length ; i++)
            {
                if (i % 2 == 0)
                {
                    EvenCount++;
                }
                else
                {
                    OddCount++;
                }
            }
            int[] EvenPositions = new int[EvenCount];
            int[] OddPositions = new int[OddCount];
            EvenCount = 0;
            OddCount = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    EvenPositions[EvenCount] = stones[i];
                    EvenCount++;
                }
                else
                {
                    OddPositions[OddCount] = stones[i];
                    OddCount++;
                }
            }
            int[] reversed = new int[OddPositions.Length];
            int index = 0;
            for (int i = OddPositions.Length - 1; i >= 0; i--)
            {
                reversed[index] = OddPositions[i];
                index++;
            }
            int ing = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (i < EvenPositions.Length)
                {
                    stones[i] = EvenPositions[i];
                }
                else
                {
                    stones[i] = reversed[ing];
                    ing++;
                }
            }
            for (int i = 0; i < stones.Length; i++)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
