using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final;

namespace TestProject1
{
    [TestClass]
    public class SimulationTest
    {
        [TestMethod]
        public void TestSimulation()
        {
            Owner owner1 = new Owner { title = "Mr", name = "Smith" };
            Owner owner2 = new Owner { title = "Mr", name = "Green" };
            Owner owner3 = new Owner { title = "Mr", name = "Harry" };
            Owner owner4 = new Owner { title = "Mrs", name = "James" };

            Areas area = new Plain(owner1, 'P', 23);
            Areas area2 = new Plain(owner2, 'P', 43);
            Areas area3 = new Lake(owner3, 'L', 37);
            Areas area4 = new Grass(owner4, 'G', 59);

            Humidity humidity = new Humidity(10);

            int initialWaterArea1 = area.waterStored;
            int initialWaterArea2 = area2.waterStored;
            int initialWaterArea3 = area3.waterStored;
            int initialWaterArea4 = area4.waterStored;

            char initialLandTypeArea1 = area.landType;
            char initialLandTypeArea2 = area2.landType;
            char initialLandTypeArea3 = area3.landType;
            char initialLandTypeArea4 = area4.landType;

            double newHumidity = 0;
            area = area.Respond(humidity, ref newHumidity);
            area2 = area2.Respond(humidity, ref newHumidity);
            area3 = area3.Respond(humidity, ref newHumidity);
            area4 = area4.Respond(humidity, ref newHumidity);
            
            int expectedWaterArea1 = initialWaterArea1 - 3;
            int expectedWaterArea2 = initialWaterArea2 - 3;
            int expectedWaterArea3 = initialWaterArea3 - 10; 
            int expectedWaterArea4 = initialWaterArea4 - 6;

            Assert.AreEqual(expectedWaterArea1, area.waterStored);
            Assert.AreEqual(expectedWaterArea2, area2.waterStored);
            Assert.AreEqual(expectedWaterArea3, area3.waterStored);
            Assert.AreEqual(expectedWaterArea4, area4.waterStored);

            // P P L G

            if (area.waterStored > 15)
            {
                Assert.AreEqual('G', area.landType);
            }
            else
            {
                Assert.AreEqual(initialLandTypeArea1, area.landType); 
            }

            if (area2.waterStored > 15)
            {
                Assert.AreEqual('G', area2.landType); 
            }
            else
            {
                Assert.AreEqual(initialLandTypeArea2, area2.landType);
            }

            if (area3.waterStored < 51)
            {
                Assert.AreEqual('G', area3.landType); 
            }
            else
            {
                Assert.AreEqual(initialLandTypeArea3, area3.landType); 
            }

            if (area4.waterStored < 16)
            {
                Assert.AreEqual('P', area4.landType); 
            }
            else if (area4.waterStored > 50)
            {
                Assert.AreEqual('L', area4.landType); 
            }
            else
            {
                Assert.AreEqual(initialLandTypeArea4, area4.landType);
            }
         }
    

        [TestMethod]
        public void TestRainyWeather()
        {
            Owner owner1 = new Owner { title = "Mr", name = "Smith" };
            Owner owner2 = new Owner { title = "Mr", name = "Green" };
            Owner owner3 = new Owner { title = "Mr", name = "Harry" };
            Owner owner4 = new Owner { title = "Mrs", name = "James" };

            Areas area = new Plain(owner1, 'P', 23);
            Areas area2 = new Plain(owner2, 'P', 43);
            Areas area3 = new Lake(owner3, 'L', 37);
            Areas area4 = new Grass(owner4, 'G', 59);

            double initialHumidity = 80; 

            double newHumidity = 0;
            area = area.Respond(new Humidity(initialHumidity), ref newHumidity);
            area2 = area2.Respond(new Humidity(initialHumidity), ref newHumidity);
            area3 = area3.Respond(new Humidity(initialHumidity), ref newHumidity);
            area4 = area4.Respond(new Humidity(initialHumidity), ref newHumidity);

            Assert.AreEqual(23 + 20, area.waterStored);
            Assert.AreEqual(43 + 20, area2.waterStored);
            Assert.AreEqual(37 + 20, area3.waterStored); 
            Assert.AreEqual(59 + 15, area4.waterStored); 
            Assert.AreEqual(10, newHumidity);
        }

        [TestMethod]
        public void TestCloudyWeather()
        {
            Owner owner1 = new Owner { title = "Mr", name = "Smith" };
            Owner owner2 = new Owner { title = "Mr", name = "Green" };
            Owner owner3 = new Owner { title = "Mr", name = "Harry" };
            Owner owner4 = new Owner { title = "Mrs", name = "James" };

            Humidity h = new Humidity(42);

            Areas area = new Plain(owner1, 'P', 23);
            Areas area2 = new Plain(owner2, 'P', 43);
            Areas area3 = new Lake(owner3, 'L', 37);
            Areas area4 = new Grass(owner4, 'G', 59);

            if (h.Cloudy())
            {
                double newHumidity = 0;
                area = area.Respond(h, ref newHumidity);
                area2 = area2.Respond(h, ref newHumidity);
                area3 = area3.Respond(h, ref newHumidity);
                area4 = area4.Respond(h, ref newHumidity);

                // Verify the changes in water stored for each area under cloudy weather
                Assert.AreEqual(23 - 1, area.waterStored);
                Assert.AreEqual(43 - 1, area2.waterStored);
                Assert.AreEqual(37 - 3, area3.waterStored);
                Assert.AreEqual(59 - 2, area4.waterStored);
            }
            else
            {
                // Test is not applicable if not cloudy weather
                Assert.Inconclusive("Test is not applicable for non-cloudy weather");
            }
        }

        [TestMethod]
        public void TestSunnyWeather()
        {
            Owner owner1 = new Owner { title = "Mr", name = "Smith" };
            Owner owner2 = new Owner { title = "Mr", name = "Green" };
            Owner owner3 = new Owner { title = "Mr", name = "Harry" };
            Owner owner4 = new Owner { title = "Mrs", name = "James" };

            Humidity h = new Humidity(24);

            Areas area = new Plain(owner1, 'P', 23);
            Areas area2 = new Plain(owner2, 'P', 43);
            Areas area3 = new Lake(owner3, 'L', 37);
            Areas area4 = new Grass(owner4, 'G', 59);

            if (h.Sunny())
            {
                double newHumidity = 0;
                area = area.Respond(h, ref newHumidity);
                area2 = area2.Respond(h, ref newHumidity);
                area3 = area3.Respond(h, ref newHumidity);
                area4 = area4.Respond(h, ref newHumidity);

                // Verify the changes in water stored for each area under cloudy weather
                Assert.AreEqual(23 - 3, area.waterStored);
                Assert.AreEqual(43 - 3, area2.waterStored);
                Assert.AreEqual(37 - 10, area3.waterStored);
                Assert.AreEqual(59 - 6, area4.waterStored);
            }
            else
            {
                // Test is not applicable if not cloudy weather
                Assert.Inconclusive("Test is not applicable for non-cloudy weather");
            }
        }
    }
}
