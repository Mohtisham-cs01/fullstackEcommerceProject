using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WatchSpace.Models
{

    public enum OrderStatus
    {
        Pending,
        Processing,
        OnTheWay,
        Delivered
    }


    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
        
        [ForeignKey("Product")]
        public Nullable<int> ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Nullable<int> PurchasedQuantity { get; set; }

        public Nullable<int> Price { get; set; }

        public Nullable<int> TotalBill { get; set; }

        public Nullable<DateTime> Date { get; set; }

        public string RefrenceNumber { get; set; }

        public Nullable<int> Original_Price { get; set; }
        public Nullable<int>  Sale_Price { get; set; }

        public OrderStatus Status { get; set; }

        }
}
