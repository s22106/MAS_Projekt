import axios from "axios";
import { TicketContext } from "../TicketContext";

export interface TicketInfo {
    startStation: string;
    endStation: string;
    date: Date;
    transitId: number;
    seatNumber: number;
    wagonNumber: number;
}


export class TicketService {


    public async buyTicket(ticket: TicketInfo) {
        const response = await axios.post('http://localhost:5185/api/Ticket', ticket, {
            headers: {
                "passengerId": 1
            }
        });
        return response.data;
    }
}