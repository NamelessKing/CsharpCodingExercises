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
    Instructions
    For want of a horseshoe nail, a kingdom was lost, or so the saying goes.

    Given a list of inputs, generate the relevant proverb. 
    For example, given the list ["nail", "shoe", "horse", "rider", "message", "battle", "kingdom"], 
    you will output the full text of this proverbial rhyme:

    For want of a nail the shoe was lost.
    For want of a shoe the horse was lost.
    For want of a horse the rider was lost.
    For want of a rider the message was lost.
    For want of a message the battle was lost.
    For want of a battle the kingdom was lost.
    And all for the want of a nail.

    Note that the list of inputs may vary; your solution should be able to handle lists of arbitrary length and content. 
    No line of the output text should be a static, unchanging string; all should vary according to the input given.

    Try to capture the structure of the song in your code, where you build up the song by composing its parts.
     */
    public static class Proverb
    {
        public static string[] Recite(string[] subjects)
        {
            if (subjects.Length != 0)
            {
                string[] result = new string[subjects.Length];
                for (int i = 0; i < subjects.Length; i++)
                {
                    if (i == subjects.Length - 1)
                    {
                        result[i] = $"And all for the want of a {subjects[0]}.";
                    }
                    else
                    {
                        result[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
                    }

                }
                return result;
            }

            return Array.Empty<string>();
        }
    }

    public class ProverbTests
    {
        [Test]
        public void Zero_pieces()
        {
            var strings = Array.Empty<string>();
            var expected = Array.Empty<string>();
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
        [Test]
        public void One_piece()
        {
            var strings = new[]
            {
            "nail"
            };
            var expected = new[]
            {
            "And all for the want of a nail."
            };
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
        [Test]
        public void Two_pieces()
        {
            var strings = new[]
            {
            "nail",
            "shoe"
            };
            var expected = new[]
            {
            "For want of a nail the shoe was lost.",
            "And all for the want of a nail."
            };
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
        [Test]
        public void Three_pieces()
        {
            var strings = new[]
            {
            "nail",
            "shoe",
            "horse"
            };
            var expected = new[]
            {
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "And all for the want of a nail."
            };
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
        [Test]
        public void Full_proverb()
        {
            var strings = new[]
            {
            "nail",
            "shoe",
            "horse",
            "rider",
            "message",
            "battle",
            "kingdom"
            };
            var expected = new[]
            {
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "For want of a horse the rider was lost.",
            "For want of a rider the message was lost.",
            "For want of a message the battle was lost.",
            "For want of a battle the kingdom was lost.",
            "And all for the want of a nail."
            };
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
        [Test]
        public void Four_pieces_modernized()
        {
            var strings = new[]
            {
            "pin",
            "gun",
            "soldier",
            "battle"
            };
            var expected = new[]
            {
            "For want of a pin the gun was lost.",
            "For want of a gun the soldier was lost.",
            "For want of a soldier the battle was lost.",
            "And all for the want of a pin."
            };
            Assert.AreEqual(expected, Proverb.Recite(strings));
        }
    }
}
