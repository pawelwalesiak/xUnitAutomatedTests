using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public static class ListHelper
    {
        public static List<int> FilterOddNumber(List<int> listOfNumbers)
        {

            //1,2,3 -> 1,3
            //1,1,2,3,3 -> 1,1,3,3
            //8,10,2 -> empty
            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] % 2 == 0)
                {
                    listOfNumbers.RemoveAt(i);
                }
            
            }
            return listOfNumbers;
        }
    }
}
