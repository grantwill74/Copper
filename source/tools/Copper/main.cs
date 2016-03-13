/*
    A simple main method for testing purposes.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copper {
    class main {

        public void test(params int[] a) {

        }

        public static void Main(string[] args) {
            var m = typeof( main ).GetMethod( "test" );
            var p = m.GetParameters();
            
        }
    }
}
