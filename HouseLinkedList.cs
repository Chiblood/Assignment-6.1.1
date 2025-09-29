namespace Assignment_6._1._1;
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