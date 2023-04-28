using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BirdingJournal.Models;
using BirdingJournal.DAL;
using BirdingJournal.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BirdingJournal.Controllers {

  public class HomeController : Controller
  {
    public int PageSize = 8;

    private readonly BirdingJournalDbContext db;
    private BirdingJournalRepository repo;

    public HomeController(BirdingJournalDbContext db){
      this.db = db;
      this.repo = new BirdingJournalRepository(db);
    }

    public IActionResult Index() {
      return View(db.BirdSightings.ToList());
    }

    [HttpGet]
    public ViewResult NewBird() {
      return View("NewBird"); 
    }

    public async Task<IActionResult> SearchBird(string term)
    {
        Console.WriteLine("term" + term);
        var birds = await db.Birds
            .Where(b => b.BirdCommonName.Contains(term))
            .Select(b => b.BirdCommonName)
            .ToListAsync();

        return Json(birds);
    }

    [HttpPost]
    public ViewResult NewBirdPost(BirdSighting birdSighting) {
      System.Diagnostics.Debug.WriteLine("Entered Method NewBirdPost");

      repo.InsertBirdSighting(birdSighting);
      return View("Thanks", birdSighting);
    }
  }
}