using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public int Orig_Price { get; set; }

        public int Display_Price { get; set; }


        [ForeignKey("Company")]

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
