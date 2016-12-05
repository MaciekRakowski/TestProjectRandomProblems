using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryRoblox
{
    public class MaximumProductProblem
    {
        static int COUNT = 3;
        public static int GetMaxProduct(List<int> list)
        {
            try
            {
                checked
                {
                    if (list.Count < COUNT)
                    {
                        throw new ArgumentException("List size needs to be < 3.");
                    }
                    if (list.Count == COUNT)
                    {
                        return list[0] * list[1] * list[2]; // We hardcode this for 3 items for the sake of the problem.
                    }

                    List<int> topCount = new List<int>();
                    List<int> bottomCount = new List<int>();

                    for (int index = 0; index < list.Count; index++)
                    {
                        int value = list[index];
                        AddToBiggestList(topCount, value);
                        AddToSmallestList(bottomCount, value);
                    }


                    //list.Count >= 6
                    if (bottomCount[1] >= 0)
                    {
                        return topCount[0] * topCount[1] * topCount[2];// We hardcode this for 3 items for the sake of the problem.
                    }

                    // We hardcode this for 3 items for the sake of the problem.
                    var doubleNegative = bottomCount[1] * bottomCount[0] * topCount[2];
                    var top3Sum = topCount[0] * topCount[1] * topCount[2];
                    return Math.Max(doubleNegative, top3Sum);
                }
            }
            catch(OverflowException ex)
            {
                throw new ArgumentException("Does not evaluate to valid Int32.", ex);
            }
        }

        private static void AddToBiggestList(List<int> topCount, int number)
        {
            if (topCount.Count == COUNT)
            {
                topCount.Sort();
                if (number > topCount[0])
                {
                    topCount.RemoveAt(0);//remove the smallest
                    topCount.Add(number);
                }
            }
            else if (topCount.Count < COUNT)
            {
                topCount.Add(number);
            }
            topCount.Sort();
        }

        private static void AddToSmallestList(List<int> bottomCount, int number)
        {
            if (bottomCount.Count == COUNT)
            {
                bottomCount.Sort();
                if (number < bottomCount[COUNT - 1])
                {
                    bottomCount.RemoveAt(COUNT - 1);//remove the greatest
                    bottomCount.Add(number);
                }
            }
            else if (bottomCount.Count < COUNT)
            {
                bottomCount.Add(number);
                
            }
            bottomCount.Sort();
        }
    }
}
