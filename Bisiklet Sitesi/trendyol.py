from selenium import webdriver
from bs4 import BeautifulSoup
import random
import time

browser = webdriver.Firefox(executable_path=r"C:\Users\HARUN\Desktop\Kurulum\Selenium Python\Selenium ve Hepsiburada\geckodriver.exe")

url= "https://www.trendyol.com/sr?wc=104580&q=bisiklet&qt=bisiklet&st=bisiklet"



browser.get(url)
html=browser.page_source
time.sleep(2)
soup=BeautifulSoup(html,'html.parser')
#data=soup.find("div",{"class":"srch-prdcts-cntnr"})
#data=browser.find_element_by_css_selector(".p-card-wrppr add-to-bs-card")
"""for i in data:
    marka=i.find("span",{"class":"prdct-desc-cntnr-ttl"}).text
    baslik=i.find("span",{"class":"prdct-desc-cntnr-name hasRatings"}).text
    fiyat=i.find("div",{"class":"prc-box-dscntd"}).text
    foto=i.find("img",{"class":"p-card-img"})
    print(marka,baslik,fiyat,foto['src'])"""
"""ekle=[]
for i in range(10):
    #icerik=data.find("div",{"class":"p-card-wrppr add-to-bs-card"})
    ekle=soup.find("span",{"class":"prdct-desc-cntnr-ttl"}).text
    ekle=soup.find("span",{"class":"prdct-desc-cntnr-name hasRatings"}).text
    ekle=soup.find("div",{"class":"prc-box-dscntd"}).text
    ekle=soup.find("img",{"class":"p-card-img"})
    #print(marka,baslik,fiyat,foto['src'])
tweetCount = 1

with open("eklenenler.txt","w",encoding = "UTF-8") as file:
    for ek in ekle:
        file.write(str(tweetCount) + ".\n" + ek + "\n")
        file.write("**************************\n")
        tweetCount += 1"""
entries=[]

markalar=browser.find_elements_by_css_selector(".prdct-desc-cntnr-ttl")
basliklar=browser.find_elements_by_css_selector(".prdct-desc-cntnr-name")
fiyatlar=browser.find_elements_by_css_selector("prc-box-dscntd")
fotolar=browser.find_elements_by_css_selector("p-card-img")
foto=fotolar['src']
entries[markalar,basliklar,fiyatlar,foto]

browser.close()