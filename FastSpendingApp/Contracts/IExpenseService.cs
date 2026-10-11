using FastSpendingApp.Dtos;
using FastSpendingApp.Entity;

namespace FastSpendingApp.Contracts {
    public interface IExpenseService {
        Task<ExpenseResponseDto> AddSpendingAsync(CreateExpenseDto request);
        Task<bool> DeleteTransactionAsync(int id);
        Task<StatisticsResponseDto> GetStatisticsAsync();
        Task<List<ExpenseResponseDto>> GetTransactionsAsync();
    }
}