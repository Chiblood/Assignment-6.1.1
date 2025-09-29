namespace Assignment_6._1._1;

public class HouseNode<T>(int houseNumber, string address, string houseType)// the basic node class of the singly linked list
{
    public int HouseNumber { get; set; } = houseNumber;
    public string Address { get; set; } = address;
    public string HouseType { get; set; } = houseType;
    public HouseNode<T>? Next { get; set; } = null;

    public void DisplayInfo()
    {
        Console.WriteLine($"House Number: {HouseNumber}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"House Type: {HouseType}");
    }
}