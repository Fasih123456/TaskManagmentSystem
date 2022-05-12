import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Courses} from './Courses';
import {Task} from './Task';
import {TimeTracker} from './TimeTracker';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Routes} from 'react-router-dom';


function App() {
  return (
    <BrowserRouter>
      <div className="container">
          <h3 className='m-3 d-flex justify-content-center'>
            Personal Project
          </h3>

          <Navigation />

          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="courses" element={<Courses />} />
            <Route path="task" element={<Task />} />
            <Route path="timetracker" element={<TimeTracker />} />
          </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
