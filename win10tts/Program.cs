using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Speech.Synthesis.TtsEngine;
using System.IO;

namespace win10tts
{
    ///   
    /// TTS请求参数  
    ///   
    public class TTSConf
    {

        public TTSConf(string text)
        {
            this.text = text;
        }

        public string text; // 内容  
        public string voice;// 声音  
        public PromptStyle style = new PromptStyle(); // 样式  

        public void setRate(String rateStr)
        {
            if (rateStr != null && rateStr != "")
            {
                PromptRate rate = (PromptRate)Enum.Parse(typeof(PromptRate), rateStr);
                this.style.Rate = rate;
            }
        }

        public void setVolume(String volumeStr)
        {
            if (volumeStr != null && volumeStr != "")
            {
                PromptVolume volume = (PromptVolume)Enum.Parse(typeof(PromptVolume), volumeStr);
                this.style.Volume = volume;
            }
        }

        public void setEmphasis(String emphasisStr)
        {
            if (emphasisStr != null && emphasisStr != "")
            {
                PromptEmphasis emphasis = (PromptEmphasis)Enum.Parse(typeof(PromptEmphasis), emphasisStr);
                this.style.Emphasis = emphasis;
            }
        }
    }

    class Program
    {
        
        ///   
        /// 获取系统已安装的声音信息  
        ///   
        ///   
        public static List<VoiceInfo> getVoiceInfos()
        {
            List<VoiceInfo> voiceList = new List<VoiceInfo>();

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    voiceList.Add(voice.VoiceInfo);
                }
            }

            return voiceList;
        }
        ///   
        /// TTS  
        ///   
        ///   
        //public static void tts(TTSConf ttsConf)
        //{
        //    SpeechSynthesizer ss = new SpeechSynthesizer();

        //    PromptBuilder pb = new PromptBuilder();
        //    pb.StartStyle(ttsConf.style);
        //    pb.StartVoice(ttsConf.voice);
        //    pb.AppendText(ttsConf.text);
        //    pb.EndVoice();
        //    pb.EndStyle();

        //    // 将TTS结果保存到流中（可以从流中读取byte并保存到byte[]中）  
        //    MemoryStream ms = new MemoryStream();
        //    ss.SetOutputToWaveStream(ms);
        //    ss.Speak(pb);
        //    ss.SetOutputToNull();


        //    // 将TTS结果保存到wav文件中  
        //    /* 
        //    ss.SetOutputToWaveFile("D:\\a.wav"); 
        //    ss.Speak(pb); 
        //    ss.SetOutputToNull(); 
        //    */

        //    // 将TTS结果输出到音频设备（播放）  
        //    /* 
        //    ss.Speak(pb); 
        //    ss.SetOutputToNull(); 
        //    */

        //    // 释放资源  
        //    ss.Dispose();
        //}
        static void Main(string[] args)
        {
            //List<VoiceInfo> lst = getVoiceInfos();
            LinkedList<VoiceInfo> lst = new LinkedList<VoiceInfo>();

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    lst.AddLast(voice.VoiceInfo);
                    Console.WriteLine("Age:{0} Id:{1} Name:{2} Description:{3} Gender:{4}.",
                        voice.VoiceInfo.Age.ToString(),
                        voice.VoiceInfo.Id,
                        voice.VoiceInfo.Name,
                        voice.VoiceInfo.Description,
                        voice.VoiceInfo.Gender.ToString());
                }
            }
            //Console.ReadKey();

            PromptStyle style = new PromptStyle();
            style.Emphasis = PromptEmphasis.NotSet;
            style.Rate = PromptRate.NotSet;
            style.Volume = PromptVolume.NotSet;

            PromptBuilder pb = new PromptBuilder();

            pb.StartVoice(lst.First.Value);

            pb.StartStyle(style);
            pb.AppendText("1-将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis");
            pb.EndStyle();

            pb.EndVoice();

            SpeechSynthesizer ss = new SpeechSynthesizer();

            // 将TTS结果保存到流中（可以从流中读取byte并保存到byte[]中）  
            MemoryStream ms = new MemoryStream();
            //ss.SetOutputToWaveStream(ms);
            ss.SetOutputToDefaultAudioDevice();
            Console.Beep();
            //Console.ReadKey();
            ss.Speak(pb);
            Console.Beep();
            Console.ReadKey();
            ss.Speak("2-将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis");
            //Console.ReadKey();
            //ss.Speak("3 将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis");
            //ss.Speak("这是一个例子");
            //ss.SetOutputToNull();
            Console.Beep();
            Console.ReadKey();
            // 将TTS结果保存到wav文件中  
            ss.SetOutputToWaveFile("D:\\temp\\a.wav"); 
            ss.Speak(pb);

            // 将TTS结果输出到音频设备（播放）  
            /* 
            ss.Speak(pb); 
            ss.SetOutputToNull(); 
            */

            ss.SetOutputToNull();
            Console.Beep();
            Console.ReadKey();
            //ss.SetOutputToNull();
            // 释放资源  
            ss.Dispose();
        }
    }
}
