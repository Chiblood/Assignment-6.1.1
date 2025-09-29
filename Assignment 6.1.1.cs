/* Assignment 6.1.1
1. Implement a single linked list with each node representing a house. 
You may add data in it like house number, brief address, type of house ( like Ranch, Colonial).
Each house (node) will be linked to next.
Create a method to search a house by its number and then display the details. 
( Windows / Console)
*/
namespace Assignment_6._1._1;
public class HouseNode<T>// the basic node class of the linked list
{
    public int HouseNumber { get; set; } // unique identifier for each house (need to implement logic to ensure uniqueness) Dictionary could be used to track existing numbers
    public string Address { get; set; }
    public string HouseType { get; set; }
    public HouseNode<T>? Next { get; set; }

    // Constructor
    public HouseNode(int houseNumber, string address, string houseType)
    {
        HouseNumber = houseNumber;
        Address = address;
        HouseType = houseType;
        Next = null;
    }
}
public class HouseLinkedList<T> // the linked list class of houses
{
    // Head of the list
    private HouseNode<T>? _head;
    public int Count { get; private set; }

    // Constructor
    public HouseLinkedList()
    {
        _head = null;
        Count = 0;
    }
    // Method to add a new house to the end of thelist
    public void AddLastHouse(int houseNumber, string address, string houseType)
    {
        HouseNode<T> newHouse = new HouseNode<T>(houseNumber, address, houseType);
        if (_head == null)
        {
            _head = newHouse;
        }
        else
        {
            HouseNode<T>? current = _head;
            while (current.Next != null)
            {
                current = current.Next ?? throw new InvalidOperationException("Next node is null.");
            }
            current.Next = newHouse;
        }
        Count++;
    }
    // Method to add a new house at the beginning of the list
    public void AddFirstHouse(int houseNumber, string address, string houseType)
    {
        HouseNode<T> newHouse = new HouseNode<T>(houseNumber, address, houseType);
        if (_head == null)
        {
            _head = newHouse;
        }
        else
        {
            newHouse.Next = _head;
            _head = newHouse;
        }
        Count++;
    }
    // Method to remove the first house from the list
    public bool RemoveFirstHouse()
    {
        if (_head == null)
        {
            return false; // List is empty
        }
        _head = _head.Next;
        Count--;
        return true;
    }

    // Method to search for a house by its assigned houseNumber and return the first matching house's details
    public HouseNode<T>? SearchHouse(int houseNumber)
    {
        HouseNode<T>? current = _head;
        while (current != null)
        {
            if (current.HouseNumber == houseNumber)
            {
                return current;
            }
            current = current.Next;
        }
        return null; // House not found
    }
    // Method to display house details
    public void DisplayHouseDetails(HouseNode<T>? house)
    {
        if (house != null)
        {
            Console.WriteLine($"House Number: {house.HouseNumber}");
            Console.WriteLine($"Address: {house.Address}");
            Console.WriteLine($"House Type: {house.HouseType}");
        }
        else
        {
            Console.WriteLine("House not found.");
        }
    }
    // Method to display all houses in the list
    public void DisplayAllHouses()
    {
        HouseNode<T>? current = _head;
        while (current != null)
        {
            Console.WriteLine($"House Number: {current.HouseNumber}, Address: {current.Address}, House Type: {current.HouseType}");
            current = current.Next;
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        // Test the HouseLinkedList class
        HouseLinkedList<object> houseList = new HouseLinkedList<object>();

        houseList.AddLastHouse(1, "123 Main St", "Ranch");
        houseList.AddLastHouse(2, "456 Oak St", "Colonial");
        houseList.DisplayAllHouses();

        // Remove the first house
        Console.WriteLine("\nRemoving the first house...");
        houseList.RemoveFirstHouse();

        // Add a new house at the beginning of the list
        Console.WriteLine("\nAdding a new house at the beginning...");
        houseList.AddFirstHouse(3, "789 Elm St", "Ranch");

        Console.WriteLine("\nAfter modifications:");
        houseList.DisplayAllHouses();

        // Search for a house by its number and display details
        Console.WriteLine("\nSearching for house number 2:");
        HouseNode<object>? foundHouse = houseList.SearchHouse(2);
        houseList.DisplayHouseDetails(foundHouse);
    }
}