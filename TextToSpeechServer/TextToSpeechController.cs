using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpeechLib;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TextToSpeechServer
{
    public static class TextToSpeechController
    {
        public static string GetSavePath(string speechText)
        {
            //根据录入内容生成唯一文件名
            string fileName = Md5(speechText).ToUpper();
            fileName += ".wav";

            //获取根目录路径
            string path = HttpRuntime.AppDomainAppPath.ToString();

            //文件夹名称
            string DirectoryName = "音频文件";

            //音频文件夹路径
            string DirectoryPath = path + DirectoryName;

            //判断音频文件夹是否存在
            if (Directory.Exists(DirectoryPath) == false)
            {
                Directory.CreateDirectory(path);
            }

            //wav文件路径
            string FilePath = DirectoryPath + "\\" + fileName;

            //如果已经有该文件，则直接返回文件名
            if (File.Exists(FilePath))
            {
                return fileName;
            }
            //否则生成音频文件
            else
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();

                synth.Volume = 100;

                //设置文件保存位置
                synth.SetOutputToWaveFile(FilePath);

                //电脑中需要安装Huihui的语音包
                synth.SelectVoice("Microsoft Huihui Desktop");//能读中英文

                synth.Speak(speechText);

                synth.SetOutputToNull();

            }
            return fileName;
        }

        /// <summary>
        /// MD5加密，主要根据输入的文字来生成唯一的音频文件名
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Md5(string value)
        {
            var result = string.Empty;
            if (string.IsNullOrEmpty(value)) return result;
            using (var md5 = MD5.Create())
            {
                result = GetMd5Hash(md5, value);
            }
            return result;
        }

        /// <summary>
        /// MD5生成
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }


    }
}