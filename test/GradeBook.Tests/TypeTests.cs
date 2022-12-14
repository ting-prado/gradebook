namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void StringBehavesLikeValueTypes()
    {
        string name = "Scott";
        var upper = MakeUppercase(name);

        Assert.Equal("Scott", name);
        Assert.Equal("SCOTT", upper);
    }

    private string MakeUppercase(string name)
    {
        return name.ToUpper();
    }

  [Fact]
    public void SettingValueTypes()
    {
        var x = GetInt();
        SetInt(x);

        Assert.Equal(3, x);
    }

    private void SetInt(int x)
    {
        x = 2;
    }

  private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CSharpCanPassByReference()
    {
        var book1 = GetBook("Book 1");
        GetBookSetNameByRef(ref book1, "New Book 1");

        Assert.Equal("New Book 1", book1.Name);
    }

    private void GetBookSetNameByRef(ref Book book, string name)
    {
        book = new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Book 1");

        Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Book 1");

        Assert.Equal("New Book 1", book1.Name);
    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        // book2 copies the value(pointer) that is stored in book1
        // or it places the value of book1 into book2
        var book2 = book1;

        // testing if these variables are pointing to the same instance/object
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    private Book GetBook(string name)
    {
        return new Book(name);
    }
}