using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(Application.Services.ExpenseService expenseService) : ControllerBase
    {
        private readonly Application.Services.ExpenseService _expenseService = expenseService;


    }
}
