# Итак здесь опишем функции для входа в аккаунт на сайте

import sqlite3 as lite
import time
from selenium.webdriver.common.keys import Keys
import sqlite3
import datetime
import InstagramBot_webdriver
import pickle
import os
# функция создания базы данных. возвращает имя базы данных
def create_new_table():
    # Итак , для имени базы данных берем текущую дату
    date_time_now = datetime.datetime.now()
    name_data_base = 'UserDataBase.db'
    # Создаем базу данных
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # Создаем базу данных - поля таблицы :  ник пользователя , пароль , Куки
    data_base.execute("CREATE TABLE user ( login_name text , user_password text, user_cookie BLOB)")
    return name_data_base ;
# Функция записи в бд , Принимает - имя бд , и переменные
def adding_data_to_tabble(name_data_base, instagram_login_name , instagram_user_password):
    # Вставляем данные в таблицу
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # INSERT INTO название_таблицы (поле1, поле2 ... ) VALUES (значение1, значение2 ...)
    data_base.execute("INSERT INTO user VALUES (?, ?, ?, ?);", ( instagram_login_name, instagram_user_password))
    # Сохраняем изменения
    user_data_base.commit()

# Записываем Куки В БД - Путь до файла кук, имя базы данных, логин , пароль
def loading_cookies_into_the_database(file_cookie ,name_data_base ,instagram_user_password , instagram_login_name ):
    # открываем файл кук
    user_cookies = open(file_cookie, "rb")
    file = user_cookies.read()
    user_cookies.close()
    # переводим в двоичный код для записи
    binary_cookie = lite.Binary(file)
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
# INSERT INTO название_таблицы (поле1, поле2 ... ) VALUES (значение1, значение2 ...)
#     Записываем данные
    data_base.execute("INSERT INTO user VALUES (?, ?, ?);", (instagram_login_name, instagram_user_password, binary_cookie))
# Сохраняем изменения
    user_data_base.commit()
# Выгружаем куки из базы данных - имя базы данных , логин по которому искать, возвращает путь до файла куки
def unloading_cookies_into_the_database(name_data_base, instagram_login_name ):
    #Выгрузка файла из БД
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # Запрос получения всех данных
    # sql_request_all = "Select * from user where login_name = ? "
    # Запрос для получения только Куки
    sql_request = "Select user_cookie from user where login_name = ?"
    data_base.execute( sql_request, [instagram_login_name ])
    data = data_base.fetchone()[0]
    file_cookie = str(instagram_login_name) + '_' + "cookie-login.pkl"
    file_output = open(file_cookie,"wb")
    file_output.write(data)
    file_output.close()
    data_base.close()
    return file_cookie;
# Функция Сохранения Куки - Кушает - Класс драйвера и указание где лежат Куки
def save_cookies (driver , location):
    pickle.dump(driver.get_cookies(), open(location, "wb"))
# Функция Добавления Куки - Принимает : Драйвер , имя , адрес
def load_cookies(driver, location , url=None):
    cookies = pickle.load(open(location, "rb"))
    driver.delete_all_cookies()
    driver.get(url)
    for cookie in cookies:
        # Проверка на обязательный ключ - срок годности куки
        if 'expiry' in cookie:
        # Без этого не работает с инстаграмом - удаляем из словоря куку срока годности.
            del cookie['expiry']
        driver.add_cookie(cookie)

# Функция для удаления и тут же вставки куки
def delite_cookies(driver, domains = None):
    cookies = driver.get_cookies()
    for cookie in cookies:
        if domains is not None :
            if str(cookie["domain"]) in domains:
                cookies.remove(cookie)
        else:
            driver.delete_all_cookies()
            return
    driver.delete_all_cookies()
    for cookie in cookies:
        driver.add_cookie(cookie)
# авторизация с помощью куки
def auth_instagram_with_using_cookies(instagram_login_name):
    try:
        # подготавиливаем куки - деграем их из БД
        name_data_base = 'UserDataBase.db'
        location = unloading_cookies_into_the_database(name_data_base, instagram_login_name )
        # Дергаем готовый шаблон драйвера айфона
        driver = InstagramBot_webdriver.InstagramBot_WebDriver_mobile_Iphone()
        # Загружаем куки
        load_cookies(driver=driver, location=location, url='https://www.instagram.com/')
        driver.refresh()
        time.sleep(5)
        # удаляем файл куки
        os.remove(location)
        print('Вход с помощью Cookies - Успешно')
    except:
        print('Вход с помощью Cookies - Неудачно')
    finally:
        return driver

