using System.Dynamic;

namespace Copper {
    public class NullConnector : DynamicObject {
        public NullConnector( IPort p ) {
            port = p;
        }

        private IPort port;

        public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result ) {

            throw new PortNotConnectedError( port );
        }

        public override bool TryGetMember(
            GetMemberBinder binder, out object result ) {

            throw new PortNotConnectedError( port );
        }

        public override bool TrySetMember(
            SetMemberBinder binder, object value ) {

            throw new PortNotConnectedError( port );
        }
    }
}