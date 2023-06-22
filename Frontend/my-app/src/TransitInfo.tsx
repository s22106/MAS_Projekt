import React, { useContext, useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { StationService } from './services/station.service';
import Transit from './models/transits';
import { SeatService, Seat } from './services/seat.service';
import Dropdown, { Option } from 'react-dropdown';
import 'react-dropdown/style.css';

import './TransitInfo.css';
import { TicketContext, TicketGet } from './TicketContext';
import { TicketInfo, TicketService } from './services/ticket.service';

function TransitInfo() {
    const { id } = useParams();
    const [transit, setTransit] = useState<Transit>();
    const [seats, setSeats] = useState<Array<Seat>>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [wagonNumbers, setWagonNumbers] = useState<string[]>([]);
    const [isWagonSelected, setIsWagonSelected] = useState<boolean>(false);
    const [selectedWagon, setSelectedWagon] = useState<Option>({ value: '', label: '' });
    const [selectedSeat, setSelectedSeat] = useState<Option>();

    const { startStation, endStation, departureTime, wagonNumber, seatNumber, firstName, lastName, seatType, setTicket } = useContext(TicketContext);


    const stationService = new StationService();
    const seatService = new SeatService();
    const ticketService = new TicketService();

    const getTransitInfo = async (transitId: number) => {
        const seats = await seatService.getSeatsByTrainId(transitId);
        setSeats(seats);
        const transitData = await stationService.getTransitById(transitId);
        setTransit(transitData);
    }

    const handleContext = async () => {
        if (selectedSeat && selectedWagon && transit && transit.trainStations[0].departureTime) {
            const ticket: TicketInfo = {
                startStation: transit.trainStations[0].name,
                endStation: transit.trainStations[transit.trainStations.length - 1].name,
                date: transit.trainStations[0].departureTime,
                wagonNumber: Number.parseInt(selectedWagon.value),
                seatNumber: Number.parseInt(selectedSeat.value),
                transitId: transit.id
            }
            const response = await ticketService.buyTicket(ticket)
            setTicket(response);
        }
    }

    const getWagonNumbers = () => {
        var wagonNumberOptions = seats.map((seat) => ({
            value: seat.wagonNumber.toString(),
            label: seat.wagonNumber.toString(),
        }));
        return wagonNumberOptions.filter((v, i, a) => a.findIndex(t => (t.value === v.value)) === i);
    };


    const handleSelection = (selection: Option) => {
        setSelectedWagon(selection);
        setIsWagonSelected(true);
    }

    const handleSeatSelection = (selection: Option) => {
        setSelectedSeat(selection);
    }

    const getSeatsByWagonNumber = (wagonNumber: Option) => {
        return seats
            .filter((seat) => seat.wagonNumber === Number.parseInt(wagonNumber.value))
            .map((seat) => ({
                value: seat.seatNumber.toString(),
                label: seat.seatNumber.toString(),
            }));
    }

    useEffect(() => {
        if (id) {
            getTransitInfo(Number.parseInt(id));
        }
    }, []);

    useEffect(() => {
        if (transit && seats) {
            setLoading(false);
        }
    }, [transit, seats]);

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
                    <h3>Wagon</h3>
                    <div className='dropdown-container'>
                        <Dropdown options={getWagonNumbers()} onChange={handleSelection} placeholder={"Wybierz wagon"} value={selectedWagon} />
                    </div>
                    <div className='dropdown-container'>
                        <Dropdown options={getSeatsByWagonNumber(selectedWagon)} onChange={handleSeatSelection} placeholder={"Wybierz miejsce"} />
                    </div>
                    {selectedSeat && selectedWagon.value ? (
                        <Link to={`/ticket/`}>
                            <button onClick={handleContext}>
                                Bilet
                            </button>
                        </Link>
                    ) : (
                        <></>
                    )}
                </>
            )
            }
        </div >
    )
}

export default TransitInfo;