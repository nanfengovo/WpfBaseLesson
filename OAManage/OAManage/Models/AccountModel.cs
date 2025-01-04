using OAManage.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OAManage.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    class AccountModel
    {
        

        private string _Account;

        //public string Account
        //{
        //    get { return _Account; }
        //    set 
        //    {
        //        _Account = value;
        //        //通知
        //        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Account"));

        //        if(PropertyChanged !=null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("Account"));
        //        }
        //    }

        //}

        //账号
        public string Account { get; set; }

        //密码
        public string Pwd { get; set; }


        private string _Pwd;

        //public string Pwd
        //{
        //    get
        //    {
        //        return _Pwd;
        //    }
        //    set
        //    {
        //        _Pwd = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs("Pwd"));
        //        }
        //    }
        //}

      
       





    }
}
