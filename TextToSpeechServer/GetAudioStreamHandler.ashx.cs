using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TextToSpeechServer
{
    /// <summary>
    /// GetAudioStreamHandler 的摘要说明
    /// </summary>
    public class GetAudioStreamHandler : HttpTaskAsyncHandler
    {
        /// <summary>
        /// 获取音频文件所在路径
        /// </summary>
        public string ServerRequestAddress = "http://" + HttpContext.Current.Request.Url.Authority + "/音频文件/{0}";

        /// <summary>
        /// 异步生成音频文件
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ProcessRequestAsync(HttpContext context)
        {
            await Task.Run(() =>
            {
                string speechText = context.Request.Params["SpeechText"].ToString().Trim();

                //将|!|!|转换为换行符
                speechText = speechText.Replace("|!|!|", "\n");
                string fileName = TextToSpeechController.GetSavePath(speechText);
                string requestURL = string.Format(ServerRequestAddress, fileName);
                //直接打开生成的音频文件
                context.Response.Redirect(requestURL);
            });
        }

    }
}