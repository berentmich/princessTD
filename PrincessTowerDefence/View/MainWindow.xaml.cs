using PrincessTowerDefence.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrincessTowerDefence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BoardController boardController = new BoardController();
            ControlPanelController controlPanelController = new ControlPanelController();
            boardController.controlPanel = controlPanelController;
            ((UserControl)(((Grid)(this.Content)).Children[0])).DataContext = controlPanelController;
            ((UserControl)(((Grid)(this.Content)).Children[1])).DataContext = boardController;
        }
    }
}
