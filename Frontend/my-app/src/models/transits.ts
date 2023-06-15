interface Transit {
    id: number;
    length: number;
    plannedTime: number;
    trainStations: TrainStations[];
    date: Date;
}

interface TrainStations {
    number: number;
    name: string;
    departureTime: Date | null;
    arrivalTime: Date | null;
    type: string;
}

export default Transit;