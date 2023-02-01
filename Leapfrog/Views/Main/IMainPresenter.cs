using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.Views.Main
{
    internal interface IMainPresenter
    {
        void SetMainView(IMainView mainView);
        void ShowView();
    }
}
