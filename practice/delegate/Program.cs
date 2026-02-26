public delegate void Calculator(int a, int b);

class Program {
    public static void Add(int x, int y) {
        Console.WriteLine(x+y);
    }
    public static void Mul(int x, int y) {
        Console.WriteLine(x*y);
    }


    public static void Main(string[] args) {
        // Calculator cal = Add;
        // cal(1,2);

        // var cal = Add;
        // cal+=Mul;
        // cal(1, 2);

        // Console.WriteLine(typeof(cal));

        // Predicate, Func, Action
        // Action -> return nahi krta
        // Predicate -> return bool
        // Func -> return something 

    }
}