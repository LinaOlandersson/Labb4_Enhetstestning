using Labb4_Enhetstestning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class ReturnTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void ReturnBook_ReturningABook_BorrowDateIsNull()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);

            librarySystem.BorrowBook(book.ISBN);
            librarySystem.ReturnBook(book.ISBN);

            Assert.AreEqual(book.BorrowDate, null);
        }

        [TestMethod]
        public void ReturnBook_ReturningANotBorrowedBook_ReturnsFalse()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);

            bool result = librarySystem.ReturnBook(book.ISBN);

            Assert.IsFalse(result);
        }


    }
}
