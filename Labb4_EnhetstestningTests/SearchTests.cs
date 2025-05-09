using Labb4_Enhetstestning;

namespace Labb4_EnhetstestningTests
{
    [TestClass]
    public class SearchTests
    {
        LibrarySystem librarySystem = new LibrarySystem();

        [TestMethod]
        public void SearchByISBN_ExistingISBN_ReturnsCorrectBook()
        {
            var existingISBN = "9780060850524";
            var expected = librarySystem.SearchByISBN(existingISBN).ISBN;

            Assert.AreEqual(expected, existingISBN);
        }

        [TestMethod]
        public void SearchByISBN_NotExistingISBN_ReturnsFalse()
        {
            var notExistingISBN = "111111111111";
            var result = librarySystem.SearchByISBN(notExistingISBN);
            Book expected = null;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("97", 8, "Should return a list of 8 objects")]
        [DataRow("97803", 2, "Should return a list of 2 objects")]
        [DataRow("9780547928227", 1, "Should return a list of 1 object")]
        public void SearchManyByISBN_ValidSearches_ReturnsHits(string searchTerm, int expected, string message)
        {
            var numberOfBooks = librarySystem.SearchManyByISBN(searchTerm).Count;

            Assert.AreEqual(expected, numberOfBooks);
        }

        [TestMethod]
        public void SearchManyByISBN_UpperLowerCaseInsensitivity_ReturnsAreEqual()
        {
            string upperCaseSearchTerm = "MMM123";
            string lowerCaseSearchTerm = "mmm123";

            var resultUpperCase = librarySystem.SearchManyByISBN(upperCaseSearchTerm);
            var resultLowerCase = librarySystem.SearchManyByISBN(lowerCaseSearchTerm);

            var upperCaseTitles = resultUpperCase.Select(b => b.Title).ToList();
            var lowerCaseTitles = resultLowerCase.Select(b => b.Title).ToList();

            CollectionAssert.AreEqual(resultUpperCase, resultLowerCase);
        }

        [TestMethod]
        [DataRow("träd", "Search with lower case should return expected isbn")]
        [DataRow("TRÄD", "Search with upper case should return expected isbn")]
        [DataRow("rä", "Search with part of name should return expected isbn")]
        public void SearchByTitle_DifferentSearchCases_ShouldReturnExpected(string searchTerm, string message)
        {
            var bookList = librarySystem.SearchByTitle(searchTerm);
            string isbn = bookList[0].ISBN;

            string expected = "mmm123";

            Assert.AreEqual(expected, isbn);
        }

        [TestMethod]
        [DataRow("george orwell", "Search with lower case should return expected title")]
        [DataRow("GEORGE ORWELL", "Search with upper case should return expected title")]
        [DataRow("Orw", "Search with part of name should return expected title")]
        public void SearchByAuthor_DifferentSearchCases_ShouldReturnExpected(string searchTerm, string message)
        {
            var bookList = librarySystem.SearchByAuthor(searchTerm);
            string title = bookList[0].Title;

            string expected = "1984";

            Assert.AreEqual(expected, title);
        }
    }
}
