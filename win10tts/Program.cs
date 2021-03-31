using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Speech.Synthesis.TtsEngine;
using System.IO;
using System.Globalization;

namespace win10tts
{
    class Program
    {
        
        ///// <summary>
        ///// 派生自 PromptBuilder，用于简单建构我们需要的特殊类
        ///// </summary>
        //public class VoiceBuilder : PromptBuilder
        //{
        //    /// <summary>
        //    /// 建构
        //    /// </summary>
        //    /// <param name="voiceName">语音库名称，比如 "Microsoft Lili ..."</param>
        //    public VoiceBuilder(string voiceName)
        //    {
        //        base.StartVoice(voiceName);
        //    }
        //    public VoiceBuilder(VoiceInfo info)
        //    {
        //        base.StartVoice(info);
        //    }
        //    public new void EndVoice()
        //    {
        //        base.EndVoice();
        //    }
        //    /// <summary>
        //    /// 让添加的发音文本形式恢复到系统默认状态，即不强调、不快不慢、音量遵循系统设置。
        //    /// </summary>
        //    /// <param name="textToSpeak">要添加的发音文本</param>
        //    public void Add_Text(string textToSpeak)
        //    {
        //        Add_NotSet_Text(textToSpeak);
        //    }
        //    /// <summary>
        //    /// 让添加的发音文本形式恢复到系统默认状态，即不强调、不快不慢、音量遵循系统设置。
        //    /// </summary>
        //    /// <param name="textToSpeak">要添加的发音文本</param>
        //    public void Add_NotSet_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_NotSet_PromptStyle());
        //        base.AppendText(textToSpeak);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 让添加的发音文本语音音量变大，并且有着重、强调的语气
        //    /// </summary>
        //    /// <param name="textToSpeak">要添加的，起强调并大声些的文本</param>
        //    public void Add_StrongLoud_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_StrongLoud_PromptStyle());
        //        base.AppendText(textToSpeak);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 让添加的发音文本语速快些
        //    /// </summary>
        //    /// <param name="textToSpeak">要添加的，语速要快些的文本</param>
        //    public void Add_Fast_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_Fast_PromptStyle());
        //        base.AppendText(textToSpeak);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 让添加的发音文本语速慢些
        //    /// </summary>
        //    /// <param name="textToSpeak">要添加的，语速要慢些的文本</param>
        //    public void Add_Slow_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_Slow_PromptStyle());
        //        base.AppendText(textToSpeak);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 将数序列作为电话号码进行朗读。 例如，把“(306) 555-1212”读作“Area code three zero six five five five one two one two”。
        //    ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
        //    /// </summary>
        //    /// <param name="textToSpeak">要读取的文本内容</param>
        //    public void Add_As_PhoneNumber_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_NotSet_PromptStyle());
        //        base.AppendTextWithHint(textToSpeak,System.Speech.Synthesis.SayAs.Telephone);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 将数序列作为日期进行朗读。 例如，把“05/19/2004”或“19.5.2004”读作为“may nineteenth two thousand four”。
        //    ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
        //    /// </summary>
        //    /// <param name="textToSpeak">要读取的文本内容</param>
        //    public void Add_As_Date_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_NotSet_PromptStyle());
        //        base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.Date);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 将要添加的文本当作时间来读取。例如 把“9:45”读作“nine forty-five”，并把“9:45 am”读作“nine forty-five A M”。
        //    ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
        //    /// </summary>
        //    /// <param name="textToSpeak">要读取的文本内容</param>
        //    public void Add_As_Time_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_NotSet_PromptStyle());
        //        base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.Time);
        //        base.EndStyle();
        //    }
        //    /// <summary>
        //    /// 将要添加的文本当作拼读读取，例如 "clock" 读作 "C L O C K"
        //    ///  注意：添加的文本 的 语速 发音音量 以及 强调语气 都遵循系统设置
        //    /// </summary>
        //    /// <param name="textToSpeak">要读取的文本内容</param>
        //    public void Add_As_SpellOut_Text(string textToSpeak)
        //    {
        //        base.StartStyle(Get_NotSet_PromptStyle());
        //        base.AppendTextWithHint(textToSpeak, System.Speech.Synthesis.SayAs.SpellOut);
        //        base.EndStyle();
        //    }
        //}

