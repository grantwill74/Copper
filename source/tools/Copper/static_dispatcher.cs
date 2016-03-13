using System.Reflection;
using System.Dynamic;
using System;

namespace Copper {

    public class StaticDispatcher : DynamicObject {

        private Type type;
        public Type DispatchType { get { return type; } }

        public StaticDispatcher(Type t ) {
            type = t;
        }

        public override bool TryInvokeMember( InvokeMemberBinder binder, object[] args, out object result ) {
            //get argument types for overload resolution
            /*Type[] types = new Type[args.Length];
            for ( int i = 0; i < args.Length; i++ )
                types[i] = args[i].GetType();

            BindingFlags flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static | 
                BindingFlags.FlattenHierarchy;

            //check for the existence of the method
            var m = type.GetMethod( binder.Name, flags, null, types, null );

            result = null;

            if ( m != null ) {
                result = m.Invoke( null, args );
                
                return true;
            }

            return false;
            */
            BindingFlags flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy |
                BindingFlags.InvokeMethod;

            result = type.InvokeMember( binder.Name, flags, null, null, args );

            return true;
        }

        //TODO: properties and events
    }

}