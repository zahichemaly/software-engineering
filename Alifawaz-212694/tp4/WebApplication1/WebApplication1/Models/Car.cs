﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using WebApplication1.CustomAttributes;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Brand")]
        [Required]
        public string Brand { get; set; }
        [BsonElement("Model")]
        [Required]
        public string Model { get; set; }
        [BsonElement("Year")]
        [Required]
        [YearRange]
        public int Year { get; set; }
        [BsonElement("Price")]
        [Display(Name = "Price($)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }
        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }
    }
}

