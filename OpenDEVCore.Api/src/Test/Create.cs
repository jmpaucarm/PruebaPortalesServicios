using Core.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Test
{
    /// <summary>
    /// 
    /// </summary>
    [MessageNamespace("products")]
    public class CreateProduct : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// 
        /// </summary>
        public string Vendor { get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="vendor"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        [JsonConstructor]
        public CreateProduct(Guid id, string name,
            string description, string vendor,
            decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Vendor = vendor;
            Price = price;
            Quantity = quantity;
        }
    }
}
