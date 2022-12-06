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

    public void AddLetterGrade(char Letter) 
    {
      switch(Letter) 
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        case 'D':
          AddGrade(60);
          break;
        default:
          AddGrade(0);
          break;
      }
    }

    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0) 
      {
        grades.Add(grade);
      } else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public Statistics GetStatistics() 
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      // do-while
      // var i = 0;
      // do {
      //   result.High = grades[i] > result.High ? grades[i] : result.High;
      //   result.Low = Math.Min(grades[i], result.Low);
      //   result.Average += grades[i];
      //   i++;
      // } while(i < grades.Count);

      foreach(var grade in grades) {
        result.High = grade > result.High ? grade : result.High;
        // or result.High = Math.Max(grade, result.High);
        result.Low = Math.Min(grade, result.Low);
        // or result.Low = grade > result.Low ? result.Low : grade;
        result.Average += grade;
      }
      result.Average /= grades.Count;
      switch(result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }
      
      return result;
    }

   List<double> grades; // this is a field (private)
   public string Name;
  }
}