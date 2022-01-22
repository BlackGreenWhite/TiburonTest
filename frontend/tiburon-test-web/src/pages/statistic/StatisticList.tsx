import React, { useEffect } from "react";
import { StatisticRow } from "./StatisticRow";
import "./StatisticStyles.css"
import {useList} from 'effector-react'
import {createStore, createEffect} from 'effector'
import { api } from "../../Api";


    export const fetchStoreFx = createEffect(async (siteUrl: string)=>{
        return await api.getStatisticOnSite(siteUrl);
    })
    const $statisticStore = createStore<any>([]).on(fetchStoreFx.doneData, (_,payload)=>payload.data);

    export const StatisticList = () => {
        const statisticList = useList($statisticStore, (statistic: any) => {
            return <StatisticRow {...statistic}/>
        })
        useEffect(()=>{
            fetchStoreFx(window.location.href);
        })
        return (
            <table className="statisticList">
                <thead>
                    <tr>
                        <th>UserIP</th>
                        <th>BannerName</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {statisticList}
                </tbody>
            </table>
        )
    }