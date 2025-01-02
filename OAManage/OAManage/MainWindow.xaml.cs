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
        public MainWindow()
        {
            InitializeComponent();
            //设置数据上下文
            this.DataContext = this;
        }

        //账号
        public string Account { get; set; }

        //密码
        public string Pwd { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Login(object sender, RoutedEventArgs e)
        {
          

            if(Account == "longma" && Pwd=="123" )
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                //清空文本框
                this.Account = "";
                this.Pwd = "";
                MessageBox.Show("登录失败");
                
            }

        }
    }
}