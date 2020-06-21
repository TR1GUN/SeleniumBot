# Здесь вторая часть нашего бомбера - Заказ звонка.
from selenium import webdriver
import time
import random
from selenium.webdriver.common.keys import Keys

from selenium.webdriver.common.action_chains import ActionChains

# Имя
name = ['Сузам', 'Василий', 'Алексей', 'Валерий','Иван','Дмитрий']
# Номер телефона
number = ' '

# Функция нашего драйвера - запуск самого драйвера
def SMS_bomber_WebDriver():
    driver = webdriver.Chrome()
    # Делаем запущенный браузер в полное окно
    driver.maximize_window()
    return driver;

# Менза Кафе
def SMS_bomber_Menza(number, name):
    driver = SMS_bomber_WebDriver()
    # Переходим на сайт
    driver.get('https://menza-cafe.ru/system/call_me.php')
    time.sleep(3)
    try:
        # Проверяем , туда ли зашли
        assert "Menza" in driver.page_source
        time.sleep(3)
        # Поиск поля имени
        field_name = driver.find_element_by_xpath('//*[@id="edit-field1"]')
        field_name.click()
        # вставка имени из массива имен
        field_name.send_keys(name[random.randint(0, 5)])
        time.sleep(3)
        # Поиск поля телефона и вставка
        field_number = driver.find_element_by_xpath('//*[@id="edit-field2"]')
        field_number.click()
        field_number.send_keys(number)
        time.sleep(3)
        # Кнопочка отправить
        button = driver.find_element_by_xpath('//*[@id="edit-submit--3"]')
        button.click()
        time.sleep(5)
        print('Menza - Успешно')
    except:
        print('Menza - Неудачно')
    finally:
        driver.close()

# МакиМаки
def SMS_bomber_MakiMaki(number, name):
    driver = SMS_bomber_WebDriver()
    # Переходим на сайт
    driver.get('https://makimaki.ru/system/callback.php')
    time.sleep(3)
    try:
        # Проверяем , туда ли зашли
        assert "makimaki" in driver.page_source
        time.sleep(3)
        # Поиск поля имени
        field_name = driver.find_element_by_xpath('//*[@id="cb_fio"]')
        field_name.click()
        # вставка имени из массива имен
        field_name.send_keys(name[random.randint(0, 5)])
        time.sleep(3)
        # Поиск поля телефона и вставка
        field_number = driver.find_element_by_xpath('//*[@id="cb_phone"]')
        field_number.click()
        field_number.send_keys(number)
        time.sleep(3)
        # Кнопочка отправить
        button = driver.find_element_by_xpath('/html/body/div[4]/div[1]/form/input[3]')
        button.click()
        time.sleep(5)
        print('Maki-Maki - Успешно')
    except:
        print('Maki-Maki - Неудачно')
    finally:
        driver.close()

def SMS_bomber_booking_okeansushi(number, name):
    # Теперь пойдем дальше - и сделаем заказ на похожем сайте - океан суши
    driver = SMS_bomber_WebDriver()
    # Переходим на сайт
    driver.get('https://okeansushi.ru/veshnyaki/sety/#formaniz')
    time.sleep(3)
    try:
        # Проверяем , туда ли зашли
        assert "Океан Суши" in driver.page_source
        time.sleep(3)
        # Делаем заказ
        button_booking = driver.find_element_by_xpath('//*[@id="tocart_507"]')
        button_booking.click()
        time.sleep(5)
        # Теперь берем - и проматываем страницу
        button_booking.send_keys(Keys.END)
        time.sleep(3)
        # а теперь закрываем всплывающее окно
        button_close = driver.find_element_by_xpath('/html/body/div[1]/div[1]')
        button_close.click()
        time.sleep(3)
        # смотрим корзину
        button_basket = driver.find_element_by_xpath('/html/body/div[1]/div/header/div/div[1]/div[3]/div[2]/div/a[2]')
        button_basket.click()
        time.sleep(3)
        # снова проматываем страницу вниз и ставим нового пользователя
        button_checkbox1 = driver.find_element_by_xpath('//*[@id="new-styler"]')
        button_checkbox1.click()
        time.sleep(1)
        # Заполняем обязательные поля
        # Заполняем имя
        textbox_name = driver.find_element_by_xpath('//*[@id="name_f"]')
        textbox_name.click()
        textbox_name.send_keys(name[random.randint(0, 5)])
        time.sleep(2)
        # Заполняем номер
        textbox_number = driver.find_element_by_xpath('//*[@id="phone_cast"]')
        textbox_number.click()
        textbox_number.send_keys(number[1:])
        time.sleep(2)
        # Заполняем е мейл
        textbox_email = driver.find_element_by_xpath('//*[@id="custinfo_form"]/div/div[4]/div[3]/div/input')
        textbox_email.click()
        textbox_email.send_keys('Seleniumlol@gmail.com')
        time.sleep(2)
        # Заполняем улицу
        textbox_street = driver.find_element_by_xpath('//*[@id="street"]')
        textbox_street.click()
        textbox_street.send_keys('Улица Валерия Жмышенко')
        time.sleep(2)
        # Заполняем номер дома
        textbox_home = driver.find_element_by_xpath('//*[@id="home"]')
        textbox_home.click()
        textbox_home.send_keys('13')
        time.sleep(2)
        # Ставим согласие на обработку персональных данных
        checkbox_consent_regulations = driver.find_element_by_xpath('//*[@id="pravila"]/div[1]')
        checkbox_consent_regulations.click()
        time.sleep(2)
        # Жмякаем на кнопку заказать
        button_to_order = driver.find_element_by_xpath('//*[@id="booking"]')
        button_to_order.click()
        time.sleep(5)
        print('Океан Суши - Успешно')
    except:
        print('Океан Суши - Неудачно')
    finally:
        driver.close()

