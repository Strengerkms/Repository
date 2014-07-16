using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
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
using SmartCOM3Lib;


namespace Project_One
{
    
    public partial class MainWindow : Window
    {
        //public _IStClient Trader1;
        public StServerClass SmartCOM = new StServerClass();
        private string ip = "213.247.232.238";
        private ushort port = 8443;
        private string login = "47HNXK";
        private string password = "KZH555";
        private const string paramsSet = "logLevel=4; maxWorkerThreads=3; logFilePath";
        

        private bool IsReady;


        public MainWindow()
        {
            InitializeComponent();
            //logFilePath=E:\\FORTS_data\\Log.txt login:ST51087,password:E04MF5
        }



        private void Create_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (!IsReady) // если SmartCOM не создан
            {
                
                SmartCOM.ConfigureClient(paramsSet);
                IsReady = true;
                
            }
           
        }

        private void Connect_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SmartCOM.connect(ip, port, login, password);
                SmartCOM.Connected += () => SmartCOM.GetPrortfolioList();
                

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }





        }


    }
}