        public static void Add_As_Normal_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd);
        }
        public static void Add_As_Fast_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd,PromptRate.Fast);
        }
        public static void Add_As_Slow_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd, PromptRate.Slow);
        }
        public static void Add_As_SoundLoud_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd, PromptVolume.Loud);
        }
        public static void Add_As_SoundMedium_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd, PromptVolume.Medium);
        }
        public static void Add_As_SoundSoft_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendText(textToAdd, PromptVolume.Soft);
        }
        /// <summary>
        /// 当作拼读字符串。串里面的英文单词或者数字都会一个一个字母数字读出来，数字不会当作数来读。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_SpellOut_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.SpellOut);
        }
        /// <summary>
        /// 字符串是当作一个完整的数字来读，而不是拼读。例如：12 读作“十二”，而不是“一二”
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_Number_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.NumberCardinal);
        }
        /// <summary>
        /// 当作电话号码来读，如果前面有区号，还会说出区号来，其余数字会一个一个数字拼读出来。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_Telephone_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.Telephone);
        }
        /// <summary>
        /// 有日期和时间两部分。请留意返回值。过程先尝试去解释日期时间串，然后再分开加入。这样的串可以是 "2021-12-1 14:23" 也可以是 "12/1/2021 14:23" 或者其他欧美国家熟悉的时间表示法。
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        /// <returns></returns>
        public static bool Add_As_DateTime_Text(ref PromptBuilder builder, string textToAdd)
        {
            DateTime dt;
            if (!DateTime.TryParse(textToAdd, out dt))
                return false;
            string sDate = dt.ToString("yyyy-M-d");
            string sTime = dt.ToString("H:m");
            builder.AppendTextWithHint(sDate, System.Speech.Synthesis.SayAs.YearMonthDay);
            builder.AppendTextWithHint(sTime, System.Speech.Synthesis.SayAs.Time24);
            return true;
        }
        /// <summary>
        /// 仅有日期部分
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        /// <returns></returns>
        public static bool Add_As_Date_Text(ref PromptBuilder builder, string textToAdd)
        {
            DateTime dt;
            if (!DateTime.TryParse(textToAdd, out dt))
                return false;
            builder.AppendTextWithHint(dt.ToString("yyyy-M-d"), System.Speech.Synthesis.SayAs.YearMonthDay);
            return true;
        }
        /// <summary>
        /// 仅有时间部分。例如 1:35pm 或者 13:35
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_Time_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.Time);
        }
        /// <summary>
        /// 12小时制时间表示法。例如 1:35pm
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_Time12_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.Time12);
        }
        /// <summary>
        /// 24小时时间表示法。例如 13:35
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="textToAdd"></param>
        public static void Add_As_Time24_Text(ref PromptBuilder builder, string textToAdd)
        {
            builder.AppendTextWithHint(textToAdd, System.Speech.Synthesis.SayAs.Time24);
        }

        // Write each word and its character position to the console.  
        static void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            Console.WriteLine("CharPos: {0}   CharCount: {1}   AudioPos: {2}    \"{3}\"",
              e.CharacterPosition, e.CharacterCount, e.AudioPosition, e.Text);
        }
        static void Main(string[] args)
        {
            LinkedList<VoiceInfo> lst = new LinkedList<VoiceInfo>();
            VoiceInfo selectedVoice = null;
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Output information about all of the installed voices.   
                Console.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in synth.GetInstalledVoices(/*new CultureInfo("zh-HK")*/))
                {
                    lst.AddLast(voice.VoiceInfo);
                    VoiceInfo info = voice.VoiceInfo;
                    string AudioFormats = "";
                    foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
                    {
                        AudioFormats += String.Format("{0}\n",
                        fmt.EncodingFormat.ToString());
                    }

                    if(string.Compare(info.Culture.Name,"zh-HK", true)==0)
                    {
                        if(info.Name.ToLower().StartsWith("microsoft tracy"))
                        {
                            selectedVoice = info;
                        }
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
            
            if(selectedVoice==null)
            {
                Console.Beep();
                Console.WriteLine("没有检索到粤语语音库 Microsoft Tracy，按任意键退出 ...");
                Console.ReadKey();
                return;
            }

            PromptBuilder sayAs = new PromptBuilder();
            sayAs.StartVoice(selectedVoice);
            TimeSpan delay = new TimeSpan(0, 0, 1);
            Add_As_DateTime_Text(ref sayAs, "2021-4-14 23:21");
            sayAs.AppendBreak(delay);
            Add_As_Date_Text(ref sayAs, "2021-4-1");
            sayAs.AppendBreak(delay);
            Add_As_Time_Text(ref sayAs, "23:15");
            sayAs.AppendBreak(delay);
            Add_As_Fast_Text(ref sayAs, "这串文字很快啊");
            sayAs.AppendBreak(delay);
            Add_As_Slow_Text(ref sayAs, "这串文字很慢啊");
            sayAs.AppendBreak(delay);
            Add_As_Normal_Text(ref sayAs, "这里加入了普通文字");
            sayAs.AppendBreak(delay);
            Add_As_Number_Text(ref sayAs, "12345");
            sayAs.AppendBreak(delay);
            Add_As_Number_Text(ref sayAs, "123.45");
            sayAs.AppendBreak(delay);
            Add_As_SoundSoft_Text(ref sayAs, "这里声音很低");
            sayAs.AppendBreak(delay);
            Add_As_SoundMedium_Text(ref sayAs, "这里声音中等");
            sayAs.AppendBreak(delay);
            Add_As_SoundLoud_Text(ref sayAs, "这里声音很大");
            sayAs.AppendBreak(delay);
            Add_As_SpellOut_Text(ref sayAs, "这里 拼读 12345.123 clock is a fox");
            sayAs.AppendBreak(delay);
            Add_As_Telephone_Text(ref sayAs, "(0759) 2134-567");
            sayAs.AppendBreak(delay);
            Add_As_Time12_Text(ref sayAs, "3:45pm");
            sayAs.AppendBreak(delay);
            Add_As_Time12_Text(ref sayAs, "11:10am");
            sayAs.AppendBreak(delay);
            Add_As_Time24_Text(ref sayAs, "13:20");
            sayAs.AppendBreak(delay);
            Add_As_Time24_Text(ref sayAs, "1:10");
            sayAs.AppendBreak(delay);
            Add_As_Time24_Text(ref sayAs, "12:00");
            sayAs.AppendBreak(delay);
            sayAs.EndVoice();

            bool saved = false;

            synth.SpeakProgress +=
              new EventHandler<SpeakProgressEventArgs>(synth_SpeakProgress);

        try_talk_again:
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(sayAs);

        show_menu_again:
            Console.Beep();
            Console.WriteLine("空格键-再读一遍\ns-保存为文件\np-播放保存的文件\n其他按键，退出程序.");

            ConsoleKeyInfo kinfo=Console.ReadKey();

            if(kinfo.KeyChar==0x20)
            {
                goto try_talk_again;
            }
            else if (kinfo.KeyChar == 's' || kinfo.KeyChar == 'S')
            {
                synth.SetOutputToWaveFile(@"D:\\temp\\a.wav");
                synth.Speak(sayAs);
                synth.SetOutputToDefaultAudioDevice();
                saved = true;
                goto show_menu_again;
            }
            else if ((kinfo.KeyChar == 'p' || kinfo.KeyChar == 'P') && saved)
            {
                System.Media.SoundPlayer m_SoundPlayer = new System.Media.SoundPlayer(@"D:\\temp\\a.wav");
                m_SoundPlayer.PlaySync();
                goto show_menu_again;
            }

            sayAs.ClearContent();
            // 释放资源  
            synth.Dispose();
        }
    }
}
