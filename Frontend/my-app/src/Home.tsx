import { Routes, Route } from 'react-router-dom';
import App from './App';
import TransitList from './TransitList';
import TransitInfo from './TransitInfo';

function Home() {
    return (
        <div className="home">
            <Routes>
                <Route path="/" element={<App />} />
                <Route path="/transit" element={<TransitList />} />
                <Route path="/transit/:id" element={<TransitInfo />} />
            </Routes>
        </div >
    )
}

export default Home;