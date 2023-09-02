using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Sockets;
using System.Net.Http;
using TimersTimer = System.Timers.Timer;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Principal;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Animation;
using static System.Windows.Forms.Design.AxImporter;

namespace Singboxui_refactored
{

    public partial class Form1 : Form
    {
        private Dictionary<string, Color[]> themePalettes = new Dictionary<string, Color[]>
        {
            ["bluePalette"] = new Color[] { Color.FromArgb(31, 165, 243), Color.FromArgb(25, 135, 198), Color.FromArgb(20, 106, 156), Color.FromArgb(135, 135, 135) },
            ["redPalette"] = new Color[] { Color.FromArgb(203, 72, 69), Color.FromArgb(176, 61, 59), Color.FromArgb(153, 47, 45), Color.FromArgb(135, 135, 135) },
            ["yellowPalette"] = new Color[] { Color.FromArgb(221, 198, 0), Color.FromArgb(208, 186, 0), Color.FromArgb(179, 160, 1), Color.FromArgb(135, 135, 135) },
            ["purplePalette"] = new Color[] { Color.FromArgb(127, 80, 210), Color.FromArgb(110, 69, 182), Color.FromArgb(93, 59, 153), Color.FromArgb(135, 135, 135) },
            ["bluegrayPalette"] = new Color[] { Color.FromArgb(123, 157, 192), Color.FromArgb(101, 130, 160), Color.FromArgb(84, 108, 134), Color.FromArgb(135, 135, 135) },
            ["brownPalette"] = new Color[] { Color.FromArgb(141, 110, 99), Color.FromArgb(123, 95, 85), Color.FromArgb(112, 86, 77), Color.FromArgb(135, 135, 135) },
            ["tealPalette"] = new Color[] { Color.FromArgb(8, 132, 132), Color.FromArgb(6, 118, 118), Color.FromArgb(4, 100, 100), Color.FromArgb(135, 135, 135) },
            ["orangePalette"] = new Color[] { Color.FromArgb(214, 146, 44), Color.FromArgb(195, 133, 39), Color.FromArgb(176, 120, 35), Color.FromArgb(135, 135, 135) },
            ["pinkPalette"] = new Color[] { Color.FromArgb(236, 64, 122), Color.FromArgb(213, 57, 110), Color.FromArgb(197, 53, 102), Color.FromArgb(135, 135, 135) }
        };

        Color[] theme = new Color[4];

        string themeName = Properties.Settings.Default.Theme ?? "bluePalette";
        bool isDarkMode = Properties.Settings.Default.IsDarkMode;
        string language = Properties.Settings.Default.Language;
        private TimersTimer timer;
        private HttpClient httpClient;
        bool isIpHidden = Properties.Settings.Default.IsIpHidden1;
        string dns = Properties.Settings.Default.DNS;


