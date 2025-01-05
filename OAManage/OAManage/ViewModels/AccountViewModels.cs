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


        private AccountModel _AccountModel = new AccountModel();

        public event PropertyChangedEventHandler? PropertyChanged;

        //账号

        public string  Account { 
            get { 
            return _AccountModel.Account;
            } 
            set {   
            _AccountModel.Account = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Account"));
                }
            }
        }


        //密码

        public string  Pwd { get 
            {
                return _AccountModel.Pwd;
            }
            set { 
                _AccountModel.Pwd = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Pwd"));
                }
            }
        }


        /// <summary>
        /// 用户属性(开放给View绑定)
        /// </summary>
        //public AccountModel AccountModel
        //{
        //    get {
        //        if(_AccountModel == null)
        //        {
        //            _AccountModel = new AccountModel();
        //        }
        //        return _AccountModel; }
        //    set {
        //        _AccountModel = value;
        //        if(PropertyChanged!=null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("AccountModel"));
        //        }
        //    }

        //}

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login()
        {
            if (Account == "longma" && Pwd == "123")
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show("登录失败");
                //清空文本框
                //AccountModel = new AccountModel();
                Account = "";
                Pwd = "";
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
