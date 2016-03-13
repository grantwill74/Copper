using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Copper;

namespace Mono.CSharp
{
	//This is a component class because it contains at least one Port
	//A port acts like a special interface that is distinct from the class's
	//normal interface.
	class ClassA
	{
		//This is a port declaration. It contains a list of methods:
		//	'in' methods are provided by whomever is connected to the port
		//	'out' methods are provided by the containing class of the port
		public port port_a {
			out void fn_a(); //method provided by containing class
			in void fn_b();	 //method required from another class
		}

		//When an outside class has a port that connects to 'port_a', it 
		//can access this method through the port. 
		void fn_a() {
			Console.WriteLine("Hello from A!");
		}

		//This method uses a port to dispatch a message. Even though messages
		//are currently dispatched dynamically, 
		public void greet_other() {
			port_a.fn_b(); //call this method through the port
		}
	}

	//ClassB contains a port which is compatible with the port in ClassA
	//It has the same method names, but the directions are reversed.
	class ClassB
	{
		public port port_b {
			in void fn_a();
			out void fn_b();
		}

		void fn_b() {
			Console.WriteLine("Hello from B!");
		}

		public void greet_other() {
			port_b.fn_a();
		}
	}


    class basic_test 
    {
		public static void Main(string[] args) {
			var a = new ClassA();
			var b = new ClassB();
			
			//Connect the ports of the two objects so they can communicate
			//Note: This will be replaced with a statement later which will 
			//look like: connect X, Y;
			Port.Connect( a.port_a, b.port_b );

			//now we invoke the methods on the classes that make use of ports 
			//to show that they work.
			a.greet_other();
			b.greet_other();
		}
    }
}