        List<string> randomFacts = new List<string>
        {
            "Victorians once used leeches to predict the weather.",
            "Your funny bone is actually a nerve.",
            "The most requested funeral song in England is by Monty Python.",
            "Research shows that all blue-eyed people may be related.",
            "Charles Darwin's personal pet tortoise didn't die until recently.",
            "The average person will spend six months of their life waiting for red lights to turn green.",
            "A bolt of lightning contains enough energy to toast 100,000 slices of bread.",
            "President Lyndon B. Johnson owned a water-surfing car.",
            "David Bowie helped topple the Berlin Wall.",
            "Cherophobia is the word for the irrational fear of being happy.",
            "You can hear a blue whale's heartbeat from two miles away.",
            "Nearly 30,000 rubber ducks were lost at sea in 1992 and are still being discovered today.",
            "The inventor of the frisbee was turned into a frisbee after he died.",
            "There's a bridge exclusively for squirrels.",
            "Subway footlongs aren't always a foot long.",
            "Marie Curie's notebooks are still radioactive.",
            "One in three divorce filings include the word 'Facebook.'",
            "Blood banks in Sweden notify donors when blood is used.",
            "Instead of saying 'cheese' before taking a picture, Victorians said 'prunes.'",
            "Roosters have built-in earplugs.",
            "The Netherlands is so safe, it imports criminals to fill jails.",
            "The world's largest pyramid isn't in Egypt.",
            "We may have already had alien contact.",
            "You can smell rain.",
            "Dolphins have actual names.",
            "Cold water is just as cleansing as hot water.",
            "Incan people used knots to keep records.",
            "Water bottle expiration dates are for the bottle, not the water.",
            "South Koreans are four centimeters taller than North Koreans.",
            "The world's most successful pirate was a woman.",
            "Pandas fake pregnancy for better care.",
            "Indians spend 10+ hours a week reading, more than any other country in the world.",
            "Pineapples were named after pine cones.",
            "The IKEA catalog is the most widely printed book in history.",
            "Crocodiles are one of the oldest living species, having survived for more than 200 million years.",
            "Doritos are flammable and can be used as kindling.",
            "It's illegal to own only one guinea pig in Switzerland.",
            "The first written use of 'OMG' was in a 1917 letter to Winston Churchill.",
            "Dead skin cells are a main ingredient in household dust",
            "There’s enough gold inside Earth to coat the planet"
        };
        public Form1()
        {

            InitializeComponent();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            isDarkMode = Properties.Settings.Default.IsDarkMode;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            //notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                Random random = new Random();
                string fact = randomFacts[random.Next(0, randomFacts.Count)];
                string message = $"Please run the application as Administrator\n" +
                                 "I know, we could make the app ask for UAC privilege but that can cause Windows Defender to detect the app as a trojan!\n" +
                                 "So please run the app as Administrator manually.\nAlso: We don't need the UAC access, Sing-Box Core needs it!\n" +
                                 $"Anyways, here's a random fact:\n\n{fact}\n\n" +
                                 "-Dave";

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            AdjustLanguage(string.IsNullOrEmpty(language) ? "english" : language);
            themeName = Properties.Settings.Default.Theme ?? "bluePalette";
            this.BackColor = Color.FromArgb(238, 238, 238);
            this.ForeColor = Color.FromArgb(33, 45, 64);
            if (themePalettes.TryGetValue(themeName, out Color[] selectedPalette)) { theme = selectedPalette; }
            else { theme = themePalettes["bluePalette"]; }
            AdjustMode(isDarkMode);
            LoadComboBoxItems();
            darkModeToolStripMenuItem.Checked = isDarkMode;
            httpClient = new HttpClient();
            timer = new TimersTimer(2000);
            timer.Elapsed += async (sender, e) => await UpdateLocationAndIP();
            timer.Elapsed += async (sender, e) => { await UpdateUIBasedOnConnection(); };
            timer.Start();



        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string downloadUrl = e.Argument.ToString();
                using (HttpClient httpClient = new HttpClient())
                {
                    var newExe = httpClient.GetByteArrayAsync(downloadUrl).Result;
                    File.WriteAllBytes("SingboxUI_new.zip", newExe);
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }

            try
            {
                string zipPath = "SingboxUI_new.zip";
                string unzipPath = "NewVersion";
                if (Directory.Exists(unzipPath))
                {
                    Directory.Delete(unzipPath, true);
                }

                if (!File.Exists(zipPath))
                {
                    MessageBox.Show($"Zip file not found at {zipPath}");
                    return;
                }

                ZipFile.ExtractToDirectory(zipPath, unzipPath);

                string batchCommands = "@echo off\n"
                                        + "taskkill /f /im SingboxUI.exe\n"
                                        + "timeout /t 5 /nobreak\n"
                                        + "if exist clash.db del /f clash.db\n"
                                        + "if exist geoip.db del /f geoip.db\n"
                                        + "if exist sing-box.exe del /f sing-box.exe\n"
                                        + "if exist SingboxUI.exe del /f SingboxUI.exe\n"
                                        + $"xcopy \"{unzipPath}\\*\" \"{AppDomain.CurrentDomain.BaseDirectory}\" /s /e /i /y\n"
                                        + "start SingboxUI.exe\n"
                                        + "exit";

                File.WriteAllText("update.bat", batchCommands);

                Process.Start(new ProcessStartInfo
                {
                    FileName = "update.bat",
                    UseShellExecute = true,
                    CreateNoWindow = true
                });

                Task.Delay(2000).ContinueWith(_ =>
                {
                    Application.Exit();
                });
            }
            catch (Exception ex1)
            {
                MessageBox.Show($"Failed to update the application: {ex1.Message}");
            }
        }

        static void ModifyOverrideAddress(string newAddress)
        {
            string configPath = "config.json";
            string text = File.ReadAllText(configPath, Encoding.UTF8);
            JObject configData = JObject.Parse(text);

            JToken inbounds = configData["inbounds"];
            foreach (var inbound in inbounds)
            {
                // Checking if this object has "override_port": 53
                if ((int?)inbound["override_port"] == 53)
                {
                    // Changing the "override_address"
                    inbound["override_address"] = newAddress;
                    break;
                }
            }

            File.WriteAllText(configPath, configData.ToString(), new UTF8Encoding(false));
        }

