﻿using AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class TesteController : Controller
    {

        //[HttpGet]
        //public string Index()
        //{
        //    return "Teste controller Index";
        //}

        //[HttpGet]
        //public string TesteTask()
        //{
        //    return "Teste controller";
        //}

        // GET: TesteController
        public ActionResult Index(string name, int age)
        {
            //https://localhost:44396/teste?name=Anildo&age=32
            TesteModel teste = new TesteModel();
            teste.Name = name;
            teste.Age = age;

            return View("TesteIndex", teste);
        }


        [HttpGet]
        public IActionResult UsarViewData(string name, int time)
        {
            ViewData["Name"] = "Olá " + name;
            ViewData["time"] = time;

            return View();
        }



        // GET: TesteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TesteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TesteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TesteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TesteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
