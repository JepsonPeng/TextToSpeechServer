using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextToSpeechServer
{
    public partial class TextToSpeechPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取当前部署的服务器IP地址，生成HTTP请求链接
        /// </summary>
        public string RequestURL = "http://" + HttpContext.Current.Request.Url.Authority + "//GetAudioStreamHandler.ashx?SpeechText={0}";


        /// <summary>
        /// 生成按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ConvertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConvertTextBox.Text))
            {
                ConvertTextBox.Text = "请输入信息";
            }
            else
            {
                //替换换行符，纺织报错
                string CheckedURL = string.Format(RequestURL, ConvertTextBox.Text).Replace("\n", "|!|!|");
                Response.Redirect(CheckedURL);
            }
        }
    }
}