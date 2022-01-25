import React from "react";
import { Header } from "../src/header/header";
import { AdvWrapper } from "./adv/AdvWrapper";
import "./App.css";
import { StatisticWrapper } from "./pages/statistic/StatisticWrapper";

export const App: React.FC = () => {
  const myIp = generateRandomIp();
  return (
    <div className="page-wrapper">
      <header className="header">
        <Header />
      </header>
      <main className="page">
        <section className="advBlock">
          <AdvWrapper  bannerSrc="https://www.reviewpro.com/wp-content/uploads/2019/06/Google-logo.jpg " 
          width="195px" height="100px" targetSite="http://google.com" bannerName="googleBanner" myIp={myIp} />
        </section>  
        <section className="content">
            <StatisticWrapper />
        </section>
        <section className="advBlock">
        <AdvWrapper bannerSrc="https://assets.turbologo.ru/blog/ru/2020/02/18162740/Yandex-logo-958x575.png" 
          width="215px" height="143px" targetSite="http://ya.ru" bannerName="yandexBanner" myIp={myIp}/>
        </section>
      </main>
    </div>
  )
};

const generateRandomIp = () => {
  const ipArr = Array.from({length: 4}, () => Math.floor(Math.random() * 256).toString());
  return ipArr.join('.');
}
