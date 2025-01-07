using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OAManage.Base
{
    /// <summary>
    /// PasswordBox的附加属性
    /// </summary>
    internal class PasswordBoxExtend
    {


        public static string GetMyPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(MyPwdProperty);
        }

        public static void SetMyPwd(DependencyObject obj, string value)
        {
            obj.SetValue(MyPwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPwdProperty =
            DependencyProperty.RegisterAttached("MyPwd", typeof(string), typeof(PasswordBoxExtend),new PropertyMetadata("",OnMyPwdChanged));


        /// <summary>
        /// MyPwd发生改变要通知password
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnMyPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = d as PasswordBox;
            if(pwdBox != null)
            {
                pwdBox.Password = (string)e.NewValue;

                //将光标移到最后
                SetSelection(pwdBox,pwdBox.Password.Length,0);
            }

        }

        /// <summary>
        /// 设置光标位置
        /// </summary>
        /// <param name="passwordBox"></param>
        /// <param name="start">光标开始位置</param>
        /// <param name="length">选中长度</param>
        private static void SetSelection(PasswordBox passwordBox, int start, int length)
        {
            passwordBox.GetType()
                       .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                       .Invoke(passwordBox, new object[] { start, length });
        }

        //password发生变化时，通知MyPwd也要变
        //1、如何知道Password变化
        //2、通知MyPwd也要变


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
            DependencyProperty.RegisterAttached("IsBind", typeof(bool), typeof(PasswordBoxExtend), new PropertyMetadata(false,OnPropChanged));

        private static void OnPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwdBox = d as PasswordBox;
            if(pwdBox != null)
            {
                //1、如果变化，则通知MyPwd也要变
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
        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwdBox = sender as PasswordBox;
            if(pwdBox != null)
            {
                SetMyPwd(pwdBox, pwdBox.Password);
            }
        }
    }
}
