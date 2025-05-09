using Labb4_Enhetstestning;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class RemoveTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void RemoveBook_RemovingExistingBook_ReturnsTrue()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);

            bool result = librarySystem.RemoveBook(book.ISBN);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveBook_RemoveBorrowedBook_ReturnsFalse()
        {
            var book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);
            book.IsBorrowed = true;

            bool result = librarySystem.RemoveBook(book.ISBN);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveBook_RemoveNotBorrowedBook_ReturnsTrue()
        {
            var book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            librarySystem.AddBook(book);
            book.IsBorrowed = false;

            bool result = librarySystem.RemoveBook(book.ISBN);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveBook_RemoveBothBorrowedAndNotBorrowedBook_ReturnsAreNotEqual()
        {
            var book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            var secondBook = new Book("Korven", "Lina Olandersson", "2345678923452", 2025);
            book.IsBorrowed = true;

            librarySystem.AddBook(book);
            librarySystem.AddBook(secondBook);

            bool firstResult = librarySystem.RemoveBook(book.ISBN);
            bool secondResult = librarySystem.RemoveBook(secondBook.ISBN);

            Assert.AreNotEqual(firstResult, secondResult);
        }
    }
}
