﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Online_Store.Models
{
    public partial class AvailableProduct
    {
        public int IdAvailableProduct { get; set; }
        public int IdShop { get; set; }
        public int IdProduct { get; set; }
        public int AvailableAmount { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Shop IdShopNavigation { get; set; }
    }
}