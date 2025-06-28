using LitCodeOloloNadOther.SupportModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitCodeOloloNadOther
{
    public class LutCodeLibrary
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int lng = nums1.Length + nums2.Length;
            int half = 0;
            bool isEvenNum = false;
            bool ImHere = false;
            // int[] nums = new int[lng];
            int i = 0, j = 0, k = 0;
            int CurrentStep = 0;
            double result = 0;

            if (lng % 2 == 0) // 
            {
                isEvenNum = true;
            }
            half = (int)lng / 2;
            if (!isEvenNum) half++;


            while (k < lng)
            {
                if (i == nums1.Length || nums1.Length == 0 || nums1 == null)
                {
                    //nums[k] = nums2[j];
                    CurrentStep = nums2[j];
                    j++;
                    k++;

                }
                else if (j == nums2.Length || nums2.Length == 0 || nums2 == null)
                {
                    //nums[k] = nums1[i];
                    CurrentStep = nums1[i];
                    i++;
                    k++;


                }
                else if (nums1.Length > 0 && nums2.Length > 0 && j < nums2.Length && i < nums1.Length)
                {

                    if (nums1[i] <= nums2[j])
                    {
                        //nums[k] = nums1[i];
                        CurrentStep = nums1[i];
                        i++;
                        k++;
                    }
                    else
                    {
                        //nums[k] = nums2[j];
                        CurrentStep = nums2[j];
                        j++;
                        k++;
                    }
                }

                if (k >= half)
                {
                    //there mediana of two arrays
                    if (!ImHere)
                    {
                        //result = (double)nums[k-1];
                        result = CurrentStep;
                        if (!isEvenNum) return result;
                        else ImHere = true;
                    }
                    else
                    {
                        result = (double)((result + CurrentStep) / 2);
                        return result;
                    }

                }
            }
            //arrays merged and sorted - in teory




            return 0;
        }


        [Obsolete]
        public int[] TwoSum1(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target) return new int[] { i, j };
                }
            }
            return new int[2] { -1, -1 };
        }


        public int[] TwoSum(int[] nums, int target)
        {
            HashSet<int> numset = new HashSet<int>(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (numset.Contains(target - nums[i]))
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target) return new int[] { i, j };
                    }
                }
            }
            return new int[2] { -1, -1 };
        }




        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = new ListNode();
            Dictionary<int, List<ListNode?>> offsets = new Dictionary<int, List<ListNode?>>();
            bool started = false, ended = false;
            int starter = 999999999;
            List<int> Nums = new List<int>();

            ListNode First = new ListNode(0, result);
            

            foreach (var v in lists)
            {
                if (v.val < starter) starter = v.val;
                //  if (!offsets.ContainsKey(v.val)) offsets.Add(v.val, new List<ListNode>() { v });

                if (offsets.TryGetValue(v.val, out var Lst))
                { Lst.Add(v); }
                else
                { offsets.Add(v.val, new List<ListNode?>() { v }); }
                //else (offsets[v.val].Add(v));
            }
            bool isended;
            for (int i = starter; ; i++)
            {
                isended = false;
                if (offsets.ContainsKey(i))
                {
                    foreach (var v in offsets[i])
                    {
                        var CurrentRty = DoChains(v, ref result.next, i, offsets);
                        isended |= CurrentRty.res;
                        result = CurrentRty.Last;
                    }
                    offsets.Remove(i);
                    if (isended)
                        return First.next;
                    //
                }
            }
            //add starter steps and add 
            return new ListNode();
        }




        public static void AddToDict(Dictionary<int, List<ListNode?>> offsets, ListNode v)
        {
            if (offsets.TryGetValue(v.val, out var Lst))
            { Lst.Add(v); }
            else
            { offsets.Add(v.val, new List<ListNode?>() { v }); }

        }

        public static (bool res, ListNode Last) DoChains(ListNode Current, ref ListNode ResultNode, int CurrValue, Dictionary<int, List<ListNode?>> Offsets)
        {
            if (Current.val == CurrValue)
            {

                ResultNode = new ListNode(CurrValue);
                if (Current.next == null)
                    return (true, ResultNode);
                if (Current.next.val > CurrValue)
                {
                    AddToDict(Offsets, Current.next);
                    return (false, Current);
                }
                else
                {
                    var hz = DoChains(Current.next,ref  ResultNode.next, CurrValue, Offsets);
                    return (hz.res, hz.Last);
                }
            }
            else
            {
                AddToDict(Offsets, Current);//not need it?
                return (false, ResultNode);
            }
        }



    }
}

