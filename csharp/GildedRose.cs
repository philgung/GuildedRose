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
                item.UpdateQuality();

                item.UpdateSellIn();
            }
        }


    }

    public class DefaultItem : Item
    {
        private const int MAX_QUALITY = 50;

        protected void DecrementSellIn()
        {
            this.SellIn -= 1;
        }

        protected void DecrementQuality()
        {
            if (this.Quality > 0)
            {
                this.Quality -= 1;
            }
        }

        protected void IncrementQuality()
        {
            if (this.Quality < MAX_QUALITY)
            {
                this.Quality += 1;
            }
        }

        protected bool IsExpired()
        {
            return this.SellIn <= 0;
        }

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

}
