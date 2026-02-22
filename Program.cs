using ITCS_3112_Exercise_2.Domain;
using ITCS_3112_Exercise_2.Contracts;
namespace ITCS_3112_Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {

            IRepository repository = new Repository();
            ICatalog catalog = new Catalog(repository);
            
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
            
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                //Entering in a new item.
                case "1":
                    
                    //Entering in new item ID.
                    Console.WriteLine("Enter item ID: ");
                    long newItemID = long.Parse(Console.ReadLine());
                    
                    //Entering in new item name.
                    Console.WriteLine("Enter item name: ");
                    string newItemName = Console.ReadLine();
                    
                    //Entering in new item's category.
                    Console.WriteLine("Enter category (Book, NewsPaper, GameConsole,VrHeadset, Dvd, and more): ");
                    TypeEnum newItemCategory;
                    while (!Enum.TryParse(Console.ReadLine(), true, out newItemCategory))
                    {
                        Console.WriteLine("Invalid item category.");
                    }
                    
                    //Entering in new item's status in system.
                    Console.Write("Enter status: ");
                    StatusEnum newStatus;
                    while (!Enum.TryParse(Console.ReadLine(), true, out newStatus))
                    {
                        Console.WriteLine("Invalid item status.");
                    }
                    
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
                    break;
                
                //Listing all available items.
                case "2":
                    var availableItems = repository.GetAllAvailableItems();

                    foreach (var item in availableItems)
                    {
                        Console.WriteLine(item);
                    }
                    

                    break;
                
                //3. List unavailable items"
                case "3":
                    
                    var unavailableItems = repository.GetAllUnavailableItems();

                    foreach (var item in unavailableItems)
                    {
                        Console.WriteLine(item);
                    }


                    break;
                
                //4. Check out item"
                case "4":

                    break;
                
                //5. Return item"
                case "5":
                    Console.WriteLine("congrats you're working!");

                    break;
                
                //6. Show due soon
                case "6":

                    break;
                
                //7. Show overdue items
                case "7":

                    break;
                
                //8. Search items (optional)
                case "8":

                    break;
                
                //9. Mark item LOST
                case "9":

                    break;
                
                //0. Exit

                    break;
                   
                    
                    
            }
            
           
            /*
            // 1. Create an Item
            Item vrHeadset = new Item(295002835, "Oculus Rift", TypeEnum.VrHeadset)
            { 
                Status = StatusEnum.Available,
                Damages = "None"
            };
            Item dvd = new Item(491002837, "Prince of Persia", TypeEnum.Dvd)
            { 
                Status = StatusEnum.Unavailable,
                Damages = "Minor Scratches on Display Side."
            };

            // 2. Create a Customer (Inheritance)
            Customer student = new Customer(101, "Ivan", "iivanov2@charlotte.edu");

            Employee employee = new Employee(102, "Marty", "msmith5@charlotte.edu");

            // 3. Create a CheckoutRecord 
            
            repository.AddItem(vrHeadset);
            repository.AddItem(dvd);
            
            var availableItems = catalog.GetAvailableItems();

            foreach (var i in availableItems)
            {
                Console.WriteLine($"ID: {i.Id} | Name: {i.Type.ToString()} | Damages: {i.Damages} | Status: {i.Status}");
            }
            
       
            
            // 4. Checkout an item
            
            // 5. Return Item
            
            // 6. Show due soon (next 24hr)
            
            //7. Show overdue items
            
            //8. Search items (optional)
            
            // 9. Mark item lost
            
            // 0. Exit
            
            
            
            
            
            
            
            
            
            
            
            
            
            // The Receipt is created internally via the constructor
            
            CheckoutService service = new CheckoutService("Vr Headset rented for 7 days to Ivan Ivanov.\n\t Damages: none.", student, catalog);
            service.Borrower = student;
            service.Item = vrHeadset;
            vrHeadset.Status = StatusEnum.CheckedOut;

            // 4. Print the Receipt
            service.Receipt.Print(service.Item);
            Console.WriteLine("--- END OF RECEIPT ---");
            
            Console.WriteLine("\nProof of functionality: ");
            Console.WriteLine("\nCustomer Name tied to Item on Checkout Record:");
            Console.WriteLine("Name: "+ service.Borrower.Name);
            Console.WriteLine("Item Borrowed: "+service.Item.Type); 
            Console.WriteLine("Date Checked Out: "+service.CheckoutDate);
            Console.WriteLine("Due Date: "+service.DueDate);

            Console.WriteLine("\nStatus of checked out Item: " + service.Item.Status);
            
                 */
            
        }
    }
}