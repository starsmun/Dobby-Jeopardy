using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dobby_Jeopardy.Data;
using Dobby_Jeopardy.models;

namespace Dobby_Jeopardy.Controllers
{
    public class GameBoardsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: GameBoards
        public ActionResult Index()
        {
            return View(db.GameBoards.ToList());
        }

        // GET: GameBoards/Board
        public ActionResult Board(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameBoards gameBoard = db.GameBoards.Find(id);
            if (gameBoard == null)
            {
                return HttpNotFound();
            }
            return View(gameBoard);
        }

        // GET: GameBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameBoards gameBoard = db.GameBoards.Find(id);
            if (gameBoard == null)
            {
                return HttpNotFound();
            }
            return View(gameBoard);
        }

        // GET: GameBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DefaultBoard")]GameBoards gameBoards)
        {
            gameBoards.fakedBoard = "";

            if (ModelState.IsValid)
            {
                try
                {
                    var fuck = gameBoards.DefaultBoard[0];
                    for (int i = 0; i < 6; i++)
                    {
                        gameBoards.fakedBoard += String.Join(";", gameBoards.DefaultBoard[i]) + "\n";


                    }
                }
                catch (Exception e)
                {

                }

                db.GameBoards.Add(gameBoards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameBoards);
        }

        // GET: GameBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameBoards gameBoards = db.GameBoards.Find(id);
            if (gameBoards == null)
            {
                return HttpNotFound();
            }
            return View(gameBoards);
        }

        // POST: GameBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] GameBoards gameBoards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameBoards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameBoards);
        }

        // GET: GameBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameBoards gameBoards = db.GameBoards.Find(id);
            if (gameBoards == null)
            {
                return HttpNotFound();
            }
            return View(gameBoards);
        }

        // POST: GameBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameBoards gameBoards = db.GameBoards.Find(id);
            db.GameBoards.Remove(gameBoards);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
