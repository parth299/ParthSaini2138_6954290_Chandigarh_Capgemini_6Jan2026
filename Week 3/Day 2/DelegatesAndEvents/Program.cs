public class Program {
    public static void Main(string[] args) {
        Test_Delegate td = new Test_Delegate();

        Math math = new Math(td.Add);
        math+=td.Subtract;
        math+=td.Divide;
        math+=td.Multiply;

        math(20,5);
    }
}