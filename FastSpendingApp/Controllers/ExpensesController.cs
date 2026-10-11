using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastSpendingApp.Entity;
using FastSpendingApp.Data;
using FastSpendingApp.Contracts;
using FastSpendingApp.Dtos;

[Route("api")]
[ApiController]
public class ExpensesController(IExpenseService expenseService) : ControllerBase
{
    

    [HttpGet("statistics")]
    public async Task<ActionResult<StatisticsResponseDto>> GetStatistics()
    {
        var statistics = await expenseService.GetStatisticsAsync();
        return Ok(statistics);
    }

    [HttpGet("transactions")]
    public async Task<ActionResult<List<ExpenseResponseDto>>> GetExpense()
    {
        var transactions = await expenseService.GetTransactionsAsync();
        return Ok(transactions);
    }

    [HttpDelete("transactions/{id}")]
    public async Task<ActionResult> DeleteExpenseAsync(int id) {
        var expense = await expenseService.DeleteTransactionAsync(id);
        if (!expense) {
            return NotFound();
        }
        return NoContent();
    }

    
    [HttpPost("spending")]
    public async Task<ActionResult<AddExpenseResponseDto>> AddNewSpending(CreateExpenseDto ExpenseDto)
    {
        var created = await expenseService.AddSpendingAsync(ExpenseDto);
        var stats = await expenseService.GetStatisticsAsync();

        var response = new AddExpenseResponseDto {
            Id = created.Id,
            TotalSpending = stats.TotalSpending,
            DailySpending = stats.DailySpending,
            WeeklySpending = stats.WeeklySpending,
            MonthlySpending = stats.MonthlySpending,
            Summary = stats.Summary


        };

        return Ok(response);

    }

   
}
