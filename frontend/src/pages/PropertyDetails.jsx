import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import api from '../api/axios';
// import PropertyCard from '../components/PropertyCard';

export default function PropertyDetails() {
  const { id } = useParams();
  const [property, setProperty] = useState(null);
  const [isFavorite, setIsFavorite] = useState(false);

  useEffect(() => {
    async function fetchProperty() {
      try {
        const res = await api.get(`/properties/${id}`);
        setProperty(res.data);
        // Track recently viewed properties for 7 days
        let recent = JSON.parse(localStorage.getItem('recent')) || [];
        const now = Date.now();
        recent = recent.filter(item => now - item.time < 7 * 24 * 60 * 60 * 1000 && item.id !== id);
        recent.unshift({ id, time: now });
        if (recent.length > 10) recent = recent.slice(0, 10);
        localStorage.setItem('recent', JSON.stringify(recent));
        // Check if property is favorite (only if logged in)
        const token = localStorage.getItem('token');
        if (token) {
          const favRes = await api.get('/favorites', {
            headers: { Authorization: `Bearer ${token}` }
          });
          setIsFavorite(favRes.data.some(p => p.id === res.data.id));
        }
      } catch {
        setProperty(null);
      }
    }
    fetchProperty();
  }, [id]);

  if (!property) {
    return (
      <div className="container-fluid py-5" style={{ backgroundImage: 'url(/property-bg.jpg)', backgroundSize: 'cover', backgroundPosition: 'center', minHeight: '100vh' }}>
        <div className="alert alert-warning mt-4 text-center bg-white bg-opacity-75 rounded p-4">Property not found.</div>
      </div>
    );
  }

  const handleFavorite = async (propertyId) => {
    try {
      if (isFavorite) {
        await api.delete(`/favorites/${propertyId}`, {
          headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        });
        setIsFavorite(false);
        window.dispatchEvent(new Event('storage'));
      } else {
        await api.post(`/favorites/${propertyId}`, {}, {
          headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        });
        setIsFavorite(true);
        window.dispatchEvent(new Event('storage'));
      }
    } catch {}
  };

  return (
    <div className="container-fluid py-5" style={{ backgroundImage: 'url(/property-bg.jpg)', backgroundSize: 'cover', backgroundPosition: 'center', minHeight: '100vh' }}>
      <div className="row justify-content-center">
        <div className="col-12 col-lg-8 bg-white bg-opacity-90 rounded shadow-lg p-4">
          <div className="row">
            <div className="col-md-6 text-center mb-4 mb-md-0">
              <img src={property.images[0]} alt={property.title} className="img-fluid rounded shadow" style={{ maxHeight: '350px', objectFit: 'cover', borderRadius: '1rem' }} />
            </div>
            <div className="col-md-6">
              <h2 className="fw-bold mb-3" style={{ color: '#6366f1' }}>{property.title}</h2>
              <p className="mb-2"><strong>Address:</strong> <span style={{ color: '#06b6d4' }}>{property.address}, {property.city}</span></p>
              <p className="mb-2"><strong>Price:</strong> <span style={{ color: '#16a34a', fontWeight: 600 }}>${property.price.toLocaleString()}</span></p>
              <p className="mb-2"><strong>Type:</strong> <span style={{ color: '#6366f1' }}>{property.listingType}</span></p>
              <div className="d-flex flex-wrap mb-2">
                <span className="me-3"><i className="bi bi-house-door"></i> {property.bedrooms} Beds</span>
                <span className="me-3"><i className="bi bi-bath"></i> {property.bathrooms} Baths</span>
                <span><i className="bi bi-car-front"></i> {property.carSpots} Car Spots</span>
              </div>
              <p className="mb-3" style={{ color: '#334155' }}>{property.description}</p>
              {localStorage.getItem('token') && (
                <button
                  className={`btn ${isFavorite ? 'btn-danger' : 'btn-outline-primary'} btn-sm px-3 py-2 mb-2`}
                  style={{ fontWeight: 500, borderRadius: '2rem' }}
                  onClick={() => handleFavorite(property.id)}
                >
                  {isFavorite ? 'Remove Favorite' : 'Save as Favorite'}
                </button>
              )}
            </div>
          </div>
          <div className="row mt-4">
            <div className="col-12">
              <h5 className="fw-bold mb-2" style={{ color: '#6366f1' }}>Gallery</h5>
              <div className="d-flex flex-wrap gap-3">
                {property.images.map((img, idx) => (
                  <img key={idx} src={img} alt={`Property ${idx + 1}`} style={{ width: '120px', height: '80px', objectFit: 'cover', borderRadius: '0.5rem', boxShadow: '0 2px 8px #06b6d4' }} />
                ))}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
