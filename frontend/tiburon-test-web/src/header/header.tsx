import React from "react";
import "./header.css";

export const Header: React.FC = () => 
{
    return (
        <div className="header-content">
            <h1 className="header__logo">         
            Header 
            </h1>
            <ul className="menu-list header__menu">
                <li className="menu-list__item">Пункт 1</li>
                <li className="menu-list__item">Пункт 2</li>
                <li className="menu-list__item">Пункт 3</li>
                <li className="menu-list__item">Пункт 4</li>
            </ul> 
        </div>
    )
}