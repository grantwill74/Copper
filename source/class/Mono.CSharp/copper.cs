using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Mono.CSharp {
    

    /*
    public class PortInterface {
        public IReadOnlyList<MethodInfo> Ins { get; private set; }
        public IReadOnlyList<MethodInfo> Outs { get; private set; }
    }
    
    public struct PortMethod {
        void test() {
            Block b;

        }
    }

    public interface Port {
        PortInterface Interface { get; }
        object Owner { get; }

        bool Connected { get; }
    }

    public class SinglePort : Port {
        public PortInterface Interface { get; private set; }
        public object Owner { get; private set; }

        public Port Other { get; private set; }

        public bool Connected { get { return Other != null; } }
    }

    public class MultiPort : Port {
        public PortInterface Interface { get; private set; }
        public object Owner { get; private set; }

        public Port[] Others { get; private set; }

        public bool Connected { get { return Others.Length > 0; } }
    }

    public class Component {

    }


    public interface IConnection {
        bool IsComplete { get; }

    }
    
    public class Connection {
        public bool IsComplete {
            get { return ( ports[0] != null ) && ( ports[1] != null ); } }

        public bool IsBroadcast { get; private set; }
        Port[] ports;

        public Connection( bool broadcast = false ) {
            IsBroadcast = broadcast;

        }
    }
    */
}
