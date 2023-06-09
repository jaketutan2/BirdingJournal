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

    [HttpGet("controller/getbirdsighting/{id}")]
    public IActionResult GetBirdSighting (long id) {
      return View("BirdSighting", repo.GetBirdSightingByID(id));
    }

    [HttpGet]
    public ViewResult NewBird() {
      return View("NewBird"); 
    }

    [HttpGet("controller/updatebirdsighting/{id}")]
    public ViewResult UpdateBirdSighting(long id) {
      return View("UpdateBirdSighting", repo.GetBirdSightingByID(id));
    }

    [HttpPost]
    [Route("controller/SubmitBirdSightingUpdate/{id}")]
    public IActionResult SubmitBirdSightingUpdate(int id, BirdSighting updatedBirdSighting)    {
        // Retrieve the existing entity from the database
        var existingEntity = repo.GetBirdSightingByID(id);

        if (existingEntity != null)
        {
            Console.WriteLine("Existing entity Found");
            // Update the properties of the existing entity
            existingEntity.BirdCommonName = updatedBirdSighting.BirdCommonName;
            existingEntity.SpottedDate = updatedBirdSighting.SpottedDate;
            existingEntity.Notes = updatedBirdSighting.Notes;
            existingEntity.Location = updatedBirdSighting.Location;        
           
            Console.WriteLine(existingEntity.Location);

            repo.Save();
            Console.WriteLine("Repo was saved");

            return View("BirdSighting", repo.GetBirdSightingByID(id));
        }

        // Handle the case when the entity does not exist
        return NotFound();
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

      Console.WriteLine("About to leave NewBirdPost method");
      return View("Thanks", birdSighting);
    }

    [HttpDelete]
    public ViewResult Delete(int id)
    {
        Console.WriteLine("Entering Delete method");
      repo.DeleteBirdSighting(id);

      Console.WriteLine("About to leave Delete method");
      return View("Index", db.BirdSightings.ToList());
    }
  }
}