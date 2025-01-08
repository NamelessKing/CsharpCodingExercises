using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xunit;

namespace CsharpCodingExercises.exercism.org.ForLoops
{
    /*
    Instructions
    Count the rectangles in an ASCII diagram like the one below.

       +--+
      ++  |
    +-++--+
    |  |  |
    +--+--+
    The above diagram contains these 6 rectangles:



    +-----+
    |     |
    +-----+
       +--+
       |  |
       |  |
       |  |
       +--+
       +--+
       |  |
       +--+




       +--+
       |  |
       +--+


    +--+
    |  |
    +--+

      ++
      ++


    You may assume that the input is always a proper rectangle (i.e. the length of every line equals the length of the first line).
     */
    public static class Rectangles
    {
        public static int Count(string[] rows)
        {
            if (rows == null || rows.Length == 0) return 0;

            int rectangleCount = 0;

            for (int topRow = 0; topRow < rows.Length; topRow++)
            {
                for (int col1 = 0; col1 < rows[topRow].Length; col1++)
                {
                    if (rows[topRow][col1] != '+') continue;

                    for (int col2 = col1 + 1; col2 < rows[topRow].Length; col2++)
                    {
                        if (rows[topRow][col2] != '+' || !IsHorizontalEdge(rows[topRow], col1, col2))
                            continue;

                        for (int bottomRow = topRow + 1; bottomRow < rows.Length; bottomRow++)
                        {
                            if (rows[bottomRow][col1] == '+' && rows[bottomRow][col2] == '+' &&
                                IsHorizontalEdge(rows[bottomRow], col1, col2) &&
                                IsVerticalEdge(rows, col1, topRow, bottomRow) &&
                                IsVerticalEdge(rows, col2, topRow, bottomRow))
                            {
                                rectangleCount++;
                            }
                        }
                    }
                }
            }

            return rectangleCount;
        }

        private static bool IsHorizontalEdge(string row, int startCol, int endCol)
        {
            for (int c = startCol + 1; c < endCol; c++)
            {
                if (row[c] != '-' && row[c] != '+')
                    return false;
            }
            return true;
        }

        private static bool IsVerticalEdge(string[] rows, int col, int startRow, int endRow)
        {
            for (int r = startRow + 1; r < endRow; r++)
            {
                if (rows[r][col] != '|' && rows[r][col] != '+')
                    return false;
            }
            return true;
        }
    }


    public class RectanglesTests
    {
        [Test]
        public void No_rows()
        {
            var strings = Array.Empty<string>();
            Assert.AreEqual(0, Rectangles.Count(strings));
        }
        [Test]
        public void No_columns()
        {
            var strings = new[]
            {
            ""
        };
            Assert.AreEqual(0, Rectangles.Count(strings));
        }
        [Test]
        public void No_rectangles()
        {
            var strings = new[]
            {
            " "
        };
            Assert.AreEqual(0, Rectangles.Count(strings));
        }
        [Test]
        public void One_rectangle()
        {
            var strings = new[]
            {
                "+-+",
                "| |",
                "+-+"
            };
            Assert.AreEqual(1, Rectangles.Count(strings));
        }
        [Test]
        public void Two_rectangles_without_shared_parts()
        {
            var strings = new[]
            {
            "  +-+",
            "  | |",
            "+-+-+",
            "| |  ",
            "+-+  "
        };
            Assert.AreEqual(2, Rectangles.Count(strings));
        }
        [Test]
        public void Five_rectangles_with_shared_parts()
        {
            var strings = new[]
            {
            "  +-+",
            "  | |",
            "+-+-+",
            "| | |",
            "+-+-+"
        };
            Assert.AreEqual(5, Rectangles.Count(strings));
        }
        [Test]
        public void Rectangle_of_height_1_is_counted()
        {
            var strings = new[]
            {
            "+--+",
            "+--+"
        };
            Assert.AreEqual(1, Rectangles.Count(strings));
        }
        [Test]
        public void Rectangle_of_width_1_is_counted()
        {
            var strings = new[]
            {
            "++",
            "||",
            "++"
        };
            Assert.AreEqual(1, Rectangles.Count(strings));
        }
        [Test]
        public void Number_1x1_square_is_counted()
        {
            var strings = new[]
            {
            "++",
            "++"
        };
            Assert.AreEqual(1, Rectangles.Count(strings));
        }
        [Test]
        public void Only_complete_rectangles_are_counted()
        {
            var strings = new[]
            {
            "  +-+",
            "    |",
            "+-+-+",
            "| | -",
            "+-+-+"
        };
            Assert.AreEqual(1, Rectangles.Count(strings));
        }
        [Test]
        public void Rectangles_can_be_of_different_sizes()
        {
            var strings = new[]
            {
            "+------+----+",
            "|      |    |",
            "+---+--+    |",
            "|   |       |",
            "+---+-------+"
        };
            Assert.AreEqual(3, Rectangles.Count(strings));
        }
        [Test]
        public void Corner_is_required_for_a_rectangle_to_be_complete()
        {
            var strings = new[]
            {
            "+------+----+",
            "|      |    |",
            "+------+    |",
            "|   |       |",
            "+---+-------+"
        };
            Assert.AreEqual(2, Rectangles.Count(strings));
        }
        [Test]
        public void Large_input_with_many_rectangles()
        {
            var strings = new[]
            {
            "+---+--+----+",
            "|   +--+----+",
            "+---+--+    |",
            "|   +--+----+",
            "+---+--+--+-+",
            "+---+--+--+-+",
            "+------+  | |",
            "          +-+"
        };
            Assert.AreEqual(60, Rectangles.Count(strings));
        }
        [Test]
        public void Rectangles_must_have_four_sides()
        {
            var strings = new[]
            {
            "+-+ +-+",
            "| | | |",
            "+-+-+-+",
            "  | |  ",
            "+-+-+-+",
            "| | | |",
            "+-+ +-+"
        };
            Assert.AreEqual(5, Rectangles.Count(strings));
        }
    }

}
