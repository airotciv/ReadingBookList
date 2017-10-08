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

        /// <summary>
        /// GET: Books - Provides the loggedin user to get the collection of books.
        /// </summary>
        /// <returns>typeof(List<Book>)</Books></returns>
        public ActionResult Index()
        {
            var userIdQuery = db.Users.Where(u => u.Email == User.Identity.Name).Select(u => u.Id);         
            return View(db.Books.Where(b=>b.UserId == userIdQuery.FirstOrDefault()).ToList());
        }

        /// <summary>
        /// GET: Books/Details/5
        /// Used to get the details of the book for a given bookId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>typeof(Book)</returns>
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
        /// <returns>title-typeof(string)</returns>
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
        /// <returns>View(book)</returns>
        public ActionResult Create()
        {
            var model = new Book();
            return View(model);
        }

        /// <summary>
        /// POST: Books/Create
        /// Used to Create or add a book to the list
        /// </summary>
        /// <param name="book"></param>
        /// <returns>typeof(View(book))</returns>
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


        /// <summary>
        /// GET: Books/Edit/5
        /// Gets a book of a given id
        /// </summary>
        /// <param name="id">book Id</param>
        /// <returns>typeof(Book)</returns>
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

        /// <summary>
        /// POST: Books/Edit/5
        /// Updates a book
        /// </summary>
        /// <param name="book">Book to be updated</param>
        /// <returns>typeof(View(book))</returns>
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

        /// <summary>
        /// GET: Books/Delete/5
        /// Used to get the book to be deleted
        /// </summary>
        /// <param name="id">book Id to be deleted</param>
        /// <returns>typeof(View(book))</returns>
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

        /// <summary>
        /// POST: Books/Delete/5
        /// Delete a book for specified id
        /// </summary>
        /// <param name="id">Book Id to be deleted</param>
        /// <returns></returns>
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
        /// Used to dispose objects
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
