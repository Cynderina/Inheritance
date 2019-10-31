using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        //Pilko toimintoja metodeihin enemmän switcheistä. Luettavuus paranee
        // Poista turhat muuttujat
        // Harkitse eri usereiden lisäämistä eri käyttöoikeuksilla
        static void PrintMenu()
        {
            Console.WriteLine("\n\nChoose from the following:\n\n");
            Console.WriteLine("[s] Search for documents\n");
            Console.WriteLine("[n] Add new document\n");
            Console.WriteLine("[i] Inspect invoice\n");
            Console.WriteLine("[r] Remove document\n");
            Console.WriteLine("[m] Menu\n");
            Console.WriteLine("[q] Quit\n\n");
        }
        static void Main(string[] args)
        {
            string orderOrInvoice;
            string orderNumber;
            string supplier;
            string purchaser;
            double total;

            //List for orders and hardcoded orders
            List<Order> orders = new List<Order>();
            //The data needs to be given in order string purchaser, string orderNumber, string supplier, double total
            orders.Add(new Order("Matti", "123", "Kesko", 13));
            orders.Add(new Order("Maija", "124", "Kesko", 13));
            orders.Add(new Order("Matti", "125", "Kesko", 13));




            //List for invoices and hardcoded invoices
            List<Invoice> invoices = new List<Invoice>();
            //The data needs to be given in order string orderNumber, string supplier, double total
            invoices.Add(new Invoice("123", "Kesko", 13));


            //Setting inspector. Data needed is string ordernumber, string supplier, List<Order> orders
            invoices[0].SetInspector("123", "Kesko", orders);


            //HARDCODED DATA ENDS HERE AND PROGRAM WITH MENU ETC STARTS!!!!!
            PrintMenu();
            Boolean continuous = true;

            while (continuous)
            {
                Console.WriteLine("Give command");
                char command = char.Parse(Console.ReadLine());

                switch (command)
                {
                    case 's': //Searching for the documents
                        Console.WriteLine("Order or Invoice?");
                        orderOrInvoice = Console.ReadLine();

                        if (orderOrInvoice == "Order")
                        {
                            Console.WriteLine("Give ordernumber");
                            orderNumber = Console.ReadLine();
                            Console.WriteLine("Give supplier");
                            supplier = Console.ReadLine();

                            foreach (Order item in orders)
                            {
                                if (orderNumber == item.GetOrderNumber() && supplier == item.GetSupplier())
                                {
                                    Console.WriteLine($"Orderer is {item.GetPurchaser()} and total is {item.GetTotal()}");
                                }
                            }
                        }
                        else if (orderOrInvoice == "Invoice")
                        {
                            Console.WriteLine("Give ordernumber");
                            orderNumber = Console.ReadLine();
                            Console.WriteLine("Give supplier");
                            supplier = Console.ReadLine();

                            foreach (Invoice item in invoices)
                            {
                                if (orderNumber == item.GetOrderNumber() && supplier == item.GetSupplier())
                                {
                                    Console.WriteLine("Inspector is " + item.GetInspector());
                                    Console.WriteLine("Total is " + item.GetTotal());
                                    if (item.GetInspectedStatus())
                                    {
                                        Console.WriteLine("Inspection status is accepted");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Inspection status is unaccepted or rejected");
                                    }
                                    Console.WriteLine($"Payer is {item.GetPayer()}");

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error in choices, it must be either Invoice or Order");
                        }
                        break;

                    case 'n'://Add new document
                        try
                        {
                            Console.WriteLine("Order or Invoice?");
                            orderOrInvoice = Console.ReadLine();
                            while(orderOrInvoice!= "Order" && orderOrInvoice!= "Invoice")
                            {
                                Console.WriteLine("Input must be either Order or Invoice. Try again.");
                                orderOrInvoice = Console.ReadLine();
                            }
                            Console.WriteLine("Give ordernumber");
                            orderNumber = Console.ReadLine();
                            Console.WriteLine("Give supplier");
                            supplier = Console.ReadLine();
                            Console.WriteLine("Give total");
                            total = double.Parse(Console.ReadLine());

                            if (orderOrInvoice == "Order")
                            {
                                Console.WriteLine("Give name of purchaser");
                                purchaser = Console.ReadLine();

                                orders.Add(new Order(purchaser, orderNumber, supplier, total));
                                Console.WriteLine("Order was added");
                            }
                            else if (orderOrInvoice == "Invoice")
                            {
                                invoices.Add(new Invoice(orderNumber, supplier, total));

                                foreach (var item in invoices)
                                {
                                    if(item.GetOrderNumber()==orderNumber && item.GetSupplier()==supplier)
                                    {
                                        item.SetInspector(orderNumber, supplier, orders);
                                    }
                                }
                                
                                Console.WriteLine("Invoice was added");
                            }
                            else
                            {
                                Console.WriteLine("Error in choices, it must be either Invoice or Order");
                            }
                        }
                            
                        
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please check data you've inputted to total. It must be XX,xx");
                        }
                       
                            break;

                    case 'i'://Inspecting invoice. Needed data is string inspectionResult
                        Console.WriteLine("Give ordernumber");
                        orderNumber = Console.ReadLine();
                        Console.WriteLine("Give supplier");
                        supplier = Console.ReadLine();
                        string inspection = "null";
                        Console.WriteLine("Inspect the invoice and order. Do you Accept or Reject the invoice? Respond Accept or Reject");
                        inspection = Console.ReadLine();
                        while (inspection != "Accept" && inspection != "Reject" && inspection != "Null")
                        {
                            Console.WriteLine("Answer must be either Accept or Reject. If you don't want respond give Null");
                            inspection = Console.ReadLine();
                            
                        }

                        foreach (var item in invoices)
                        {
                            if (item.GetOrderNumber() == orderNumber && item.GetSupplier() == supplier)
                            {
                                item.SetInspectedStatus(inspection);
                            }
                        }
                        

                       
                        break;

                    case 'r': //Remove document
                        break;

                    case 'm': //Bring menu
                        PrintMenu();
                        break;

                    case 'q': //Quit program
                        continuous = false;
                        break;
                }
            }


           
        }
    }
}
