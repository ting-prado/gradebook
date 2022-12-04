using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name) // this is a constructor
    {
      grades = new List<double>();
      Name = name;
    }

    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }

    public Statistics GetStatistics() 
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach(var grade in grades) {
        result.High = grade > result.High ? grade : result.High;
        // or result.High = Math.Max(grade, result.High);
        result.Low = Math.Min(grade, result.Low);
        // or result.Low = grade > result.Low ? result.Low : grade;
        result.Average += grade;
      }
      result.Average /= grades.Count;
      
      return result;
    }

   List<double> grades; // this is a field (private)
   public string Name;
  }
}