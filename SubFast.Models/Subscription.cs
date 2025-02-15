namespace SubFast.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int CustomerId { get; set; }
        public string SubscriptionChannel { get; set; } = "";
        public string SubscriptionFee { get; set; } = "";
        public DateTime SubscritionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}