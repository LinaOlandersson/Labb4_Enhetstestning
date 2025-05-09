using Labb4_Enhetstestning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class BorrowTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void BorrowBook_BookIsBorrowed_StatusChanges()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);
            bool statusWhenNew = book.IsBorrowed;
            bool statusWhenBorrowed = librarySystem.BorrowBook(book.ISBN);

            Assert.IsFalse(statusWhenNew);
            Assert.IsTrue(statusWhenBorrowed);
        }

        [TestMethod]
        public void BorrowBook_BorrowABorrowedBook_ReturnsFalse()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);
            book.IsBorrowed = true;

            bool result = librarySystem.BorrowBook(book.ISBN);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BorrowBook_BorrowABook_SetDateTimeIsSameAsNow()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);

            librarySystem.BorrowBook(book.ISBN);

            DateOnly whenBorrowing = DateOnly.FromDateTime((DateTime)book.BorrowDate);
            DateOnly expectedDate = DateOnly.FromDateTime(DateTime.Now);

            Assert.AreEqual(whenBorrowing, expectedDate);
        }
    }
}
