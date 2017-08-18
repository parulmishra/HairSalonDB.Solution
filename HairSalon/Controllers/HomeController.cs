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
	public ActionResult GetClient(int clientId)
	{
		return View(Client.Find(clientId));
	}

	[HttpGet("/stylists")]
	public ActionResult GetAllStylists()
	{
		return View(Stylist.GetAll());
	}

	[HttpGet("/stylists/{id}")]
	public ActionResult GetStylist(int stylistId)
	{
		return View(Stylist.Find(stylistId));
	}

	[HttpGet("/clients/add")]
	public ActionResult AddClientForm()
	{
		return View();
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
		string email = Request.Form["email"];
		string phone = Request.Form["phone"];
		string stylistid = Request.Form["stylistid"];
		var client = new Client(name, email, phone, stylistid);
		client.Save();
		return View("GetAllClients", Client.GetAll());	
	}

	[HttpPost("/stylist/add")]
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

	[HttpPut("/client/update")]
	public ActionResult UpdateClient()
	{
		return View();
	}

	[HttpGet("/clients/delete/{id}")]
	public ActionResult DeleteClient(int clientId)
	{
		return View();
	}

	[HttpGet("/stylists/delete/{id}")]
	public ActionResult DeleteStylist(int stylistId)
	{
		return View();
	}
  }
}
