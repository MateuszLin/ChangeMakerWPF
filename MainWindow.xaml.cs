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

namespace ChangeMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CallAlgoritms()
        {
            Alghoritms alghoritm = new Alghoritms();

            alghoritm.PrepareParameters(coins.Text, amount.Text);
            var output = alghoritm.CallGreedyAlghortim();

            var output2 = alghoritm.CallDynamicAlghoritm();


            greedyOutput.Text = output;
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            CallAlgoritms();
        }
    }
}
