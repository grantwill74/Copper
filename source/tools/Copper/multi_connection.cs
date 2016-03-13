using System;
using System.Collections.Generic;

namespace Copper {

    class MultiConnection : IConnection {
        public IConnectable First { get; private set; }
        public ICollection<object> Others { get; private set; }

        public MultiConnection(IConnectable first, ICollection<object> others) {
            First = first;
            Others = others;
        }
        
        public ICollection<object> Connectables {
            get {
                var set = new SortedSet<object>();
                set.Add( First );
                set.UnionWith( Others ); //If sorted set is a fibonacci set, 
                return set;
            }
        }
    }
}