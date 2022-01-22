import React from "react";
import { Adv } from "./Adv";
import { AdvModel } from "./AdvModel";
import "./AdvStyles.css"


export const AdvWrapper = (props : AdvModel) =>
{
    return (
        <div className="advBlockWrapper">
            <Adv {...props}/>
        </div>
    );
}