namespace FastSpendingApp.Dtos {
    public class CategorySummaryDto {
        public string Category { get; set; } = string.Empty;

        public int Total { get; set; }

        public double Percentage { get; set; }
    }
}
