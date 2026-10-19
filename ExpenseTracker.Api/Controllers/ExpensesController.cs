using ExpenseTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;
namespace ExpenseTracker.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private static readonly List<Expense> _expenses = new()
    {
        new Expense { Id =1,Title="ahmed",Amount=85.6 , Category = "eat food " , Date = DateTime.Now},
        new Expense { Id =3,Title="mahmoud",Amount=70 , Category = "eat not food " , Date = DateTime.Now}
    };
    [HttpGet]
    public ActionResult<List<Expense>> GetAll()
    {
        return Ok(_expenses);
    }
    [HttpPost]
    public ActionResult<Expense> Add(Expense expense)
    {
        expense.Id = _expenses.Count == 0 ? 1 : _expenses.Max(e => e.Id) + 1;
        _expenses.Add(expense);
        return Ok(expense);
    }
}