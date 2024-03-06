/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Specify the maximum size of the queue
        // Expected Result: 
        Console.WriteLine("Test 1");
        CustomerService cs1 = new CustomerService(5);
        Console.WriteLine(cs1);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Invalid mx size (less than or equal to 0)
        // Expected Result: 
        Console.WriteLine("Test 2");
        CustomerService cs2 = new CustomerService(0);
        Console.WriteLine(cs2);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3: Add new customer
        Console.WriteLine("\nTest 3: Add New Customer");
        cs1.AddNewCustomer();
        Console.WriteLine(cs1);
        // Expected Output: [size=1 max_size=5 => (customer details)]

        Console.WriteLine("=================");

        // Test 4: Queue full error
        Console.WriteLine("Test 4: Queue Full Error");
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        // Above additions fill up the queue of size 5
        cs1.AddNewCustomer();
        // Expected Output: Maximum Number of Customers in Queue.

        Console.WriteLine("=================");

        // Test 5: Serve Customer
        Console.WriteLine("Test 5: Serve Customer");
        cs1.ServeCustomer();
        Console.WriteLine(cs1);
        // Expected Output: [size=0 max_size=5 =>]

        Console.WriteLine("=================");

        // Test 6: Empty Queue Error
        Console.WriteLine("Test 6: Empty Queue Error");
        cs1.ServeCustomer();
        // Expected Output: Queue is Empty. No Customers to Serve.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}