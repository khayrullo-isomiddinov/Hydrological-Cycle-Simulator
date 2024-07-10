using System;
using System.Text;

namespace Final
{
    public class Humidity
    {
        public double h;
        public Humidity(double h) { this.h = h; }
        
        public override string ToString()
        {
            return h.ToString() + "%";
        }
        public bool Sunny()
        {
            return h < 40;
        }

        public bool Cloudy()
        {
            return (h >= 40 && h < 70) && ((h - 30) * 3.3) <= 50;
        }
        public bool Rainy()
        {
            return h >= 70 || (h >= 40 && h < 70) && ((h - 30) * 3.3) > 50;
        }
    }
}
