using System;
using CarnivalCrawler.Weapons.FivesPoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarnivalCrawlerTests.Weapons.FivesPoker
{
    [TestClass]
    public class PokerHandTests
    {
        [TestMethod]
        public void Junk_Hand()
        {
            PlayingCard[] junk1 =
            {
                new PlayingCard(0, 2),
                new PlayingCard(2, 5),
                new PlayingCard(3, 1),
                new PlayingCard(2, 6),
                new PlayingCard(3, 8)
            };
            PlayingCard[] junk2 =
            {
                new PlayingCard(3, 8),
                new PlayingCard(1, 5),
                new PlayingCard(2, 4),
                new PlayingCard(1, 2),
                new PlayingCard(2, 9)
            };
            PlayingCard[] notJunk =
            {
                new PlayingCard(3, 8),
                new PlayingCard(1, 9),
                new PlayingCard(2, 4),
                new PlayingCard(1, 2),
                new PlayingCard(2, 9)
            };


            IPokerHand hand1 = new PokerHand(junk1);
            IPokerHand hand2 = new PokerHand(junk2);
            IPokerHand hand3 = new PokerHand(notJunk);

            Assert.AreEqual(PokerHandType.Junk, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Junk, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Junk, hand3.GetHandType());
        }

        [TestMethod]
        public void One_Pair_Hand()
        {
            PlayingCard[] onePair1 =
            {
                new PlayingCard(0, 2),
                new PlayingCard(2, 5),
                new PlayingCard(3, 1),
                new PlayingCard(2, 2),
                new PlayingCard(3, 8)
            };
            PlayingCard[] onePair2 =
            {
                new PlayingCard(3, 8),
                new PlayingCard(1, 5),
                new PlayingCard(2, 4),
                new PlayingCard(1, 9),
                new PlayingCard(2, 9)
            };
            PlayingCard[] notOnePair =
            {
                new PlayingCard(3, 8),
                new PlayingCard(1, 9),
                new PlayingCard(2, 4),
                new PlayingCard(1, 9),
                new PlayingCard(2, 9)
            };

            IPokerHand hand1 = new PokerHand(onePair1);
            IPokerHand hand2 = new PokerHand(onePair2);
            IPokerHand hand3 = new PokerHand(notOnePair);

            Assert.AreEqual(PokerHandType.Pair, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Pair, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Pair, hand3.GetHandType());
        }

        [TestMethod]
        public void Two_Pair_Hand()
        {
            PlayingCard[] twoPair1 =
            {
                new PlayingCard(0, 2),
                new PlayingCard(2, 5),
                new PlayingCard(3, 5),
                new PlayingCard(2, 4),
                new PlayingCard(3, 4)
            };
            PlayingCard[] twoPair2 =
            {
                new PlayingCard(3, 11),
                new PlayingCard(1, 11),
                new PlayingCard(2, 4),
                new PlayingCard(1, 4),
                new PlayingCard(2, 9)
            };
            PlayingCard[] notTwoPair =
            {
                new PlayingCard(3, 2),
                new PlayingCard(1, 2),
                new PlayingCard(2, 2),
                new PlayingCard(1, 9),
                new PlayingCard(2, 9)
            };

            IPokerHand hand1 = new PokerHand(twoPair1);
            IPokerHand hand2 = new PokerHand(twoPair2);
            IPokerHand hand3 = new PokerHand(notTwoPair);

            Assert.AreEqual(PokerHandType.TwoPair, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.TwoPair, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.TwoPair, hand3.GetHandType());
        }

        [TestMethod]
        public void Threes_Hand()
        {
            PlayingCard[] threes1 =
            {
                new PlayingCard(0, 2),
                new PlayingCard(2, 5),
                new PlayingCard(3, 5),
                new PlayingCard(2, 5),
                new PlayingCard(3, 4)
            };
            PlayingCard[] threes2 =
            {
                new PlayingCard(3, 4),
                new PlayingCard(1, 11),
                new PlayingCard(2, 2),
                new PlayingCard(1, 4),
                new PlayingCard(2, 4)
            };
            PlayingCard[] notThrees =
            {
                new PlayingCard(3, 2),
                new PlayingCard(1, 2),
                new PlayingCard(2, 2),
                new PlayingCard(1, 9),
                new PlayingCard(2, 9)
            };

            IPokerHand hand1 = new PokerHand(threes1);
            IPokerHand hand2 = new PokerHand(threes2);
            IPokerHand hand3 = new PokerHand(notThrees);

            Assert.AreEqual(PokerHandType.Threes, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Threes, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Threes, hand3.GetHandType());
        }

        [TestMethod]
        public void Fours_Hand()
        {
            PlayingCard[] fours1 =
            {
                new PlayingCard(0, 5),
                new PlayingCard(2, 5),
                new PlayingCard(3, 5),
                new PlayingCard(2, 5),
                new PlayingCard(3, 4)
            };
            PlayingCard[] fours2 =
            {
                new PlayingCard(3, 4),
                new PlayingCard(1, 11),
                new PlayingCard(2, 4),
                new PlayingCard(1, 4),
                new PlayingCard(2, 4)
            };
            PlayingCard[] notFours =
            {
                new PlayingCard(3, 2),
                new PlayingCard(1, 3),
                new PlayingCard(2, 10),
                new PlayingCard(1, 3),
                new PlayingCard(2, 3)
            };

            IPokerHand hand1 = new PokerHand(fours1);
            IPokerHand hand2 = new PokerHand(fours2);
            IPokerHand hand3 = new PokerHand(notFours);

            Assert.AreEqual(PokerHandType.Fours, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Fours, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Fours, hand3.GetHandType());
        }

        [TestMethod]
        public void Full_House_Hand()
        {
            PlayingCard[] fh1 =
            {
                new PlayingCard(0, 5),
                new PlayingCard(2, 5),
                new PlayingCard(3, 4),
                new PlayingCard(2, 5),
                new PlayingCard(3, 4)
            };
            PlayingCard[] fh2 =
            {
                new PlayingCard(3, 4),
                new PlayingCard(1, 4),
                new PlayingCard(2, 4),
                new PlayingCard(1, 11),
                new PlayingCard(2, 11)
            };
            PlayingCard[] notFH =
            {
                new PlayingCard(3, 2),
                new PlayingCard(1, 3),
                new PlayingCard(2, 10),
                new PlayingCard(1, 3),
                new PlayingCard(2, 3)
            };

            IPokerHand hand1 = new PokerHand(fh1);
            IPokerHand hand2 = new PokerHand(fh2);
            IPokerHand hand3 = new PokerHand(notFH);

            Assert.AreEqual(PokerHandType.FullHouse, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.FullHouse, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.FullHouse, hand3.GetHandType());
        }

        [TestMethod]
        public void Flush_Hand()
        {
            PlayingCard[] flush1 =
            {
                new PlayingCard(1, 7),
                new PlayingCard(1, 2),
                new PlayingCard(1, 4),
                new PlayingCard(1, 5),
                new PlayingCard(1, 1)
            };
            PlayingCard[] flush2 =
            {
                new PlayingCard(3, 1),
                new PlayingCard(3, 4),
                new PlayingCard(3, 2),
                new PlayingCard(3, 10),
                new PlayingCard(3, 12)
            };
            PlayingCard[] notFlush1 =
            {
                new PlayingCard(2, 2),
                new PlayingCard(2, 3),
                new PlayingCard(2, 4),
                new PlayingCard(2, 5),
                new PlayingCard(2, 6)
            };
            PlayingCard[] notFlush2 =
            {
                new PlayingCard(2, 2),
                new PlayingCard(1, 6),
                new PlayingCard(2, 1),
                new PlayingCard(2, 3),
                new PlayingCard(2, 11)
            };


            IPokerHand hand1 = new PokerHand(flush1);
            IPokerHand hand2 = new PokerHand(flush2);
            IPokerHand hand3 = new PokerHand(notFlush1);
            IPokerHand hand4 = new PokerHand(notFlush2);

            Assert.AreEqual(PokerHandType.Flush, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Flush, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Flush, hand3.GetHandType());
            Assert.AreNotEqual(PokerHandType.Flush, hand4.GetHandType());
        }

        [TestMethod]
        public void Straight_Hand()
        {
            PlayingCard[] straight1 =
            {
                new PlayingCard(0, 6),
                new PlayingCard(2, 7),
                new PlayingCard(3, 8),
                new PlayingCard(2, 9),
                new PlayingCard(3, 10)
            };
            PlayingCard[] straight2 =
            {
                new PlayingCard(3, 6),
                new PlayingCard(1, 3),
                new PlayingCard(2, 5),
                new PlayingCard(1, 4),
                new PlayingCard(2, 2)
            };
            PlayingCard[] notStraight =
            {
                new PlayingCard(0, 13),
                new PlayingCard(0, 10),
                new PlayingCard(0, 1),
                new PlayingCard(0, 12),
                new PlayingCard(0, 11)
            };

            IPokerHand hand1 = new PokerHand(straight1);
            IPokerHand hand2 = new PokerHand(straight2);
            IPokerHand hand3 = new PokerHand(notStraight);

            Assert.AreEqual(PokerHandType.Straight, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Straight, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.Straight, hand3.GetHandType());
        }

        [TestMethod]
        public void Straight_Flush_Hand()
        {
            PlayingCard[] straightF1 =
            {
                new PlayingCard(0, 6),
                new PlayingCard(0, 7),
                new PlayingCard(0, 8),
                new PlayingCard(0, 9),
                new PlayingCard(0, 10)
            };
            PlayingCard[] straightF2 =
            {
                new PlayingCard(3, 6),
                new PlayingCard(3, 3),
                new PlayingCard(3, 5),
                new PlayingCard(3, 4),
                new PlayingCard(3, 2)
            };
            PlayingCard[] notStraightF =
            {
                new PlayingCard(0, 13),
                new PlayingCard(0, 10),
                new PlayingCard(0, 1),
                new PlayingCard(0, 12),
                new PlayingCard(0, 11)
            };

            IPokerHand hand1 = new PokerHand(straightF1);
            IPokerHand hand2 = new PokerHand(straightF2);
            IPokerHand hand3 = new PokerHand(notStraightF);

            Assert.AreEqual(PokerHandType.StraightFlush, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.StraightFlush, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.StraightFlush, hand3.GetHandType());
        }

        [TestMethod]
        public void Royal_Flush_Hand()
        {
            PlayingCard[] royalFlush1 =
            {
                new PlayingCard(1, 1),
                new PlayingCard(1, 10),
                new PlayingCard(1, 11),
                new PlayingCard(1, 12),
                new PlayingCard(1, 13)
            };
            PlayingCard[] royalFlush2 =
            {
                new PlayingCard(3, 10),
                new PlayingCard(3, 12),
                new PlayingCard(3, 1),
                new PlayingCard(3, 11),
                new PlayingCard(3, 13)
            };
            PlayingCard[] notRoyalFlush1 =
            {
                new PlayingCard(2, 9),
                new PlayingCard(2, 10),
                new PlayingCard(2, 11),
                new PlayingCard(2, 12),
                new PlayingCard(2, 13)
            };
            PlayingCard[] notRoyalFlush2 =
            {
                new PlayingCard(3, 10),
                new PlayingCard(1, 12),
                new PlayingCard(3, 1),
                new PlayingCard(3, 11),
                new PlayingCard(3, 13)
            };


            IPokerHand hand1 = new PokerHand(royalFlush1);
            IPokerHand hand2 = new PokerHand(royalFlush2);
            IPokerHand hand3 = new PokerHand(notRoyalFlush1);
            IPokerHand hand4 = new PokerHand(notRoyalFlush2);

            Assert.AreEqual(PokerHandType.RoyalFlush, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.RoyalFlush, hand2.GetHandType());
            Assert.AreNotEqual(PokerHandType.RoyalFlush, hand3.GetHandType());
            Assert.AreNotEqual(PokerHandType.RoyalFlush, hand4.GetHandType());
        }
    }
}
