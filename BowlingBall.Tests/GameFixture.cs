using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game g;

        public GameFixture()
        {
            g = new Game();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            g.Roll(6);
            g.Roll(4);
        }

        [Fact]

        public void TestBowlingGameClass()
        {
            Assert.IsType<Game>(g);
        }

        [Fact]
        public void TestLooserGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(4);
            RollMany(17, 0);
            Assert.Equal(18, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            RollMany(17, 0);
            Assert.Equal(28, g.GetScore());
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void TestRandomGameNoExtraRoll()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, g.GetScore());
        }

        [Fact]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, g.GetScore());
        }

        [Fact]
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, g.GetScore());
        }

    }
}
