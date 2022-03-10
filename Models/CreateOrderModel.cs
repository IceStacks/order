using System;

namespace WebApi.Models
{
    public class CreateOrderModel
    {
        public int UserId { get; set; }
       
       public int[] ItemIds { get; set; }
    }
}

