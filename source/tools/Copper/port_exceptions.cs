using System;
using System.Collections.Generic;
using System.Reflection;

namespace Copper {
    public class ConnectionIncompatibleError : System.Exception {
        public ConnectionIncompatibleError( IConnectable a, object b,
            List<MethodInfo> incompat_methods )
            : base( "Attempted to connect to objects with incompatible interfaces." ) {
            A = a;
            B = b;
            incompat = incompat_methods;
        }

        public IConnectable A { get; private set; }
        public object B { get; private set; }
        private List<MethodInfo> incompat;
        public IReadOnlyList<MethodInfo> IncompatibleMethods { get { return incompat; } }
    }

    public class InvalidAttachmentError : Exception {
        public InvalidAttachmentError( object first, object attached )
            : base( "Attempt to attach a non-connectable." ) {
            First = first;
            Attached = attached;
        }

        public object First { get; private set; }
        public object Attached { get; private set; }
    }

    public class InvalidDetachmentError : Exception {
        public InvalidDetachmentError( IConnectable first, object detached )
            : base( "Attempt to detach a port that was never attached." ) {
            First = first;
            Detached = detached;
        }

        public IConnectable First { get; private set; }
        public object Detached { get; private set; }
    }



    public class PortNotConnectedError : Exception {
        public PortNotConnectedError( IPort port ) :
            base( "A method was invoked on a port that was not connected." ) {
            Port = port;
        }

        public IPort Port { get; private set; }
    }
}