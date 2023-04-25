using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BirdingJournal.Models;
using BirdingJournal.DAL;
using BirdingJournal.Models.ViewModels;

namespace BirdingJournal.Controllers {

  public class HomeController : Controller
  {
    public int PageSize = 8;

    private BirdingJournalDbContext db;
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

    [HttpPost]
    public ViewResult NewBirdPost(BirdSighting birdSighting) {
      System.Diagnostics.Debug.WriteLine("Entered Method NewBirdPost");

      repo.InsertBirdSighting(birdSighting);
      return View("Thanks", birdSighting);
    }
  }
}