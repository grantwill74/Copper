using System.Reflection;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Copper {

    public class MultiPort : PortBase {

        public MultiPort( object owner ) {
            Embed( owner );
            Sender = new NullConnector( this );
        }
        
        public override void Attach( object other ) {
            if ( Sender == null || Sender is NullConnector )
                Sender = new MultiDispatcher();

            var to_add = other;

            if ( other is Type )
                to_add = new StaticDispatcher( (Type)other );

            ( (MultiDispatcher) Sender ).AddOther( to_add );

            //Console.WriteLine( "Attaching multi. Count: " + ((MultiDispatcher) Sender ).Others.Count );
        }

        public override void Detach( object other ) {
            if ( Sender is NullConnector || 
                !( (MultiDispatcher) Sender ).RemoveOther( other ) )
                    throw new InvalidDetachmentError( this, other );
        }

        public override void Detach() {
            Sender = new NullConnector( this );
        }

        public override IConnection Connection {
            get {
                if ( Sender is NullConnector )
                    return null;
                
                var first = Owner;
                var rest = ( (MultiDispatcher) Sender ).Others;
                return new MultiConnection( first, rest );
            }
        }
    }

}