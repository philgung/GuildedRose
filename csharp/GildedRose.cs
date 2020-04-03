using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const int MAX_QUALITY = 50;
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Aged Brie")
                {
                    IncrementQuality(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncrementQuality(item);

                    if (item.SellIn < 11)
                    {
                        IncrementQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncrementQuality(item);
                    }
                }
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                }
                else
                {
                    DecrementQuality(item);
                }

                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                }
                else
                {
                    DecrementSellIn(item);
                }

                if (item.SellIn < 0)
                {
                    if (item.Name == "Aged Brie")
                    {
                        IncrementQuality(item);
                    }
                    else
                    {
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            item.Quality = 0;
                        }
                        else if (item.Name == "Sulfuras, Hand of Ragnaros")
                        {
                            continue;
                        }
                        else
                        {
                            DecrementQuality(item);
                        }
                    }
                }
            }
        }

        private static void DecrementSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        private static void DecrementQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private static void IncrementQuality(Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality += 1;
            }
        }
    }
}
