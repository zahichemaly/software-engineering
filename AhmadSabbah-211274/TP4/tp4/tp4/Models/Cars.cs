using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tp4.CustomAttributes; 

namespace tp4.Models
{
    public class Cars
    {
        public Cars()
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

        internal static void InsertOne(Cars car)
        {
            throw new NotImplementedException();
        }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

    }
}