        static void ModifyConfig(bool flag)
        {
            string configPath = "config.json";
            string text = File.ReadAllText(configPath, Encoding.UTF8);
            JObject configData = JObject.Parse(text);

            JToken inbounds = configData["inbounds"];
            JObject item = new JObject
            {
                ["type"] = "tun",
                ["tag"] = "tun-in",
                ["domain_strategy"] = "",
                ["interface_name"] = "tun0",
                ["inet4_address"] = "172.19.0.1/30",
                ["mtu"] = 9000,
                ["auto_route"] = true,
                ["strict_route"] = true,
                ["stack"] = "system",
                ["endpoint_independent_nat"] = true,
                ["sniff"] = true,
                ["sniff_override_destination"] = true
            };

            if (flag == false)
            {
                JArray newArray = new JArray();
                foreach (var inbound in inbounds)
                {
                    if ((string)inbound["type"] != "tun")
                    {
                        newArray.Add(inbound);
                    }
                }
                configData["inbounds"] = newArray;
            }
            else if (flag == true)
            {
                if (!inbounds.Contains(item))
                {
                    ((JArray)inbounds).Add(item);
                }
            }

            File.WriteAllText(configPath, configData.ToString(), new UTF8Encoding(false));
        }

        static int? FindMixedPort()
        {
            string configPath = "config.json";
            string text = File.ReadAllText(configPath, Encoding.UTF8);
            JObject configData = JObject.Parse(text);
            JToken inbounds = configData["inbounds"];

            foreach (var inbound in inbounds)
            {
                if ((string)inbound["type"] == "mixed")
                {
                    return (int)inbound["listen_port"];
                }
            }
            return null;
        }


        private void AdjustMode(bool isDarkMode)
        {
            this.BackColor = isDarkMode ? Color.FromArgb(45, 45, 48) : Color.White;
            themeName = Properties.Settings.Default.Theme ?? "bluePalette";
            if (themePalettes.TryGetValue(themeName, out Color[] selectedPalette)) { theme = selectedPalette; }

            foreach (Control c in this.Controls)
            {
                switch (c)
                {
                    case Button button:
                        button.BackColor = isDarkMode ? theme[0] : theme[0];
                        button.ForeColor = isDarkMode ? Color.White : Color.Black;
                        break;

                    case Label label:
                        label.ForeColor = isDarkMode ? Color.White : Color.Black;
                        break;

                    case TextBox textBox:
                        textBox.BackColor = isDarkMode ? theme[0] : theme[0];
                        textBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                        break;

                    default:
                        break;
                    case ComboBox comboBox:
                        comboBox.BackColor = isDarkMode ? theme[0] : theme[0];
                        comboBox.ForeColor = isDarkMode ? Color.White : Color.Black;
                        break;
                }
            }

            statusStrip1.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
            toolStripStatusLabel1.ForeColor = isDarkMode ? Color.LightGray : Color.Black;

            menuStrip1.BackColor = isDarkMode ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = isDarkMode ? Color.LightGray : Color.Black;
            }
        }

