using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BirdingJournal.Models;
// using BirdingJournal.Managers;

namespace BirdingJournal.Controllers;

public class HomeController : Controller
{
    // public BirdingManager? birdingManager;

    public ViewResult NewBird() {
    return View("NewBird"); 
  }
   public ViewResult Index() {
    // ViewResult viewResult= birdingManager.getLifeList();
    return View("LifeList"); 
  }
}
