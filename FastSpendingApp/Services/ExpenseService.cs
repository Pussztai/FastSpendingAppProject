using FastSpendingApp.Data;
using FastSpendingApp.Dtos;
using FastSpendingApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FastSpendingApp.Services {
    public class ExpenseService(FastSpendingDbContext context) {
        public async Task<ExpenseResponseDto> AddSpendingAsync(CreateExpenseDto request) {
            var NewExpense = new Expense {
                Category = request.Category,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            await context.AddAsync(NewExpense);
            await context.SaveChangesAsync();
            return new ExpenseResponseDto {
                Id = NewExpense.Id,
                Category = NewExpense.Category,
                Amount = NewExpense.Amount,
                PaymentMethod = NewExpense.PaymentMethod,
                Comment = NewExpense.Comment,
                CreatedAt = NewExpense.CreatedAt
            };

        }

        public async Task<List<ExpenseResponseDto>> GetTransactionsAsync() {
            return await context.Expenses
                .OrderByDescending(e => e.CreatedAt)
                .Select(e => new ExpenseResponseDto {
                    Id = e.Id,
                    Category = e.Category,
                    Amount = e.Amount,
                    PaymentMethod = e.PaymentMethod,
                    Comment = e.Comment,
                    CreatedAt = e.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<bool> DeleteTransactionAsync(int id) {
            var expense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if(expense == null) {
                return false;
            }
            context.Expenses.Remove(expense);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<StatisticsResponseDto> GetStatisticsAsync() {
            var expenses = await context.Expenses.ToListAsync();
            return CalculateStatistics(expenses, DateTime.UtcNow);
        }

        public static StatisticsResponseDto CalculateStatistics(List<Expense> t, DateTime time) {
            int TotalSpending = t.Sum(e => e.Amount);
            int DailySpending = t.Where(t => t.CreatedAt.Day == time.Day).Sum(e => e.Amount);
            int WeeklySpending = t.Where(t => t.CreatedAt >= time.Date.AddDays(-6)).Sum(e => e.Amount);
            int MonthlySpending = t.Where(t => t.CreatedAt.Year == time.Year && t.CreatedAt.Month == time.Month).Sum(e => e.Amount);
            private static readonly string[] AllCategories =
                {
                    "Vásárlás", "Ajándékok", "Étel", "Auto",
                    "Cigi/Vape", "Egészség", "Szórakozás", "Bármi más"
                };
        //List<CategorySummaryDto> Summary = AllCa
        //}

    }
}
