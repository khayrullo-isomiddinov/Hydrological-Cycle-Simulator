using System;
using System.Text;

namespace Final
{
    public class Plain : Areas
    {
        public Plain(Owner owner, char type, int waterStored) : base(owner, type, waterStored) { }
        public override Areas Respond(Humidity h, ref double humidity)
        {
            if (h.Rainy())
            {
                ModifyWaterAmount(20);
            }

            if (h.Sunny())
            {
                ModifyWaterAmount(-3);
            }

            if (h.Cloudy())
            {
                ModifyWaterAmount(-1);
            }
            if (waterStored > 15)
            {
                if (h.Rainy()) { humidity = 5; }
                return new Grass(owner, 'G', waterStored);
            }
            if (waterStored < 0) { waterStored = 0; }
            if (h.Rainy()) { humidity = 5; }
            return this;
        }
    }

}
