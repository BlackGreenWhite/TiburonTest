import axios from "axios";

const baseUrl = "http://localhost:5000/api";

export const api = {
    sendStatistic: async (statisticModel: StatisticRequestModel) => await axios
                        .post(baseUrl+"/Statistic", statisticModel),
    getStatisticOnSite: async (siteUrl: string) => await axios
                        .get(baseUrl+"/Statistic/onsite?siteUrl="+siteUrl)
}

export interface StatisticRequestModel {
    SiteUrl: string,
    UserIp: string,
    BannerName: string,
    AdvEventsEnum: AdvEvents 
}

export enum AdvEvents {
    NotWatched,
    Watched,
    Clicked
}

