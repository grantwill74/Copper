using System.Collections.Generic;
using System.Reflection;
using System.Dynamic;
using System.Linq;
using System;

namespace Copper {
    
    class MultiDispatcher : DynamicObject {
        LinkedList<dynamic> others = new LinkedList<dynamic>();

        public ICollection<dynamic> Others { get { return others; } }
        
        public void AddOther( object other ) {
            others.AddLast( other );
        }
        
        public bool RemoveOther( object other ) {
            if( others.Contains( other )  ) {
                others.Remove( other );
                return true;
            }
            
            return false;
        }
        
        public override bool TryInvokeMember( InvokeMemberBinder binder, object[] args, out object result ) {
            var res = new List<object>();

            BindingFlags flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance |
                BindingFlags.FlattenHierarchy |
                BindingFlags.InvokeMethod;
            
            foreach ( var other in others ) {
                object ret;
                
                //Try to invoke the method using reflection. If this does 
                //not work, then it's possible the object is a DynamicObject,
                //so use its TryInvokeMember method
                try {
                    ret = other.GetType().InvokeMember(
                        binder.Name, flags, null, other, args );
                }
                catch (Exception) {
                    if ( other is DynamicObject ) {
                        other.TryInvokeMember( binder, args, out ret );
                    }
                    else {
                        ret = null;
                        throw new PortConnectorNoMethodError( binder.Name, args );
                    }
                }

                res.Add( ret );
            }
            
            result = res;

            return true;
        }
    }

}