        private Dictionary<string, Dictionary<string, string>> _languages;
        public string GetLocalizedString(string language, string key)
        {
            _languages = new Dictionary<string, Dictionary<string, string>>
            {

{
               "english", new Dictionary<string, string>
               {
                   {"deleteall" , "Delete All"},
                   {"colors" , "Colors" },
                   {"singboxconnected","User is connected to sing-box."},
                   {"singboxdisconnected","User is NOT connected to sing-box."},
                   { "darkmode", "Dark Mode" },
                   {"appearance" , "Appearance" } ,
                   {"exit" , "Exit Confirmation"},
                   {"deleteitem" , "Delete current link"},
                   {"exitsure" , "Are you sure you want to exit the SingBoxUI?"},
                   {"exiting" , "Exiting SingBoxUI..."},
                   {"secretissue" , "Either Secret code is wrong or there's a connection problem!"},
                   {"hideip" , "Show IP Data"},
                   {"showip" , "Hide IP Data"},
                   {"dns", "DNS" },
                   {"sublink" , "Subscription Link: "},
                   {"localconfig" , "Use Local Config"},
                   {"vpnmode" , "VPN Mode (Reconnection Required)"},
                   {"connect" , "CONNECT"},
                   {"disconnect" , "DISCONNECT"},
                   {"singdash" , "Open Sing-Box Dashboard"},
                   {"availservers" , "Available Servers"},
                   {"menu" , "Menu"},
                   {"lang" , "Language 🌐"},
                   {"about" , "About"},
                   {"downloading" , "Downloading Config File..."},
                   {"downloaded" , "Config File Downloaded!"},
                   {"downloadingerror" , "Failed to download the config file"},
                   {"wronglink" , "Wrong link or no internet connection!"},
                   {"nolocalconfig" , "There is no Local config.json file in application folder!"},
                   {"vpnmodeon" , "VPN Mode: ON"},
                   {"proxyport" , "Proxy Port: "},
                   {"singboxrunning" , "Sing-Box is running!"},
                   {"somethingwrong" , "Something went wrong! Try again!"},
                   {"fetchingerror" , "There is a problem with fetching your subscription link!" },
                   {"singboxnotrunning" , "Sing-Box is NOT running"}
               }
},
           {
    "persian", new Dictionary<string, string>
               {
                   {"hideip" , "نمایش  آی‌پی"},
                   {"showip" , "پنهان کردن آی‌پی"},
                   {"dns", "دی ان اس (DNS)" },
                   {"deleteall" , "حذف همه"},
                   {"colors" , "رنگبندی" },
                   {"appearance" , "ظاهر برنامه" },
                   { "singboxconnected", "اتصال به سینگ باکس برقرار است" },
                   { "singboxdisconnected", "اتصال به سینگ باکس برقرار نیست" },
                   {"darkmode" , "حالت تاریک" },
                   {"deleteitem" , "حذف لینک کنونی"},
                   {"exit" , "تأیید خروج"},
                   {"exitsure" , "آیا مطمئن هستید که می خواهید از SingBoxUI خارج شوید؟"},
                   {"exiting" , "در حال خروج از SingBoxUI ..."},
                   {"secretissue" , "یا کد رمز اشتباه است یا مشکل ارتباطی وجود دارد!"},
                   {"refresh" , "به روز رسانی"},
                   {"sublink" , "لینک اشتراک: "},
                   {"localconfig" , "استفاده از پیکربندی محلی"},
                   {"vpnmode" , "حالت VPN (نیاز به اتصال مجدد)"},
                   {"connect" , "اتصال"},
                   {"disconnect" , "قطع اتصال"},
                   {"singdash" , "باز کردن داشبورد Sing-Box"},
                   {"availservers" , "سرورهای موجود"},
                   {"menu" , "منو"},
                   {"lang" , "زبان 🌐"},
                   {"about" , "درباره"},
                   {"downloading" , "در حال دانلود فایل پیکربندی..."},
                   {"downloaded" , "فایل پیکربندی دانلود شد!"},
                   {"downloadingerror" , "ناموفق در دالنود فایل پیکربندی"},
                   {"wronglink" , "لینک اشتباه است یا اتصال اینترنتی وجود ندارد!"},
                   {"nolocalconfig" , "فایل config.json در پوشه برنامه وجود ندارد!"},
                   {"vpnmodeon" , "حالت VPN: روشن"},
                   {"proxyport" , "پورت پروکسی: "},
                   {"singboxrunning" , "Sing-Box در حال اجرا است!"},
                   {"somethingwrong" , "مشکلی پیش آمده است! دوباره تلاش کنید!"},
                   {"fetchingerror" , "مشکلی در دانلود لینک اشتراک شما وجود دارد!"},
                   {"singboxnotrunning" , "Sing-Box در حال اجرا نیست"}
               }
           },

                       {
    "russian", new Dictionary<string, string>
               {
                   {"hideip" , "Показать данные IP"},
                   {"dns", "DNS" },
                   {"showip" , "Скрыть данные IP"},
                   {"appearance" , "Внешний вид"},
                   {"colors" , "Цвета" },
                   { "singboxconnected", "Пользователь подключен к sing-box." },
                   { "singboxdisconnected", "Пользователь НЕ подключен к sing-box." },
                   {"darkmode" , "Тёмный режим"},
                   {"deleteall" , "Удалить все"},
                   {"deleteitem" , "Удалить текущую ссылку"},
                   {"exit" , "Подтверждение выхода"},
                   {"exitsure" , "Вы уверены, что хотите выйти из SingBoxUI?"},
                   {"exiting" , "Выход из SingBoxUI..."},
                   {"secretissue" , "Секретный код неверный или проблема с соединением!"},
                   {"refresh" , "Обновить"},
                   {"sublink" , "Ссылка на подписку: "},
                   {"localconfig" , "Использовать локальную конфигурацию"},
                   {"vpnmode" , "Режим VPN (Требуется переподключение)"},
                   {"connect" , "ПОДКЛЮЧИТЬ"},
                   {"disconnect" , "ОТКЛЮЧИТЬ"},
                   {"singdash" , "Открыть панель управления Sing-Box"},
                   {"availservers" , "Доступные серверы"},
                   {"menu" , "Меню"},
                   {"lang" , "Язык 🌐"},
                   {"about" , "О программе"},
                   {"downloading" , "Загрузка файла конфигурации..."},
                   {"downloaded" , "Файл конфигурации загружен!"},
                   {"downloadingerror" , "Не удалось загрузить файл конфигурации"},
                   {"wronglink" , "Неправильная ссылка или отсутствует интернет-соединение!"},
                   {"nolocalconfig" , "В папке приложения нет файла local config.json!"},
                   {"vpnmodeon" , "РЕЖИМ VPN: ВКЛ"},
                   {"proxyport" , "Прокси-порт: "},
                   {"singboxrunning" , "Sing-Box работает!"},
                   {"somethingwrong" , "Что-то пошло не так! Попробуйте ещё раз!"},
                   {"fetchingerror" , "Есть проблема с получением вашей ссылки на подписку!"},
                   {"singboxnotrunning" , "Sing-Box НЕ работает"}
               }
           },

                                   {
    "chinese", new Dictionary<string, string>
               {
                   {"hideip" , "显示IP数据"},
                   {"dns", "DNS" },
                   {"showip" , "隐藏IP数据"},
                   {"appearance" , "外观"},
                   {"colors" , "颜色" },
                   { "singboxconnected", "用户已连接到sing-box。" },
                   { "singboxdisconnected", "用户未连接到sing-box。" },
                   {"darkmode",  "暗黑模式"},
                   {"deleteall" , "删除所有"},
                   {"deleteitem" , "删除当前链接"},
                   {"exit" , "退出确认"},
                   {"exitsure" , "您确定要退出SingBoxUI吗？"},
                   {"exiting" , "正在退出SingBoxUI..."},
                   {"secretissue" , "秘密代码错误或存在连接问题！"},
                   {"refresh" , "刷新"},
                   {"sublink" , "订阅链接："},
                   {"localconfig" , "使用本地配置"},
                   {"vpnmode" , "VPN模式（需要重新连接）"},
                   {"connect" , "连接"},
                   {"disconnect" , "断开连接"},
                   {"singdash" , "打开Sing-Box控制面板"},
                   {"availservers" , "可用服务器"},
                   {"menu" , "菜单"},
                   {"lang" , "语言 🌐"},
                   {"about" , "关于"},
                   {"downloading" , "正在下载配置文件..."},
                   {"downloaded" , "配置文件已下载！"},
                   {"downloadingerror" , "无法下载配置文件"},
                   {"wronglink" , "链接错误或无互联网连接！"},
                   {"nolocalconfig" , "应用程序文件夹中没有本地config.json文件！"},
                   {"vpnmodeon" , "VPN模式：开启"},
                   {"proxyport" , "代理端口："},
                   {"singboxrunning" , "Sing-Box正在运行！"},
                   {"somethingwrong" , "出了点问题！再试一次！"},
                   {"fetchingerror" , "获取订阅链接时出现问题!"},
                   {"singboxnotrunning" , "Sing-Box未在运行"}
               }
           }

       };

            if (_languages.TryGetValue(language, out var langDict))
            {
                if (langDict.TryGetValue(key, out var localizedString))
                {
                    return localizedString;
                }
                else
                {
                    return $"Key '{key}' not found in language '{language}'";
                }
            }
            else
            {
                return $"Language '{language}' not found";
            }
        }

