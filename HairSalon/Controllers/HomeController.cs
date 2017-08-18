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
		return View();
	}

	[HttpGet("/clients/{id}")]
	public ActionResult GetClient(int clientId)
	{
		return View();
	}

	[HttpGet("/stylists")]
	public ActionResult GetAllStylists()
	{
		return View();
	}

	[HttpGet("/stylists/{id}")]
	public ActionResult GetStylist(int stylistId)
	{
		return View();
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
		return View();
	}

	[HttpPost("/stylist/add")]
	public ActionResult AddStylist()
	{
		return View();
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
