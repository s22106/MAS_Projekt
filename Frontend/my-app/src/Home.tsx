import { Routes, Route } from 'react-router-dom';
import App from './App';
import TransitList from './TransitList';
import TransitInfo from './TransitInfo';
import TicketInfo from './TicketInfo';
import { TicketContext, TicketGet, defaultTicket } from './TicketContext';
import { TicketInfo as TicketInfoModel } from './services/ticket.service';
import { useState } from 'react';

function Home() {
    const [ticketData, setTicketData] = useState<TicketGet>(defaultTicket);

    return (
        <div className="home">
            <TicketContext.Provider value={ticketData}>
                <Routes>
                    <Route path="/" element={<App />} />
                    <Route path="/transit" element={<TransitList />} />
                    <Route path="/transit/:id" element={<TransitInfo />} />
                    <Route path="/ticket/" element={<TicketInfo />} />
                </Routes>
            </TicketContext.Provider>
        </div >
    )
}

export default Home;