using System;
using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{
    public class Car {
        public Car(string make, string model, int year, int price, string description, string id)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            Description = description;
            Id = id;
        }

        [Required]
    [MinLength(3)]

    public string Make { get; set; }
    [MaxLength(30)]

    public string Model { get; set; }

    public int Year { get; set; }
    [Range(1908, 2021)]
    public int Price { get; set; }

    public string Description { get; set; }

    // public string imgUrl {get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();

    
    }
}