# А теперь интернет магазин  - Все нам знакомый Мвидео
def SMS_bomber_booking_Mvideo(number, name):
    driver = SMS_bomber_WebDriver()
    # Переходим на страницу товара
    driver.get('https://www.mvideo.ru/products/noutbuk-apple-macbook-air-13-i5-1-8-8gb-128ssd-mqd32ru-a-30028577')
    time.sleep(5)
    try:
        # Подтверждаем геолокацию
        button_geolocation = driver.find_element_by_xpath('/html/body/div[1]/div/div[6]/div[1]/div/div/div/a[2]')
        button_geolocation.click()
        time.sleep(5)
        # Чтоб убрать всплывающее окно - перезагружаем страницу
        driver.refresh()
        time.sleep(3)
        # делаем  заказ
        button_quick_order = driver.find_element_by_xpath(
            '/html/body/div[1]/div/div[3]/div[1]/div[3]/div[2]/div/div[3]/div[1]/input')
        button_quick_order.click()
        time.sleep(5)
        # Потверждение того что мы делали
        button_quick_order_continuation = driver.find_element_by_xpath('/html/body/div[13]/div/div[2]/div/div/a[2]')
        button_quick_order_continuation.click()
        time.sleep(3)
        # Продолжение оформления заказа
        button_continue_clearance = driver.find_element_by_xpath(
            '/html/body/div[4]/div[1]/div[2]/div[2]/form/div[3]/div/div[3]/div/div/input[5]')
        button_continue_clearance.click()
        time.sleep(3)
        # отказываемся от регистрации
        button_continue_without_authorization = driver.find_element_by_xpath(
            '/html/body/div[1]/div[1]/div[2]/div[3]/form/input[7]')
        button_continue_without_authorization.click()
        time.sleep(3)
        # вводим данные получателя заказа
        field_email = driver.find_element_by_xpath('//*[@id="field_8"]')
        field_email.click()
        field_email.send_keys('Seleniumlol@gmail.com')
        time.sleep(3)
        field_name = driver.find_element_by_xpath('//*[@id="field_6"]')
        field_name.click()
        field_name.send_keys(name[random.randint(0, 5)])
        time.sleep(3)
        field_numer = driver.find_element_by_xpath('//*[@id="myPhone"]')
        field_numer.click()
        field_numer.send_keys(number[1:])
        time.sleep(3)
        button_make_an_order = driver.find_element_by_xpath(
            '/html/body/div[1]/div[1]/div[2]/div[3]/div[2]/div/form/input[9]')
        button_make_an_order.click()
        time.sleep(3)
        print('М.Видео - Успешно')
    except:
        print('М.Видео - Неудачно')
    finally:
        driver.close()

