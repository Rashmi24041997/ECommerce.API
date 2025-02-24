using System;
using System.ComponentModel.DataAnnotations;

namespace Products.DAL.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductID{get;set;}//(GUID, primary key)

        public string ProductName{get;set;}//(string)
        
        public string Category{get;set;}//(string)
        
        public double? UnitPrice{get;set;}//(double, nullable)
        
        public int? QuantityInStock{get;set;}//(int, nullable)

    }
}
