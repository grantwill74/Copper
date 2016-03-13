using System.Reflection;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Copper {

    public class ConnectorMap {
        public dynamic First { get; private set; }
        public dynamic Second { get; private set; }

        public ConnectorMap(object first, object second) {
            First = first;
            Second = second;
        }
    }

}