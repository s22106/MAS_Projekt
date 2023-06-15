import React, { useEffect, useState } from 'react';
import './App.css';
import Dropdown from './Dropdown';
import { StationService } from './services/station.service';
import DatePicker from "react-datepicker";
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';

import "react-datepicker/dist/react-datepicker.css"

function App() {

  const [stations, setStations] = React.useState<string[]>([])
  const [startDate, setStartDate] = React.useState<Date>();
  const [selectedStartStation, setSelectedStartStation] = useState<string | null>(null);
  const [selectedEndStation, setSelectedEndStation] = useState<string | null>(null);

  const stationService = new StationService();
  const getStations = async () => {
    const stations = await stationService.getTrainStations();
    console.log('getStations');
    setStations(stations);
  }

  const handleButtonClick = async () => {
    // if (selectedEndStation && selectedStartStation && startDate) {
    //   startDate.setHours(0, 0, 0, 0);
    //   startDate.setDate(startDate.getDate() + 1);
    //   const trainLinks = await stationService.getTrainLinks(selectedStartStation, selectedEndStation, startDate);
    //   console.log(trainLinks);
    // }
  }

  useEffect(() => {
    getStations();
  }, []);

  return (
    <div className="app">
      <div className="contents">
        <Link to={`/transit/?startStation=${selectedStartStation}&endStation=${selectedEndStation}&startDate=${startDate}`}>
          <button >Get Train Links</button>
        </Link>
        <DatePicker
          selected={startDate}
          onChange={(date: Date) => setStartDate(date)} />
        <Dropdown
          placeholder='Wybierz'
          options={stations}
          isSearchable={true}
          onChange={(value) => setSelectedEndStation(value)} />
        <Dropdown
          placeholder='Wybierz'
          options={stations}
          isSearchable={true}
          onChange={(value) => setSelectedStartStation(value)} />
      </div>
    </div>
  );
}

export default App;
