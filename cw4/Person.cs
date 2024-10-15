public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age = 18) // constructor
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person() // default constructor
    {
        firstName = "";
        lastName = "";
        age = 18;
    }

    public override string ToString() // string representation
    {
        return firstName + " " + lastName + " wiek : " + age;
    }

    // properties
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int Age // note: capital 'A' for property name
    {
        get { return age; }
        set { age = value < 0 ? -value : value; }
    }
}