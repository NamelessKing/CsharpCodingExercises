using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xunit;

namespace CsharpCodingExercises.exercism.org.Arrays
{

    /*
    Introduction
    You have stumbled upon a group of mathematicians who are also singer-songwriters. 
    They have written a song for each of their favorite numbers, and, as you can imagine, 
    they have a lot of favorite numbers (like 0 or 73 or 6174).

    You are curious to hear the song for your favorite number, 
    but with so many songs to wade through, finding the right song could take a while. 
    Fortunately, they have organized their songs in a playlist sorted by the title — which is simply the number that the song is about.

    You realize that you can use a binary search algorithm to quickly find a song given the title.

    Instructions
    Your task is to implement a binary search algorithm.

    A binary search algorithm finds an item in a list by repeatedly splitting it in half, 
    only keeping the half which contains the item we're looking for. 
    It allows us to quickly narrow down the possible locations of our item until we find it, 
    or until we've eliminated all possible locations.

    Caution
    Binary search only works when a list has been sorted.

    The algorithm looks like this:

    Find the middle element of a sorted list and compare it with the item we're looking for.
    If the middle element is our item, then we're done!
    If the middle element is greater than our item, we can eliminate that element and all the elements after it.
    If the middle element is less than our item, we can eliminate that element and all the elements before it.
    If every element of the list has been eliminated then the item is not in the list.
    Otherwise, repeat the process on the part of the list that has not been eliminated.
    Here's an example:

    Let's say we're looking for the number 23 in the following sorted list: [4, 8, 12, 16, 23, 28, 32].

    We start by comparing 23 with the middle element, 16.
    Since 23 is greater than 16, we can eliminate the left half of the list, leaving us with [23, 28, 32].
    We then compare 23 with the new middle element, 28.
    Since 23 is less than 28, we can eliminate the right half of the list: [23].
    We've found our item.
     */
    public static class BinarySearch
    {
        public static int Find(int[] input, int value)
        {
            int left = 0;
            int right = input.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (input[middle] == value)
                {
                    return middle;
                }
                if (input[middle] < value)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;
        }
    }

    public class BinarySearchTests
    {
        [Test]
        public void Finds_a_value_in_an_array_with_one_element()
        {
            var array = new[] { 6 };
            var value = 6;
            Assert.AreEqual(0, BinarySearch.Find(array, value));
        }
        [Test]
        public void Finds_a_value_in_the_middle_of_an_array()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 6;
            Assert.AreEqual(3, BinarySearch.Find(array, value));
        }
        [Test]
        public void Finds_a_value_at_the_beginning_of_an_array()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 1;
            Assert.AreEqual(0, BinarySearch.Find(array, value));
        }
        [Test]
        public void Finds_a_value_at_the_end_of_an_array()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 11;
            Assert.AreEqual(6, BinarySearch.Find(array, value));
        }
        [Test]
        public void Finds_a_value_in_an_array_of_odd_length()
        {
            var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 };
            var value = 144;
            Assert.AreEqual(9, BinarySearch.Find(array, value));
        }
        [Test]
        public void Finds_a_value_in_an_array_of_even_length()
        {
            var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 };
            var value = 21;
            Assert.AreEqual(5, BinarySearch.Find(array, value));
        }
        [Test]
        public void Identifies_that_a_value_is_not_included_in_the_array()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 7;
            Assert.AreEqual(-1, BinarySearch.Find(array, value));
        }
        [Test]
        public void A_value_smaller_than_the_arrays_smallest_value_is_not_found()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 0;
            Assert.AreEqual(-1, BinarySearch.Find(array, value));
        }
        [Test]
        public void A_value_larger_than_the_arrays_largest_value_is_not_found()
        {
            var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
            var value = 13;
            Assert.AreEqual(-1, BinarySearch.Find(array, value));
        }
        [Test]
        public void Nothing_is_found_in_an_empty_array()
        {
            var array = Array.Empty<int>();
            var value = 1;
            Assert.AreEqual(-1, BinarySearch.Find(array, value));
        }
        [Test]
        public void Nothing_is_found_when_the_left_and_right_bounds_cross()
        {
            var array = new[] { 1, 2 };
            var value = 0;
            Assert.AreEqual(-1, BinarySearch.Find(array, value));
        }
    }
}
