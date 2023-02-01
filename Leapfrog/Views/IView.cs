using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.Views
{
    public interface IView
    {
        event EventHandler ViewLoaded;
    }
}
