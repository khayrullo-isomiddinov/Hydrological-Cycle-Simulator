using System;
using System.Text;

namespace Final
{
    public class Lake : Areas
    {
        public Lake(Owner owner, char type, int waterStored) : base(owner, type, waterStored) { }
        
        public override Areas Respond(Humidity h, ref double humidity)
        {
            if(h.Rainy())
            {
                ModifyWaterAmount(20);
            }

            if (h.Sunny())
            {
                ModifyWaterAmount(-10);
            }

            if(h.Cloudy())
            {
                ModifyWaterAmount(-3);
            }
            if (waterStored < 51)
            {
                if (h.Rainy()) { humidity = 15; }
                return new Grass(owner, 'G', waterStored); 
            }
            if (waterStored < 0) { waterStored = 0; }
            if (h.Rainy()) { humidity = 15; }
            return this;
        }
    }
}
