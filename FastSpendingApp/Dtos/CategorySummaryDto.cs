namespace FastSpendingApp.Dtos {
    public class CategorySummaryDto {
        public string Category { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public decimal Percentage { get; set; }
    }
}
