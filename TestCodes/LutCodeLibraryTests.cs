using LitCodeOloloNadOther.SupportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodes
{
    public class LutCodeLibraryTests
    {

        public LitCodeOloloNadOther.LutCodeLibrary TestedClass = new LitCodeOloloNadOther.LutCodeLibrary();



        //        Given a 0-indexed integer array nums of size n, find the maximum difference between nums[i] and nums[j] (i.e., nums[j] - nums[i]), such that 0 <= i<j<n and nums[i] < nums[j].

        //        Return the maximum difference.If no such i and j exists, return -1.


        //Input: nums = [7, 1, 5, 4]
        //Output: 4
        //Input: nums = [9, 4, 3, 2]
        //Output: -1

        //[Theory]
        //[InlineData([7, 1, 5, 4])]
   
        //public void Add_ShouldReturnSumOfNumbers(int a, int b, int expected)
        //{
        //    // Act
        //   // var result = _calculator.Add(a, b);

        //    // Assert
        //    //Assert.Equal(expected, result);
        //}


        [Theory]
        [InlineData(new int[2] { 1, 3 }, new int[1] { 2 }, 2)]
        [InlineData(new int[2] { 1, 2 }, new int[2] { 3, 4 }, 2.5)]
        [InlineData(new int[2] { -1, 3 }, new int[1] { 2 }, 2)]
        [InlineData(new int[2] { 0, 0 }, new int[2] { 0, 0 }, 0)]
        [InlineData(new int[1] { 2 }, new int[0] { }, 2)]
        public void Check_FindMedianSortedArrays(int[] num1, int[] num2, double expected)
        {
            // Act
            var result = TestedClass.FindMedianSortedArrays(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(new int[4] { 2, 7, 11, 15 }, 9, new int[2] { 0,1})]
        [InlineData(new int[3] { 3, 2, 4 }, 6, new int[2] { 1,2 })]
        [InlineData(new int[2] { 3, 3 }, 6, new int[2] { 0,1 })]
        public void Check_TwoSum(int[] nums, int target, int[] expected)
        {

            var result = TestedClass.TwoSum(nums,  target);

            Assert.Equal(expected, result);
        }


        //Input: lists = [[1, 4, 5],[1, 3, 4],[2, 6]]  Output: [1,1,2,3,4,4,5,6]
        [Theory]
        [InlineData(1,  new int[8] { 1, 1, 2, 3, 4, 4, 5, 6 }) ]
        public void Check_MergeKLists(int hz1, int[] expected)
        {

           var hz =  new int[][] { new int[3] { 1, 4, 5 }, new int[3] { 1, 3, 4 }, new int[2] { 2, 6 } };
            ListNode[] Checked = new ListNode[3] { new ListNode(hz[0]), new ListNode(hz[1]), new ListNode(hz[2]) };

            var result = TestedClass.MergeKLists(Checked);

            Assert.Equal(new ListNode(expected), result);


        }




        public void FindMedianSortedArraysTest(int a, int b, int expected)
        {



        }

    }
}
