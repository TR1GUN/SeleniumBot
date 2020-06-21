import InstagramBot_account_login
import time

# Функция лайка поста
def like_post_on_separate_post_page(driver):
    time.sleep(2)
    # Ищем лайк , и кликаем
    button_like = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/div/article/div[2]/section[1]/span[1]/button')
    button_like.click()
    return driver
# функция для отслеживания уже поставленного лайка
def find_out_the_status_of_the_like(driver):
    # like_status = driver.find_element_by_xpath('/html/body/div[1]/section/main/div/div/article/div[2]/section[1]/span[1]/button/svg')
    try:
        # Проверяем , поставлен ли лайк
        assert 'fill="#ed4956"' in driver.page_source
        like_already_set = True
    except:
        like_already_set = False
    return like_already_set;

# функция для постановки лайка:
# Кушает драйвер и линк ,возвращает линк
def InstagramBot_to_take_like_on_the_post_by_link(instagram_login_name, link_to_post):

    driver = InstagramBot_account_login.InstagramBot_profile_login(instagram_login_name)
    # обработка ссылки :
    if 'https://www.instagram.com/' in link_to_post :
        link_to_post = link_to_post
    else:
        link_to_post = 'https://www.instagram.com/' + link_to_post
    driver.get(link_to_post)
    # чтоб понимать , лайк поставлен или нет , надо узнать цвет
    # Если возвращается True , то лайк уже поставлен
    like_already_set = find_out_the_status_of_the_like(driver)
    if like_already_set == True :
        print('Лайк уже поставлен')
    else:
        like = like_post_on_separate_post_page(driver)
    # Проверяем поставлен ли лайк :
    like_already_set_check = find_out_the_status_of_the_like(driver)
    if like_already_set_check == True :
        print('Лайк на Пост' ,link_to_post , 'Успешно Поставлен')
    time.sleep(5)
    driver.close()

# Функция снятия лайка
def InstagramBot_to_take_off_like_on_the_post_by_link(instagram_login_name, link_to_post):

    driver = InstagramBot_account_login.InstagramBot_profile_login(instagram_login_name)
    # обработка ссылки :
    if 'https://www.instagram.com/' in link_to_post :
        link_to_post = link_to_post
    else:
        link_to_post = 'https://www.instagram.com/' + link_to_post
    driver.get(link_to_post)
    # чтоб понимать , лайк поставлен или нет , надо узнать цвет
    # Если возвращается True , то лайк уже поставлен
    like_already_set = find_out_the_status_of_the_like(driver)
    if like_already_set == True :
        like = like_post_on_separate_post_page(driver)
    else:
        print('Лайк еще не поставлен')
    # Проверяем поставлен ли лайк :
    like_already_set_check = find_out_the_status_of_the_like(driver)
    if like_already_set_check == True :
        print('Лайк на Пост' ,link_to_post , 'Успешно Снято')
    time.sleep(5)
    driver.close()

