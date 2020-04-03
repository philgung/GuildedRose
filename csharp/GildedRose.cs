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
            foreach (DefaultItem item in Items)
            {
                item.UpdateQuality() ;

                item.UpdateSellIn();
            }
        }


    }

    public class DefaultItem : Item
    {
        public virtual void UpdateQuality()
        {
            this.DecrementQuality();

            if (this.IsExpired())
            {
                this.DecrementQuality();
            }
        }

        public virtual void UpdateSellIn()
        {
            this.DecrementSellIn();
        }
    }

    public class AgedBrie : DefaultItem
    {
        public override void UpdateQuality()
        {
            this.IncrementQuality();
            if (this.IsExpired())
            {
                this.IncrementQuality();
            }
        }
    }

    public class Backstage : DefaultItem
    {
        public override void UpdateQuality()
        {
            this.IncrementQuality();

            if (this.SellIn < 11)
            {
                this.IncrementQuality();
            }

            if (this.SellIn < 6)
            {
                this.IncrementQuality();
            }
            if (this.IsExpired())
            {
                this.Quality = 0;
            }
        }
        }


        public class Sulfuras : DefaultItem
        {
            public override void UpdateQuality() { }
            
            public override void UpdateSellIn()
            {
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
                return item.SellIn <= 0;
            }
        }
    }
