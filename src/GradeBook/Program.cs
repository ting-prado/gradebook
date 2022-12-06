// See https://aka.ms/new-console-template for more information
using System;

namespace GradeBook
{
    class Program
    {
      static void Main(string[] args)
      {
        var book = new Book("Sample book");

        while (true)
        {
          Console.WriteLine("Enter a grade or press 'Q' to quit.");
          var input = Console.ReadLine();
          if(input == "q" || input == "q")
          {
            break;
          } else {

            try
            {
              var grade = double.Parse(input);
              book.AddGrade(grade);
            }
            catch(ArgumentException ex)
            {
              Console.WriteLine(ex.Message);
              // throw; - if you want the program to stop after the error
            }
            catch(FormatException ex)
            {
              Console.WriteLine(ex.Message);
            }
            finally 
            {
              Console.WriteLine("***");
            }
          }
        }

        var stats = book.GetStatistics();
        Console.WriteLine($"The lowest grade is {stats.Low}.");
        Console.WriteLine($"The highest grade is {stats.High}.");
        Console.WriteLine($"The average of grades is {stats.Average:N2}.");
        Console.WriteLine($"The letter grade is {stats.Letter}");
      }
    }
}