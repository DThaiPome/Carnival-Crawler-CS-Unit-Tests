using System;
using CarnivalCrawler.Weapons.FivesPoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarnivalCrawlerTests.Weapons.FivesPoker
{
    [TestClass]
    public class FivesPokerModelTests
    {
        private IFivesPokerModel model1;
        //One joker on draw
        private IFivesPokerModel model2;
        //Two jokers on draw
        private IFivesPokerModel model3;
        //One joker on exchange
        private IFivesPokerModel model4;

        [TestInitialize]
        public void Init_Model()
        {
            this.model1 = new FivesPokerModel(new Random(69));
            this.model2 = new FivesPokerModel(new Random(5));
            this.model3 = new FivesPokerModel(new Random(6));
            this.model4 = new FivesPokerModel(new Random(16));
        }

        [TestMethod]
        public void Initial_Model()
        {
            Assert.AreEqual(0, this.model1.GetJokersDrawn());
            try
            {
                this.model1.GetCurrentHand();
            } catch (InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Draw_Hand_Twice_Fails()
        {
            this.model1.DrawHand();
            try
            {
                this.model1.DrawHand();
            } catch(InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Draw_Hand_Fails_After_Exchange()
        {
            this.model1.DrawHand();
            this.model1.ExchangeCards(new bool[5]{ false, false, false, false, false});
            try
            {
                this.model1.DrawHand();
            } catch(InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Get_Current_Hand_Fails_Before_Draw()
        {
            try
            {
                this.model1.GetCurrentHand();
            } catch(InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Get_Current_Hand_After_Draw()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);
        }

        [TestMethod]
        public void Hand_Contains_No_Jokers_After_Draw()
        {
            this.model2.DrawHand();
            this.model3.DrawHand();

            PlayingCard[] cards1 = this.model2.GetCurrentHand();
            PlayingCard[] cards2 = this.model3.GetCurrentHand();

            int count = 0;
            foreach(PlayingCard card in cards1)
            {
                count++;
                Assert.AreNotEqual(card.suit, PlayingCard.Suit.Joker);
            }
            Assert.AreEqual(5, count);
            count = 0;
            foreach (PlayingCard card in cards2)
            {
                count++;
                Assert.AreNotEqual(card.suit, PlayingCard.Suit.Joker);
            }
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void Get_Jokers_No_Jokers()
        {
            this.model1.DrawHand();
            Assert.AreEqual(0, this.model1.GetJokersDrawn());
        }

        [TestMethod]
        public void Get_Jokers_One_Joker()
        {
            this.model2.DrawHand();
            Assert.AreEqual(1, this.model2.GetJokersDrawn());
        }

        [TestMethod]
        public void Get_Jokers_Two_Jokers()
        {
            this.model3.DrawHand();
            Assert.AreEqual(2, this.model3.GetJokersDrawn());
        }

        [TestMethod]
        public void Exchange_Resets_Jokers()
        {
            this.model2.DrawHand();
            Assert.AreEqual(1, this.model2.GetJokersDrawn());
            this.model2.ExchangeCards(new bool[5] { false, false, false, false, false });
            Assert.AreEqual(0, this.model2.GetJokersDrawn());
        }

        [TestMethod]
        public void Reset_Resets_Jokers()
        {
            this.model4.DrawHand();
            Assert.AreEqual(0, this.model4.GetJokersDrawn());
            this.model4.ExchangeCards(new bool[5] { true, true, true, true, true });
            Assert.AreEqual(1, this.model4.GetJokersDrawn());
            this.model4.ResetHand();
            Assert.AreEqual(0, this.model4.GetJokersDrawn());
        }

        [TestMethod]
        public void Exchange_One_Joker()
        {
            this.model4.DrawHand();
            this.model4.ExchangeCards(new bool[5] { true, true, true, true, true });
            Assert.AreEqual(1, this.model4.GetJokersDrawn());
        }

        [TestMethod]
        public void Exchange_Before_Draw_Fails()
        {
            try
            {
                this.model1.ExchangeCards(new bool[5] { false, true, false, true, false });
            } catch (InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Exchange_Twice_Fails()
        {
            this.model1.DrawHand();
            this.model1.ExchangeCards(new bool[5] { false, true, false, true, false });
            try
            {
                this.model1.ExchangeCards(new bool[5] { false, true, false, true, false });
            }
            catch (InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Exchange_No_Cards()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);

            this.model1.ExchangeCards(new bool[5] { false, false, false, false, false });
            cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);
        }

        [TestMethod]
        public void Exchange_One_Card()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);

            this.model1.ExchangeCards(new bool[5] { false, false, false, true, false });
            cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(3, 8), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);
        }

        [TestMethod]
        public void Exchange_Two_Cards()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);

            this.model1.ExchangeCards(new bool[5] { false, true, false, false, true });
            cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 8), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(3, 3), cards[4]);
        }

        [TestMethod]
        public void Exchange_All_Cards()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);

            this.model1.ExchangeCards(new bool[5] { true, true, true, true, true });
            cards = this.model1.GetCurrentHand();

            Assert.AreEqual(new PlayingCard(3, 8), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 3), cards[1]);
            Assert.AreEqual(new PlayingCard(0, 1), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 2), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 7), cards[4]);
        }

        [TestMethod]
        public void Final_Hand_Fails_Before_Draw()
        {
            try
            {
                this.model1.GetFinalHand();
            } catch(InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Final_Hand_Fails_Before_Exchange()
        {
            this.model1.DrawHand();
            try
            {
                this.model1.GetFinalHand();
            }
            catch (InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Get_Final_Hand_Pair()
        {
            this.model1.DrawHand();
            this.model1.ExchangeCards(new bool[5] {false, false, false, true, false});
            IPokerHand finalHand = this.model1.GetFinalHand();
            Assert.AreEqual(PokerHandType.Pair, finalHand.GetHandType());
            Assert.IsFalse(finalHand.IsCardInHand(0));
            Assert.IsFalse(finalHand.IsCardInHand(1));
            Assert.IsFalse(finalHand.IsCardInHand(2));
            Assert.IsTrue(finalHand.IsCardInHand(3));
            Assert.IsTrue(finalHand.IsCardInHand(4));
        }

        [TestMethod]
        public void Get_Final_Hand_Two_Pair()
        {
            this.model1.DrawHand();
            this.model1.ExchangeCards(new bool[5] { true, false, false, false, false });
            IPokerHand finalHand = this.model1.GetFinalHand();
            Assert.AreEqual(PokerHandType.TwoPair, finalHand.GetHandType());
            Assert.IsTrue(finalHand.IsCardInHand(0));
            Assert.IsFalse(finalHand.IsCardInHand(1));
            Assert.IsTrue(finalHand.IsCardInHand(2));
            Assert.IsTrue(finalHand.IsCardInHand(3));
            Assert.IsTrue(finalHand.IsCardInHand(4));
        }

        [TestMethod]
        public void No_Hand_After_Reset()
        {
            this.model1.DrawHand();
            PlayingCard[] cards = this.model1.GetCurrentHand();
            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);

            this.model1.ResetHand();
            try
            {
                cards = this.model1.GetCurrentHand();
            } catch(InvalidOperationException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Two_Rounds()
        {
            PlayingCard[] cards;
            this.model1.DrawHand();
            cards = this.model1.GetCurrentHand();
            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(0, 5), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);
            this.model1.ExchangeCards(new bool[5] { false, false, false, true, false });
            cards = this.model1.GetCurrentHand();
            Assert.AreEqual(new PlayingCard(1, 7), cards[0]);
            Assert.AreEqual(new PlayingCard(3, 6), cards[1]);
            Assert.AreEqual(new PlayingCard(3, 5), cards[2]);
            Assert.AreEqual(new PlayingCard(3, 8), cards[3]);
            Assert.AreEqual(new PlayingCard(2, 8), cards[4]);
            IPokerHand hand1 = this.model1.GetFinalHand();
            this.model1.ResetHand();
            this.model1.DrawHand();
            cards = this.model1.GetCurrentHand();
            Assert.AreEqual(new PlayingCard(3, 3), cards[0]);
            Assert.AreEqual(new PlayingCard(0, 1), cards[1]);
            Assert.AreEqual(new PlayingCard(2, 11), cards[2]);
            Assert.AreEqual(new PlayingCard(1, 9), cards[3]);
            Assert.AreEqual(new PlayingCard(1, 10), cards[4]);
            this.model1.ExchangeCards(new bool[5] { true, false, false, true, true });
            cards = this.model1.GetCurrentHand();
            Assert.AreEqual(new PlayingCard(1, 8), cards[0]);
            Assert.AreEqual(new PlayingCard(0, 1), cards[1]);
            Assert.AreEqual(new PlayingCard(2, 11), cards[2]);
            Assert.AreEqual(new PlayingCard(3, 4), cards[3]);
            Assert.AreEqual(new PlayingCard(0, 11), cards[4]);
            IPokerHand hand2 = this.model1.GetFinalHand();

            Assert.AreEqual(PokerHandType.Pair, hand1.GetHandType());
            Assert.AreEqual(PokerHandType.Pair, hand1.GetHandType());
        }
    }
}
