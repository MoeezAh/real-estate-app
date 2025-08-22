
import React, { useEffect, useState } from 'react';
import api from '../api/axios';
import PropertyCard from '../components/PropertyCard';

export default function Recent() {
  const [recent, setRecent] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchRecent() {
      const recentRaw = JSON.parse(localStorage.getItem('recent')) || [];
      const now = Date.now();
      const recentIds = recentRaw.filter(item => now - item.time < 7 * 24 * 60 * 60 * 1000).map(item => item.id);
      if (recentIds.length === 0) {
        setRecent([]);
        setLoading(false);
        return;
      }
      try {
        const res = await api.get('/properties', {
          params: { ids: recentIds.join(',') }
        });
        if (Array.isArray(res.data)) {
          setRecent(res.data);
        } else if (res.data && Array.isArray(res.data.properties)) {
          setRecent(res.data.properties);
        } else {
          setRecent([]);
        }
      } catch {
        setRecent([]);
      }
      setLoading(false);
    }
    fetchRecent();
  }, []);

  if (loading) return <div className="container py-5 text-center"><div className="spinner-border" /></div>;

  return (
    <div className="container-fluid py-5" style={{ backgroundImage: 'url(/property-bg.jpg)', backgroundSize: 'cover', backgroundPosition: 'center', minHeight: '100vh' }}>
      <h2 className="fw-bold mb-4 text-center" style={{ color: '#6366f1' }}>
        <i className="bi bi-clock-history me-2"></i> Recently Viewed
      </h2>
      <div className="row justify-content-center">
        {recent.length === 0 ? (
          <div className="col-12 text-center text-muted bg-white bg-opacity-75 rounded p-4">No recently viewed properties.</div>
        ) : (
          recent.map(property => (
            <div className="col-12 col-md-6 col-lg-4 mb-4" key={property.id}>
              <PropertyCard property={property} linkTo={`/property/${property.id}`} />
            </div>
          ))
        )}
      </div>
    </div>
  );
}
