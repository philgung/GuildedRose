using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (item.Name == "Aged Brie")
                {
                    item.IncrementQuality();
                    item.DecrementSellIn();
                    if (item.IsExpired())
                    {
                        item.IncrementQuality();
                    }

                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.IncrementQuality();

                    if (item.SellIn < 11)
                    {
                        item.IncrementQuality();
                    }

                    if (item.SellIn < 6)
                    {
                        item.IncrementQuality();
                    }
                    item.DecrementSellIn();
                    if (item.IsExpired())
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    item.DecrementQuality();
                    item.DecrementSellIn();
                    if (item.IsExpired())
                    {
                        item.DecrementQuality();
                    }
                }
            }
        }


    }
    public static class ItemExtension
    {
        private const int MAX_QUALITY = 50;

        public static void DecrementSellIn(this Item item)
        {
            item.SellIn -= 1;
        }

        public static void DecrementQuality(this Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        public static void IncrementQuality(this Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality += 1;
            }
        }

        public static bool IsExpired(this Item item)
        {
            return item.SellIn < 0;
        }
    }
}
