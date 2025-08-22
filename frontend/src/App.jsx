
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useState, useEffect } from 'react';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import ProtectedRoute from './components/ProtectedRoute';
import './assets/bootstrap-icons.css';
import Search from './pages/Search';
import PropertyDetails from './pages/PropertyDetails';
import Home from './pages/Home';
import Favorites from './pages/Favorites';
import Recent from './pages/Recent';
import Login from './pages/Login';
import Register from './pages/Register';


function App() {
  // Authentication state based on JWT
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  useEffect(() => {
    const token = localStorage.getItem('token');
    setIsAuthenticated(!!token);
    window.addEventListener('storage', () => {
      const token = localStorage.getItem('token');
      setIsAuthenticated(!!token);
    });
    return () => {
      window.removeEventListener('storage', () => {});
    };
  }, []);

  return (
    <>
  <Navbar isAuthenticated={isAuthenticated} key={isAuthenticated ? 'auth' : 'guest'} />
  <main style={{ minHeight: '80vh', backgroundImage: 'url(/property-bg.jpg)', backgroundSize: 'cover', backgroundPosition: 'center', backgroundRepeat: 'no-repeat' }}>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/search" element={<Search />} />
          <Route path="/property/:id" element={<PropertyDetails />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/favorites" element={
            <ProtectedRoute isAuthenticated={isAuthenticated}>
              <Favorites />
            </ProtectedRoute>
          } />
          <Route path="/recent" element={
            <ProtectedRoute isAuthenticated={isAuthenticated}>
              <Recent />
            </ProtectedRoute>
          } />
        </Routes>
      </main>
      <Footer />
    </>
  );
}

export default App;
