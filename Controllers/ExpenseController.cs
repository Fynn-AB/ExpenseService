using Application.DTOs;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(Application.Services.ExpenseService expenseService) : ControllerBase
    {
        private readonly Application.Services.ExpenseService _expenseService = expenseService;


        [HttpGet]
        public async Task<List<ExpenseDto>> GetAllExpensesAsync()
        {
            return await _expenseService.GetAllExpensesAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync(ExpenseEntity expenseEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdExpense = await _expenseService.CreateNewExpenseAsync(expenseEntity);
            return Ok(createdExpense);
        }
    }
}
