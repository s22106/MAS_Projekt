import { FC, createContext } from "react";

export interface TicketGet {
    startStation: string;
    endStation: string;
    departureTime: Date;
    wagonNumber: number;
    seatNumber: number;
    firstName: string;
    lastName: string;
    seatType: string;
    setTicket: (ticket: TicketGet) => void;
}

export const defaultTicket: TicketGet = {
    startStation: "",
    endStation: "",
    departureTime: new Date(),
    wagonNumber: 0,
    seatNumber: 0,
    firstName: "",
    lastName: "",
    seatType: "",
    setTicket: () => { }
}

export const TicketContext = createContext<TicketGet>(defaultTicket)

