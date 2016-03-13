
/*
    Scratchpad:
 
    creating an empty block:
    expression_block
	: ARROW
	 {
		if (lang_version < LanguageVersion.V_6) {
			FeatureIsNotAvailable (GetLocation ($1), "expression bodied members");
		}

		++lexer.parsing_block;
		start_block (GetLocation ($1));
	 }
	 expression SEMICOLON
	 {
		lexer.parsing_block = 0;
		current_block.AddStatement (new ContextualReturn ((Expression) $3));
		var b = end_block (GetLocation ($4));
		b.IsCompilerGenerated = true;
		$$ = b;
	 }
	;

    using member access:
    new MemberAccess( new SimpleName( 
						"Copper", GetLocation($5) ), attribute_class_name )


    constructors:
    var c = new Constructor (current_type, IDENTIFIER.Value, mods, (Attributes) $1, 
        current_local_parameters, lt.Location);
    ADD: current_type.AddConstructor (c);

    new ConstructorBaseInitializer ((Arguments) $5, GetLocation ($2));
    c.Initializer = (ConstructorInitializer) $9;
    

    fields:
    current_field = new Field (current_type, type, (Modifiers) $2, new MemberName (lt.Value, lt.Location), (Attributes) $1);
		current_type.AddField (current_field);
        
    current_local_parameters = ParametersCompiled.EmptyReadOnlyParameters;
	  	start_block (GetLocation ($1));
        current_field.Initializer = (Expression) $3;
		lbag.AppendToMember (current_field, GetLocation ($1));
		end_block (lexer.Location);
		current_local_parameters = null;
*/

namespace Copper {


    
    //This interface exists solely as a target for extension methods.
    //Port interfaces are implemented as regular interfaces, which themselves
    //implement this particular interface so that I can add convenience methods
    //to them.
    public interface PortInterface { }
    //TODO: Overhaul
    public class PortInterfaceExtensions {
        
    }
}