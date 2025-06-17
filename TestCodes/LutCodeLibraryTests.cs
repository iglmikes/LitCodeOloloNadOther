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
        [InlineData(new int[2] { -1, 2 }, new int[2] { 3, 4 }, 2.5)]

        public void Check_FindMedianSortedArrays(int[] num1, int[] num2, double expected)
        {


            // Act
            var result = TestedClass.FindMedianSortedArrays(num1, num2);

            // Assert
            Assert.Equal(expected, result);




        }








  

        public void FindMedianSortedArraysTest(int a, int b, int expected)
        {



        }

    }
}
