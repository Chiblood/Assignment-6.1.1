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
    
    // HashSet to track existing house numbers for efficient uniqueness checking
    private HashSet<int> _existingHouseNumbers;

    // Constructor
    public HouseLinkedList()
    {
        _head = null;
        Count = 0;
        _existingHouseNumbers = new HashSet<int>();
    }
    
    // Private helper method to check if house number is unique
    private bool IsHouseNumberUnique(int houseNumber)
    {
        return !_existingHouseNumbers.Contains(houseNumber);
    }
    // Method to add a new house to the end of thelist
    public bool AddLastHouse(int houseNumber, string address, string houseType)
    {
        // Check if house number is unique
        if (!IsHouseNumberUnique(houseNumber))
        {
            Console.WriteLine($"Error: House number {houseNumber} already exists. Cannot add duplicate house numbers.");
            return false;
        }
        
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
        
        // Add to tracking set and increment count
        _existingHouseNumbers.Add(houseNumber);
        Count++;
        return true;
    }
    // Method to add a new house at the beginning of the list
    public bool AddFirstHouse(int houseNumber, string address, string houseType)
    {
        // Check if house number is unique
        if (!IsHouseNumberUnique(houseNumber))
        {
            Console.WriteLine($"Error: House number {houseNumber} already exists. Cannot add duplicate house numbers.");
            return false;
        }
        
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
        
        // Add to tracking set and increment count
        _existingHouseNumbers.Add(houseNumber);
        Count++;
        return true;
    }
    // Method to remove the first house from the list
    public bool RemoveFirstHouse()
    {
        if (_head == null)
        {
            return false; // List is empty
        }
        
        // Remove house number from tracking set
        _existingHouseNumbers.Remove(_head.HouseNumber);
        
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

        // Test adding houses
        Console.WriteLine("Adding houses to the list:");
        houseList.AddLastHouse(1, "123 Main St", "Ranch");
        houseList.AddLastHouse(2, "456 Oak St", "Colonial");
        
        // Test duplicate house number - should fail
        Console.WriteLine("\nTrying to add duplicate house number 1:");
        houseList.AddLastHouse(1, "999 Test St", "Colonial");
        
        houseList.DisplayAllHouses();

        // Remove the first house
        Console.WriteLine("\nRemoving the first house...");
        houseList.RemoveFirstHouse();

        // Add a new house at the beginning of the list
        Console.WriteLine("\nAdding a new house at the beginning...");
        houseList.AddFirstHouse(3, "789 Elm St", "Ranch");
        
        // Now we should be able to add house number 1 again since it was removed
        Console.WriteLine("\nTrying to add house number 1 again after removal:");
        houseList.AddLastHouse(1, "999 New St", "Victorian");

        Console.WriteLine("\nAfter modifications:");
        houseList.DisplayAllHouses();

        // Search for a house by its number and display details
        Console.WriteLine("\nSearching for house number 2:");
        HouseNode<object>? foundHouse = houseList.SearchHouse(2);
        houseList.DisplayHouseDetails(foundHouse);
    }
}