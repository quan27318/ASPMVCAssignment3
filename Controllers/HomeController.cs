using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VewMVC.Interfaces;
using VewMVC.Models;

namespace VewMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ISender _sender;
    private IPeople _people;

    public HomeController(ILogger<HomeController> logger, IPeople people)
    {
        _logger = logger;
        _people = people;
        
    }

    public IActionResult Index()
    {
        Set("QuanDepTraiCookie", "this my first cookie", 10);
        HttpContext.Session.SetString("QuanSesson", "This Is My MVC Session");
        return View(_people.List());
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Test()
    {
        return Content(_sender.PrintToScreen());
    }
    public IActionResult SampleView()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        var sessionValue = HttpContext.Session.GetString("QuanSesson");
        var result = Get("QuanDepTraiCookie");
        ViewBag.QuanDepTrai = result;
        ViewBag.Quan = "Quan Dep Trai";
        ViewBag.Quanss = sessionValue;
        return View();
    }
    [HttpGet]
    public IActionResult Update(int id)
    {
        var person = _people.List().Where(x => x.Id == id).FirstOrDefault();
        return View(person);

    }
    [HttpPost]
    public IActionResult Update(PersonModel person)
    {
        _people.Update(person);
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int id)
    {
        var personDetail = _people.List().Where(x => x.Id == id).FirstOrDefault();
        return View(personDetail);
    }
    public IActionResult Delete(int id)
    {
        var person = _people.Delete(id);

        return RedirectToAction("Index");

    }

    [HttpPost]
    public IActionResult Create(PersonModel model)
    {
        _people.Create(model);
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    private void Set(string key, string value, int? expireTime)
    {
        CookieOptions options = new CookieOptions();
        if (expireTime.HasValue)
        {
            options.Expires = DateTime.Now.AddMinutes(expireTime.Value);

        }
        else
        {
            options.Expires = DateTime.Now.AddSeconds(30);

        }
        Response.Cookies.Append(key, value, options);
    }
    private string Get(string key)
    {
        return Request.Cookies[key];
    }
    private void Remove(string key)
    {
        Response.Cookies.Delete(key);
    }
}
