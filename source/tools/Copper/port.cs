using System;
using System.Reflection;
using System.Collections.Generic;

namespace Copper {
    public abstract class Port : PortBase {
        public enum Direction {
            None = 0,
            In,
            Out,
        }

        public override IConnection Connection {
            get { return new SingleConnection( this, Sender ); }
        }

        public Port( object owner ) {
            Embed( owner );
            Sender = new NullConnector( this );
        }

        /*
        public override void Embed( object owner ) {
            if ( owner is Type )
                Owner = new StaticDispatcher( (Type) owner );
            else 
                Owner = owner;
        }*/

        public override void Attach( object other ) {
            //var incompatibles = IncompatibleMethods( other );

            //if ( incompatibles.Count > 0 )
            //    throw new ConnectionIncompatibleError( this, other, incompatibles );
            
            if ( other is Type )
                Sender = new StaticDispatcher( (Type) other );
            else
                Sender = other;
        }
        
        public override void Detach( object other ) {
            if ( other != Sender )
                throw new InvalidDetachmentError( this, other );

            Sender = new NullConnector( this );
        }

        public override void Detach() {
            Sender = new NullConnector( this );
        }


        /// <summary>
        /// A port is compatible with another object, if that object 
        /// possesses a method that corresponds to an "in" method of this port.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public List<MethodInfo> IncompatibleMethods( object other ) {
            var methods = this.GetType().GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );

            var incompatible_methods = new List<System.Reflection.MethodInfo>();

            //loop through each method in the port
            foreach ( var method in methods ) {
                var attrs = method.GetCustomAttributes( true );
                var is_in =
                    Array.Exists( attrs, ( object x ) => x is DirectionInAttribute );
                bool has_match = false; //have we found a match for this method

                //if the given method is an in method, then it needs a matching method
                //that is compatible. Otherwise ignore it.
                if ( !is_in )
                    continue;

                var other_methods = other.GetType().GetMethods();

                foreach ( var other_method in other_methods ) {
                    var other_attrs = other_method.GetCustomAttributes( true );
                    bool other_is_in =
                        Array.Exists( other_attrs, ( object x ) => x is DirectionInAttribute );

                    //if the other name doesn't match up, or if it is also an 'in' 
                    //method, then it cannot be a match.
                    if ( other_method.Name != method.Name || other_is_in ) {
                        continue;
                    }

                    var this_params = method.GetParameters();
                    var other_params = other_method.GetParameters();

                    //if the methods have different parameter counts, they aren't compatible
                    //(ignoring some possibilities with variable arguments)
                    if ( this_params.Length != other_params.Length )
                        continue;

                    //if the methods both have no parameters, they are always compatible
                    if ( this_params.Length == 0 )
                        has_match = true;

                    for ( int i = 0; i < this_params.Length; i++ ) {
                        if ( Type.Equals(
                            ( this_params[i].ParameterType ),
                            ( other_params[i].ParameterType ) ) )
                            has_match = true;
                        Console.WriteLine( this_params[i].ParameterType );
                        Console.WriteLine( other_params[i].ParameterType );
                    }
                }

                if ( !has_match )
                    incompatible_methods.Add( method );

            }

            return incompatible_methods;
        }

        public static void Connect( IConnectable a, IConnectable b ) {
            a.Attach( b );
            b.Attach( a );
        }

        public static void Disconnect( IConnectable a, IConnectable b ) {
            b.Detach( a );
            a.Detach( b );
        }

        public static void Attach( IConnectable a, object b ) {
            a.Attach( b );
        }

        public static void Detach( IConnectable a, object b ) {
            a.Detach( b );
        }
        
        public static void Detach( IConnectable a ) {
            a.Detach();
        }
        
        public static void Embed( IPort a, object owner ) {
            a.Embed( owner );
        }

        public static void ConnectMap( object a, object b, Type map_type ) {
            if ( !( a is IConnectable ) )
                throw new InvalidAttachmentError( a, b );

            if ( !(b is IConnectable) )
                throw new InvalidAttachmentError( b, a );

            var map = (ConnectorMap)Activator.CreateInstance( map_type, a, b );
            var conn1 = new ConnectorMapDispatcher( map, b );
            var conn2 = new ConnectorMapDispatcher( map, a );
            
            ((IConnectable) a).Attach( conn1 );
            ((IConnectable) b).Attach( conn2 );

            //if( b is IConnectable )
            //    ((IConnectable)b).Attach( conn2 );
        }

        public static void AttachMap( object a, object b, Type map_type ) {
            if ( !( a is IConnectable ) )
                throw new InvalidAttachmentError( a, b );

            var map = (ConnectorMap) Activator.CreateInstance( map_type, a, b );
            var conn = new ConnectorMapDispatcher( map, b );
            
            ( (IConnectable) a ).Attach( conn );
        }
    }
}