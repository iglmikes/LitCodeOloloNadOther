using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitCodeOloloNadOther
{
    public  class LutCodeLibrary
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int lng = nums1.Length + nums2.Length;
            int half = 0;
            bool isEvenNum = false;
            bool ImHere = false;
            int[] nums = new int[lng];
            int i = 0, j = 0, k = 0;
            double result = 0;

            if (lng%2 == 0 ) // 
            {
                isEvenNum = true;
            }
            half = (int)lng/2;
            if (!isEvenNum) half++;

            while (k<nums.Length)
            {
                if (i == nums1.Length)
                {
                    nums[k] = nums2[j];
                    j++;
                    k++;

                }
                else if (j == nums.Length)
                {
                    nums[k] = nums1[i];
                    i++;
                    k++;


                }

                else if (nums1[i] < nums2[j]&& j< nums2.Length && i< nums1.Length)
                {
                    nums[k] = nums1[i];
                    i++;
                    k++;
                }
                else 
                {
                    nums[k] = nums2[j];
                    j++;
                    k++;
                }


                if(k >= half)
                {
                    //there mediana of two arrays
                    if (!ImHere)
                    {
                        result = (double)nums[k-1];
                        if (!isEvenNum) return result;
                        else ImHere = true;
                    }
                    else
                    {
                        result = (double)((result +nums[k-1])/2);
                        return result;
                    }

                }
            }
            //arrays merged and sorted - in teory




            return 0;
        }




    }
}
