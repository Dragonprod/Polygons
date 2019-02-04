using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
	public interface ICommand<T>
	{
		T Undo(T input);
		T Redo(T input);
	}
}
