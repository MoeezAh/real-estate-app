
import React, { useEffect, useState } from 'react';
import api from '../api/axios';
import PropertyCard from '../components/PropertyCard';

export default function Favorites() {
  const [favorites, setFavorites] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchFavorites() {
      try {
        const res = await api.get('/favorites', {
          headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        });
        setFavorites(res.data);
      } catch {
        setFavorites([]);
      }
      setLoading(false);
    }
    fetchFavorites();
    const handleStorage = () => fetchFavorites();
    window.addEventListener('storage', handleStorage);
    return () => window.removeEventListener('storage', handleStorage);
  }, []);

  if (loading) return <div className="container py-5 text-center"><div className="spinner-border" /></div>;

  return (
    <div className="container py-5">
      <h2 className="fw-bold mb-4" style={{ color: '#6366f1' }}>
        <i className="bi bi-heart-fill me-2"></i> My Favorites
      </h2>
      <div className="row">
        {favorites.length === 0 ? (
          <div className="col-12 text-center text-muted">No favorite properties yet.</div>
        ) : (
          favorites.map(property => (
            <div className="col-12 col-md-6 col-lg-4 mb-4" key={property.id}>
              <PropertyCard property={property} linkTo={`/property/${property.id}`} />
            </div>
          ))
        )}
      </div>
    </div>
  );
}
