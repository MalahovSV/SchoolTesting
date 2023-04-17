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

namespace SchholTestingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, UserControl> _controls;

        public MainWindow()
        {
            InitializeComponent();
            declaringControls();
        }

        private void declaringControls()
        {
            _controls= new Dictionary<string, UserControl> ();
            _controls.Add("home", new Controls.HomeControl());
            _controls.Add("news", new Controls.NewsControl());
            _controls.Add("test", new Controls.TestControl());
            _controls.Add("settings", new Controls.SettingsControl());
            _controls.Add("help", new Controls.HelpControl());
        }

        private void setupControl(string name)
        {
            if(ViewPanel.Children.Count > 0)
                ViewPanel.Children.RemoveAt(0);
            ViewPanel.Children.Insert(0, _controls[name]);
        }

        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            setupControl("news");
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            setupControl("home");
        }

        private void TestsButton_Click(object sender, RoutedEventArgs e)
        {
            setupControl("test");
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            setupControl("settings");
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            setupControl("help");
        }
    }
}
