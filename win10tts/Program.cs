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
    class Program
    {
        
        public static PromptStyle Get_NotSet_PromptStyle()
        {
            PromptStyle style = new PromptStyle();
            style.Emphasis = PromptEmphasis.NotSet;
            style.Rate = PromptRate.NotSet;
            style.Volume = PromptVolume.NotSet;
            return style;
        }
        public static void Set_NotSet_PromptStyle(ref PromptStyle style)
        {
            style.Emphasis = PromptEmphasis.NotSet;
            style.Rate = PromptRate.NotSet;
            style.Volume = PromptVolume.NotSet;
        }
        public static PromptStyle Get_StrongLoud_PromptStyle()
        {
            PromptStyle style = new PromptStyle();
            style.Emphasis = PromptEmphasis.Strong;
            style.Rate = PromptRate.NotSet;
            style.Volume = PromptVolume.Loud;
            return style;
        }
        public static void Set_StrongLoud_PromptStyle(ref PromptStyle style)
        {
            style.Emphasis = PromptEmphasis.Strong;
            style.Volume = PromptVolume.Loud;
        }
        public static PromptStyle Get_Fast_PromptStyle()
        {
            PromptStyle style = new PromptStyle();
            style.Emphasis = PromptEmphasis.NotSet;
            style.Rate = PromptRate.Fast;
            style.Volume = PromptVolume.NotSet;
            return style;
        }
        public static void Set_Fast_PromptStyle(ref PromptStyle style)
        {
            style.Rate = PromptRate.Fast;
        }
        public static PromptStyle Get_Slow_PromptStyle()
        {
            PromptStyle style = new PromptStyle();
            style.Emphasis = PromptEmphasis.NotSet;
            style.Rate = PromptRate.Slow;
            style.Volume = PromptVolume.NotSet;
            return style;
        }
        public static void Set_Slow_PromptStyle(ref PromptStyle style)
        {
            style.Rate = PromptRate.Slow;
        }
        /// <summary>
        /// 派生自 PromptBuilder，用于简单建构我们需要的特殊类
        /// </summary>
        public class VoiceBuilder : PromptBuilder
        {
            /// <summary>
            /// 建构
            /// </summary>
            /// <param name="voiceName">语音库名称，比如 "Microsoft Lili ..."</param>
            public VoiceBuilder(string voiceName)
            {
                base.StartVoice(voiceName);
            }
            void End_Voice()
            {
                base.EndVoice();
            }
            /// <summary>
            /// 让添加的发音文本形式恢复到系统默认状态，即不强调、不快不慢、音量遵循系统设置。
            /// </summary>
            /// <param name="textToSpeak">要添加的发音文本</param>
            void Add_Text(string textToSpeak)
            {
                Add_NotSet_Text(textToSpeak);
            }
            /// <summary>
            /// 让添加的发音文本形式恢复到系统默认状态，即不强调、不快不慢、音量遵循系统设置。
            /// </summary>
            /// <param name="textToSpeak">要添加的发音文本</param>
            void Add_NotSet_Text(string textToSpeak)
            {
                base.StartStyle(Get_NotSet_PromptStyle());
                base.AppendText(textToSpeak);
                base.EndStyle();
            }
            /// <summary>
            /// 让添加的发音文本语音音量变大，并且有着重、强调的语气
            /// </summary>
            /// <param name="textToSpeak">要添加的，起强调并大声些的文本</param>
            void Add_StrongLoud_Text(string textToSpeak)
            {
                base.StartStyle(Get_StrongLoud_PromptStyle());
                base.AppendText(textToSpeak);
                base.EndStyle();
            }
            /// <summary>
            /// 让添加的发音文本语速快些
            /// </summary>
            /// <param name="textToSpeak">要添加的，语速要快些的文本</param>
            void Add_Fast_Text(string textToSpeak)
            {
                base.StartStyle(Get_Fast_PromptStyle());
                base.AppendText(textToSpeak);
                base.EndStyle();
            }
            /// <summary>
            /// 让添加的发音文本语速慢些
            /// </summary>
            /// <param name="textToSpeak">要添加的，语速要慢些的文本</param>
            void Add_Slow_Text(string textToSpeak)
            {
                base.StartStyle(Get_Slow_PromptStyle());
                base.AppendText(textToSpeak);
                base.EndStyle();
            }
            /// <summary>
            /// 将数序列作为电话号码进行朗读。 例如，把“(306) 555-1212”读作“Area code three zero six five five five one two one two”。
            ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
            /// </summary>
            /// <param name="textToSpeak">要读取的文本内容</param>
            void Add_As_PhoneNumber_Text(string textToSpeak)
            {
                base.StartStyle(Get_NotSet_PromptStyle());
                base.AppendTextWithHint(textToSpeak,System.Speech.Synthesis.SayAs.Telephone);
                base.EndStyle();
            }
            /// <summary>
            /// 将数序列作为日期进行朗读。 例如，把“05/19/2004”或“19.5.2004”读作为“may nineteenth two thousand four”。
            ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
            /// </summary>
            /// <param name="textToSpeak">要读取的文本内容</param>
            void Add_As_Date_Text(string textToSpeak)
            {
                base.StartStyle(Get_NotSet_PromptStyle());
                base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.Date);
                base.EndStyle();
            }
            /// <summary>
            /// 将要添加的文本当作时间来读取。例如 把“9:45”读作“nine forty-five”，并把“9:45 am”读作“nine forty-five A M”。
            ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
            /// </summary>
            /// <param name="textToSpeak">要读取的文本内容</param>
            void Add_As_Time_Text(string textToSpeak)
            {
                base.StartStyle(Get_NotSet_PromptStyle());
                base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.Time);
                base.EndStyle();
            }
            /// <summary>
            /// 将要添加的文本当作拼读读取，例如 "clock" 读作 "C L O C K"
            ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
            /// </summary>
            /// <param name="textToSpeak">要读取的文本内容</param>
            void Add_As_SpellOut_Text(string textToSpeak)
            {
                base.StartStyle(Get_NotSet_PromptStyle());
                base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.SpellOut);
                base.EndStyle();
            }
        }
        // Write each word and its character position to the console.  
        static void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            Console.WriteLine("CharPos: {0}   CharCount: {1}   AudioPos: {2}    \"{3}\"",
              e.CharacterPosition, e.CharacterCount, e.AudioPosition, e.Text);
        }
        static void Main(string[] args)
        {
            //List<VoiceInfo> lst = getVoiceInfos();
            LinkedList<VoiceInfo> lst = new LinkedList<VoiceInfo>();

            //using (SpeechSynthesizer synth = new SpeechSynthesizer())
            //{
            //    foreach (InstalledVoice voice in synth.GetInstalledVoices())
            //    {
            //        lst.AddLast(voice.VoiceInfo);
            //        Console.WriteLine("Age:{0} Id:{1} Name:{2} Description:{3} Gender:{4}.",
            //            voice.VoiceInfo.Age.ToString(),
            //            voice.VoiceInfo.Id,
            //            voice.VoiceInfo.Name,
            //            voice.VoiceInfo.Description,
            //            voice.VoiceInfo.Gender.ToString());
            //    }
            //}

            // Initialize a new instance of the SpeechSynthesizer.  
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Output information about all of the installed voices.   
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    lst.AddLast(voice.VoiceInfo);
                    VoiceInfo info = voice.VoiceInfo;
                    string AudioFormats = "";
                    foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                    {
                        AudioFormats += String.Format("{0}\n",
                        fmt.EncodingFormat.ToString());
                    }

                    Console.WriteLine(" Name:          " + info.Name);
                    Console.WriteLine(" Culture:       " + info.Culture);
                    Console.WriteLine(" Age:           " + info.Age);
                    Console.WriteLine(" Gender:        " + info.Gender);
                    Console.WriteLine(" Description:   " + info.Description);
                    Console.WriteLine(" ID:            " + info.Id);
                    Console.WriteLine(" Enabled:       " + voice.Enabled);
                    if (info.SupportedAudioFormats.Count != 0)
                    {
                        Console.WriteLine(" Audio formats: " + AudioFormats);
                    }
                    else
                    {
                        Console.WriteLine(" No supported audio formats found");
                    }

                    string AdditionalInfo = "";
                    foreach (string key in info.AdditionalInfo.Keys)
                    {
                        AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
                    }

                    Console.WriteLine(" Additional Info - " + AdditionalInfo);
                    Console.WriteLine();
                }
            }
            Console.Beep();
            Console.WriteLine("即将说出：“1-将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis”");
            Console.ReadKey();


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

            // Add a handler for the SpeakProgress event.  
            ss.SpeakProgress +=
              new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);

            // 将TTS结果保存到流中（可以从流中读取byte并保存到byte[]中）  
            MemoryStream ms = new MemoryStream();
            //ss.SetOutputToWaveStream(ms);
            ss.SetOutputToDefaultAudioDevice();
            Console.Beep();
            //Console.ReadKey();
            ss.Speak(pb);
            Console.Beep();
            Console.WriteLine("即将说出：“2-将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis”");
            Console.ReadKey();
            ss.Speak("2-将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis");
            //Console.ReadKey();
            //ss.Speak("3 将TTS结果输出12345到一二三四五音频设备 Prompt Emphasis");
            //ss.Speak("这是一个例子");
            //ss.SetOutputToNull();
            Console.Beep();
            Console.WriteLine("以下即将播放的内容将会保存到文件...");
            Console.ReadKey();
            // 将TTS结果保存到wav文件中  
            ss.SetOutputToWaveFile(@"D:\\temp\\a.wav"); 
            ss.Speak(pb);

            // 将TTS结果输出到音频设备（播放）  
            /* 
            ss.Speak(pb); 
            ss.SetOutputToNull(); 
            */

            ss.SetOutputToNull();
            Console.WriteLine("点击任何键后即将 回放刚才保存的语音文件...");
            Console.Beep();
            Console.ReadKey();
            // Create a SoundPlayer instance to play the output audio file.  
            System.Media.SoundPlayer m_SoundPlayer =
              new System.Media.SoundPlayer(@"D:\\temp\\a.wav");
            //ss.SetOutputToNull();
            //m_SoundPlayer.Play();
            m_SoundPlayer.PlaySync();
            Console.WriteLine();
            Console.WriteLine("回放结束。Press any key to exit...");
            Console.ReadKey();
            // 释放资源  
            ss.Dispose();
        }
    }
}
