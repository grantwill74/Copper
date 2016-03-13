using System.Collections.Generic;
using System.Reflection;
using System.Dynamic;

namespace Copper {
    public static class PortExtensions {
        public static string DirectionName( this Port.Direction d ) {
            return new string[] { "nil", "in", "out" }[(int) d];
        }
    }

    public interface IConnectable {
        void Attach( object other );
        void Detach( object other );
        void Detach();

        IConnection Connection { get; }
        //List<MethodInfo> IncompatibleMethods( object other );
    }

    public interface IPort : IConnectable {
        object Owner { get; }
        bool IsStatic { get; }
        void Embed( object owner );
    }

    public abstract class PortBase : DynamicObject, IPort {
        public bool IsStatic { get { return Owner is StaticDispatcher; } }
        public dynamic Owner { get; protected set; }
        public dynamic Sender { get; protected set; }

        public abstract void Attach( object other );
        public abstract void Detach( object other );
        public abstract void Detach();

        //public abstract void Embed( object owner );
        public void Embed( object owner ) {
            if ( owner is System.Type )
                Owner = new StaticDispatcher( (System.Type) owner );
            else
                Owner = owner;
        }

        public abstract IConnection Connection { get; }
        //public abstract List<MethodInfo> IncompatibleMethods( object other );
    }
}