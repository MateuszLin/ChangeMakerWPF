using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

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
            string coinsStr = coins.Text, amountStr = amount.Text;

            SolveButton.IsEnabled = false;

            Task.Run(() =>
            {
                Debug.WriteLine("Task started");
                Alghoritms alghoritm = new Alghoritms();
                if (alghoritm.PrepareParameters(coinsStr, amountStr))
                {
                    var output = alghoritm.CallGreedyAlghortim();
                    var output2 = alghoritm.CallDynamicAlghoritm();

                    greedyOutput.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        greedyOutput.Text = output;
                    }));

                    dynamicOutput.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dynamicOutput.Text = output2;
                    }));

                    SolveButton.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SolveButton.IsEnabled = true;
                    }));

                }
            });
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            CallAlgoritms();
        }
    }
}
