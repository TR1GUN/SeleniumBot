using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Instagram_Bot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Создаем базу данных при запуске программы
            if (System.IO.File.Exists("UserDataBase.db"))
            {
                textBox_log_message.Text = "База данных успешно найдена";
            }
            else
            {
                //файла нет
                textBox_log_message.Text = "База данных отсутсвует";
                textBox_log_message.AppendText(Environment.NewLine + "Создаем....");
                //Создаем базу данных
                Create_DataBase();
                if  (System.IO.File.Exists("UserDataBase.db"))
                    {
                        textBox_log_message.AppendText(Environment.NewLine + "База данных успешно создана") ;
                    }

                else
                    {
                    textBox_log_message.AppendText(Environment.NewLine + "Ошибка при создании базы данных");
                    }
            }
            //Создаем Тхт

            //Create_txt_ststistics();
            try
            {
                Account_upload_to_form_from_database();
                //Создаем Копии 

                //Добавляем к чекетс боксу для постановки лайка.
                checkedListBox_list_like_post.Items.AddRange(checkedListBox_list_account.Items);
                checkedListBox_list_follow.Items.AddRange(checkedListBox_list_account.Items);


            }
            catch
            {

            }
            
        }
        private void TextBox_log_message_TextChanged(object sender, EventArgs e)
        {

        }
        //Метод для создания базы данных.
        private void Create_DataBase()
        {
            SQLiteConnection.CreateFile("UserDataBase.db");
            //Создаем таблицу и поля:
            // Подключаемся
            SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
            Connect.Open();
            // строка запроса на создание таблицы
            string commandText = "CREATE TABLE user ( login_name text , user_password text, user_cookie BLOB)";
            //выполняем
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            // выполнить запрос
            Command.ExecuteNonQuery(); 
            // закрыть соединение
            Connect.Close();  
        }

        // Метод для загрузки пользователей 
        private void Account_upload_to_form_from_database()
        {
            
            //А тут Очень важно - создаем колличество чекбоксов по колличеству добавленных аккаунтов.
            //Подключаем БД
            SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
            Connect.Open();
            //Ищем все значения по ряду имени аккаунта
            string commandText = "Select login_name from User";
            //выполняем
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            // выполнить запрос и читаем ответ запроса 
            SQLiteDataReader sqlReader = Command.ExecuteReader();
            //Записываем это в наш массив аккаунтов
            while (sqlReader.Read())
            {
                var result = (Convert.ToString(sqlReader["login_name"]));
                checkedListBox_list_account.Items.Add(result);
                textBox_log_message.AppendText(Environment.NewLine + "Пользователь" + result + "Найден");
                
            }
            // закрыть соединение
            Connect.Close();
        }
        // Метод для загрузки пользователей - тоже самое что и выше - только возвращаем массив аккаунтов - иногда это важна
        private List<string> Account_upload_to_form_from_database_list()
        {
            //Поскольку массивы в С# очень сомнительная вещь , делаем через список 
            List<string> Instabot_account = new List<string>();

            //А тут Очень важно - создаем колличество чекбоксов по колличеству добавленных аккаунтов.
            //Подключаем БД
            SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
            Connect.Open();
            //Ищем все значения по ряду имени аккаунта
            string commandText = "Select login_name from User";
            //выполняем
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            // выполнить запрос и читаем ответ запроса 
            SQLiteDataReader sqlReader = Command.ExecuteReader();
            //Записываем это в наш массив аккаунтов
            while (sqlReader.Read())
            {
                var result = (Convert.ToString(sqlReader["login_name"]));
                Instabot_account.Add(result);
            }
            // закрыть соединение
            Connect.Close();

            return Instabot_account;
        }

        //Метод Выгрузки статистики 
        /* public void upload_statistics_to_textbox(string text)
         {
         textBox_log_message.AppendText(Environment.NewLine + text);
         }*/

        public string Upload_statistics_to_textbox
        {
            get { return textBox_log_message.Text; }
            set { textBox_log_message.AppendText(Environment.NewLine + value); }
        }

        private void button_test_Click(object sender, EventArgs e)
        {

        }


        ///итак обработаем 
        private void Button_cookies_Click(object sender, EventArgs e)
        {

        }

        //Итак - ЧекбоксЛист с аккаунтами
        private void CheckedListBox_list_account_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Кнопка для обработки первичного входа в аккаунт 
        private void Button_add_account_to_database_Click(object sender, EventArgs e)
        {

            Button_added_new_account(textBox_Login.Text, textBox_Password.Text);


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////// Функции для обработки первичного входа                      //////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
       


        //Функция для обработки баттона первичного входа
        public void Button_added_new_account(string instagram_login_name, string instagram_user_password)
        {
            //Итак  - МЫ получили логин и пароль
            label_added_account.Text = "";
            //Сначала мы проверяем наличие данного аккаунта в баззе данных 
            bool login_found = Check_login_in_database(instagram_login_name);
             if (login_found == false)
            {
                //Итак - мы не нашли совпадения,  значит запускаем драйвер 
                Program.Auth_instagram_to_new_prifile(instagram_login_name, instagram_user_password, textBox_log_message);


            }
            else
            {
                //Мы нашли совпадение - тут грустно
                
                textBox_log_message.AppendText(Environment.NewLine + "Профиль" + instagram_login_name + "Уже есть");
                label_added_account.Text = "Профиль" + instagram_login_name + "Уже есть";
                textBox_Login.Clear();
                textBox_Password.Clear();
            }

            //Если его нет , то запускаем вебдрайвер с профилем данного пользователя

            //
        }
        //Функция проверки наличия логина  в базе данных
        public bool  Check_login_in_database(string instagram_login_name)
        {
            //Коннектимся к базе данных
        SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
            Connect.Open();
            //Ищем в базе данных нужный ник

            //Ищем все значения по ряду имени аккаунта
            string commandText = "Select login_name from User where login_name like";
            //выполняем
            SQLiteCommand Command = new SQLiteCommand(commandText + " \"" + instagram_login_name + "\" ;" , Connect);
            // выполнить запрос и читаем ответ запроса 
            SQLiteDataReader sqlReader = Command.ExecuteReader();
            //Делаем немного колхоз - читаем ответ булевого типа
            bool login_found = sqlReader.Read();
            // закрыть соединение
            Connect.Close();
            return login_found;
        }

        private void label_added_account_Click(object sender, EventArgs e)
        {

        }

        private void Button_uploading_statistics_Click(object sender, EventArgs e)
        {
            string text = textBox_log_message.Text;
            //записываем в файл
            Uploading_statistics(text);

        }

        private void Button_clear_statistics_Click(object sender, EventArgs e)
        {
            textBox_log_message.Clear();
        }

        //Функция для обработки текстового файла
        public void Create_txt_ststistics()
        {
            //Смотрим на наличие файла 
            if (System.IO.File.Exists("Statistics.txt"))
            {
                textBox_log_message.Text = "Файл статистики найден";
            }
            else
            {
            //Создаем текстовый файл
                System.IO.File.Create("Statistics.txt");
            }
            
        }

        public void Uploading_statistics(string text)
        {
            System.IO.File.AppendAllText("Statistics.txt", text);
            System.IO.File.AppendAllText("Statistics.txt", "\n");
            System.IO.File.AppendAllText("Statistics.txt", "\n");
        }

        //Кнопка Добавления Линка в массив из текстбокса
        private void Button_added_list_like_post_Click(object sender, EventArgs e)
        {
            added_list_like_post();
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////           Функции для Лайканья постов                       //////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //Метод добавления линка в массив текстбокса
        private void added_list_like_post()
        {
            //Ообработка пустого значения
            string text = Convert.ToString(textBox_added_list_like_post.Text);
            if (text == "")
            {
                textBox_added_list_like_post.Text = "Пустое значение нельзя вводить";
            }
            if (text == null)
            {
                textBox_added_list_like_post.Text = "Пустое значение нельзя вводить";
            }
            else
            {
            listBox_list_like_post.Items.Add(text);
            textBox_added_list_like_post.Clear();
            }
        }

        private void TextBox_added_list_like_post_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Удаляем что написанно , при щелканьи на кнопку
        private void TextBox_added_list_like_post_Click(object sender, EventArgs e)
        {
            if (textBox_added_list_like_post.Text == "Пустое значение нельзя вводить")
            {
                textBox_added_list_like_post.Clear();
            }
            if (textBox_added_list_like_post.Text == "Значение пусто")
            {
                textBox_added_list_like_post.Clear();
            }


        }

        //Функция для удаления выделенного поста
        private void Button_deletion_list_like_post_Click(object sender, EventArgs e)
        {
            if (listBox_list_like_post.SelectedItems.Count > 0)
            {
                listBox_list_like_post.Items.RemoveAt(listBox_list_like_post.SelectedIndex);
            }

        }
        //Итак - Обрабатывааем чек бокс 
        private void CheckedListBox_list_like_post_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        //Функция для того чтоб ставить лайки - Поставить лайк на посты по выделенным аккаунтам 
        public void Like_posts_on_selected_accounts()
        {
            //Итак формируем два списка - один из выделенных аккаунтов , другой из постов 

            //Перебираем значения выделенных аккаунта
            int list_account_count = checkedListBox_list_like_post.CheckedItems.Count;
            //Массив списка аккаунтов
            string[] list_account = new string[list_account_count];
            //Добавляем аккаунты 
            for ( int i = 0 ; i < list_account_count; i++ )
            {
                //Добавляем в список
                list_account[i] = Convert.ToString(checkedListBox_list_like_post.CheckedItems[i]);
            }

            //Формируем длину массива из всех добавленных постов
            int list_post_count = listBox_list_like_post.Items.Count; 
            //Формируем массив из всех добавленных постов
            string[] list_post = new string[list_post_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_post_count; i++)
            {
            //Добавляем в список
            list_post[i] = Convert.ToString(listBox_list_like_post.Items[i]);
            }
            //Проверяем массивы на пустое значение
            bool checking_account = function_for_checking_an_empty_value(list_account); 
            bool checking_post = function_for_checking_an_empty_value(list_post);
            // НАши действия 
            if (checking_post == false && checking_account == false)
            {
                //Вызываем функцию которая проходится по аккаунтам и 
                function_for_traversing_an_array_in_single_thread(list_post, list_account);
            }
            else
            {

            }

        }

        //Функция для того чтоб снять лайк
        public void Take_off_like_posts_on_selected_accounts()
        {

            //Итак формируем два списка - один из выделенных аккаунтов , другой из постов 

            //Перебираем значения выделенных аккаунта
            int list_account_count = checkedListBox_list_like_post.CheckedItems.Count;
            //Массив списка аккаунтов
            string[] list_account = new string[list_account_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_account_count; i++)
            {
                //Добавляем в список
                list_account[i] = Convert.ToString(checkedListBox_list_like_post.CheckedItems[i]);
            }

            //Формируем длину массива из всех добавленных постов
            int list_post_count = listBox_list_like_post.Items.Count;
            //Формируем массив из всех добавленных постов
            string[] list_post = new string[list_post_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_post_count; i++)
            {
                //Добавляем в список
                list_post[i] = Convert.ToString(listBox_list_like_post.Items[i]);
            }
            //Проверяем массивы на пустое значение
            bool checking_account = function_for_checking_an_empty_value(list_account);
            bool checking_post = function_for_checking_an_empty_value(list_post);
            // НАши действия 
            if (checking_post == false && checking_account == false)
            {
                //Вызываем функцию которая проходится по аккаунтам и 
                Take_off_like_function_for_traversing_an_array_in_single_thread(list_post, list_account);
            }
            else
            {

            }

        }
        //Функция для прохода одним потоком по массиву
        public void Take_off_like_function_for_traversing_an_array_in_single_thread(string[] list_post_f, string[] list_account_f)
        {
            //Итак берем массив аккаунтов и проходимся про каждому из элементов

            for (int i = 0; i < list_account_f.Count(); i++)
            {
                //Заходим в аккаунт
                IWebDriver driver = Program.Auth_instagram_to_cookies_prifile(list_account_f[i]);
                //Проходимся по постам 
                for (int ii = 0; ii < list_post_f.Count(); ii++)
                {
                    IWebDriver driver_like = Program.Take_off_like_on_the_post_by_link(driver, list_post_f[ii], textBox_log_message);

                }
            }
        }

        //Функция для прохода одним потоком по массиву
        public void function_for_traversing_an_array_in_single_thread(string[] list_post_f , string[] list_account_f)
        {
            //Итак берем массив аккаунтов и проходимся про каждому из элементов

            for (int i = 0; i < list_account_f.Count(); i++)
            {
                //Заходим в аккаунт
                IWebDriver driver = Program.Auth_instagram_to_cookies_prifile(list_account_f[i]);
                //Проходимся по постам 
                for (int ii = 0; ii < list_post_f.Count(); ii++)
                {
                    IWebDriver driver_like = Program.Take_like_on_the_post_by_link(driver, list_post_f[ii] , textBox_log_message);
                }
            }
        }

        //Функции для проверки массива на пустое значение
        public bool function_for_checking_an_empty_value(string[] list)
        {
            //переменная для обозначения "пустоты" значения
            bool checking = false;
            //Получаем длину массива
            // int len_list = list.Count();
            //Перебираем сам массив
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == "")
                {
                    checking = true;
                    textBox_added_list_like_post.Text = "Значение пусто";

                }

            }
            if(list.Count() == 0)
            {

                checking = true;
                textBox_added_list_like_post.Text = "Значение пусто";
            }

                return checking;
        }
        private void Button_like_setting_Click(object sender, EventArgs e)
        {
            Like_posts_on_selected_accounts();
        }

        private void Button_switch_off_like_setting_Click(object sender, EventArgs e)
        {
            Take_off_like_posts_on_selected_accounts();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////           Функции для Подписки на аккаунт                   //////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //добавление аккаунта в список +
        private void Button_added_account_Click(object sender, EventArgs e)
        {
            Added_list_follow_account();
          

        }

        //Метод добавления линка в массив текстбокса +
        private void Added_list_follow_account()
        {
            //Ообработка пустого значения
            string text = Convert.ToString(textBox_added_account.Text);
            if (text == "")
            {
                textBox_added_account.Text = "Пустое значение нельзя вводить";
            }
          
            else
            {
                listBox_list_account.Items.Add(text);
                textBox_added_account.Clear();
            }
        }

        //Текст бокс для добавления аккаунта +
        private void TextBox_added_account_TextChanged(object sender, EventArgs e)
        {

        }
        // Функция для удаления значений для текст бокса при щелканьи на поле +
        private void TextBox_added_account_Click(object sender, EventArgs e)
        {
            if (textBox_added_account.Text == "Пустое значение нельзя вводить")
            {
                textBox_added_account.Clear();
            }
            if (textBox_added_account.Text == "Значение пусто")
            {
                textBox_added_account.Clear();
            }
        }

        //кнопка удаления поста из листбокса +
        private void Button_deletion_account_Click(object sender, EventArgs e)
        {
            if (listBox_list_account.SelectedItems.Count > 0)
            {
                listBox_list_account.Items.RemoveAt(listBox_list_account.SelectedIndex);
            }
        }

        // Чек лист аккаунтов +
        private void CheckedListBox_list_follow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //лист аккаунтов +
        private void ListBox_list_account_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Функция для обработки корректности ссылки



        //Функция для того чтоб ставить
        public void Follow_posts_on_selected_accounts()
        {
            //Итак формируем два списка - один из выделенных аккаунтов , другой из постов 

            //Перебираем значения выделенных аккаунта
            int list_account_count = checkedListBox_list_follow.CheckedItems.Count;
            //Массив списка аккаунтов
            string[] list_account = new string[list_account_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_account_count; i++)
            {
                //Добавляем в список
                list_account[i] = Convert.ToString(checkedListBox_list_follow.CheckedItems[i]);
            }

            //Формируем длину массива из всех добавленных постов
            int list_post_count = listBox_list_account.Items.Count;
            //Формируем массив из всех добавленных постов
            string[] list_post = new string[list_post_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_post_count; i++)
            {
                //Добавляем в список
                list_post[i] = Convert.ToString(listBox_list_account.Items[i]);
            }
            //Проверяем массивы на пустое значение
            bool checking_account = function_for_checking_an_empty_value_follow(list_account);
            bool checking_post = function_for_checking_an_empty_value_follow(list_post);
            // НАши действия 
            if (checking_post == false && checking_account == false)
            {
                //Вызываем функцию которая проходится по аккаунтам и 
                function_for_traversing_an_array_in_single_thread_follow(list_post, list_account);
            }
            else
            {

            }

        }

        //Функция для того чтоб снять лайк
        public void Take_off_like_posts_on_selected_accounts_follow()
        {

            //Итак формируем два списка - один из выделенных аккаунтов , другой из постов 

            //Перебираем значения выделенных аккаунта
            int list_account_count = checkedListBox_list_follow.CheckedItems.Count;
            //Массив списка аккаунтов
            string[] list_account = new string[list_account_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_account_count; i++)
            {
                //Добавляем в список
                list_account[i] = Convert.ToString(checkedListBox_list_follow.CheckedItems[i]);
            }

            //Формируем длину массива из всех добавленных постов
            int list_post_count = listBox_list_account.Items.Count;
            //Формируем массив из всех добавленных постов
            string[] list_post = new string[list_post_count];
            //Добавляем аккаунты 
            for (int i = 0; i < list_post_count; i++)
            {
                //Добавляем в список
                list_post[i] = Convert.ToString(listBox_list_account.Items[i]);
            }
            //Проверяем массивы на пустое значение
            bool checking_account = function_for_checking_an_empty_value_follow(list_account);
            bool checking_post = function_for_checking_an_empty_value_follow(list_post);
            // НАши действия 
            if (checking_post == false && checking_account == false)
            {
                //Вызываем функцию которая проходится по аккаунтам и 
                Take_off_like_function_for_traversing_an_array_in_single_thread_follow(list_post, list_account);
            }
            else
            {

            }

        }
        //Функция для прохода одним потоком по массиву
        public void Take_off_like_function_for_traversing_an_array_in_single_thread_follow(string[] list_post_f, string[] list_account_f)
        {
            //Итак берем массив аккаунтов и проходимся про каждому из элементов

            for (int i = 0; i < list_account_f.Count(); i++)
            {
                //Заходим в аккаунт
                IWebDriver driver = Program.Auth_instagram_to_cookies_prifile(list_account_f[i]);
                //Проходимся по постам 
                for (int ii = 0; ii < list_post_f.Count(); ii++)
                {
                    IWebDriver driver_like = Program.Unfollow_account(driver, list_post_f[ii], textBox_log_message);

                }
            }
        }

        //Функция для прохода одним потоком по массиву
        public void function_for_traversing_an_array_in_single_thread_follow(string[] list_post_f, string[] list_account_f)
        {
            //Итак берем массив аккаунтов и проходимся про каждому из элементов

            for (int i = 0; i < list_account_f.Count(); i++)
            {
                //Заходим в аккаунт
                IWebDriver driver = Program.Auth_instagram_to_cookies_prifile(list_account_f[i]);
                //Проходимся по постам 
                for (int ii = 0; ii < list_post_f.Count(); ii++)
                {
                    IWebDriver driver_like = Program.Follow_account(driver, list_post_f[ii], textBox_log_message);
                }
            }
        }

        //Функции для проверки массива на пустое значение
        public bool function_for_checking_an_empty_value_follow(string[] list)
        {
            //переменная для обозначения "пустоты" значения
            bool checking = false;
            //Получаем длину массива
            // int len_list = list.Count();
            //Перебираем сам массив
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] == "")
                {
                    checking = true;
                    textBox_added_list_like_post.Text = "Значение пусто";
                }
            }
            if (list.Count() == 0)
            {
                checking = true;
                textBox_added_list_like_post.Text = "Значение пусто";
            }
            return checking;
        }


        /// ///// ////// /////



        
        //подписка на аккаунт
        private void Button_follow_account_list_Click(object sender, EventArgs e)
        {
            Follow_posts_on_selected_accounts();
        }
        //отписка от аккаунтов
        private void Button_unfollow_account_list_Click(object sender, EventArgs e)
        {
            ////------------------------------------------------------------------------------------------------
        }

        private void Label_Password_Click(object sender, EventArgs e)
        {

        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*
 * 
 * 
 * 
            //А тут Очень важно - создаем колличество чекбоксов по колличеству добавленных аккаунтов.
            string[] InstagramBot_added_account = { };
            //Подключаем БД
            SQLiteConnection Connect = new SQLiteConnection("Data Source=UserDataBase.db");
            Connect.Open();
            //Ищем все значения по ряду имени аккаунта
            string commandText = "Select login_name from User";
            //выполняем
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            // выполнить запрос
            //Command.ExecuteNonQuery();

            //Читаем ответ запроса 
            SQLiteDataReader sqlReader = Command.ExecuteReader();
            //Записываем это в наш массив 


             while (sqlReader.Read()){
                var result = (Convert.ToString(sqlReader["login_name"]));
                
                InstagramBot_added_account.Append(result);
                checkedListBox_list_account.Items.Add(result);

            }

            textBox_log_message.AppendText(Environment.NewLine + InstagramBot_added_account);
          

            // закрыть соединение
            Connect.Close();
            //Закрываем БД
            //Добавляем все именна в массив

            //Добавляем лист 
            checkedListBox_list_account.Items.Add("Leiyjt,");
            checkedListBox_list_account.Items.AddRange(InstagramBot_added_account);
            */
