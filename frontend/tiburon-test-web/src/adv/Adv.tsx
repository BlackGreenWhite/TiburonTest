import { createEffect, createEvent, forward } from "effector";
import React, { useEffect, useState } from "react";
import { AdvEvents, api, StatisticRequestModel } from "../Api";
import { fetchStoreFx } from "../pages/statistic/StatisticList";
import { AdvModel } from "./AdvModel";

const sendStatisticFx = createEffect(async (statisticRequest: StatisticRequestModel) => {
    await api.sendStatistic(statisticRequest);
    fetchStoreFx(window.location.href);
})
const AdvEvent = createEvent<StatisticRequestModel>();

forward({
    from: AdvEvent,
    to: sendStatisticFx.prepend(req => req)
})

export const Adv= ({targetSite, bannerSrc, width, height, bannerName, myIp} : AdvModel) =>
{
    const [eventLocks, setEventLocks] = useState({watched:false, clicked:false, loaded: false});
    const eventHandler = (advEvent: AdvEvents, lockerName: "watched" | "clicked" | "loaded") => 
    {
        if (lockerName && eventLocks[lockerName] === false) 
            {
                AdvEvent({SiteUrl: window.location.href, UserIp: myIp, BannerName: bannerName, AdvEventsEnum: advEvent })
                let replacer = eventLocks;
                replacer[lockerName] = true;
                setEventLocks(replacer);
            }
    }

    useEffect(()=>{
        eventHandler(AdvEvents.NotWatched, "loaded")
    });
    return (
        <div className="adv-wrapper" >
            <a href="" onClick={(e)=>e.preventDefault()}>
                <img src={bannerSrc}  width={width} height={height} alt="Banner can't be loaded" 
                    onClick={()=>eventHandler(AdvEvents.Clicked, "clicked")} 
                    onMouseEnter={()=>eventHandler(AdvEvents.Watched, "watched")} />
            </a>
        </div>
    );
}

