using System;
using System.Text;

namespace Final
{
    public class Grass : Areas
    {
        public Grass(Owner owner, char type, int waterStored) : base(owner, type, waterStored) { }
        public override Areas Respond(Humidity h,  ref double humidity)
        {
            if (h.Rainy())
            {
                ModifyWaterAmount(15);
            }
            
            if (h.Sunny())
            {
                ModifyWaterAmount(-6);
            }

            if (h.Cloudy())
            {
                ModifyWaterAmount(-2);
            }
            if (waterStored > 50)
            {
                if (h.Rainy()) { humidity = 10; }
                return new Lake(owner, 'L', waterStored);
            }
            if (waterStored < 16)
            {
                if (h.Rainy()) { humidity = 5; }
                return new Plain(owner, 'P', waterStored);
            }
            if (waterStored < 0) { waterStored = 0; }
            if (h.Rainy()) {  humidity = 10; }
            return this;
        }
        
    }
}

