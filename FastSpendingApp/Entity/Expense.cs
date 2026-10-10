namespace FastSpendingApp.Entity {
    public class Expense {
        public int Id { get; set; }

        public string Category { get; set; } = string.Empty;

        public int Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string? Comment { get; set; }

        public int MyProperty { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
