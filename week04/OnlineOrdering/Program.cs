using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address addr2 = new Address("456 Elm St", "Calgary", "AB", "Canada");

        Customer cust1 = new Customer("Alice Johnson", addr1);
        Customer cust2 = new Customer("Bob Patterson", addr2);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Widget", "W123", 10.0, 2));
        order1.AddProduct(new Product("Gadget", "G456", 20.5, 1));

        Order order2 = new Order(cust1);
        order2.AddProduct(new Product("Thingamajig", "T789", 15.0, 3));
        order2.AddProduct(new Product("Doohickey", "D321", 12.0, 2));

        PrintOrder(order1);
        PrintOrder(order2);
    }

    static void PrintOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"Total Price: {order.GetTotalPrice():C}");
        Console.WriteLine("------------------------------\n");
    }
}