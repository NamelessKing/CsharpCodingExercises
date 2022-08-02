using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.edabit.com.Easy.RemoveDuplicatesFromArrayOfObjects
{
    public class Program
    {
        public static object[] RemoveDups(object[] str)
        {

            var output = new List<object>();
            output.Add(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                if (!output.Contains(str[i]))
                {
                    output.Add(str[i]);
                }
            }

            return output.ToArray();
        }
    }

    [TestFixture]
    public class FindNeedleTest
    {
        [Test]
        public void GenericTests()
        {
            object[] haystack_1 = new object[] { "John", "Taylor", "John" };
            object[] haystack_2 = new object[] { "John", "Taylor", "John", "john" };
            object[] haystack_3 = new object[] { "javascript", "python", "python", "ruby", "javascript", "c", "ruby" };
            object[] haystack_4 = new object[] { 1, 2, 2, 2, 3, 2, 5, 2, 6, 6, 3, 7, 1, 2, 5 };
            object[] haystack_5 = new object[] { "#", "#", "%", "&", "#", "$", "&" };
            object[] haystack_6 = new object[] { 3, "Apple", 3, "Orange", "Apple" };

            Assert.AreEqual(new object[] { "John", "Taylor" }, Program.RemoveDups(haystack_1));
            Assert.AreEqual(new object[] { "John", "Taylor", "john" }, Program.RemoveDups(haystack_2));
            Assert.AreEqual(new object[] { "javascript", "python", "ruby", "c" }, Program.RemoveDups(haystack_3));
            Assert.AreEqual(new object[] { 1, 2, 3, 5, 6, 7 }, Program.RemoveDups(haystack_4));
            Assert.AreEqual(new object[] { "#", "%", "&", "$" }, Program.RemoveDups(haystack_5));
            Assert.AreEqual(new object[] { 3, "Apple", "Orange" }, Program.RemoveDups(haystack_6));
        }
    }
}