# Попробуем еще раз сделать заказ - Магазин книг Лабиринт
def SMS_bomber_booking_Labirint(number, name):
    driver = SMS_bomber_WebDriver()
    # Переходим на сайт
    driver.get('https://www.labirint.ru/books/714909/')
    time.sleep(3)
    try:
        # ищем кнопку заказать
        button_add_to_basket = driver.find_element_by_xpath('//*[@id="buyingbtns714909"]/a')
        button_add_to_basket.click()
        time.sleep(3)
        # Подтверждаем куки
        button_cookies = driver.find_element_by_xpath('/html/body/div[1]/div[6]/div[6]/div[2]/button')
        button_cookies.click()
        time.sleep(5)
        # Теперь оформляем заказ
        button_checkout = driver.find_element_by_xpath('//*[@id="buyingbtns714909"]/a[2]')
        button_checkout.click()
        time.sleep(5)
        # Подтверждаем заказ
        button_placing_an_order = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[3]/div/div/div/div/div[1]/form/div[4]/div[3]/div/button')
        button_placing_an_order.send_keys(Keys.DOWN)
        webdriver.ActionChains(driver).move_to_element(button_placing_an_order).click(button_placing_an_order).perform()
        # тут сложность и однавременно хитрость против ботов - центр кнопки не имеет самого баттона. Поэтому нельзя сделать сразу клик. надо "щелкнуть" немного скраю - чуть выше чем сама надпись
        cursor_offset = ActionChains(driver)
        # Делаем смещение чуть вверх и делаем эмуляцию нажатия ЛКМ
        cursor_offset.move_to_element(button_placing_an_order).move_by_offset(int(-20), int(-7)).click().perform()
        # А тут важно - надо много ждать. Идет проверка всех пунктов самовывоза
        time.sleep(10)
        # Теперь оформляем заказ
        # Здесь опять же  - надо искать по FullxPath
        # Электронная почта
        field_email = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[1]/div[1]/input')
        field_email.click()
        field_email.send_keys('Seleniumlol' + str(random.randint(7, 15)) + '@gmail.com')
        time.sleep(3)
        # Телефон
        field_mobile = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[1]/div[3]/span[1]/input[2]')
        field_mobile.click()
        field_mobile.send_keys(number[1:])
        time.sleep(3)
        # Фамилия
        field_last_name = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[1]/div[7]/input')
        field_last_name.click()
        field_last_name.send_keys('Жмышенко')
        time.sleep(3)
        # Имя - Есть заморока - надо так же скрыть всплывающее окно, после того , как написали имя
        field_first_name = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[2]/div[5]/div/div[1]/div[6]/input')
        field_first_name.click()
        field_first_name.send_keys(name[random.randint(0, 5)])
        time.sleep(3)
        field_email.click()
        # А теперь жаришка : выбор на карте пункта самовывоза
        checkbox_pickup = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[1]/div[3]/div/div[2]/div[2]/div/div[1]/label')
        checkbox_pickup.click()
        time.sleep(10)
        # Тут очень сложно , ибо тут карта
        # Ищем по адресу
        address = 'Лермонтовский, д. 6'
        field_find_address = driver.find_element_by_xpath('/html/body/div[6]/div/div[1]/div[3]/input')
        field_find_address.click()
        field_find_address.send_keys(address)
        time.sleep(5)
        # Выбираем его
        field_address_selection = driver.find_element_by_xpath('/html/body/div[6]/div/div[1]/div[3]/div/div[786]')
        field_address_selection.click()
        time.sleep(3)
        # подтверждаем точку самовывоз
        button_confirmation_of_pickup_point = driver.find_element_by_xpath(
            '/html/body/div[6]/div/div[2]/ymaps/ymaps/ymaps[1]/ymaps[7]/ymaps/ymaps/ymaps/ymaps[1]/ymaps[2]/ymaps/ymaps/div/div[4]/div[3]/span')
        button_confirmation_of_pickup_point.click()
        time.sleep(5)
        # Завершаем заказ
        button_finish_checkout = driver.find_element_by_xpath(
            '/html/body/div[1]/div[6]/div[4]/div/div/div/div/div/div[2]/div/div[2]/form/div[6]/div[4]')
        button_finish_checkout.click()
        time.sleep(10)
        print('Лабиринт - Успешно')
    except:
        print('Лабиринт - Неудачно')
    finally:
        driver.close()



SMS_bomber_Menza(number, name)
SMS_bomber_MakiMaki(number, name)
SMS_bomber_booking_okeansushi(number, name)
SMS_bomber_booking_Labirint(number, name)
SMS_bomber_booking_Mvideo(number, name)
