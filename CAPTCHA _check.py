from selenium import webdriver
import time
def SMS_bomber_WebDriver():
    driver = webdriver.Chrome()
    # Делаем запущенный браузер в полное окно
    driver.maximize_window()
    return driver;

driver = SMS_bomber_WebDriver()
driver.get('https://patrickhlauke.github.io/recaptcha/')
time.sleep(5)

check_box = driver.find_element_by_xpath('//*[@id="recaptcha-anchor"]/div[1]')
print('капча найдена')
check_box.click()
time.sleep(5)

