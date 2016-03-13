using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Copper {
    public class PortConnectorNoMethodError : Exception {
        public PortConnectorNoMethodError(string method_name, object[] args) {
            MethodName = method_name;
            MethodArgs = args;
        }
        
        public string MethodName;
        public object[] MethodArgs;
    }

    public class PortMapConnector : DynamicObject {
        public PortMapConnector( object a, object b ) {
            this.a = a;
            this.b = b;
        }
        
        private object a, b;
    }


}
