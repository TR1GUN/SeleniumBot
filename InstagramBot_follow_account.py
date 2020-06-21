

import time
import InstagramBot_account_login

# Функция обработки ссылки
def processing_the_correct_link(link):
    if 'https://www.instagram.com/' in link :
        link = link
    else:
        link = 'https://www.instagram.com/' + link
    return link;

# функция для выявления ника в ссылке на аккаунт
def account_name(link):
    name = link[26:]
    return name

# Функция для подписки на аккаунт
def InstagramBot_follow(driver, link_to_account):
    # обработка ссылки :
    link  = processing_the_correct_link(link = link_to_account)
    # переходим на сам аккаунт
    driver.get(link)
    time.sleep(5)
    name = account_name(link)
    try:
        assert name in driver.page_source
        print('Пользователь', name ,'Найден')
# Кнопка Подписки - действует в ту и другую сторону- это важно
# Поэтому поступаем так - Если появляется кнопка отписки - жмякаем - отмену
        try:
            button_follow_subscribe_account = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/header/section/div[2]/div/span/span[1]/button')
            button_follow_subscribe_account.click()
            time.sleep(5)
            button_close = driver.find_element_by_xpath('/html/body/div[4]/div/div/div[3]/button[2]')
            button_close.click()
            time.sleep(2)
            print('Подписка на аккаунт', link_to_account, 'уже стоит')
        except:
            print('Подписка на аккаунт',link_to_account,'- Успешно')
    except:
        print('Страница пользователя',name ,'Не найдена')
    driver.close()
    return driver;


# Функция для отписки от аккаунта.
def InstagramBot_repeal_follow(driver, link_to_account):
    # обработка ссылки :
    link  = processing_the_correct_link(link = link_to_account)
    # переходим на сам аккаунт
    driver.get(link)
    time.sleep(5)
    name = account_name(link)
    try:
        assert name in driver.page_source
        print('Пользователь', name ,'Найден')
# Тут в разы сложнее и надо сделать обратную последовательность.
        try:
            button_follow_subscribe_account = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/header/section/div[2]/div/span/span[1]/button')
            button_follow_subscribe_account.click()
            time.sleep(5)
            # Ищем и кликаем кнопку отписки
            button_unsubscribe = driver.find_element_by_xpath('/html/body/div[4]/div/div/div[3]/button[1]')
            button_unsubscribe.click()
            time.sleep(2)
            print('Отписка от аккаунта', link_to_account, 'Успешно')
        except:
            # При ошибке отписки - очень важный момент - мы подписываемся. Поэтому тут костыль - Вторичная отписка.
            print('Вы не были подписаны на аккаунт ',link_to_account,', Исправляем')
            time.sleep(5)
            button_follow_subscribe_account = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/header/section/div[2]/div/span/span[1]/button')
            button_follow_subscribe_account.click()
            time.sleep(5)
            # Ищем и кликаем кнопку отписки
            button_unsubscribe = driver.find_element_by_xpath('/html/body/div[4]/div/div/div[3]/button[1]')
            button_unsubscribe.click()
            time.sleep(2)
    except:
        print('Страница пользователя',name ,'Не найдена')
    driver.close()
    return driver;

