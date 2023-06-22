import { useContext } from "react";
import { TicketContext } from "./TicketContext";


function TicketInfo() {
    const { startStation, endStation, departureTime, wagonNumber, seatNumber, firstName, lastName, seatType, setTicket } = useContext(TicketContext);

    return (
        <div className="ticket-info">
            {startStation && endStation && departureTime && wagonNumber && seatNumber && firstName && lastName && seatType ?
                (
                    <div>
                        <h2>Ticket information</h2>
                        <p>Start station: {startStation}</p>
                        <p>End station: {endStation}</p>

                    </div>
                ) : (
                    <div>
                        <p>Loading</p>
                    </div>
                )
            }
        </div>
    )
}

export default TicketInfo;