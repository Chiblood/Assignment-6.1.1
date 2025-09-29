/* Assignment 6.1.1
1. Implement a single linked list with each node representing a house. 
You may add data in it like house number, brief address, type of house ( like Ranch, Colonial).
Each house (node) will be linked to next.
Create a method to search a house by its number and then display the details. 
( Windows / Console)
*/
namespace Assignment_6._1._1;

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