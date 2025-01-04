using OAManage.Command;
using OAManage.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OAManage.ViewModels
{
    class AccountViewModels:INotifyPropertyChanged
    {


        private AccountModel _AccountModel;

        public event PropertyChangedEventHandler? PropertyChanged;



        /// <summary>
        /// 用户属性(开放给View绑定)
        /// </summary>
        public AccountModel AccountModel
        {
            get {
                if(_AccountModel == null)
                {
                    _AccountModel = new AccountModel();
                }
                return _AccountModel; }
            set {
                _AccountModel = value;
                if(PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AccountModel"));
                }
            }

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login()
        {
            if (AccountModel.Account == "longma" && AccountModel.Pwd == "123")
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                AccountModel = new AccountModel();
                //AccountModel.Account = "";
                //AccountModel.Pwd = "";
            }
        }

        /// <summary>
        /// 命令属性
        /// </summary>
        public ICommand Command
        {
            get
            {
                return new DoCommand(Login);
            }
        }

    }
}
