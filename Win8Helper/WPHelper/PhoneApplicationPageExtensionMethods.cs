using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.pedrolamas.com/2014/01/20/disabling-screenshot-functionality-in-a-windows-phone-app/
namespace WPHelper
{
    /// <summary>
    /// APP中禁用截图功能
    ///<para>
    /// Disabling screenshot functionality in a Windows Phone app
    /// </para>
    /// </summary>
    public static class PhoneApplicationPageExtensionMethods
    {
        /// <summary>
        /// 是否允许设置截图
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool CanSetScreenCaptureEnabled(this PhoneApplicationPage page)
        {
            return Environment.OSVersion.Version >= new Version(8, 0, 10322);
        }

        public static void SetScreenCaptureEnabled(this PhoneApplicationPage page, bool enabled)
        {
            var propertyInfo = typeof(PhoneApplicationPage).GetProperty("IsScreenCaptureEnabled");

            if (propertyInfo == null)
            {
                throw new NotSupportedException("Not supported in this Windows Phone version!");
            }

            propertyInfo.SetValue(page, enabled);
        }

        public static bool GetScreenCaptureEnabled(this PhoneApplicationPage page)
        {
            var propertyInfo = typeof(PhoneApplicationPage).GetProperty("IsScreenCaptureEnabled");

            if (propertyInfo == null)
            {
                throw new NotSupportedException("Not supported in this Windows Phone version!");
            }

            return (bool)propertyInfo.GetValue(page);
        }

        /* eg
         * 
         * public partial class MainPage : PhoneApplicationPage
         *    {
         *        public MainPage()
         *        {
         *            InitializeComponent();
         *           if (this.CanSetScreenCaptureEnabled())
         *           {
         *               this.SetScreenCaptureEnabled(false);
         *           }
         *       }
         *   }
         */
    }
}
