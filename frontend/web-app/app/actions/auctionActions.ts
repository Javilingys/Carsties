'use server'
// server side functions

import { Auction, PagedResult } from "@/types";
import { getTokenWorkaround } from "./authActions";

// from node js erver to api, come back in server side, render and return to client html
export async function getData(query: string): Promise<PagedResult<Auction>> {
    // fetch also cache data
    const res = await fetch(`http://localhost:6001/search${query}`);

    if (!res.ok) throw new Error('Failed to fetch data');

    return res.json();
}

export async function UpdateAuctionTest() {
    const data = {
        mileage: Math.floor(Math.random() * 100000) + 1 // random from 1 - 100_000
    }

    const token = await getTokenWorkaround();

    const res = await fetch('http://localhost:6001/auctions/bbab4d5a-8565-48b1-9450-5ac2a5c4a654', {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'Authorization': 'Bearer ' + token?.acess_token
        },
        body: JSON.stringify(data)
    })

    if (!res.ok) return {status: res.status, message: res.statusText}

    return res.statusText;
}
