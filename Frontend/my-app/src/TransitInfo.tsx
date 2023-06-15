import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { StationService } from './services/station.service';
import Transit from './models/transits';
import { SeatService } from './services/seat.service';



function TransitInfo() {
    const { id } = useParams();
    const [transit, setTransit] = useState<Transit>();
    const [seats, setSeats] = useState<Map<number, Map<number, number>>>();
    const [seatsMap, setSeatsMap] = useState<Map<number, number>>()
    const [loading, setLoading] = useState<boolean>(true);
    const [selectedSeat, setSelectedSeat] = useState<number>(0);

    const stationService = new StationService();
    const seatService = new SeatService();

    const getTransitInfo = async (transitId: number) => {
        const seats = await seatService.getSeatsByTrainId(transitId);
        setSeats(seats);
        const transitData = await stationService.getTransitById(transitId);
        setTransit(transitData);
    }


    useEffect(() => {
        if (id) {
            getTransitInfo(Number.parseInt(id));
        }
    }, []);

    useEffect(() => {
        if (transit)
            setLoading(false);
    }, [transit]);

    return (
        <div className="transit-info">
            {loading ? (
                <div>Loading...</div>
            ) : !transit ? (
                <div>No data</div>
            ) : (
                <>
                    <h1>Transit</h1>
                    <p>Czas podróy: {transit.plannedTime}</p>
                    <p>Długość: {transit.length}</p>
                    <h3>Stacje</h3>
                    <ul>
                        {transit.trainStations.map((station) => (
                            <li key={station.number}>
                                <p>
                                    {station.name}
                                </p>
                                <p>
                                    {station.departureTime ? 'Czas odjazdu: ' : ''}
                                    {station.departureTime ? station.departureTime.toLocaleString() : ''}
                                </p>
                                <p>
                                    {station.arrivalTime ? 'Czas przyjazdu: ' : ''}
                                    {station.arrivalTime ? station.arrivalTime.toLocaleString() : ''}
                                </p>

                            </li>
                        ))}
                    </ul>
                </>
            )}
        </div >
    )
}

export default TransitInfo;