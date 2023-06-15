import React, { useEffect, useState } from 'react';
import { StationService } from './services/station.service';
import { Link, useLocation, useSearchParams } from 'react-router-dom';
import { start } from 'repl';
import moment from 'moment';
import Transit from './models/transits';

function TransitList() {
    //const { startStation, endStation, date } = useParams()
    const [trainLinks, setTrainLinks] = useState<Transit[]>([]);
    const [searchParams, setSearchParams] = useSearchParams();
    const [loading, setLoading] = useState<boolean>(true);
    const [startStation, setStartStation] = useState<string | null>(null);
    const [endStation, setEndStation] = useState<string | null>(null);
    const [startDate, setStartDate] = useState<string | null>(null);
    const location = useLocation();

    const stationService = new StationService();
    // const startStation = searchParams.get('startStation');
    // const endStation = searchParams.get('endStation');
    // const date = searchParams.get('startDate');

    const getTrainLinks = async (startStation: string | null, endStation: string | null, startDate: string | null) => {
        if (endStation && startStation && startDate) {
            const date = moment(startDate, 'ddd MMM DD YYYY HH:mm:ss [GMT]ZZ (zz)').toDate();
            console.log(date);
            date.setHours(0, 0, 0, 0);
            date.setDate(date.getDate() + 1);
            const links = await stationService.getTrainLinks(startStation, endStation, date);
            console.log(links);
            setTrainLinks(links);
        }
    }

    useEffect(() => {
        console.log(trainLinks)
        setLoading(false);
    }, [trainLinks]);

    useEffect(() => {
        const params = new URLSearchParams(location.search);
        const startStationParam = params.get('startStation');
        const endStationParam = params.get('endStation');
        const startDateParam = params.get('startDate');
        if (endStationParam && startStationParam && startDateParam) {
            setStartStation(startStationParam);
            setEndStation(endStationParam);
            setStartDate(startDateParam);
            getTrainLinks(startStationParam, endStationParam, startDateParam);
        }
    }, []);

    return (
        <div>
            {loading ? (
                <div>Loading...</div>
            ) : trainLinks.length === 0 ? (
                <div>No data</div>
            ) : (
                <>
                    <h1>Transit List</h1>
                    <ul>
                        {trainLinks.map((transit) => (
                            <li key={transit.id}>
                                <p>Data: {transit.plannedTime}</p>
                                <p>Długość: {transit.length}</p>
                                <p>
                                    Stacja początkowa:{" "}
                                    {transit.trainStations.at(transit.trainStations.findIndex((station) => station.name === startStation))?.name}
                                </p>
                                <p>
                                    Stacja końcowa:{" "}
                                    {transit.trainStations.at(transit.trainStations.findIndex((station) => station.name === endStation))?.name}
                                </p>
                                <Link to={`/transit/${transit.id}`}>
                                    <button>Wybierz przejazd</button>
                                </Link>
                            </li>
                        ))}
                    </ul>
                </>
            )}
        </div>
    );
}

export default TransitList;