﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Online_Store.Models
{
    public partial class Shop
    {
        public Shop()
        {
            AvailableProducts = new HashSet<AvailableProduct>();
        }

        public int IdShop { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AvailableProduct> AvailableProducts { get; set; }
    }
}