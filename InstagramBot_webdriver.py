# Создадим отдельный файл для функций начала работы с Веб Драйвером
from selenium import webdriver

from selenium.webdriver.chrome.options import Options
# Обычный Браузер - главная страница
def InstagramBot_WebDriver_default():
    driver = webdriver.Chrome()
    # Делаем запущенный браузер в полное окно
    driver.maximize_window()
    driver.get('https://www.instagram.com/')
    return driver;

# Браузер в безголовом браузере - не отображает что делается
def InstagramBot_WebDriver_headless():
    options_headless = Options()
    options_headless.add_argument('--headless')
    driver = webdriver.Chrome(options=options_headless)
    # Делаем запущенный браузер в полное окно
    driver.maximize_window()
    driver.get('https://www.instagram.com/')
    return driver;

# Вебдрайвер эмулирующий поведение смартфона - айфон
def InstagramBot_WebDriver_mobile_Iphone():
    mobile_emulation = {
        "deviceMetrics": {"width": 360, "height": 640, "pixelRatio": 3.0},
        "userAgent": "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3 like Mac OS X) AppleWebKit/602.1.50 (KHTML, like Gecko) CriOS/56.0.2924.75 Mobile Safari/535.19"}
    chrome_options = Options()
    chrome_options.add_experimental_option("mobileEmulation", mobile_emulation)
    driver = webdriver.Chrome(options=chrome_options)
    # driver.get('https://www.instagram.com/')
    return driver;