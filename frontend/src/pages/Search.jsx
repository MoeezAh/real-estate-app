import React, { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import api from '../api/axios';
import PropertyCard from '../components/PropertyCard';

const PAGE_SIZE = 12;

export default function Search() {
  const [searchParams, setSearchParams] = useSearchParams();
  const isAuthenticated = !!localStorage.getItem('token');
  const [properties, setProperties] = useState([]);
  const [filters, setFilters] = useState({ city: '', minPrice: '', maxPrice: '', bedrooms: '' });
  const [favorites, setFavorites] = useState([]);
  const [loading, setLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(0);

  // Initialize filters and page from URL params
  useEffect(() => {
    setFilters({
      city: searchParams.get('city') || '',
      minPrice: searchParams.get('minPrice') || '',
      maxPrice: searchParams.get('maxPrice') || '',
      bedrooms: searchParams.get('bedrooms') || ''
    });
    setPage(Number(searchParams.get('page')) || 1);
  }, [searchParams]);

  // Fetch properties when filters or page change
  useEffect(() => {
    fetchProperties();
    // eslint-disable-next-line
  }, [filters, page]);

  const fetchProperties = async () => {
    setLoading(true);
    try {
      let params = { page, pageSize: PAGE_SIZE };
      if (filters.city) params.city = filters.city;
      if (filters.minPrice) params.minPrice = filters.minPrice;
      if (filters.maxPrice) params.maxPrice = filters.maxPrice;
      if (filters.bedrooms) params.bedrooms = filters.bedrooms;
      const res = await api.get('/properties', { params });
      setProperties(res.data.properties);
      setTotalCount(res.data.totalCount);
    } catch {
      setProperties([]);
      setTotalCount(0);
    }
    setLoading(false);
    // Fetch favorites for authenticated user (for favorite status only)
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const favRes = await api.get('/favorites', {
          headers: { Authorization: `Bearer ${token}` }
        });
        setFavorites(favRes.data.map(p => p.id));
      } catch {
        setFavorites([]);
      }
    } else {
      setFavorites([]);
    }
  };

  const handleFilterChange = (e) => {
    setFilters({ ...filters, [e.target.name]: e.target.value });
  };

  const handleFilterSubmit = (e) => {
    e.preventDefault();
    // Update URL with filter params and reset to page 1
    const params = {};
    if (filters.city) params.city = filters.city;
    if (filters.minPrice) params.minPrice = filters.minPrice;
    if (filters.maxPrice) params.maxPrice = filters.maxPrice;
    if (filters.bedrooms) params.bedrooms = filters.bedrooms;
    params.page = 1;
    setSearchParams(params);
    setPage(1);
    fetchProperties();
  };

  const handleFavorite = async (propertyId) => {
    if (!isAuthenticated) return;
    try {
      if (favorites.includes(propertyId)) {
        await api.delete(`/favorites/${propertyId}`, {
          headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        });
        setFavorites(favorites.filter(id => id !== propertyId));
        window.dispatchEvent(new Event('storage'));
      } else {
        await api.post(`/favorites/${propertyId}`, {}, {
          headers: { Authorization: `Bearer ${localStorage.getItem('token')}` }
        });
        setFavorites([...favorites, propertyId]);
        window.dispatchEvent(new Event('storage'));
      }
    } catch (e) {
      // Optionally log error
    }
  };

  const totalPages = Math.ceil(totalCount / PAGE_SIZE);

  const handlePageChange = (newPage) => {
    if (newPage < 1 || newPage > totalPages) return;
    const params = {};
    if (filters.city) params.city = filters.city;
    if (filters.minPrice) params.minPrice = filters.minPrice;
    if (filters.maxPrice) params.maxPrice = filters.maxPrice;
    if (filters.bedrooms) params.bedrooms = filters.bedrooms;
    params.page = newPage;
    setSearchParams(params);
    setPage(newPage);
  };

  return (
    <div>
      <div className="container py-4">
        <div className="row mb-4">
          <div className="col-12 text-center">
            <h2 className="fw-bold mb-2" style={{ color: '#6366f1' }}>
              <i className="bi bi-search me-2"></i> Find Properties
            </h2>
            <p className="lead" style={{ color: '#06b6d4' }}>Filter by city, price, and bedrooms to find your dream home.</p>
          </div>
        </div>
        <form className="row g-3 justify-content-center mb-4 p-3 rounded shadow" style={{ background: 'linear-gradient(90deg, #e0e7ff 0%, #f8fafc 100%)' }} onSubmit={handleFilterSubmit}>
          <div className="col-12 col-md-3">
            <input type="text" className="form-control form-control-lg" name="city" placeholder="City" value={filters.city} onChange={handleFilterChange} />
          </div>
          <div className="col-6 col-md-2">
            <input type="number" className="form-control form-control-lg" name="minPrice" placeholder="Min Price" value={filters.minPrice} onChange={handleFilterChange} />
          </div>
          <div className="col-6 col-md-2">
            <input type="number" className="form-control form-control-lg" name="maxPrice" placeholder="Max Price" value={filters.maxPrice} onChange={handleFilterChange} />
          </div>
          <div className="col-6 col-md-2">
            <input type="number" className="form-control form-control-lg" name="bedrooms" placeholder="Bedrooms" value={filters.bedrooms} onChange={handleFilterChange} />
          </div>
          <div className="col-12 col-md-2 d-flex align-items-end">
            <button type="submit" className="btn btn-primary btn-lg w-100">
              <i className="bi bi-funnel-fill me-2"></i> Apply Filters
            </button>
          </div>
        </form>
        <div className="row">
          {loading ? (
            <div className="col-12 text-center"><div className="spinner-border" /></div>
          ) : properties.length === 0 ? (
            <div className="col-12">
              <div className="alert alert-info">No properties found.</div>
            </div>
          ) : (
            properties.map((property) => (
              <div className="col-12 col-md-6 col-lg-4 mb-4" key={property.id}>
                <PropertyCard
                  property={{ ...property, images: property.images || [] }}
                  onFavorite={isAuthenticated ? handleFavorite : undefined}
                  isFavorite={isAuthenticated ? favorites.includes(property.id) : false}
                  showFavorite={isAuthenticated}
                  linkTo={`/property/${property.id}`}
                />
              </div>
            ))
          )}
        </div>
        {/* Pagination Controls */}
        {totalPages > 1 && (
          <div className="row mt-4">
            <div className="col-12 d-flex justify-content-center">
              <nav>
                <ul className="pagination">
                  <li className={`page-item${page === 1 ? ' disabled' : ''}`}>
                    <button className="page-link" onClick={() => handlePageChange(page - 1)}>&laquo;</button>
                  </li>
                  {[...Array(totalPages)].map((_, idx) => (
                    <li key={idx + 1} className={`page-item${page === idx + 1 ? ' active' : ''}`}>
                      <button className="page-link" onClick={() => handlePageChange(idx + 1)}>{idx + 1}</button>
                    </li>
                  ))}
                  <li className={`page-item${page === totalPages ? ' disabled' : ''}`}>
                    <button className="page-link" onClick={() => handlePageChange(page + 1)}>&raquo;</button>
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
