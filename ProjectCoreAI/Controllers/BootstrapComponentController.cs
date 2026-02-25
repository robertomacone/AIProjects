using Microsoft.AspNetCore.Mvc;
using ProjectCoreAI.Models.ViewModels;

namespace ProjectCoreAI.Controllers;

public class BootstrapComponentController : Controller
{
    public IActionResult Paginazione()
    {
        var demoRows = Enumerable.Range(1, 120)
            .Select(i => new ProductTableRowViewModel
            {
                Id = i,
                Name = $"Prodotto {i}",
                Category = i % 2 == 0 ? "Hardware" : "Software",
                Price = Math.Round(10 + (decimal)(i * 1.37), 2),
                CreatedAt = DateTime.Today.AddDays(-i)
            })
            .ToList();

        return View(demoRows);
    }
}
