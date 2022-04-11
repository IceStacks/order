using Bogus;
using System;

namespace WebApi.Models
{

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemCount { get; set; }
        public float TotalPrice { get; set; }
        public float PaidPrice { get; set; }
        public float DiscountedPrice { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime OrderDate { get; set; }
        public  Status Status { get; set; }
        public string Notes { get; set; }

        //public int[] ItemIds { get; set; }

        public static Faker<Order> FakeData { get; } =
    new Faker<Order>()
        .RuleFor(p => p.UserId, f => f.Random.Number(1, 50))
        .RuleFor(p => p.ItemCount, f => f.Random.Number(1, 50))
        .RuleFor(p => p.TotalPrice, f => f.Random.Float(10, 5000))
        .RuleFor(p => p.PaidPrice, f => f.Random.Float(10, 5000))
        .RuleFor(p => p.DiscountedPrice, f => f.Random.Float(10, 5000))
        .RuleFor(p => p.PaidDate, f => f.Date.Recent(1, DateTime.Now))
        .RuleFor(p => p.Status, f => f.PickRandom<Status>())
        .RuleFor(p => p.Notes, f => f.Lorem.Paragraph(4));
        //.RuleFor(p => p.ItemIds, f => f.Phone.PhoneNumber("(###)-###-####"));

    }
    public enum Status
    {
        Success,
        Failed
    }

}