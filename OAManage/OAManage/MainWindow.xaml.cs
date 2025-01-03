using OAManage.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OAManage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 账号Model
        /// </summary>
        private AccountModel accountModel;
        public MainWindow()
        {
            InitializeComponent();
            //设置数据上下文
            accountModel = new AccountModel();
            this.DataContext = accountModel ;
            
        }

       

      
    }
}