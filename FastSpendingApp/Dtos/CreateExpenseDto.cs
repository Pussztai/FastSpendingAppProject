namespace FastSpendingApp.Dtos {
    public class CreateExpenseDto {
        public string Category { get; set; } = string.Empty;

        public int Amount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string? Comment { get; set; }

    }
}
