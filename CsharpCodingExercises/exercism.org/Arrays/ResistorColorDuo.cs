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
    If you want to build something using a Raspberry Pi, you'll probably use resistors. 
    For this exercise, you need to know two things about them:

    Each resistor has a resistance value.
    Resistors are small - so small in fact that if you printed the resistance value on them, it would be hard to read.
    To get around this problem, manufacturers print color-coded bands onto the resistors to denote their resistance values. 
    Each band has a position and a numeric value.

    The first 2 bands of a resistor have a simple encoding scheme: each color maps to a single number. 
    For example, if they printed a brown band (value 1) followed by a green band (value 5), it would translate to the number 15.

    In this exercise you are going to create a helpful program so that you don't have to remember the values of the bands. 
    The program will take color names as input and output a two digit number, even if the input is more than two colors!

    The band colors are encoded as follows:

    black: 0
    brown: 1
    red: 2
    orange: 3
    yellow: 4
    green: 5
    blue: 6
    violet: 7
    grey: 8
    white: 9
    From the example above: brown-green should return 15, and brown-green-violet should return 15 too, ignoring the third color.
     */
    public static class ResistorColorDuo
    {
        private static readonly string[] colorBands =
        {
            "black",
            "brown",
            "red",
            "orange",
            "yellow",
            "green",
            "blue",
            "violet",
            "grey",
            "white"
        };

        public static int Value(string[] colors)
        {
            return Array.IndexOf(colorBands, colors[0]) * 10 + Array.IndexOf(colorBands, colors[1]);
        }
    }

    public class ResistorColorDuoTests
    {
        [Test]
        public void Brown_and_black()
        {
            Assert.AreEqual(10, ResistorColorDuo.Value(new[] { "brown", "black" }));
        }
        [Test]
        public void Blue_and_grey()
        {
            Assert.AreEqual(68, ResistorColorDuo.Value(new[] { "blue", "grey" }));
        }
        [Test]
        public void Yellow_and_violet()
        {
            Assert.AreEqual(47, ResistorColorDuo.Value(new[] { "yellow", "violet" }));
        }
        [Test]
        public void White_and_red()
        {
            Assert.AreEqual(92, ResistorColorDuo.Value(new[] { "white", "red" }));
        }
        [Test]
        public void Orange_and_orange()
        {
            Assert.AreEqual(33, ResistorColorDuo.Value(new[] { "orange", "orange" }));
        }
        [Test]
        public void Ignore_additional_colors()
        {
            Assert.AreEqual(51, ResistorColorDuo.Value(new[] { "green", "brown", "orange" }));
        }
        [Test]
        public void Black_and_brown_one_digit()
        {
            Assert.AreEqual(1, ResistorColorDuo.Value(new[] { "black", "brown" }));
        }
    }

}
