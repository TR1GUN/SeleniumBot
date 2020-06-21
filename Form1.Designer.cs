namespace Instagram_Bot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_log_message = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.button_cookies = new System.Windows.Forms.Button();
            this.tabControl_function = new System.Windows.Forms.TabControl();
            this.tabPage_Managing_added_accounts = new System.Windows.Forms.TabPage();
            this.tabControl_function_be_added_account = new System.Windows.Forms.TabControl();
            this.tabPage_added_account = new System.Windows.Forms.TabPage();
            this.checkedListBox_list_account = new System.Windows.Forms.CheckedListBox();
            this.tabPage_like = new System.Windows.Forms.TabPage();
            this.button_switch_off_like_setting = new System.Windows.Forms.Button();
            this.button_like_setting = new System.Windows.Forms.Button();
            this.button_deletion_list_like_post = new System.Windows.Forms.Button();
            this.textBox_added_list_like_post = new System.Windows.Forms.TextBox();
            this.button_added_list_like_post = new System.Windows.Forms.Button();
            this.listBox_list_like_post = new System.Windows.Forms.ListBox();
            this.checkedListBox_list_like_post = new System.Windows.Forms.CheckedListBox();
            this.tabPage_follow = new System.Windows.Forms.TabPage();
            this.textBox_added_account = new System.Windows.Forms.TextBox();
            this.button_added_account = new System.Windows.Forms.Button();
            this.button_unfollow_account_list = new System.Windows.Forms.Button();
            this.button_follow_account_list = new System.Windows.Forms.Button();
            this.button_deletion_account = new System.Windows.Forms.Button();
            this.listBox_list_account = new System.Windows.Forms.ListBox();
            this.checkedListBox_list_follow = new System.Windows.Forms.CheckedListBox();
            this.tabPage_Added_new_account = new System.Windows.Forms.TabPage();
            this.label_added_account = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.button_add_account_to_database = new System.Windows.Forms.Button();
            this.tabPage_Upload_statistics = new System.Windows.Forms.TabPage();
            this.button_uploading_statistics = new System.Windows.Forms.Button();
            this.button_clear_statistics = new System.Windows.Forms.Button();
            this.label_login = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.tabControl_function.SuspendLayout();
            this.tabPage_Managing_added_accounts.SuspendLayout();
            this.tabControl_function_be_added_account.SuspendLayout();
            this.tabPage_added_account.SuspendLayout();
            this.tabPage_like.SuspendLayout();
            this.tabPage_follow.SuspendLayout();
            this.tabPage_Added_new_account.SuspendLayout();
            this.tabPage_Upload_statistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_log_message
            // 
            this.textBox_log_message.Location = new System.Drawing.Point(25, 13);
            this.textBox_log_message.Multiline = true;
            this.textBox_log_message.Name = "textBox_log_message";
            this.textBox_log_message.Size = new System.Drawing.Size(483, 198);
            this.textBox_log_message.TabIndex = 0;
            this.textBox_log_message.TextChanged += new System.EventHandler(this.TextBox_log_message_TextChanged);
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(289, 56);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 1;
            this.button_test.Text = "button1";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_cookies
            // 
            this.button_cookies.Location = new System.Drawing.Point(289, 110);
            this.button_cookies.Name = "button_cookies";
            this.button_cookies.Size = new System.Drawing.Size(75, 23);
            this.button_cookies.TabIndex = 2;
            this.button_cookies.Text = "cookies";
            this.button_cookies.UseVisualStyleBackColor = true;
            this.button_cookies.Click += new System.EventHandler(this.Button_cookies_Click);
            // 
            // tabControl_function
            // 
            this.tabControl_function.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabControl_function.Controls.Add(this.tabPage_Managing_added_accounts);
            this.tabControl_function.Controls.Add(this.tabPage_Added_new_account);
            this.tabControl_function.Controls.Add(this.tabPage_Upload_statistics);
            this.tabControl_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_function.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.tabControl_function.Location = new System.Drawing.Point(0, 0);
            this.tabControl_function.Name = "tabControl_function";
            this.tabControl_function.SelectedIndex = 0;
            this.tabControl_function.Size = new System.Drawing.Size(1022, 487);
            this.tabControl_function.TabIndex = 3;
            // 
            // tabPage_Managing_added_accounts
            // 
            this.tabPage_Managing_added_accounts.Controls.Add(this.tabControl_function_be_added_account);
            this.tabPage_Managing_added_accounts.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Managing_added_accounts.Name = "tabPage_Managing_added_accounts";
            this.tabPage_Managing_added_accounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Managing_added_accounts.Size = new System.Drawing.Size(1014, 461);
            this.tabPage_Managing_added_accounts.TabIndex = 0;
            this.tabPage_Managing_added_accounts.Text = "Управление Добавленными Аккаунтами";
            this.tabPage_Managing_added_accounts.UseVisualStyleBackColor = true;
            // 
            // tabControl_function_be_added_account
            // 
            this.tabControl_function_be_added_account.Controls.Add(this.tabPage_added_account);
            this.tabControl_function_be_added_account.Controls.Add(this.tabPage_like);
            this.tabControl_function_be_added_account.Controls.Add(this.tabPage_follow);
            this.tabControl_function_be_added_account.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_function_be_added_account.Location = new System.Drawing.Point(3, 3);
            this.tabControl_function_be_added_account.Multiline = true;
            this.tabControl_function_be_added_account.Name = "tabControl_function_be_added_account";
            this.tabControl_function_be_added_account.SelectedIndex = 0;
            this.tabControl_function_be_added_account.Size = new System.Drawing.Size(1008, 455);
            this.tabControl_function_be_added_account.TabIndex = 6;
            // 
            // tabPage_added_account
            // 
            this.tabPage_added_account.Controls.Add(this.checkedListBox_list_account);
            this.tabPage_added_account.Controls.Add(this.button_cookies);
            this.tabPage_added_account.Controls.Add(this.button_test);
            this.tabPage_added_account.Location = new System.Drawing.Point(4, 22);
            this.tabPage_added_account.Name = "tabPage_added_account";
            this.tabPage_added_account.Size = new System.Drawing.Size(1000, 429);
            this.tabPage_added_account.TabIndex = 2;
            this.tabPage_added_account.Text = "Список добавленных Аккаунтов";
            this.tabPage_added_account.UseVisualStyleBackColor = true;
            // 
            // checkedListBox_list_account
            // 
            this.checkedListBox_list_account.FormattingEnabled = true;
            this.checkedListBox_list_account.Location = new System.Drawing.Point(17, 3);
            this.checkedListBox_list_account.Name = "checkedListBox_list_account";
            this.checkedListBox_list_account.Size = new System.Drawing.Size(242, 379);
            this.checkedListBox_list_account.TabIndex = 3;
            this.checkedListBox_list_account.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_list_account_SelectedIndexChanged);
            // 
            // tabPage_like
            // 
            this.tabPage_like.Controls.Add(this.button_switch_off_like_setting);
            this.tabPage_like.Controls.Add(this.button_like_setting);
            this.tabPage_like.Controls.Add(this.button_deletion_list_like_post);
            this.tabPage_like.Controls.Add(this.textBox_added_list_like_post);
            this.tabPage_like.Controls.Add(this.button_added_list_like_post);
            this.tabPage_like.Controls.Add(this.listBox_list_like_post);
            this.tabPage_like.Controls.Add(this.checkedListBox_list_like_post);
            this.tabPage_like.Location = new System.Drawing.Point(4, 22);
            this.tabPage_like.Name = "tabPage_like";
            this.tabPage_like.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_like.Size = new System.Drawing.Size(1000, 429);
            this.tabPage_like.TabIndex = 0;
            this.tabPage_like.Text = "Постановка лайка";
            this.tabPage_like.UseVisualStyleBackColor = true;
            // 
            // button_switch_off_like_setting
            // 
            this.button_switch_off_like_setting.Location = new System.Drawing.Point(579, 227);
            this.button_switch_off_like_setting.Name = "button_switch_off_like_setting";
            this.button_switch_off_like_setting.Size = new System.Drawing.Size(162, 39);
            this.button_switch_off_like_setting.TabIndex = 10;
            this.button_switch_off_like_setting.Text = "Снять лайк";
            this.button_switch_off_like_setting.UseVisualStyleBackColor = true;
            this.button_switch_off_like_setting.Click += new System.EventHandler(this.Button_switch_off_like_setting_Click);
            // 
            // button_like_setting
            // 
            this.button_like_setting.Location = new System.Drawing.Point(579, 168);
            this.button_like_setting.Name = "button_like_setting";
            this.button_like_setting.Size = new System.Drawing.Size(162, 37);
            this.button_like_setting.TabIndex = 9;
            this.button_like_setting.Text = "Поставить лайк";
            this.button_like_setting.UseVisualStyleBackColor = true;
            this.button_like_setting.Click += new System.EventHandler(this.Button_like_setting_Click);
            // 
            // button_deletion_list_like_post
            // 
            this.button_deletion_list_like_post.Location = new System.Drawing.Point(579, 356);
            this.button_deletion_list_like_post.Name = "button_deletion_list_like_post";
            this.button_deletion_list_like_post.Size = new System.Drawing.Size(75, 23);
            this.button_deletion_list_like_post.TabIndex = 8;
            this.button_deletion_list_like_post.Text = "Удалить пост из списка";
            this.button_deletion_list_like_post.UseVisualStyleBackColor = true;
            this.button_deletion_list_like_post.Click += new System.EventHandler(this.Button_deletion_list_like_post_Click);
            // 
            // textBox_added_list_like_post
            // 
            this.textBox_added_list_like_post.Location = new System.Drawing.Point(265, 314);
            this.textBox_added_list_like_post.Name = "textBox_added_list_like_post";
            this.textBox_added_list_like_post.Size = new System.Drawing.Size(271, 20);
            this.textBox_added_list_like_post.TabIndex = 7;
            this.textBox_added_list_like_post.Click += new System.EventHandler(this.TextBox_added_list_like_post_Click);
            this.textBox_added_list_like_post.TextChanged += new System.EventHandler(this.TextBox_added_list_like_post_TextChanged);
            // 
            // button_added_list_like_post
            // 
            this.button_added_list_like_post.Location = new System.Drawing.Point(579, 314);
            this.button_added_list_like_post.Name = "button_added_list_like_post";
            this.button_added_list_like_post.Size = new System.Drawing.Size(102, 23);
            this.button_added_list_like_post.TabIndex = 6;
            this.button_added_list_like_post.Text = "Добавить Пост";
            this.button_added_list_like_post.UseVisualStyleBackColor = true;
            this.button_added_list_like_post.Click += new System.EventHandler(this.Button_added_list_like_post_Click);
            // 
            // listBox_list_like_post
            // 
            this.listBox_list_like_post.FormattingEnabled = true;
            this.listBox_list_like_post.Location = new System.Drawing.Point(265, 15);
            this.listBox_list_like_post.Name = "listBox_list_like_post";
            this.listBox_list_like_post.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_list_like_post.Size = new System.Drawing.Size(286, 277);
            this.listBox_list_like_post.TabIndex = 5;
            // 
            // checkedListBox_list_like_post
            // 
            this.checkedListBox_list_like_post.FormattingEnabled = true;
            this.checkedListBox_list_like_post.Location = new System.Drawing.Point(18, 15);
            this.checkedListBox_list_like_post.Name = "checkedListBox_list_like_post";
            this.checkedListBox_list_like_post.Size = new System.Drawing.Size(217, 319);
            this.checkedListBox_list_like_post.TabIndex = 4;
            this.checkedListBox_list_like_post.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_list_like_post_SelectedIndexChanged);
            // 
            // tabPage_follow
            // 
            this.tabPage_follow.Controls.Add(this.textBox_added_account);
            this.tabPage_follow.Controls.Add(this.button_added_account);
            this.tabPage_follow.Controls.Add(this.button_unfollow_account_list);
            this.tabPage_follow.Controls.Add(this.button_follow_account_list);
            this.tabPage_follow.Controls.Add(this.button_deletion_account);
            this.tabPage_follow.Controls.Add(this.listBox_list_account);
            this.tabPage_follow.Controls.Add(this.checkedListBox_list_follow);
            this.tabPage_follow.Location = new System.Drawing.Point(4, 22);
            this.tabPage_follow.Name = "tabPage_follow";
            this.tabPage_follow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_follow.Size = new System.Drawing.Size(1000, 429);
            this.tabPage_follow.TabIndex = 1;
            this.tabPage_follow.Text = "Управление Подписками";
            this.tabPage_follow.UseVisualStyleBackColor = true;
            // 
            // textBox_added_account
            // 
            this.textBox_added_account.Location = new System.Drawing.Point(297, 325);
            this.textBox_added_account.Name = "textBox_added_account";
            this.textBox_added_account.Size = new System.Drawing.Size(240, 20);
            this.textBox_added_account.TabIndex = 11;
            this.textBox_added_account.Click += new System.EventHandler(this.TextBox_added_account_Click);
            this.textBox_added_account.TextChanged += new System.EventHandler(this.TextBox_added_account_TextChanged);
            // 
            // button_added_account
            // 
            this.button_added_account.Location = new System.Drawing.Point(555, 322);
            this.button_added_account.Name = "button_added_account";
            this.button_added_account.Size = new System.Drawing.Size(159, 23);
            this.button_added_account.TabIndex = 10;
            this.button_added_account.TabStop = false;
            this.button_added_account.Text = "Добавить Аккаунт";
            this.button_added_account.UseVisualStyleBackColor = true;
            this.button_added_account.Click += new System.EventHandler(this.Button_added_account_Click);
            // 
            // button_unfollow_account_list
            // 
            this.button_unfollow_account_list.Location = new System.Drawing.Point(555, 217);
            this.button_unfollow_account_list.Name = "button_unfollow_account_list";
            this.button_unfollow_account_list.Size = new System.Drawing.Size(159, 32);
            this.button_unfollow_account_list.TabIndex = 9;
            this.button_unfollow_account_list.Text = "Отписаться от аккаунтов";
            this.button_unfollow_account_list.UseVisualStyleBackColor = true;
            this.button_unfollow_account_list.Click += new System.EventHandler(this.Button_unfollow_account_list_Click);
            // 
            // button_follow_account_list
            // 
            this.button_follow_account_list.Location = new System.Drawing.Point(555, 160);
            this.button_follow_account_list.Name = "button_follow_account_list";
            this.button_follow_account_list.Size = new System.Drawing.Size(159, 30);
            this.button_follow_account_list.TabIndex = 8;
            this.button_follow_account_list.Text = "Подписаться на аккаунты";
            this.button_follow_account_list.UseVisualStyleBackColor = true;
            this.button_follow_account_list.Click += new System.EventHandler(this.Button_follow_account_list_Click);
            // 
            // button_deletion_account
            // 
            this.button_deletion_account.Location = new System.Drawing.Point(297, 372);
            this.button_deletion_account.Name = "button_deletion_account";
            this.button_deletion_account.Size = new System.Drawing.Size(187, 23);
            this.button_deletion_account.TabIndex = 7;
            this.button_deletion_account.Text = "Удалить аккаунт";
            this.button_deletion_account.UseVisualStyleBackColor = true;
            this.button_deletion_account.Click += new System.EventHandler(this.Button_deletion_account_Click);
            // 
            // listBox_list_account
            // 
            this.listBox_list_account.FormattingEnabled = true;
            this.listBox_list_account.Location = new System.Drawing.Point(288, 6);
            this.listBox_list_account.Name = "listBox_list_account";
            this.listBox_list_account.Size = new System.Drawing.Size(249, 303);
            this.listBox_list_account.TabIndex = 6;
            this.listBox_list_account.SelectedIndexChanged += new System.EventHandler(this.ListBox_list_account_SelectedIndexChanged);
            // 
            // checkedListBox_list_follow
            // 
            this.checkedListBox_list_follow.FormattingEnabled = true;
            this.checkedListBox_list_follow.Location = new System.Drawing.Point(25, 3);
            this.checkedListBox_list_follow.Name = "checkedListBox_list_follow";
            this.checkedListBox_list_follow.Size = new System.Drawing.Size(237, 379);
            this.checkedListBox_list_follow.TabIndex = 5;
            this.checkedListBox_list_follow.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox_list_follow_SelectedIndexChanged);
            // 
            // tabPage_Added_new_account
            // 
            this.tabPage_Added_new_account.Controls.Add(this.label_Password);
            this.tabPage_Added_new_account.Controls.Add(this.label_login);
            this.tabPage_Added_new_account.Controls.Add(this.label_added_account);
            this.tabPage_Added_new_account.Controls.Add(this.textBox_Password);
            this.tabPage_Added_new_account.Controls.Add(this.textBox_Login);
            this.tabPage_Added_new_account.Controls.Add(this.button_add_account_to_database);
            this.tabPage_Added_new_account.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Added_new_account.Name = "tabPage_Added_new_account";
            this.tabPage_Added_new_account.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Added_new_account.Size = new System.Drawing.Size(1014, 461);
            this.tabPage_Added_new_account.TabIndex = 1;
            this.tabPage_Added_new_account.Text = "Добавление Нового Аккаунта";
            this.tabPage_Added_new_account.UseVisualStyleBackColor = true;
            // 
            // label_added_account
            // 
            this.label_added_account.AutoSize = true;
            this.label_added_account.Location = new System.Drawing.Point(89, 30);
            this.label_added_account.Name = "label_added_account";
            this.label_added_account.Size = new System.Drawing.Size(0, 13);
            this.label_added_account.TabIndex = 3;
            this.label_added_account.Click += new System.EventHandler(this.label_added_account_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(198, 102);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(165, 20);
            this.textBox_Password.TabIndex = 2;
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(198, 65);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(165, 20);
            this.textBox_Login.TabIndex = 1;
            // 
            // button_add_account_to_database
            // 
            this.button_add_account_to_database.Location = new System.Drawing.Point(198, 139);
            this.button_add_account_to_database.Name = "button_add_account_to_database";
            this.button_add_account_to_database.Size = new System.Drawing.Size(165, 23);
            this.button_add_account_to_database.TabIndex = 0;
            this.button_add_account_to_database.Text = "Добавить новый аккаунт ";
            this.button_add_account_to_database.UseVisualStyleBackColor = true;
            this.button_add_account_to_database.Click += new System.EventHandler(this.Button_add_account_to_database_Click);
            // 
            // tabPage_Upload_statistics
            // 
            this.tabPage_Upload_statistics.Controls.Add(this.button_uploading_statistics);
            this.tabPage_Upload_statistics.Controls.Add(this.button_clear_statistics);
            this.tabPage_Upload_statistics.Controls.Add(this.textBox_log_message);
            this.tabPage_Upload_statistics.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Upload_statistics.Name = "tabPage_Upload_statistics";
            this.tabPage_Upload_statistics.Size = new System.Drawing.Size(1014, 461);
            this.tabPage_Upload_statistics.TabIndex = 2;
            this.tabPage_Upload_statistics.Text = "Выгрузка Статистики";
            this.tabPage_Upload_statistics.UseVisualStyleBackColor = true;
            // 
            // button_uploading_statistics
            // 
            this.button_uploading_statistics.Location = new System.Drawing.Point(298, 244);
            this.button_uploading_statistics.Name = "button_uploading_statistics";
            this.button_uploading_statistics.Size = new System.Drawing.Size(199, 23);
            this.button_uploading_statistics.TabIndex = 2;
            this.button_uploading_statistics.Text = "Выгрузка Статистики";
            this.button_uploading_statistics.UseVisualStyleBackColor = true;
            this.button_uploading_statistics.Click += new System.EventHandler(this.Button_uploading_statistics_Click);
            // 
            // button_clear_statistics
            // 
            this.button_clear_statistics.Location = new System.Drawing.Point(25, 244);
            this.button_clear_statistics.Name = "button_clear_statistics";
            this.button_clear_statistics.Size = new System.Drawing.Size(199, 23);
            this.button_clear_statistics.TabIndex = 1;
            this.button_clear_statistics.Text = "Очистить статистику";
            this.button_clear_statistics.UseVisualStyleBackColor = true;
            this.button_clear_statistics.Click += new System.EventHandler(this.Button_clear_statistics_Click);
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(125, 68);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(38, 13);
            this.label_login.TabIndex = 4;
            this.label_login.Text = "Логин";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(125, 109);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(45, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Пароль";
            this.label_Password.Click += new System.EventHandler(this.Label_Password_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 487);
            this.Controls.Add(this.tabControl_function);
            this.Name = "Form1";
            this.Text = "Instagram Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_function.ResumeLayout(false);
            this.tabPage_Managing_added_accounts.ResumeLayout(false);
            this.tabControl_function_be_added_account.ResumeLayout(false);
            this.tabPage_added_account.ResumeLayout(false);
            this.tabPage_like.ResumeLayout(false);
            this.tabPage_like.PerformLayout();
            this.tabPage_follow.ResumeLayout(false);
            this.tabPage_follow.PerformLayout();
            this.tabPage_Added_new_account.ResumeLayout(false);
            this.tabPage_Added_new_account.PerformLayout();
            this.tabPage_Upload_statistics.ResumeLayout(false);
            this.tabPage_Upload_statistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_log_message;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button_cookies;
        private System.Windows.Forms.TabControl tabControl_function;
        private System.Windows.Forms.TabPage tabPage_Managing_added_accounts;
        private System.Windows.Forms.CheckedListBox checkedListBox_list_account;
        private System.Windows.Forms.TabPage tabPage_Added_new_account;
        private System.Windows.Forms.TabPage tabPage_Upload_statistics;
        private System.Windows.Forms.TabControl tabControl_function_be_added_account;
        private System.Windows.Forms.TabPage tabPage_added_account;
        private System.Windows.Forms.TabPage tabPage_like;
        private System.Windows.Forms.CheckedListBox checkedListBox_list_like_post;
        private System.Windows.Forms.TabPage tabPage_follow;
        private System.Windows.Forms.CheckedListBox checkedListBox_list_follow;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Button button_add_account_to_database;
        private System.Windows.Forms.Label label_added_account;
        private System.Windows.Forms.Button button_uploading_statistics;
        private System.Windows.Forms.Button button_clear_statistics;
        private System.Windows.Forms.Button button_deletion_list_like_post;
        private System.Windows.Forms.TextBox textBox_added_list_like_post;
        private System.Windows.Forms.Button button_added_list_like_post;
        private System.Windows.Forms.ListBox listBox_list_like_post;
        private System.Windows.Forms.Button button_like_setting;
        private System.Windows.Forms.Button button_switch_off_like_setting;
        private System.Windows.Forms.TextBox textBox_added_account;
        private System.Windows.Forms.Button button_added_account;
        private System.Windows.Forms.Button button_unfollow_account_list;
        private System.Windows.Forms.Button button_follow_account_list;
        private System.Windows.Forms.Button button_deletion_account;
        private System.Windows.Forms.ListBox listBox_list_account;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_login;
    }
}

