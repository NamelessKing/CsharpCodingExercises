using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsharpCodingExercises.codewars.com._7kyu.ListFilterer
{
    public class ListFilterer
    {

        /**
        In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.

        Example
        ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
        ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => {1, 2, 0, 15}
        ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 231}) => {1, 2, 231}
         */
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            return listOfItems.Where(x => x.GetType() == typeof(int)).Select(x => (int)x);
        }
        /*
        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            return listOfItems.OfType<int>();
        }

        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            foreach (object x in listOfItems)
                if (x is int) yield return (int)x;
        }

         //But I am sure there is a way where you can just cast a List<object> to a IEnumerable<int> without any trouble
         //In that case you simply want to do the following:

        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            for (int i = listOfItems.Count - 1; i >= 0; i--)
            {
                if (listOfItems[i] is string)
                    listOfItems.RemoveAt(i);
            }
            return listOfItems; // <-- Please tell me a way of returning this without problems, thank you <3
        }
        */
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_1()
        {
            var list = new List<object>() { 1, 2, "a", "b" };
            var expected = new List<int>() { 1, 2 };
            var actual = ListFilterer.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_2()
        {
            var list = new List<object>() { 1, "a", "b", 0, 15 };
            var expected = new List<int>() { 1, 0, 15 };
            var actual = ListFilterer.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        [Test]
        public void GetIntegersFromList_MixedValues_ShouldPass_3()
        {
            var list = new List<object>() { 1, 2, "aasf", "1", "123", 123 };
            var expected = new List<int>() { 1, 2, 123 };
            var actual = ListFilterer.GetIntegersFromList(list);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
