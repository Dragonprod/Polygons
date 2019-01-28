using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
	interface IManager
	{
		void Undo();
		void Redo();
	}
}
