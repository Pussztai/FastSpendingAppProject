namespace FastSpendingApp.Dtos {
    public class StatisticsResponseDto {
        public decimal TotalSpending { get; set; }

        public decimal DailySpending { get; set; }

        public decimal WeeklySpending { get; set; }

        public decimal MonthlySpending { get; set; }

        public List<CategorySummaryDto> Summary { get; set; } = new();
    }
}
