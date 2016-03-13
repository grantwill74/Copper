using System.Reflection;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Copper {

    class ConnectorMapDispatcher : DynamicObject {

        public ConnectorMap Connector { get; private set; }
        public dynamic Other { get; private set; }

        public ConnectorMapDispatcher(ConnectorMap connector, dynamic other) {
            Connector = connector;
            Other = other;
        }

        public override bool TryInvokeMember( 
            InvokeMemberBinder binder, object[] args, out object result ) {

            return DoInvoke( binder.Name, args, out result );
        }
        
        public bool DoInvoke(string name, object[] args, out object result) {
            BindingFlags flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.FlattenHierarchy |
                BindingFlags.InvokeMethod;

            result = null;

            try {
                result = Connector.GetType().InvokeMember(
                    name, flags, null, Connector, args );
            }
            catch ( MissingMethodException ) {
                result = Other.GetType().InvokeMember(
                    name, flags, null, Other, args );
            }

            return true;
        }
    }

}
