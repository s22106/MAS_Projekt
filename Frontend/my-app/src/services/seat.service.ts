import axios from "axios";
import Transit from "../models/transits";

export interface Seat {
    wagonNumber: number;
    seatNumber: number;
}

export class SeatService {
    public async getSeatsByTrainId(trainId: number): Promise<Array<Seat>> {
        const response = await axios.get(`http://localhost:5185/api/Seat/${trainId}`);
        const seats: Array<Seat> = response.data;
        return seats;
    }
}