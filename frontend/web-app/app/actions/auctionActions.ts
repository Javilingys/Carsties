'use server'
// server side functions

import { Auction, PagedResult } from "@/types";

// from node js erver to api, come back in server side, render and return to client html
export async function getData(query: string): Promise<PagedResult<Auction>> {
    // fetch also cache data
    const res = await fetch(`http://localhost:6001/search${query}`);

    if (!res.ok) throw new Error('Failed to fetch data');

    return res.json();
}