import axios from 'axios';
import Transit from '../models/transits';

export class StationService {
    public async getTrainStations(): Promise<string[]> {
        const response = await axios.get('http://localhost:5185/api/TrainStationControler');
        const stations: string[] = response.data.map(((station: { name: string }) => station.name));
        console.log('service');
        return stations;
    }

    public async getTrainLinks(startStation: string, endStation: string, date: Date): Promise<Transit[]> {
        const requestData = { startStation, endStation, date };
        const response = await axios.get('http://localhost:5185/api/TransitControler', { params: requestData });
        const transit: Transit[] = response.data;
        return transit;
    }

    public async getTransitById(id: number): Promise<Transit> {
        const response = await axios.get(`http://localhost:5185/api/TransitControler/${id}`);
        const transit: Transit = response.data;
        return transit;
    }
}
