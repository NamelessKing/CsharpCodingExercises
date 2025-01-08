using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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

    In this exercise you are going to create a helpful program so that you don't have to remember the values of the bands.

    These colors are encoded as follows:

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
    The goal of this exercise is to create a way:

    to look up the numerical value associated with a particular color band
    to list the different band colors
     */
    public static class ResistorColor
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

        public static int ColorCode(string color)
        {
            return Array.IndexOf(colorBands, color);
        }

        public static string[] Colors()
        {
            return colorBands;
        }
    }
    public class ResistorColorTests
    {
        [Test]
        public void Black()
        {
            Assert.AreEqual(0, ResistorColor.ColorCode("black"));
        }
        [Test]
        public void White()
        {
            Assert.AreEqual(9, ResistorColor.ColorCode("white"));
        }
        [Test]
        public void Orange()
        {
            Assert.AreEqual(3, ResistorColor.ColorCode("orange"));
        }
        [Test]
        public void Colors()
        {
            Assert.AreEqual(new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" }, ResistorColor.Colors());
        }
    }
}
