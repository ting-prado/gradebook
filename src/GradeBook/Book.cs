using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book(string name) // this is a constructor
    {
      grades = new List<double>() { 12.7, 10.3, 6.11, 4.1, 56.1 };
      this.name = name;
    }

    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }

    public void ShowStatistics() {
      double sum = 0, average, maxGrade = double.MinValue, minGrade = double.MaxValue;

      foreach(var num in grades) {
        maxGrade = num > maxGrade ? num : maxGrade;
        // or maxGrade = Math.Max(num, maxGrade);
        minGrade = Math.Min(num, minGrade);
        // or minGrade = num > minGrade ? minGrade : num;
        sum += num;
      }
      average = sum / grades.Count;
      
      Console.WriteLine($"The lowest grade is {minGrade}.");
      Console.WriteLine($"The highest grade is {maxGrade}.");
      Console.WriteLine($"The average of grades is {average:N2}.");
    }

   List<double> grades; // this is a field (private)
   private string name;
  }
}