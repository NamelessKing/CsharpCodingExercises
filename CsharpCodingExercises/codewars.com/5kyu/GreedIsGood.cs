﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCodingExercises.codewars.com._5kyu.GreedIsGood
{
    public static class Kata
    {
        /*
        5 kyu - Greed is Good https://www.codewars.com/kata/5270d0d18625160ada0000e4/train/csharp

        Greed is a dice game played with five six-sided dice. 
        Your mission, should you choose to accept it, is to score a throw according to these rules. 
        You will always be given an array with five six-sided dice values.

        Three 1's => 1000 points
        Three 6's =>  600 points
        Three 5's =>  500 points
        Three 4's =>  400 points
        Three 3's =>  300 points
        Three 2's =>  200 points
        One   1   =>  100 points
        One   5   =>   50 point
        A single die can only be counted once in each roll. 
        For example, a given "5" can only count as part of a triplet (contributing to the 500 points) or as a single 50 points, but not both in the same roll.

        Example scoring

        Throw       Score
        ---------   ------------------
        5 1 3 4 1   250:  50 (for the 5) + 2 * 100 (for the 1s)
        1 1 1 3 1   1100: 1000 (for three 1s) + 100 (for the other 1)
        2 4 4 5 4   450:  400 (for three 4s) + 50 (for the 5)

        In some languages, it is possible to mutate the input to the function. 
        This is something that you should never do. If you mutate the input, you will not be able to pass all the tests.

         */
        public static int Score(int[] dice)
        {
            var counters = dice.GroupBy(d => d).ToDictionary(d => d.Key, d => d.ToList().Count);

            int score = 0;
            foreach (var c in counters)
            {
                var triplets = c.Value / 3;
                var remainders = c.Value % 3;

                if (c.Key == 5)
                {
                    score += (triplets * 500) + (remainders * 50);
                }
                else if (c.Key == 1) 
                {
                    score += (triplets * 1000) + (remainders * 100);
                }
                else 
                {
                    score += (triplets * c.Key * 100) ;
                }
            }

            return score;
        }
    }

    public static class ScoreChecker
    {
        [Test]
        public static void ShouldBeWorthless()
        {
            Assert.AreEqual(0, Kata.Score(new int[] { 2, 3, 4, 6, 2 }), "Should be 0 :-(");
        }

        [Test]
        public static void ShouldValueTriplets()
        {
            Assert.AreEqual(400, Kata.Score(new int[] { 4, 4, 4, 3, 3 }), "Should be 400");
        }

        [Test]
        public static void ShouldValueMixedSets()
        {
            Assert.AreEqual(450, Kata.Score(new int[] { 2, 4, 4, 5, 4 }), "Should be 450");
        }
    }
}
