public delegate void Math(int x, int y);
public class Test_Delegate {
    public void Add(int x, int y) {
        Console.WriteLine("Add: " + (x+y));
    }

    public void Subtract(int x, int y) {
        Console.WriteLine("Subtract: " + (x-y));
    }

    public void Multiply(int x, int y) {
        Console.WriteLine("Multiply: " + (x*y));
    }

    public void Divide(int x, int y) {
        Console.WriteLine("Division: " + (x/y));
    }
}