using ITCS_3112_Exercise_2.Domain;

namespace ITCS_3112_Exercise_2.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Create an Item
            Item laptop = new Item 
            { 
                Type = TypeEnum.VrHeadset, 
                Status = StatusEnum.Available,
                Damages = "None"
            };

            // 2. Create a Customer (Inheritance)
            Customer student = new Customer 
            { 
                Id = 101, 
                Name = "Ivan" 
            };

            Employee employee = new Employee
            {
                Id = 102,
                Name = "Marty"
            };

            // 3. Create a CheckoutRecord 
            // The Receipt is created internally via the constructor
            CheckoutRecord record = new CheckoutRecord("Vr Headset rented for 7 days to Ivan Ivanov.\n\t Damages: none.");
            record.Borrower = student;
            record.Item.Add(laptop);
            laptop.Status = StatusEnum.CheckedOut;

            // 4. Print the Receipt
            record.Receipt.Print(record.Item);
            Console.WriteLine("--- END OF RECEIPT ---");
            
            Console.WriteLine("\nProof of functionality: ");
            Console.WriteLine("\nCustomer Name tied to Item on Checkout Record:");
            Console.WriteLine("Name: "+ record.Borrower.Name);
            Console.WriteLine("Item Borrowed: "+record.Item[0].Type); 
            Console.WriteLine("Date Checked Out: "+record.CheckoutDate);
            Console.WriteLine("Due Date: "+record.DueDate);

            Console.WriteLine("\nStatus of checked out Item: " + record.Item[0].Status);
            
        }
    }
}