
namespace Copper {
    [System.AttributeUsage( System.AttributeTargets.Class |
            System.AttributeTargets.Struct )]
    public class ComponentAttribute : System.Attribute { }

    [System.AttributeUsage( System.AttributeTargets.Interface )]
    public class PortInterfaceAttribute : System.Attribute { }

    [System.AttributeUsage( System.AttributeTargets.Class |
        System.AttributeTargets.Struct )]
    public class PortClassAttribute : System.Attribute { }

    [System.AttributeUsage( System.AttributeTargets.Field )]
    public class PortFieldAttribute : System.Attribute { }

    [System.AttributeUsage(
        System.AttributeTargets.Event |
        System.AttributeTargets.Method |
        System.AttributeTargets.Property )]
    public class HasDirectionAttribute : System.Attribute {
        public Port.Direction Direction { get; private set; }

        public HasDirectionAttribute( Port.Direction d ) {
            Direction = d;
        }
    }

    [System.AttributeUsage(
    System.AttributeTargets.Event |
    System.AttributeTargets.Method |
    System.AttributeTargets.Property |
    System.AttributeTargets.Delegate )]
    public class DirectionInAttribute : HasDirectionAttribute {
        public DirectionInAttribute() : base( Port.Direction.In ) { }

    }

    [System.AttributeUsage(
    System.AttributeTargets.Event |
    System.AttributeTargets.Method |
    System.AttributeTargets.Property |
    System.AttributeTargets.Delegate )]
    public class DirectionOutAttribute : HasDirectionAttribute {
        public DirectionOutAttribute() : base( Port.Direction.Out ) { }
    }
}