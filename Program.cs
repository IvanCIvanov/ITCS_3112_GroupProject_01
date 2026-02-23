using System.Runtime.InteropServices.JavaScript;
using ITCS_3112_Exercise_2.Domain;
using ITCS_3112_Exercise_2.Contracts;
using ITCS_3112_Exercise_2.Services;

///* Lab 1 NinerCS Equipment Checkout
/// Authors:
///     Ivan Ivanov - 801084868
///     Keilee Wright 801405109
///
/// 
namespace ITCS_3112_Exercise_2
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            IRepository repository = new Repository();
            ICatalog catalog = new Catalog(repository);
            IPolicy policy = new Policy();
            IClock clock = new SystemClock();
            ICheckoutService checkoutService = new CheckoutService(repository, clock, policy);
            long userID = 3455267;
            
            string userInput = "";
            while (userInput != "0")
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("1. Add items to inventory");
                Console.WriteLine("2. List available items");
                Console.WriteLine("3. List unavailable items");
                Console.WriteLine("4. Check out item");
                Console.WriteLine("5. Return item");
                Console.WriteLine("6. Show due soon");
                Console.WriteLine("7. Show overdue items");
                Console.WriteLine("8. Search items (optional)");
                Console.WriteLine("9. Mark item LOST");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=========================================");
                
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    //Entering in a new item.
                    case "1":
                        string userContinue = "Y";
                        while (userContinue == "Y")
                        {

                            //Entering in new item ID.
                            Console.WriteLine("Enter item ID: ");
                            long newItemID = long.Parse(Console.ReadLine());

                            //Entering in new item name.
                            Console.WriteLine("Enter item name: ");
                            string newItemName = Console.ReadLine();

                            //Entering in new item's category.
                            Console.WriteLine(
                                "Enter category (Book, NewsPaper, GameConsole,VrHeadset, Dvd, and more): ");
                            TypeEnum newItemCategory;
                            while (!Enum.TryParse(Console.ReadLine(), true, out newItemCategory))
                            {
                                Console.WriteLine("Invalid item category.");
                            }

                            // Item addition should not ask for status.
                            // Should be available after adding to repository.
                            StatusEnum newStatus = StatusEnum.Available;


                            //Entering in new item's condition.
                            Console.WriteLine("Enter condition (Good, Bad, Okay, Poor, Unknown): ");
                            ConditionEnum newItemCondition;
                            while (!Enum.TryParse(Console.ReadLine(), true, out newItemCondition))
                            {
                                Console.WriteLine("Invalid item condition.");
                            }



                            Item newItem = new Item(
                                newItemID,
                                newItemName,
                                newItemCategory,
                                newStatus,
                                newItemCondition
                            );

                            repository.AddItem(newItem);


                            Console.WriteLine(newItem);
                            Console.WriteLine("Continue Adding? (Y/N)");
                            userContinue = Console.ReadLine();
                        }

                        break;

                    //Listing all available items.
                    case "2":
                        var availableItems = catalog.GetAvailableItems();

                        foreach (var item in availableItems)
                        {
                            Console.WriteLine(item);
                        }


                        break;

                    //3. List unavailable items"
                    case "3":

                        var unavailableItems = catalog.GetUnavailableItems();

                        foreach (var item in unavailableItems)
                        {
                            Console.WriteLine(item);
                        }


                        break;

                    //4. Check out item
                    //Currently working on this section
                    case "4":
                        Console.WriteLine("Enter item ID: ");
                        long itemID = long.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Enter borrower name: ");
                        string borrowerName = Console.ReadLine();
                        
                        Console.WriteLine("Enter borrower email: ");
                        string borrowerEmail = Console.ReadLine();
                        
                        Console.WriteLine("Enter due date (YYYY-MM-DD): ");
                        DateTime borrowerDueDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter a summary of the transaction: ");
                        string employeeSummary = Console.ReadLine();
                        Item tempItem = repository.GetItemById(itemID);
                        Person borrower = new Customer(userID, borrowerName, borrowerEmail);
                        userID++;
                        var record = new CheckoutRecord(tempItem, borrower, borrowerDueDate, employeeSummary);
                        
                        
                        Console.WriteLine("---RECEIPT---");
                        Console.WriteLine("Name: "+ record.Borrower.Name);
                        Console.WriteLine("Item Borrowed: "+record.Item.Type); 
                        Console.WriteLine("Date Checked Out: "+record.CheckoutDate);
                        Console.WriteLine("Due Date: "+record.DueDate);
                        record.Receipt.Print(record.Item);
                        Console.WriteLine("--- END OF RECEIPT ---");
                        break;

                    //5. Return item
                    case "5":
                        Console.WriteLine("Enter item ID: ");
                        long itemId = long.Parse(Console.ReadLine());

                        try
                        {
                            var receipt = checkoutService.ReturnItem((itemId));
                            Console.WriteLine(receipt.Summary);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    //6. Show due soon
                    case "6":
                        var dueSoonList = checkoutService.FindDueSoon(TimeSpan.FromDays(3));

                        foreach (var item in dueSoonList)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    //7. Show overdue items
                    case "7":
                        var overdueList = checkoutService.FindOverdue();

                        foreach (var item in overdueList)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    //8. Search items (optional)
                    case "8":
                        Console.WriteLine("What was the item you were looking for ");
                        string query = Console.ReadLine();
                        var results = catalog.Search(query);

                        if (results.Count == 0)
                        {
                            Console.WriteLine("No items found.");
                        }
                        else
                        {
                            foreach (var item in results)
                            {
                                Console.WriteLine($"ID: {item.Id}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Type: {item.Type}");
                                Console.WriteLine($"Status: {item.Status}");
                                Console.WriteLine("-----------------------");
                            }
                        }

                        break;

                    //9. Mark item LOST
                    case "9":
                        Console.WriteLine("Enter item ID: ");
                        long lostId = long.Parse(Console.ReadLine());

                        try
                        {
                            checkoutService.MarkLost(lostId);
                            Console.WriteLine($"{lostId} is successfully marked as lost");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        
                        
                        break;
                    
                    
                    //0. Exit using while-loop status, no code required
                }
            }
        }
    } }