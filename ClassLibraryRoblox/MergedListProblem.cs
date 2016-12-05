using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryRoblox
{
    public class MergedListProblem
    {
        public static List<int> GetMergedList(List<int> list1, List<int> list2)
        {
            list1 = list1 ?? new List<int>();
            list2 = list2 ?? new List<int>();
            int i1 = 0, i2 = 0;

            List<int> merged = new List<int>();
            while (i1 < list1.Count && i2 < list2.Count)
            {
                if (list1[i1] < list2[i2])
                {
                    merged.Add(list1[i1]);
                    i1++;
                }
                else
                {
                    merged.Add(list2[i2]);
                    i2++;
                }
            }

            while (i1 < list1.Count)
            {
                merged.Add(list1[i1]);
                i1++;
            }

            while (i2 < list2.Count)
            {
                merged.Add(list2[i2]);
                i2++;
            }
            return merged;
        }
    }
}
