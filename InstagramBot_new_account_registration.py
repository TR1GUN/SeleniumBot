# Давайте попытаемся сделать новый аккаунт инстаграмма
from selenium import webdriver
import time
import random
from selenium.webdriver.common.keys import Keys
import sqlite3
import datetime
import string
import secrets


# Функция нашего драйвера - запуск самого драйвера
def SMS_bomber_WebDriver():
    driver = webdriver.Chrome()
    # Делаем запущенный браузер в полное окно
    driver.maximize_window()
    return driver;

# функция генерации рандомной строки, принимает длину строки , возвращает саму строку
def random_string(len_string):
    # используя random.choices () генерация случайных строк
    random_string = ''.join(secrets.choice(string.ascii_uppercase + string.digits)
        for i in range(len_string))
    str(random_string)
    return random_string;

# функция создания базы данных. возвращает имя базы данных
def create_new_table():
    # Итак , для имени базы данных берем текущую дату
    date_time_now = datetime.datetime.now()
    name_data_base = 'UserDataBase' + str(date_time_now.year) + '-' + str(date_time_now.month) + '-' + str(date_time_now.day) + '_' +  str(date_time_now.hour) + '-' + str(date_time_now.minute) + '-' + str(date_time_now.second) + '.db'
    # Создаем базу данных
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # Создаем базу данных - поля таблицы : электронный адрес , имя и фамилия , ник пользователя , пароль
    data_base.execute("CREATE TABLE user (email text , first_last_name text , login_name text , user_password text)")
    return name_data_base ;

# Функция записи в бд , Принимает - имя бд , и переменные
def adding_data_to_tabble(name_data_base, instagram_email , instagram_first_last_name  , instagram_login_name , instagram_user_password):
    # Вставляем данные в таблицу
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # INSERT INTO название_таблицы (поле1, поле2 ... ) VALUES (значение1, значение2 ...)
    data_base.execute("INSERT INTO user VALUES (?, ?, ?, ?);", (instagram_email, instagram_first_last_name, instagram_login_name, instagram_user_password))
    # Сохраняем изменения
    user_data_base.commit()

def registration_new_user_WebDriver(table):
    try:
        driver = SMS_bomber_WebDriver()
        # Заходим на страницу
        driver.get('https://www.instagram.com/accounts/emailsignup/?hl=ru')
        time.sleep(3)
        # Электронный адрес
        field_email = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[3]/div/label/input')
        field_email.click()
        # генерируем емаил
        instagram_email = random_string(8) + '@gmail.com'
        field_email.send_keys(instagram_email)
        time.sleep(4)
        # имя и фамилия
        field_first_last_name = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[4]/div/label/input')
        instagram_first_last_name = 'Жмышенко Валерий Альбертович'
        field_first_last_name.click()
        field_first_last_name.send_keys(instagram_first_last_name)
        time.sleep(5)
        # ник пользователя
        field_login = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[5]/div/label/input')
        field_login.click()
        instagram_login_name = random_string(8)
        field_login.send_keys(instagram_login_name)
        time.sleep(5)
        # пароль
        field_password = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[6]/div/label/input')
        field_password.click()
        instagram_user_password = random_string(15)
        field_password.send_keys(instagram_user_password)
        time.sleep(5)
        # показываем пароль
        show_password = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[6]/div/div/div/button')
        show_password.click()
        time.sleep(4)
        # Кнопка зарегестироваться
        button = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[7]/div/button')
        button.click()
        time.sleep(5)


        # Печатаем наши данные :
        print('Введен email : ', instagram_email)
        print('Введенно имя и фамилия: ',instagram_first_last_name)
        print('Введен Логин: ',instagram_login_name)
        print('Введен Пароль: ',instagram_user_password)
        # И записываем наши данные в таблицу
        try:
            adding_data_to_tabble(table, instagram_email , instagram_first_last_name  , instagram_login_name , instagram_user_password)
            print('Данные успешно записанны')
        except:
            print('произошла ошибка при записи данных')
        print('Аккаунт зарегестрирован')
    except:
        print('Произошла ошибка при регистрации аккаунта')

# Функция массовой регистрации с созданием новой базы данных - принимает число аккаунтов
def registration_new_user_on_new_database(count):
    table = create_new_table()
    for i in range(count):
        registration_new_user_WebDriver(table)
        print('+')


driver = SMS_bomber_WebDriver()
        # Заходим на страницу
driver.get('https://www.instagram.com/accounts/emailsignup/?hl=ru')
time.sleep(3)
        # Электронный адрес
field_email = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[3]/div/label/input')
field_email.click()
        # генерируем емаил
instagram_email = random_string(8) + '@gmail.com'
field_email.send_keys(instagram_email)
time.sleep(4)
        # имя и фамилия
field_first_last_name = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[4]/div/label/input')
instagram_first_last_name = 'Жмышенко Валерий Альбертович'
field_first_last_name.click()
field_first_last_name.send_keys(instagram_first_last_name)
time.sleep(5)
        # ник пользователя
field_login = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[5]/div/label/input')
field_login.click()
instagram_login_name = random_string(8)
field_login.send_keys(instagram_login_name)
time.sleep(5)
        # пароль
field_password = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[6]/div/label/input')
field_password.click()
instagram_user_password = random_string(15)
field_password.send_keys(instagram_user_password)
time.sleep(5)
        # показываем пароль
show_password = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[6]/div/div/div/button')
show_password.click()
time.sleep(4)
        # Кнопка зарегестироваться
button = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[7]/div/button')
button.click()
# /////////////////////////////////////////////////
# Теперь надо ввести дату нашего рождения
# Массивы икспасов для дат, понадобятся чуть ниже
date_of_birth_year = ['/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[27]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[36]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[31]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[23]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[25]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[24]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[21]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[22]',
                      '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select/option[52]']

date_of_birth_month = ['/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[1]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[2]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[3]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[4]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[5]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[6]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[7]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[8]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[9]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[10]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[11]',
                       '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select/option[12]']

date_of_birth_day = ['/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[1]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[4]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[26]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[24]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[22]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[20]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[18]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[14]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[15]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[16]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[12]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[10]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[9]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[8]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[6]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[3]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[7]',
                     '/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select/option[27]']

# Итак тут задача - надо выбрать из выпадающего списка
# выбираем год
element_year = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[3]/select')
element_year.click()
time.sleep(2)
element_year_select = driver.find_element_by_xpath(date_of_birth_year[random.randint(0, 8)])
element_year_select.click()
time.sleep(2)
element_month = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[1]/select')
element_month.click()
time.sleep(2)
element_month_select = driver.find_element_by_xpath(date_of_birth_month[random.randint(0, 11)])
element_month_select.click()
time.sleep(2)
element_day = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/div[4]/div/div/span/span[2]/select')
element_day.click()
time.sleep(2)
element_day_select = driver.find_element_by_xpath(date_of_birth_day[random.randint(0, (len(date_of_birth_day) - 1) )])
element_day_select.click()
time.sleep(2)
button_onward = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/article/div/div[1]/div/div[5]/div[2]/button')
button_onward.click()
time.sleep(5)
