namespace Vehicles;

public class CustomException : Exception
{
    public CustomException() : base("A lekérdezés nem adott eredményt.")
    {
    }
}