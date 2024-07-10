using System;
using System.Text;

namespace Final
{
    public struct Owner
    {
        public string title;
        public string name;

        public override string ToString()
        {
            return title + " " + name;
        }
    }

    public abstract class Areas
    {
        protected Owner owner;
        public char landType;
        public int waterStored;
        public Humidity? humidity;
        public void ModifyWaterAmount(int e) { waterStored += e; }
        
        protected Areas(Owner owner, char landType, int waterStored)
        {
            this.owner = owner;
            this.landType = landType;
            this.waterStored = waterStored;
        }

        public abstract Areas Respond(Humidity humidity, ref double humid);
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(owner + " " + landType + " " + waterStored);
            return sb.ToString();
        }
    }
}
