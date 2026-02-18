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
            
        }
    }
}