class Base {
	int x;
	char ch;
	int y;
}

class Program {
	public static void Main(string[] args) {
	unsafe{	
	Console.WriteLine(sizeof(Base));
	}
	}
}
