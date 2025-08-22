using Application.DTOs;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(Application.Services.IExpenseService expenseService) : ControllerBase
    {
        private readonly Application.Services.IExpenseService _expenseService = expenseService;


        [HttpGet]
        public async Task<List<ExpenseDto>> GetAllExpensesAsync()
        {
            return await _expenseService.GetAllExpensesAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseAsync(CreateExpenseDto expenseEntity)
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
