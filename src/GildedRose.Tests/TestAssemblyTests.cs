using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {

        [Fact]
        public void RunAllTestCasesForSingleIterationCheck()
        {

            Program app = new Program();
            app.Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                              new Item {Name = "Conjured", SellIn = 10, Quality = 10},
                                              new Item {Name = "Aged Brie", SellIn = 10, Quality = 10}

                                          };

            app.UpdateQuality();


            /* 
             *   Check Quality
             */
            Assert.Equal((double)19, (double)app.Items[0].Quality, 0);
            Assert.Equal((double)6, (double)app.Items[1].Quality, 0);
            Assert.Equal((double)80, (double)app.Items[2].Quality, 0);

            //Backstage passes to a TAFKAL80ETC concert
            Assert.Equal((double)21, (double)app.Items[3].Quality, 0);
            Assert.Equal((double)5, (double)app.Items[4].Quality, 0);

            // Conjured
            Assert.Equal((double)8, (double)app.Items[5].Quality, 0);

            //Aged Brie 
            Assert.Equal((double)12, (double)app.Items[6].Quality, 0);



            /* 
             *   Check SellIn
             */


            Assert.Equal((double)9, (double)app.Items[0].SellIn, 0);
            Assert.Equal((double)4, (double)app.Items[1].SellIn, 0);

            Assert.Equal((double)0, (double)app.Items[2].SellIn, 0);
            Assert.Equal((double)14, (double)app.Items[3].SellIn, 0);
            Assert.Equal((double)2, (double)app.Items[4].SellIn, 0);
            Assert.Equal((double)9, (double)app.Items[5].SellIn, 0);
            Assert.Equal((double)9, (double)app.Items[6].SellIn, 0);


        }


        [Fact]
        public void RunAllTestCasesForMultipleIterationCheck()
        {

            Program app = new Program();
            app.Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                                              new Item {Name = "Conjured", SellIn = 10, Quality = 10},
                                              new Item {Name = "Aged Brie", SellIn = 10, Quality = 10}

                                          };

            

            for (int i = 0; i < 100; i++)
                app.UpdateQuality();

            // Check for the Quality of an item is never more than 50 and not less than 0 
            //Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
            foreach (Item item  in app.Items)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                    Assert.InRange((double)item.Quality, 0, 50);
                else
                    //"Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
                    Assert.Equal((double)80, (double) item.Quality, 0);
            }

        }


    }



}
