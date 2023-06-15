import axios from "axios";
import Transit from "../models/transits";

export class SeatService {
    public async getSeatsByTrainId(trainId: number): Promise<Map<number, Map<number, number>>> {
        const response = await axios.get(`http://localhost:5185/api/Seat/${trainId}`);
        const seats: Map<number, Map<number, number>> = response.data;
        console.log(seats);
        return seats;
    }
}