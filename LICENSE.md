# License
This file describes the licenses of the different pieces of 
software distributed with Copper. 

## Disclaimer
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.

## License Texts 
Parts of this software are licensed under a variety of different
terms. Copies of some of these licenses are provided in the 
following files:
*	GNU GPL: details avaliable in the file LICENSE.GPL
*	GNU LGPL: details available in the file LICENSE.LGPL
*	MIT X11: text available in the file MIT.X11
*	MPL: text available in the file LICENSE.MPL

## License Choices
The software contained in this package is broken into multiple 
categories for license purposes:

1. 	The Copper library, for building Copper.dll. Located at 
	source/tools/copper  This library is released under the 
	MIT license.

2.	The Copper compiler is a derivative work of the 
	Mono C# compiler (MCS). MCS is released under dual
	MIT and GPL licenses. The Copper compiler is also released 
	under the same dual license (MIT and GPL). 

3.  The parser generator Jay is taken as-is from the mono 
	project; the same license applies:
	> This is a port of Berkeley yacc, so it is available under 
	>the BSD license. See the license in the individual C files 
	>for details.
	
4.	Class Libraries:
	These are the libraries located in source/class. These 
	are taken directly from the Mono project as-is, and the 
	same licenses apply to them:
	
	> All of the core classes licensed under the terms of
	> the MIT X11 license.
	>
	> Third party libraries that we distribute for
	> convenience reasons are distributed under their own
	> terms (all of them allow development of proprietary
	> applications with them).
	>
	> Third party libraries include: ByteFX.Data,
	> ICSharpCode.SharpZipLib, Npgsql, MicrosoftAjaxLibrary.
	>
	> The Microsoft.JScript assembly is covered by the
	> MIT X11 and the Mozilla MPL license as it contains
	> ported pieces of code from Rhino, the Mozilla JavaScript
	> implementations
	
5.  Monop tool: 
	The source code files in the directory source/tools/monop 
	contain a license statement directly.
	
6.  IKVM:
	The IKVM library, located in external/ikvm
	is distributed under its own set of licenses, which 
	are included in its directory.