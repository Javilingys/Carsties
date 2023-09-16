"use client";

import { Auction, PagedResult } from "@/types";
import { useEffect, useState } from "react";
import shallow from "zustand/shallow";
import qs from "query-string";
import { getData } from "../actions/auctionActions";
import Filters from "./Filters";
import AuctionCard from "./AuctionCard";
import AppPagination from "../components/AppPagination";
import { useParamsStore } from "@/hooks/useParamsStore";
import EmptyFilter from "../components/EmptyFilter";
import { useAuctionStore } from "@/hooks/useAuctionStore";

export default function Listings() {
	const [loading, setLoading] = useState(true);
	const params = useParamsStore((state) => ({
		pageNumber: state.pageNumber,
		pageSize: state.pageSize,
		searchTerm: state.searchTerm,
		orderBy: state.orderBy,
		filterBy: state.filterBy,
		seller: state.seller,
		winner: state.winner
	}));
	const data = useAuctionStore(state => ({
		auctions: state.auctions,
		totalCount: state.totalCount,
		pageCount: state.pageCount
	}));
	const setData = useAuctionStore(state => state.setData);

	const setParams = useParamsStore((state) => state.setParams);
	const url = qs.stringifyUrl({ url: "", query: params });

	function setPageNumber(pageNumber: number) {
		setParams({ pageNumber: pageNumber });
	}

	// executs AT LEAST ONCE, when component is loading, And then depeneding what happen to re-render component
	// if in list of dependnecise is empty array - it says what we want run ONCE and ONLY ONCE
	// if we put for instance 'pageNumber' to array, its means what if pageNumberChanges - useEffect called again and component re-render
	useEffect(() => {
		getData(url).then((data) => {
			setData(data);
			setLoading(false);
		});
	}, [url, setData]);

	if (loading) return <h3>Loading...</h3>;

	return (
		<>
			<Filters />
			{data.totalCount === 0 ? (
				<EmptyFilter showReset />
			) : (
				<>
					<div className="grid grid-cols-4 gap-6">
						{data.auctions.map((auction) => (
							<AuctionCard auction={auction} key={auction.id} />
						))}
					</div>
					<div className="flex justify-center mt-4">
						<AppPagination
							pageChanged={setPageNumber}
							currentPage={params.pageNumber}
							pageCount={data.pageCount}
						/>
					</div>
				</>
			)}
		</>
	);
}
