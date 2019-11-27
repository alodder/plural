using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int ReturnMessageCount =0;

        [Fact]
        public void WriteLogDelegateCanPoint()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Hello");
            Assert.Equal("Hello", result);
            Assert.Equal(3, ReturnMessageCount);
        }

        string IncrementCount(string message)
        {
            ReturnMessageCount++;
            return message;
        }

        string ReturnMessage(string message)
        {
            ReturnMessageCount++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            //arrange
            String name = "Scott";

            //act
            String upper = MakeUpperCase(name);

            //assert
            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private String MakeUpperCase(String input)
        {
            return input.ToUpper();
        }

        [Fact]
        public void TestValueReference()
        {
            //arrange
            int x = GetInt();

            //act
            SetInt(ref x);

            //assert
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        [Fact]
        public void TestValue()
        {
            //arrange
            int x = GetInt();

            //act
            SetInt( x);

            //assert
            Assert.Equal(3, x);
        }

        private void SetInt( int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        [Fact]
        public void PassByReference()
        {
            //arrange
            var bookFirst = GetBook("Name One");

            //act
            GetBookSetName(ref bookFirst, "New Name"); //passing by value, a reference

            //assert
            Assert.Equal("New Name", bookFirst.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            //book.Name = name;
            book = new Book(name); //book now references new value
        }

        [Fact]
        public void PassByValue()
        {
            //arrange
            var bookFirst = GetBook("Name One");

            //act
            GetBookSetName(bookFirst, "New Name"); //passing by value, a reference


            //assert
            Assert.Equal("Name One", bookFirst.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name); //book now references new value
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var bookFirst = GetBook("Name One");
            SetName(bookFirst, "New Name"); //passing by value, a reference

            //act

            //assert
            Assert.Equal("New Name", bookFirst.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name; //book now references the same value as passed in
        }
        
        [Fact]
        public void ReferenceDifferentInstances()
        {
            //arrange
            var bookFirst = GetBook("Name One");
            var bookSecond = GetBook("Name Two");

            //act

            //assert
            Assert.Equal("Name One", bookFirst.Name);
            Assert.Equal("Name Two", bookSecond.Name);
        }

        [Fact]
        public void TwoReferencesSameInstance()
        {
            //arrange
            var bookFirst = GetBook("Name One");
            var bookSecond = bookFirst; // copy reference

            //act

            //assert
            Assert.Same(bookSecond, bookFirst);
            Assert.True(Object.ReferenceEquals(bookFirst, bookSecond));
        }

        public Book GetBook(String name){
            return new Book(name);
        }
    }
}
