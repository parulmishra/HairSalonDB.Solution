using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HairSalon.Models;

namespace HairSalon.Controllers
	{
	public class HomeController : Controller
	{
	[HttpGet("/")]
	public ActionResult Index()
	{
		return View();
	}

	[HttpGet("/clients")]
	public ActionResult GetAllClients()
	{
		return View(Client.GetAll());
	}

	[HttpGet("/clients/{id}")]
	public ActionResult GetClient(int id)
	{
		return View("ClientDetails", Client.Find(id));
	}

	[HttpGet("/stylists")]
	public ActionResult GetAllStylists()
	{
		return View(Stylist.GetAll());
	}

	[HttpGet("/stylists/{id}")]
	public ActionResult GetStylist(int id)
	{
		return View("StylistDetails", Stylist.Find(id));
	}

	[HttpGet("/clients/add")]
	public ActionResult AddClientForm()
	{
		return View(Stylist.GetAll());
	}

	[HttpGet("/stylists/add")]
	public ActionResult AddStylistForm()
	{
		return View();
	}

	[HttpPost("/clients/add")]
	public ActionResult AddClient()
	{
		string name = Request.Form["client-name"];
		string email = Request.Form["client-email"];
		string phone = Request.Form["client-phone"];
		int stylistid = int.Parse(Request.Form["stylistid"]);
		var client = new Client(name, email, phone, stylistid);
		client.Save();
		return View("GetAllClients", Client.GetAll());	
	}

	[HttpPost("/stylists/add")]
	public ActionResult AddStylist()
	{
		string name = Request.Form["stylist-name"];
		string expertise = Request.Form["expertise"];
		int experience = int.Parse(Request.Form["experience"]);
		int rate = int.Parse(Request.Form["rate"]);
		var stylist = new Stylist(name, expertise, experience, rate);
		stylist.Save();
		return View("GetAllStylists", Stylist.GetAll());
	}

	[HttpGet("/clients/update/{id}")]
	public ActionResult UpdateClientForm(int id)
	{
		var dict = new Dictionary<string, object>();
		dict.Add("client", Client.Find(id));
		dict.Add("stylists", Stylist.GetAll());
		return View(dict);
	}
	
	[HttpPost("/clients/update/{id}")]
	public ActionResult UpdateClient(int id)
	{
		string name = Request.Form["client-name"];
		string email = Request.Form["client-email"];
		string phone = Request.Form["client-phone"];
		int stylistid = int.Parse(Request.Form["stylistid"]);
		var client = new Client(name, email, phone, stylistid, id);
		client.Update();
		return View("GetAllClients", Client.GetAll());
	}

	[HttpGet("/clients/delete/{id}")]
	public ActionResult DeleteClient(int id)
	{
		Client.Delete(id);
		return View("GetAllClients", Client.GetAll());
	}

	[HttpGet("/stylists/delete/{id}")]
	public ActionResult DeleteStylist(int id)
	{
		Stylist.Delete(id);
		return View("GetAllStylists", Stylist.GetAll());
	}
	[HttpGet("/clients/delete")]
	public ActionResult DeleteClients()
	{
		Client.DeleteAll();
		return View("GetAllClients", Client.GetAll());
	}
	[HttpGet("/stylists/delete/")]
	public ActionResult DeleteStylists()
	{
		Stylist.DeleteAll();
		return View("GetAllStylists", Stylist.GetAll());
	}
  }
}
