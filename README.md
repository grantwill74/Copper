# Copper
This is the official source of the Copper research language, 
a Component Oriented Programming Language (COPL). Copper is 
built on top of the Mono C# Compiler (MCS), and extends C# 
to have .

## How to Get Copper
Click on the "releases" tab on github, or follow this link:
https://github.com/seelprojects/copper/releases

For pre-release version 0.1.0, scroll to the bottom of the page 
and download the .zip file.

## Examples
Sample code is located in the 'examples/' directory. To build 
the samples, run the file build_examples.bat. These samples 
include the following:
*	basic_features.cop: This file demonstrates the basic features of 
	copper, such as ports, components, and connections.
*	connection_map.cop: This file demonstrates the connection map,
	a feature unique to copper. This feature is demonstrated by 
	connecting incompatible ports.
*	multiport.cop: This file demonstrates multiports, which 
	allow two-way communication over a one-to-many connection.
*	component_object_transparency.cop: Demonstrates the ability
	for copper ports to be attached to ordinary objects.
*	static_port.cop: Demonstrates that Copper allows ports to 
	be declared static, in order to associate them with a type 
	rather than with an instance.

## How to Use
Copper comes pre-built for the windows platform. 

For the binary distribution, download the CopperBinary 
release. Then, you can build the 
examples with the batch file in the 'examples/' directory. The 
examples demonstrate how to create a basic Copper program and build 
it. The copper compiler is named "copperc". It supports most of 
the command-line arguments that the mono C# compiler does. Type:
"copperc -help" for more information.

For the source distribution,  download the project
using the "Download ZIP" button in GitHub or clone the repository
to your computer. 

## Using the compiler 
To compiler copperc on a single file, run:
"copperc <filename>.cop"
The output will be filename.exe

Copper supports the same command line flags as the mono C# compiler 
(mcs).

## Building
Copper was built with Visual Studio 2015. The solution file for copper 
is "mcs.sln" (because it was a modification of the mcs compiler). 

## Known Issues
*	Currently, port methods are not allowed to contain 'out' parameters
	due to a problem with flow analysis in the Mono compiler.

## License
Please read the file LICENSE.md for license information.

## Disclaimer
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.