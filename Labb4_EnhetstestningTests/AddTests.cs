using Labb4_Enhetstestning;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class AddTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        [TestCategory("Normal")]
        public void AddBook_AddBookWith13DigitsISBN_ReturnsTrue()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);

            bool result = librarySystem.AddBook(book);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBook_AddBookWithoutISBN_ReturnsFalse()
        {
            Book book = new Book("Djungelboken", "Rudyard Kipling", "1234567890000", 1888);
            book.ISBN = null;

            bool result = librarySystem.AddBook(book);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBook_AddBookWithTakenISBN_ReturnsFalse()
        {
            Book alreadyExists = new Book("1984", "George Orwell", "9780451524935", 1949);

            bool result = librarySystem.AddBook(alreadyExists);

            Assert.IsFalse(result);
        }
    }
}