using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using Pickle;
using System.Data.SQLite;
using OpenQA.Selenium.Support.UI;


namespace Instagram_Bot
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////           Функции для Запуска самого драйвера                  ///////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       






        //Создаем экземпляр драйвера по заданным характеристикам , и после возвращаем его.
        //Функция для эмуляции драйвером айфона
        static IWebDriver Driver_Iphone()
        {
            ChromeOptions options_Mobile = new ChromeOptions();
            //Загружаем характеристики
            ChromeMobileEmulationDeviceSettings settings = new ChromeMobileEmulationDeviceSettings();
            settings.EnableTouchEvents = true;
            settings.Height = 640;
            settings.Width = 360;
            settings.PixelRatio = 3.0;
            settings.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile Safari/535.19";
            options_Mobile.EnableMobileEmulation(settings);
            //Пишем Обьект класса , который будет эмулировать окно браузера мобильной версии 
            IWebDriver driver = new ChromeDriver(options_Mobile);
            // driver.Manage().Window.Maximize();//
            return driver;
        }

        //Создаем Обьект драйвера - айфон с профилем
        static IWebDriver Driver_Iphone_Profile(string profileName)
        {
            ChromeOptions options_Mobile = new ChromeOptions();
            //Загружаем характеристики
            ChromeMobileEmulationDeviceSettings settings = new ChromeMobileEmulationDeviceSettings();
            settings.EnableTouchEvents = true;
            settings.Height = 640;
            settings.Width = 360;
            settings.PixelRatio = 3.0;
            settings.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile Safari/535.19";
            options_Mobile.EnableMobileEmulation(settings);
            //Добавляем профиль 
            options_Mobile.AddArguments("--user-data-dir=" + profileName);
            //Скрываем браузер
            //options_Mobile.AddArguments("--headless");
            //Пишем Обьект класса , который будет эмулировать окно браузера мобильной версии 
            IWebDriver driver = new ChromeDriver(options_Mobile);
            // driver.Manage().Window.Maximize();//
            return driver;
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////           Функции для работы с Куки                  /////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Функция для получения куки и записи их в бинарный файл 
        static public IWebDriver Get_cookies(IWebDriver driver)
        {
            //Получаем Куки
            var cookies = driver.Manage().Cookies.AllCookies;
            //Записываем куки в файл:
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("cookies.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, cookies);
                stream.Close();
            }
            //var picker = new Picker<OpenQA.Selenium.Cookie>();
            //picker.AddItem(cookies , 1.0);
            return driver;
        }

        //Функция для чтения куки
        static public OpenQA.Selenium.Cookie Read_User_Cookie()
        {
            OpenQA.Selenium.Cookie Cookies;
            using (Stream stream = new FileStream("cookies.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                //Получаем куки
                Cookies = (OpenQA.Selenium.Cookie)formatter.Deserialize(stream);
            }

            return Cookies;
        }

        //Функция для чтения куки
        static public OpenQA.Selenium.Cookie Read_Cookie()
        {
            //Читаем куки из файла:
            //заключаем в блок try, поскольку при открытии файла может возникнуть исключение(например, если файл открыт другой программой для монопольного доступа и т.д...)
            OpenQA.Selenium.Cookie Cookies ;
            try
            {
                using (Stream stream = new FileStream("cookies.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try //заключаем в блок try, поскольку во время десериализации может возникнуть иключение (если в указанном файле хранится не правильно сериализованные куки или их там вообще нет)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        //Получаем куки
                        Cookies = (OpenQA.Selenium.Cookie)formatter.Deserialize(stream);
                        //Теперь  удаляем не нужное
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);   
                        Cookies = null;
                    }
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Cookies = null;
            }

            return Cookies;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////           Функции для работы с БД                    /////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Добавляем в базу логин
        public static bool upload_login_to_database(string instagram_login_name, string instagram_user_password)
        {
            bool success;
            try
            {
                //Подключаемся к базе данным
                SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
                Connect.Open();
                //Делаем запрос
                string commandText = "INSERT INTO user (login_name, user_password) VALUES (\"" + instagram_login_name + "\" ,\"" +  instagram_user_password + "\") ; ";
                //выполняем
                SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                // выполнить запрос
                Command.ExecuteNonQuery();
                // закрыть соединение
                Connect.Close();
                success = true;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////           Функции для работы с профилем              /////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Функция для работы с новым профилем с куки
        static public IWebDriver Auth_instagram_to_new_prifile_cookies(string instagram_login_name, string instagram_user_password, TextBox textBox_log_message)
        {
            IWebDriver driver;
            driver = Driver_Iphone_Profile(instagram_login_name);
            //Отправляемся на сайт
            driver.Navigate().GoToUrl("https://www.instagram.com/");
            Thread.Sleep(5000);

           //Включаем обработчик
            try
            {
                //Проверяем наличие прогруженной страницы
                bool status_page_successful = driver.Url.Contains("www.instagram.com");
                //Если страница прогрухилась :
                if (status_page_successful == true)
                {
                    Thread.Sleep(3000);
                    //Ищем Кнопку входа
                    IWebElement button_login = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/div[2]/button"));
                    button_login.Click();
                    Thread.Sleep(3000);
                    //Ищем поле Логина
                    IWebElement space_login = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[2]/div/label/input"));
                    space_login.Click();
                    space_login.SendKeys(instagram_login_name);
                    Thread.Sleep(3000);
                    //Ищем Поле Пароля
                    IWebElement space_password = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[3]/div/label/input"));
                    space_password.Click();
                    space_password.SendKeys(instagram_user_password);
                    Thread.Sleep(3000);
                    //Нажимаем на кнопку войти 
                    IWebElement button_ligin_final = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[5]/button"));
                    button_ligin_final.Click();
                    Thread.Sleep(10000);
                    //Ждем Прогрузки страницы , и соглашаемся сохранить данные.
                    IWebElement button_save = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div/section/div/button"));
                    button_save.Click();
                    Thread.Sleep(9000);
                    //Успешно вошли, закрывакем окно
                    IWebElement button_close_popup1 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/button[2]"));
                    button_close_popup1.Click();
                    Thread.Sleep(3000);
                    //Закрываем нижнее преждложение
                    IWebElement button_close_use_app = driver.FindElement(By.XPath("/html/body/div[1]/section/div[2]/div/div[1]/button"));
                    //Проматываем страницу вниз, тут очень важно - надо правильно определить Keys
                    button_close_use_app.SendKeys(OpenQA.Selenium.Keys.PageDown);
                    button_close_use_app.Click();
                    Thread.Sleep(3000);
                    //Проверяем правильно ли мы зашли
                    Get_cookies(driver);
                    textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Успешно");

                    bool status_account_successful = driver.Url.Contains(instagram_login_name);
                    //Если вход успешный :
                    if (status_account_successful == true)
                    {
                        //Сообщаем
                        textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Успешно");
                        //Если вход успешный , то Сохраняем куки в бд
                        //Получаем Куки

                        var cookies = driver.Manage().Cookies.AllCookies;

                        //Записываем куки в файл:
                        IFormatter formatter = new BinaryFormatter();
                        using (Stream stream = new FileStream("cookies.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            formatter.Serialize(stream, cookies);
                            stream.Close();
                        }

                    }
                    else
                    {
                        textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Неуспешно");
                        //Удаляем неудачный профиль
                        Directory.Delete(instagram_login_name, true);

                    }
                }
            }
            catch
            {
                //Удаляем неудачный профиль
                textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Неуспешно");
                Directory.Delete(instagram_login_name, true);
            }

            return driver;
        }


        //Функция для работы с новым профилем
        static public IWebDriver Auth_instagram_to_new_prifile(string instagram_login_name, string instagram_user_password , TextBox textBox_log_message )
        {
            IWebDriver driver;
            driver = Driver_Iphone_Profile(instagram_login_name);
            //Отправляемся на сайт
            driver.Navigate().GoToUrl("https://www.instagram.com/");
            Thread.Sleep(5000);
            //Включаем обработчик
            bool added_to_database = false;
            try
                {
                    //Проверяем наличие прогруженной страницы
                    bool status_page_successful = driver.Url.Contains("www.instagram.com");
                    //Если страница прогрухилась :
                    if (status_page_successful == true)
                    {
                    Thread.Sleep(3000);
                    //Ищем Кнопку входа
                    IWebElement button_login = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/div[2]/button"));
                    button_login.Click();
                    Thread.Sleep(3000);
                    //Ищем поле Логина
                    IWebElement space_login = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[2]/div/label/input"));
                    space_login.Click();
                    space_login.SendKeys(instagram_login_name);
                    Thread.Sleep(3000);
                    //Ищем Поле Пароля
                    IWebElement space_password = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[3]/div/label/input"));
                    space_password.Click();
                    space_password.SendKeys(instagram_user_password);
                    Thread.Sleep(3000);
                    //Нажимаем на кнопку войти 
                    IWebElement button_ligin_final = driver.FindElement(By.XPath("/html/body/div[1]/section/main/article/div/div/div/form/div[5]/button"));
                    button_ligin_final.Click();
                    Thread.Sleep(10000);
                    //Ждем Прогрузки страницы , и соглашаемся сохранить данные.
                    IWebElement button_save = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div/section/div/button"));
                    button_save.Click();
                    Thread.Sleep(9000);
                    //Успешно вошли, закрывакем окно
                    IWebElement button_close_popup1 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/button[2]"));
                    button_close_popup1.Click();
                    Thread.Sleep(3000);
                    //Заходим на страницу профиля - это важно 
                    IWebElement button_profilie = driver.FindElement(By.XPath("/html/body/div[1]/section/nav[2]/div/div/div[2]/div/div/div[5]"));
                    button_profilie.Click();
                    Thread.Sleep(3000);
                    //Выводим статистику
                    textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Успешно");
                    //Проверяем правильно ли мы зашли
                    bool status_account_successful = driver.Url.Contains(instagram_login_name);
                    driver.Close();
                    //Если вход успешный :
                    if (status_account_successful == true)
                        {
                       
                        //Добавляем Профиль в базу данных
                        added_to_database = upload_login_to_database(instagram_login_name, instagram_user_password);
                        //statistics = statistics + "Aккаунт" + instagram_login_name + " - Успешно сохранен" + "\n";
                    }
                    else
                        {
                        textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Неуспешно");
                        //Удаляем неудачный профиль
                        Directory.Delete(instagram_login_name, true);
                        }
                        }
                        }
            catch
            {
                driver.Close();
                //Сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Вход в аккаунт" + instagram_login_name + " - Неуспешно");
                //Удаляем неудачный профиль
                Directory.Delete(instagram_login_name, true);

            }

            if (added_to_database == true)
            {
                //Проверяем базу данных и сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Сохранение в Базу Данных" + instagram_login_name + " - Успешно");
            }
            else
            {
                //добавляем в базу данных и сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Сохранение в Базу Данных" + instagram_login_name + " - Неуспешно");
            }

            return driver;

        }

        //Функция Аунтификации с помощью профиля
        static public IWebDriver Auth_instagram_to_cookies_prifile(string instagram_login_name )
        {

            IWebDriver driver;
            driver = Driver_Iphone_Profile(instagram_login_name);
            //Отправляемся на сайт
            driver.Navigate().GoToUrl("https://www.instagram.com/");
            
            return driver;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////         Функции для Работы с Постами                 /////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Функции для выявлении кореектности ссылки
        static public string Link_validation(string link)
        {
            string correct_link;
            if ( link.Contains("https://www.instagram.com/p/") )
            {
                correct_link = link;
            }
            else
            {
                correct_link = "https://www.instagram.com/p/" + link;
            }

            return correct_link;
        }
        //Функция для проверки - лайк уже поставлен или нет
        static bool find_out_the_status_of_the_like(IWebDriver driver)
        {
            bool like_already_set;
            string page_source = driver.PageSource;
          
                if (page_source.Contains("fill=\"#ed4956\""))
                {
                like_already_set = false;
                }
                else
                {
                like_already_set = true;
                }
            return like_already_set;
        }

        //Функция нажатия кнопочки сердечка
        static public IWebDriver like_post_on_separate_post_page(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement Button_like = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div/article/div[2]/section[1]/span[1]/button"));
            Button_like.Click();
            return driver;
        }


        static public void Button_close_click(IWebDriver driver)
        {

            Thread.Sleep(3000);
            try
            {
                IWebElement Button_close = driver.FindElement(By.XPath("/html/body/div[1]/section/div[2]/div/div[1]/button"));
                Button_close.Click();
            }

            catch
            {

            }
        }
        //Функция для проверки правильности входа - по кпопке лайка

        static public bool Find_button_like(IWebDriver driver ,string link)
        {
            bool check_success;
            //Ставим Ожидание
            Thread.Sleep(3000);
            //driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(10));
            Button_close_click(driver);

            try
            {
                //Итак - смотрим по контенту страницы 
                string page_source = driver.PageSource;

               if( page_source.Contains(link))
                {
                    check_success = true;
                   //check_success = page_source.Contains(link);
                }
                else
                {
                    check_success = false;
                }
            }
            catch
            {
                check_success = false;
            }
            return check_success;
        }

        //Функция для поствановки лайка
        static public IWebDriver Take_like_on_the_post_by_link(IWebDriver driver , string link , TextBox textBox_log_message)
        {
            //Обрабатываем ссылку
            string link_correct;
            link_correct = Link_validation(link);
            Thread.Sleep(3000);
            //Переходим по ссылке 
            driver.Navigate().GoToUrl(link_correct);
            Thread.Sleep(3000);
            //Проверяем коректность входа на ссылку 
            bool check_success = Find_button_like(driver, link);
            if (check_success == true)
            {
            //Смотрим - Лайк стоит или нет
            bool status_like;
            status_like = find_out_the_status_of_the_like(driver);
                if (status_like == true)
                {
                //Ставим лайк 
                like_post_on_separate_post_page(driver);
                //сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Лайк на пост " + link + " - Успешно");
                }
                else
                {
                //сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Лайк на пост " + link + " - Уже стоит");
                }
            }
            else
                {
                //сообщаем
                textBox_log_message.AppendText(Environment.NewLine + "Вход на ссылку " + link + " - не корректен");
            }

            return driver;
        }

        //Функция для снятия лайка
        static public IWebDriver Take_off_like_on_the_post_by_link(IWebDriver driver, string link , TextBox textBox_log_message)
        {
            //Обрабатываем ссылку
            string link_correct;
            link_correct = Link_validation(link);
            Thread.Sleep(3000);
            //Переходим по ссылке 
            driver.Navigate().GoToUrl(link_correct);
            Thread.Sleep(3000);
            //Проверяем коректность входа на ссылку 
            bool check_success = Find_button_like(driver, link);
            if (check_success == true)
            {
                //Смотрим - Лайк стоит или нет
                bool status_like;
                status_like = find_out_the_status_of_the_like(driver);
                if (status_like == false)
                {
                    //Ставим лайк 
                    like_post_on_separate_post_page(driver);
                    //сообщаем
                    textBox_log_message.AppendText(Environment.NewLine + "Лайк на пост " + link + " - Успешно снят");
                }
                else
                {
                    //сообщаем
                    textBox_log_message.AppendText(Environment.NewLine + "Лайк на пост " + link + " - не поставлен");
                }
            }
            else
            {
                //сообщаем

                textBox_log_message.AppendText(Environment.NewLine + "Вход на ссылку " + link + " - не корректен");
            }

            return driver;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////            Функции для Работы с Аккаунтами            ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Функция для обработки линка
        static string Link_validation_account(string link)
        {
            string correct_link;
            if (link.Contains("https://www.instagram.com/"))
            {
                correct_link = link;
            }
            else
            {
                correct_link = "https://www.instagram.com/" + link;
            }

            return correct_link;
        }


        //Функция для проверки исходного кода - да или нет
        static bool Assert_string (IWebDriver driver, string text)
        {
            bool like_already_set;
            string page_source = driver.PageSource;

            if (page_source.Contains(text))
            {
                like_already_set = true;
            }
            else
            {
                like_already_set = false;
            }
            return like_already_set;
        }



        //Функция для получения ника акаунта
        public static string account_name (string link)
        {
            //Обрезаем строку
            link = link.Substring(26);
            return link;
        }

        //Подпискана аккаунт 
        public static IWebDriver Follow_account(IWebDriver driver, string link , TextBox textBox_log_message)
        {
            //сначала обрабатываем ссылку
            link = Link_validation_account(link);
            //После находим имя аккаунта
            string name = account_name(link);
            //Заходим на страницу аккаунта
            driver.Navigate().GoToUrl(link);
            Thread.Sleep(3000);
            //Проверяем в исходном коде - туда ли мы зашли
            bool assert_name = Assert_string(driver, name);
            if (assert_name == true)
            {
            //Кнопка подписки как мы знаем дейсвтвует в одну сторону 
            IWebElement button_follow_subscribe_account = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/div[2]/div/span/span[1]/button"));
            button_follow_subscribe_account.Click() ;
            Thread.Sleep(3000);
            //Если мы подписались - то все успешно - проверяем , должна выскочить кнопка отписки.
                try
                {
                    // Так - если мы уже подписаны - то ждем ожидание элемента 
                    IWebElement button_close = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/button[2]"));
                    button_close.Click();
                    textBox_log_message.AppendText(Environment.NewLine + "Мы уже подписаны " + link + " ");

                }

                catch
                {
                    //Мы уже 

                    textBox_log_message.AppendText(Environment.NewLine + "Успешно подписаны " + link + " ");

                }

            }
            else
            {
                //Неудачный вход на ссылку.

                textBox_log_message.AppendText(Environment.NewLine + "Вход на аккаунт " + link + " - Неуспешно");
            }
            return driver;
        }

        //Отписка от аккаунта 
        public static IWebDriver Unfollow_account(IWebDriver driver, string link, TextBox textBox_log_message)
        {
            //сначала обрабатываем ссылку
            link = Link_validation_account(link);
            //После находим имя аккаунта
            string name = account_name(link);
            //Заходим на страницу аккаунта
            driver.Navigate().GoToUrl(link);
            Thread.Sleep(3000);
            //Проверяем в исходном коде - туда ли мы зашли
            bool assert_name = Assert_string(driver, name);
            if (assert_name == true)
            {
                //Кнопка подписки как мы знаем дейсвтвует в одну сторону 
                try
              {  
                //Ищем Кнопку отписки 
                IWebElement button_follow_subscribe_account = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/header/section/div[2]/div/span/span[1]/button"));
                button_follow_subscribe_account.Click();
                Thread.Sleep(3000);
                  // Так - если мы уже подписаны - то ждем ожидание элемента 
                    IWebElement button_close = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/button[1]"));
                    button_close.Click();
                    textBox_log_message.AppendText(Environment.NewLine + "Мы уже подписаны " + link + " ");
                }
                catch
                {
                    //Мы уже 
                    textBox_log_message.AppendText(Environment.NewLine + "Успешно подписаны " + link + " ");
                }
            }
            else
            {
                //Неудачный вход на ссылку.
                textBox_log_message.AppendText(Environment.NewLine + "Вход на аккаунт " + link + " - Неуспешно");
            }
            return driver;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////                                                               //////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    }



}
