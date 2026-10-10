namespace FastSpendingApp.Dtos {
    public class ExpenseResponseDto {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
