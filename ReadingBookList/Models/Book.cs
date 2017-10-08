using ReadingBookList.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace ReadingBookList.Models
{
    /// <summary>
    /// This class is used for creating a Book object
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The Id Property represents the Book's Id
        /// </summary>
        /// <value>The Id property gets/sets the value of the int field</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The ISBN Property represents the Book's ISBN
        /// </summary>
        /// <value>The ISBN property gets/sets the value of the string field</value> 
        [ValidateISBN(ErrorMessage = "Invalid ISBN Format")]

        /// <summary>
        /// The ISBN Property represents the Book's ISBN
        /// </summary>
        /// <value>The ISBN property gets/sets the value of the string field</value>
        public string ISBN { get; set; }

        /// <summary>
        /// The Title Property represents the Book's Title/Name
        /// </summary>
        /// <value>The Title property gets/sets the value of the string field</value>
        public string Title { get; set; }

        /// <summary>
        /// The Mark Property represents the Book's Mark (true  if it's read, otherwise it's set to false)
        /// by the default it is set to false
        /// </summary>
        /// <value>The Mark property gets/sets the value of the boolean field</value>
        public bool Mark { get; set; }

        /// <summary>
        /// The AddedDate Property represents the DateTime when the book was added.
        /// </summary>
        /// <value>The Added property gets/sets the value of the DateTime field</value>
        public DateTime? AddedDate { get; set; }

        /// <summary>
        /// The ModifiedDate Property represents the DateTime when the book was last modified
        /// </summary>
        /// <value>The ModifiedDate property gets/sets the value of the DateTime field</value>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// The UserId Property represents the Id of the User owner of the book
        /// </summary>
        /// <value>The UserId property gets/sets the value of the string field</value>
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        /// <summary>
        /// The ApplicationUser Property represents the ApplicationUser of the Book
        /// </summary>
        /// <value>The ApplicationUser property gets/sets the value of the ApplicationUser field</value>
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
    
}