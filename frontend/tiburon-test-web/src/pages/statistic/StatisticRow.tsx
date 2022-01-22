import React from "react";

export const StatisticRow = (props: any) => {
    return (
        <tr>
            <td>{props.userIP}</td>
            <td>{props.bannerName}</td>
            <td>{props.advEventsEnum}</td>
        </tr>
    )
}