using System.Collections.Generic;

namespace Copper {
    public interface IConnection {
        ICollection<object> Connectables { get; }
    }

    public class SingleConnection : IConnection {

        public IConnectable First { get; private set; }
        public IConnectable Second { get; private set; }
        public ICollection<object> Connectables {
            get { return new IConnectable[] { First, Second }; }
        }

        public SingleConnection( IConnectable first, IConnectable second ) {
            First = first;
            Second = second;
        }

    }
}