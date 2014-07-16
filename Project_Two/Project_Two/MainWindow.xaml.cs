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
using Ecng.Common;
using StockSharp.Logging;
using StockSharp.SmartCom;

namespace Project_Two
{
   
    public partial class MainWindow : Window
    {
        public SmartTrader Trader;
        private readonly LogManager logManager = new LogManager();
        private Boolean IsConnected;
        public robot Robot = new robot();



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!IsConnected)
            {
                if (Login_tb.Text.IsEmpty())
                {
                    MessageBox.Show("Enter Login!");
                    return;
                }
                if (Password_tb.Text == String.Empty)
                {
                    MessageBox.Show("Enter password!");
                    return;
                }

                Trader = new SmartTrader();
                logManager.Listeners.Add(new ConsoleLogListener());
                logManager.Sources.Add(Trader);

                Trader.Login = Login_tb.Text;
                Trader.Password = Password_tb.Text;
                Trader.Address = SmartComAddresses.Demo;
                Trader.Connect();
                Trader.Connected += () =>
                {
                    Trader.StartExport();
                    MessageBox.Show("Export Started!");
                };
                

            }



        }
    }
}