# первичная авторизация с сохранением куки входа
def auth_instagram_to_new_prifile(instagram_login_name , instagram_user_password):
    # Запускаем драйвер айфона
    driver = InstagramBot_webdriver.InstagramBot_WebDriver_mobile_Iphone()
    driver.get('https://www.instagram.com/')
    time.sleep(5)
    try:
        # Проверка надписи
        assert "instagram" in driver.page_source
        time.sleep(4)
        button_login = driver.find_element_by_xpath('/html/body/div[1]/section/main/article/div/div/div/div[2]/button')
        button_login.click()
        time.sleep(3)
        space_login = driver.find_element_by_xpath('/html/body/div[1]/section/main/article/div/div/div/form/div[2]/div/label/input')
        space_login.click()
        space_login.send_keys(instagram_login_name)
        time.sleep(3)
        space_password = driver.find_element_by_xpath('/html/body/div[1]/section/main/article/div/div/div/form/div[3]/div/label/input')
        space_password.click()
        space_password.send_keys(instagram_user_password)
        time.sleep(3)
        button_ligin_final = driver.find_element_by_xpath('/html/body/div[1]/section/main/article/div/div/div/form/div[5]/button')
        button_ligin_final.click()
        time.sleep(5)
        # сохраняем данные
        button_save = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/div/section/div/button')
        button_save.click()
        time.sleep(5)
        # Отказываемся от главного экрана
        button_close_popup1 = driver.find_element_by_xpath('/html/body/div[4]/div/div/div[3]/button[2]')
        button_close_popup1.click()
        time.sleep(5)
        try:
            # Закрываем нижнее преждложение
            button_close_use_app = driver.find_element_by_xpath('/html/body/div[1]/section/div[2]/div/div[1]/button')
            button_close_use_app.send_keys(Keys.DOWN)
            button_close_use_app.send_keys(Keys.DOWN)
            button_close_use_app.send_keys(Keys.DOWN)
            time.sleep(3)
            button_close_use_app.click()
            time.sleep(2)
        except:
            time.sleep(2)
        # driver.close()
        # Сохраняем куки в файл
        file_cookie = str(instagram_login_name) + '_' + "cookie-login.pkl"
        save_cookies(driver=driver , location=file_cookie)
        # загружаем Куки в БД
        name_data_base = 'UserDataBase.db'
        loading_cookies_into_the_database(file_cookie ,name_data_base ,instagram_user_password , instagram_login_name )
        # driver.quit()
        time.sleep(5)
        os.remove(file_cookie)
        print('Первичный вход - Успешно')
    except:
        print('Первичный вход - Неудачно')
    finally:
        return driver;
# Итак , напишем здесь общую функцию входа -
# сначала проверяем наличие ника в бд ,затем попытаемся зайти с помощью кук , если неудачно то входим с помощью обычного входа
# функция поиска В БД ника пользоваьтеля
def search_user_login_in_database(instagram_login_name):
    name_data_base = 'UserDataBase.db'
    user_data_base = sqlite3.connect(name_data_base)
    data_base = user_data_base.cursor()
    # Запрос для получения только логина
    sql_request = "Select login_name from user where login_name = ?"
    data_base.execute( sql_request, [instagram_login_name ])
    data = data_base.fetchone()[0]
    return data

# Окончательная функция входа в аккаунт
def InstagramBot_profile_login(instagram_login_name):
    profile_name = search_user_login_in_database(instagram_login_name)
    if profile_name == instagram_login_name:
        print( 'Профиль', profile_name , 'найден')
        try:
            print('Попробуем авторизизоваться с помощью Cookies')
            driver = auth_instagram_with_using_cookies(instagram_login_name)
        except:
            print('Вход с помощью Cookies неудался , попробуем войти в обычный вход, введите пароль к профилю')
            instagram_user_password = input()
            driver = auth_instagram_to_new_prifile(instagram_login_name, instagram_user_password)
    else:
        print('Профиль', profile_name, 'Не найден, введите пароль к профилю')
        instagram_user_password = input()
        driver = auth_instagram_to_new_prifile(instagram_login_name, instagram_user_password)
    try:
        assert instagram_login_name in driver.page_source
        print('Успешно')
    except:
        print('Вход в профиль неудачный')
    return driver;

