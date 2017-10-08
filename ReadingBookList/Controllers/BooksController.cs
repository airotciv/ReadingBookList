using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ReadingBookList.Models;
using System.Xml;
using ReadingBookList.Common;

namespace ReadingBookList.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            var userIdQuery = db.Users.Where(u => u.Email == User.Identity.Name).Select(u => u.Id);         
            return View(db.Books.Where(b=>b.UserId == userIdQuery.FirstOrDefault()).ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        /// <summary>
        /// SearchISBN - calls ISBN.SearchTitleByIsbn to get the Title of the given ISBN code.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public ActionResult SearchISBN(string isbn)
        {
            string title = "";
            if (isbn is null)
            {
                return Json(title, JsonRequestBehavior.AllowGet);
            }

             title = ISBN.SearchTitleByIsbn(isbn);
      
            return Json(title, JsonRequestBehavior.AllowGet);
        }

              
        /// <summary>
        /// GET - Create Book 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var model = new Book();
            return View(model);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ISBN,Title,Mark")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.ISBN = book.ISBN.Trim();           
                var userIdQuery = db.Users.Where(u => u.Email == User.Identity.Name).Select(u => u.Id);
                var userId = userIdQuery.FirstOrDefault();

                //Check if ISBN is already exist in book list
                if(db.Books.Where(b=> b.ISBN == book.ISBN && b.UserId == userId).Count() > 0 )
                {
                   // TempData["error"] = "Book with ISBN + " + book.ISBN + " already exists in your list.";
                    ModelState.AddModelError("", "Book with ISBN : " + book.ISBN + " already exists in your list.");
                    return View(book);
                   // return RedirectToAction("form_Post", "Form");
                }

                //Search for the title by ISBN through ISBNdb.com
                //This is just an alternative, for Search Button in CreateView
                string title = ISBN.SearchTitleByIsbn(book.ISBN);
                if (title != null)
                {
                    book.Title = title;
                }

                book.UserId = userId;
                book.AddedDate = DateTime.Now;
          
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {

                ModelState.AddModelError("", "Book with ISBN : " + book.ISBN + " already exists in your list.");
                return View(book);
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ISBN,Title,Mark")] Book book)
        {
            if (ModelState.IsValid)
            {
                var userIdQuery = db.Users.Where(u => u.Email == User.Identity.Name).Select(u => u.Id);
                var userId = userIdQuery.FirstOrDefault();
                book.ModifiedDate = DateTime.Now;
                book.UserId = userId;
                book.AddedDate = db.Books.Find(book.Id).AddedDate;
                db.Entry(book).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose objects
        /// </summary>
        /// <param name="disposing"></param>
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
