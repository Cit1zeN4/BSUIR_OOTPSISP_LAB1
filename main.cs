using System;

// Library
// Должно быть 5 классов
// 3 Поля 
// 3 Метода

// TODO: Доделать библиотеку

public class Publisher
{
  public string Id;
  public string Name;
  public string Address;
}

public class Author
{
  public string Id;
  public string FirstName;
  public string Surname;
  public string NickName;
}

public class Bookcase
{
  public Bookshelf[] Bookshelfs;
}

public class Bookshelf
{
  public string Id;
  public Book[] Books;
}

public class Book
{
  public string Id;
  public string Title;
  public Author Author;
  public Publisher Publisher;

  public Book(string title, Author author, Publisher publisher)
  {
    Title = title;
    Author = author;
    Publisher = publisher;
  }

  public override string ToString()
  {
    return String.Format("Title: {0}\tAuthor: {1}\tPublisher: {2}", Title, Author.NickName, Publisher.Name);
  }
}

public enum RightTriangleSide
{
  A,
  B
}

public class RightTriangle
{
  private double a_side;
  private double b_side;

  public RightTriangle(double a, double b)
  {
    a_side = a;
    b_side = b;
  }
  public void ChangeSizeInPercentages(uint value, RightTriangleSide side, bool increase = true)
  {
    if (side == RightTriangleSide.A)
    {
      if (increase)
        a_side = a_side + (a_side / 100) * value;
      else
        a_side = a_side - (a_side / 100) * value;
    }
    else
    {
      if (increase)
        b_side = b_side + (b_side / 100) * value;
      else
        b_side = b_side - (b_side / 100) * value;
    }
  }
  public double GetRadiusOfCircumscribedCircle()
  {
    return (Math.Sqrt(Math.Pow(a_side, 2) + Math.Pow(b_side, 2))) / 2;
  }

  public double GetHalfPerimeter()
  {
    return (GetSides().c + a_side + b_side) / 2;
  }

  public (double a, double b, double c) GetSides()
  {
    return (a_side, b_side, Math.Sqrt(Math.Pow(a_side, 2) + Math.Pow(b_side, 2)));
  }

  public (double alpha, double beta, double gamma) GetCorners()
  {
    var a = Math.Asin(a_side / GetSides().c) * (180 / Math.PI);
    var b = Math.Asin(b_side / GetSides().c) * (180 / Math.PI);
    var g = 90;
    return (a, b, g);
  }
}

class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Hello World");
    RightTriangle triangle = new RightTriangle(10, 20);
    Console.WriteLine(triangle.GetSides());
    Console.WriteLine(triangle.GetCorners());
  }
}