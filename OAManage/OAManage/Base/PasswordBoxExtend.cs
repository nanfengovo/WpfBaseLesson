using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OAManage.Base
{
    /// <summary>
    /// MyPwd 自定义属性名
    /// 自定义PasswordBox 的依赖属性
    /// </summary>
    internal class PasswordBoxExtend
    {
        
        /// <summary>
        /// 附加属性（特殊的依赖属性）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetMyPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(MyPwdProperty);
        }

        /// <summary>
        /// MyPwd属性赋值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetMyPwd(DependencyObject obj, string value)
        {
            obj.SetValue(MyPwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPwdProperty =
            DependencyProperty.RegisterAttached("MyPwd", typeof(string), typeof(PasswordBoxExtend), new PropertyMetadata("",OnMyPwdChanged));


        /// <summary>
        /// MyPwd → Password  当MyPwd发生改变给Password 赋值
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnMyPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox =  d as PasswordBox;
            if (pwdBox != null)
            {
                pwdBox.Password = (string)e.NewValue;//当MyPwd的值发生变化时，给Password属性赋值
            }


        }

        //Password 发生变化 通知MyPwd也要变
        //如何知道Password
        //通知MyPwd也要变



        public static bool GetIsBind(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBindProperty);
        }

        public static void SetIsBind(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBindProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsBind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBindProperty =
            DependencyProperty.RegisterAttached("IsBind", typeof(bool), typeof(PasswordBoxExtend), new PropertyMetadata(false, OnPropChanged));

        private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = new PasswordBox();
            if( pwdBox != null )
            {
                //1.如果Password属性变化了则通知MyPwd也要变
                //2.没有变则不通知
                if((bool)e.NewValue)
                {
                    pwdBox.PasswordChanged += OnPasswordChanged;
                }
                if((bool)e.OldValue)
                {
                    pwdBox.PasswordChanged -= OnPasswordChanged;
                }
            }
        }





        //赋值
        private static void  OnPasswordChanged(object sender,RoutedEventArgs e)
        {
            PasswordBox pwdBox = sender as PasswordBox;
            if(pwdBox != null)
            {
                SetMyPwd(pwdBox, pwdBox.Password);
            }

        }
    }
}
