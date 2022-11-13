using System;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;
using AssemblyObserver.View;

namespace WPF.View
{
    public class View : IView
    {
        public void ShowAssemblyInfo(IAssemblyInfo assemblyInfo)
        {

        }


        internal View(MainWindow window)
        {
            _mainWindow = window;
        }

        private MainWindow _mainWindow;
    }
}
