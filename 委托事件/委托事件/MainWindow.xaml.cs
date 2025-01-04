
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

namespace 委托事件
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


        /// <summary>
        /// 委托给子窗口做+
        /// </summary>
        public void F1()
        {
            this.txtTest.Text = "成功了";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SonWindow son = new SonWindow();
            son.Dele = F1;//委托属性赋值
            son.Show();

        }
    }
}