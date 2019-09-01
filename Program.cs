using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonSerialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = @"";

            // Deserializing
            if (File.Exists(path))
            {
                using(var reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();

                    // NewtonSoft json
                    Parking parking = JsonConvert.DeserializeObject<Parking>(json);

                    // javascriptSerializer
                    //JavascriptSerializer serializer = new JavascriptSerializer();
                    //var parking = serializer.Deserialize<Parking>(json);

                    Console.WriteLine(parking.Address); 
                }
            }

            // Serializing
            Parking parkingOne = new Parking()
            {
                Id = 1,
                Address = "324 East 7th St, brooklyn",
                Cars = new List<Car>
                    {
                        new Car()
                        {
                            Id = 1,
                            Make = "BMW",
                            Model = "X5",
                            Owner = new Owner
                            {
                                FirstName = "Obed",
                                LastName = "Garcia"
                            },
                            DateOfBuy = new DateTime(2020, 6, 18)
                        }
                    }
            };

            // NewtonSoft json
            string jsonSerialized = JsonConvert.SerializeObject(parkingOne, Formatting.Indented);
            Console.WriteLine(jsonSerialized);

            // javascriptSerializer
            //JavascriptSerializer serializer = new JavascriptSerializer();
            //var jsonSerialized = serializer.Serialize(parkingOne);
        }
    }
}

public class Parking
{
    public int Id { get; set; }

    public string Address { get; set; }

    public List<Car> Cars { get; set; }
}

public class Car
{
    public int Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public Owner Owner { get; set; }

    public DateTime DateOfBuy { get; set; }
}

public class Owner
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}
