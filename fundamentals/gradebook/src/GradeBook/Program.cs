using System;
using System.Collections.Generic;


namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskBook book = new DiskBook("GradeBook");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            EnterGrades(book);

            book.ShowStatistics();

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter A Grade or 'q' to Quit");
                String input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
                finally
                {
                    Console.WriteLine("Finally");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added to book");
        }
    }
}
