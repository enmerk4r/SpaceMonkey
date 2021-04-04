using SpaceMonkey.Rhinoceros.ViewModels;
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

namespace SpaceMonkey.Rhinoceros.Views
{
    /// <summary>
    /// Interaction logic for SpaceMonkeyDocPanel.xaml
    /// </summary>
    public partial class SpaceMonkeyDocPanel : UserControl
    {
        public static SpaceMonkeyDocPanel Instance;
        public SpaceMonkeyDocPanel(uint documentSerialNumber)
        {
            DataContext = new SpaceMonkeyDocPanelViewModel(documentSerialNumber);
            InitializeComponent();
            Instance = this;
        }
    }
}
