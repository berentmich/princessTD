using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrincessTowerDefence.Controller
{
    public class PositioningCommand : ICommand
    {
        public PositioningCommand()
        {
        }

        public void Execute(object parameter)
        {
            Point mousePos = Mouse.GetPosition((IInputElement)parameter);

        }

        public bool CanExecute(object parameter) { return true; }

        public event EventHandler CanExecuteChanged;
    }
}