        private void AdjustLanguage(string language)

        {
            toolStripStatusLabel1.Text = "I'm a status bar";
            colorsToolStripMenuItem.Text = GetLocalizedString(language, "colors");
            label1.Text = "Location | IP :";
            label2.Text = "Updating..";
            dns = Properties.Settings.Default.DNS;
            if (dns == "")
            {
                textBox3.Text = "8.8.8.8";
            }
            else
            {
                textBox3.Text = dns;
            }

            isIpHidden = Properties.Settings.Default.IsIpHidden1;
            if (isIpHidden)
            {
                button1.Text = GetLocalizedString(language, "hideip");
            }
            else
            {
                button1.Text = GetLocalizedString(language, "showip");
            }
            //button1.Text = GetLocalizedString(language, "refresh");
            button2.Text = "Proxy Mode";
            label3.Text = GetLocalizedString(language, "vpnmodeon");
            label4.Text = GetLocalizedString(language, "proxyport") + " : 2080";
            label5.Text = GetLocalizedString(language, "localconfig");
            label8.Text = GetLocalizedString(language, "dns");
            label6.Text = "Secret Key";
            textBox1.Text = "YEBEKHE";
            textBox2.Text = "https://raw.githubusercontent.com/yebekhe/TelegramV2rayCollector/main/singbox/sfasfi/reality.json";
            label7.Text = GetLocalizedString(language, "sublink");
            button4.Text = GetLocalizedString(language, "deleteall");
            button5.Text = GetLocalizedString(language, "deleteitem");
            menuStrip1.Text = "menuStrip1";
            toolStripMenuItem1.Text = GetLocalizedString(language, "menu");
            languageToolStripMenuItem.Text = GetLocalizedString(language, "lang");
            englishToolStripMenuItem.Text = "English";
            فارسیToolStripMenuItem.Text = "فارسی";
            中文ToolStripMenuItem.Text = "中文";
            русскийToolStripMenuItem.Text = "Русский";
            appearanceToolStripMenuItem.Text = GetLocalizedString(language, "appearance");
            darkModeToolStripMenuItem.Text = GetLocalizedString(language, "darkmode");
            aboutToolStripMenuItem.Text = GetLocalizedString(language, "about");
            button6.Text = GetLocalizedString(language, "connect");
            button7.Text = GetLocalizedString(language, "singdash");
            button8.Text = GetLocalizedString(language, "availservers");
            if (language == "persian")
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
            }
        }

        private async Task<bool> IsSingBoxRunningAsync()
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    await tcpClient.ConnectAsync("127.0.0.1", 9090);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        private async Task UpdateUIBasedOnConnection()
        {
            bool isRunning = await IsSingBoxRunningAsync();
            themeName = Properties.Settings.Default.Theme ?? "bluePalette";
            if (themePalettes.TryGetValue(themeName, out Color[] selectedPalette)) { theme = selectedPalette; }
            language = Properties.Settings.Default.Language;
            this.Invoke((MethodInvoker)delegate
            {
                if (isRunning)
                {

                    button6.Text = GetLocalizedString(Properties.Settings.Default.Language, "disconnect");
                    button6.BackColor = Color.Red;
                    button6.Enabled = true;
                    toolStripStatusLabel1.Text = GetLocalizedString(Properties.Settings.Default.Language, "singboxconnected");


                    button7.Enabled = true;
                    button8.Enabled = true;
                    StyleButton(button7, theme);
                    StyleButton(button8, theme);
                }
                else
                {
                    button6.Text = GetLocalizedString(Properties.Settings.Default.Language, "connect");
                    button7.Enabled = false;
                    button8.Enabled = false;
                    StyleButton(button7, theme);
                    StyleButton(button8, theme);
                    button6.BackColor = Color.Green;
                    button6.Enabled = true;
                    toolStripStatusLabel1.Text = GetLocalizedString(Properties.Settings.Default.Language, "singboxdisconnected");
                }
            });
        }



        private Task UpdateLocationAndIP()
        {
            return Task.Run(async () =>
            {
                string url = "http://ip-api.com/json/";
                try
                {
                    var response = await httpClient.GetStringAsync(url);
                    var data = JObject.Parse(response);
                    string ip = data["query"].ToString();
                    string countrycode = data["countryCode"].ToString();
                    string country = data["country"].ToString();
                    string flagEmoji = IsoCountryCodeToFlagEmoji(countrycode);


                    this.Invoke((MethodInvoker)delegate
                    {
                        isIpHidden = Properties.Settings.Default.IsIpHidden1;
                        if (isIpHidden)
                        {
                            label2.Text = $"{flagEmoji} {country}";
                        }
                        else
                        {
                            label2.Text = $"{flagEmoji} {country} | {ip}";
                        }

                    });
                }
                catch (Exception ex)
                {

                    this.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = "FAILED TO GET YOUR IP";
                    });
                }
            });
        }
        private void LoadComboBoxItems()
        {
            if (File.Exists("list.txt"))
            {
                using (StreamReader reader = new StreamReader("list.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        comboBox1.Items.Add(line);
                    }
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                }
            }
        }
        private void SaveComboBoxItems()
        {
            using (StreamWriter writer = new StreamWriter("list.txt"))
            {
                foreach (var item in comboBox1.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {textBox1.Text}");
                    HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:9090/proxies");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject whole = JObject.Parse(responseBody);
                    JObject proxies = (JObject)whole["proxies"];

                    List<Tuple<string, int>> results = new List<Tuple<string, int>>();

                    foreach (var proxy in proxies)
                    {
                        string key = proxy.Key;
                        JToken value = proxy.Value;
                        if (value["history"] != null)
                        {
                            foreach (var i in value["history"])
                            {
                                if (i["delay"] != null)
                                {
                                    int delay = (int)i["delay"];
                                    results.Add(new Tuple<string, int>(key, delay));
                                }
                            }
                        }
                    }

                    results.Sort((x, y) => x.Item2.CompareTo(y.Item2));

                    Form newDialog = new Form();
                    newDialog.Size = new Size(500, 500);
                    RichTextBox delayText = new RichTextBox();
                    delayText.Dock = DockStyle.Fill;
                    newDialog.Controls.Add(delayText);

                    foreach (var result in results)
                    {
                        string proxyName = result.Item1;
                        int delay = result.Item2;

                        string color;

                        if (delay < 600)
                        {
                            color = "Green";
                        }
                        else if (delay >= 600 && delay <= 1500)
                        {
                            color = "Orange";
                        }
                        else
                        {
                            color = "Red";
                        }

                        delayText.SelectionColor = Color.FromName(color);
                        delayText.SelectionFont = new Font(delayText.Font, FontStyle.Bold);
                        delayText.AppendText($"{proxyName} : {delay}\n");
                    }

                    newDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text.ToLower() == "disconnect")
            {
                button6.Enabled = false;
                bool processKilled = false;
                foreach (var process in Process.GetProcessesByName("sing-box"))
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                        toolStripStatusLabel1.Text = "Disconnected. sing-box.exe is terminated.";
                        processKilled = true;
                    }
                    catch (Win32Exception ex)
                    {
                        toolStripStatusLabel1.Text = "An error occurred while terminating sing-box.exe (Access Denied).";
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException ex)
                    {
                        toolStripStatusLabel1.Text = "An error occurred while terminating sing-box.exe (No Process).";
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        toolStripStatusLabel1.Text = "An unknown error occurred while terminating sing-box.exe.";
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (!processKilled)
                {
                    toolStripStatusLabel1.Text = "No sing-box.exe process found to terminate.";
                }
                button6.Text = "CONNECT";
                button6.Enabled = true;
                return;
            }
            try
            {
                button6.Enabled = false;
                string subscriptionUrl = textBox2.Text;
                if (checkBox1.Checked)
                {
                    if (!File.Exists("config.json"))
                    {
                        MessageBox.Show("Error: config.json does not exist.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(subscriptionUrl))
                    {
                        if (!comboBox1.Items.Contains(subscriptionUrl))
                        {
                            comboBox1.Items.Add(subscriptionUrl);
                        }
                        comboBox1.SelectedItem = subscriptionUrl;
                        SaveComboBoxItems();
                        subscriptionUrl = comboBox1.SelectedItem.ToString();
                        string configContent = await httpClient.GetStringAsync(subscriptionUrl);
                        File.WriteAllText("config.json", configContent);
                        toolStripStatusLabel1.Text = "JSON file downloaded.";
                    }
                }

                if (!File.Exists("sing-box.exe"))
                {
                    string latestVersion = await GetLatestVersion();
                    if (latestVersion == null)
                    {
                        toolStripStatusLabel1.Text = "Could not find the latest version of sing-box.exe";
                        return;
                    }

                    string downloadUrl = $"https://github.com/SagerNet/sing-box/releases/download/{latestVersion}/sing-box-{latestVersion.Substring(1)}-windows-amd64.zip";
                    var zipBytes = await httpClient.GetByteArrayAsync(downloadUrl);
                    File.WriteAllBytes($"sing-box-{latestVersion.Substring(1)}-windows-amd64.zip", zipBytes);

                    toolStripStatusLabel1.Text = "sing-box.exe downloaded.";

                    ZipFile.ExtractToDirectory($"sing-box-{latestVersion.Substring(1)}-windows-amd64.zip", ".");
                    File.Move($".\\sing-box-{latestVersion.Substring(1)}-windows-amd64\\sing-box.exe", ".\\sing-box.exe");


                    File.Delete($"sing-box-{latestVersion.Substring(1)}-windows-amd64.zip");
                    Directory.Delete($".\\sing-box-{latestVersion.Substring(1)}-windows-amd64", true);

                    toolStripStatusLabel1.Text = "sing-box.exe extracted.";
                }
                else
                {
                    toolStripStatusLabel1.Text = "sing-box.exe already exists.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "An error occurred.";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists("sing-box.exe") && File.Exists("config.json"))
            {
                if (label4.Visible) { ModifyConfig(false); }
                else { ModifyConfig(false); ModifyConfig(true); }
                ModifyOverrideAddress(textBox3.Text);
                try
                {
                    toolStripStatusLabel1.Text = "Running sing-box.exe as administrator...";

                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "sing-box.exe",
                        Arguments = "run",
                        Verb = "runas",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    process.StartInfo = startInfo;

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();


                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = "Failed to run sing-box.exe.";
                    MessageBox.Show($"Error running sing-box.exe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Missing sing-box.exe or config.json.";
            }

        }

        private async Task<string> GetLatestVersion()
        {
            try
            {
                var response = await httpClient.GetAsync("https://github.com/SagerNet/sing-box/releases/latest", HttpCompletionOption.ResponseHeadersRead);
                var redirectedUrl = response.RequestMessage.RequestUri;
                var segments = redirectedUrl.Segments;
                var latestVersionTag = segments[^1];
                return latestVersionTag;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting the latest version: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void StyleButton(Button btn, Color[] palette)
        {
            if (btn.Enabled)
            {
                btn.ForeColor = Color.White;
                btn.BackColor = palette[0];
                btn.FlatAppearance.MouseOverBackColor = palette[1];
                btn.FlatAppearance.MouseDownBackColor = palette[2];
                btn.FlatAppearance.BorderColor = palette[3];
            }
            else
            {
                {
                    btn.BackColor = Color.Gray;
                }
            }
        }
        private void StyleLabel(Label lbl)
        {
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
        }
        private readonly BackgroundWorker backgroundWorker;
        private readonly string currentVersion = "v" + Properties.Settings.Default.Version;

        private async void Form1_Load(object sender, EventArgs e)
        {
            themeName = Properties.Settings.Default.Theme ?? "bluePalette";
            if (themePalettes.TryGetValue(themeName, out Color[] selectedPalette)) { theme = selectedPalette; }
            StyleButton(button1, theme);
            StyleButton(button2, theme);
            // StyleButton(button3, bluePalette);
            StyleButton(button4, theme);
            StyleButton(button5, theme);
            StyleButton(button6, theme);
            button7.Enabled = false;
            button8.Enabled = false;
            StyleButton(button7, theme);
            StyleButton(button8, theme);
            StyleLabel(label1);
            StyleLabel(label2);
            StyleLabel(label3);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://github.com/yebekhe/SingBox-UI/releases/latest");
                if (response.IsSuccessStatusCode)
                {
                    string redirectedUrl = response.RequestMessage.RequestUri.ToString();
                    string[] splitUrl = redirectedUrl.Split('/');
                    string newVersion = splitUrl[splitUrl.Length - 1];

                    if (newVersion != currentVersion)
                    {
                        DialogResult result = MessageBox.Show($"A new version ({newVersion}) is available. Your version is {currentVersion}!\nWould you like to update?", "New Version Available", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            string downloadUrl = $"https://github.com/yebekhe/SingBox-UI/releases/download/{newVersion}/SingboxUI.zip";
                            backgroundWorker.RunWorkerAsync(downloadUrl);
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isIpHidden = Properties.Settings.Default.IsIpHidden1;
            isIpHidden = !isIpHidden;
            Properties.Settings.Default.IsIpHidden1 = isIpHidden;
            Properties.Settings.Default.Save();
            button1.Text = isIpHidden ? GetLocalizedString(language, "hideip") : GetLocalizedString(language, "showip");
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public static string IsoCountryCodeToFlagEmoji(string country)
        {
            return string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            Properties.Settings.Default.IsDarkMode = isDarkMode;
            Properties.Settings.Default.Save();
            darkModeToolStripMenuItem.Checked = isDarkMode;
            AdjustMode(isDarkMode);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "english";
            Properties.Settings.Default.Save();
            AdjustLanguage("english");
        }

        private void فارسیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "persian";
            Properties.Settings.Default.Save();
            AdjustLanguage("persian");
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "chinese";
            Properties.Settings.Default.Save();
            AdjustLanguage("chinese");
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "russian";
            Properties.Settings.Default.Save();
            AdjustLanguage("russian");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            language = Properties.Settings.Default.Language;
            if (label4.Visible)
            { label4.Visible = false; button2.Text = "Proxy Mode"; label3.Text = GetLocalizedString(language, "vpnmodeon"); }

            else
            { label4.Visible = true; button2.Text = "VPN Mode"; label3.Text = GetLocalizedString(language, "vpnmode"); }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                if (comboBox1.Items.Count >= 2) { comboBox1.SelectedIndex = comboBox1.Items.Count - 1; }
                else if (comboBox1.Items.Count == 1) { comboBox1.SelectedIndex = 0; }
                else if (comboBox1.Items.Count == 0) { comboBox1.Text = ""; }

                SaveComboBoxItems();
            }
            else if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Clear();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            SaveComboBoxItems();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "http://127.0.0.1:9090/ui",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;

                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool processKilled = false;
            language = Properties.Settings.Default.Language;

            DialogResult dialog;
            MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly;


            if (language == "persian")
            {
                options = MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
                dialog = MessageBox.Show(GetLocalizedString(language, "exitsure"), "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, options);
            }
            else
            {
                dialog = MessageBox.Show(GetLocalizedString(language, "exitsure"), "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }

            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            foreach (var process in Process.GetProcessesByName("sing-box"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    toolStripStatusLabel1.Text = "Disconnected. sing-box.exe is terminated.";
                    processKilled = true;
                }
                catch (Win32Exception ex)
                {
                    toolStripStatusLabel1.Text = "An error occurred while terminating sing-box.exe (Access Denied).";
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ex)
                {
                    toolStripStatusLabel1.Text = "An error occurred while terminating sing-box.exe (No Process).";
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = "An unknown error occurred while terminating sing-box.exe.";
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "yellowPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "bluePalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "redPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "purplePalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void blueGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "bluegrayPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "brownPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void tealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "tealPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "orangePalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = "pinkPalette";
            Properties.Settings.Default.Save();
            AdjustMode(isDarkMode);
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dns = textBox3.Text;
            Properties.Settings.Default.DNS = dns;
            Properties.Settings.Default.Save();
        }
    }
}
