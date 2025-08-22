
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';


export default function PropertyCard({ property, onFavorite, isFavorite, linkTo }) {
  return (
    <div className="card mb-4 shadow-lg border-0" style={{ background: 'linear-gradient(135deg, #e0e7ff 0%, #f8fafc 100%)' }}>
      <div className="row g-0 align-items-center">
        <div className="col-md-4 col-12 text-center p-3">
          <img
            src={property.images[0]}
            className="img-fluid rounded shadow"
            alt={property.title}
            style={{ maxHeight: '220px', objectFit: 'cover', borderRadius: '1rem' }}
          />
        </div>
        <div className="col-md-8 col-12">
          <div className="card-body">
            <h5 className="card-title mb-2" style={{ color: '#6366f1', fontWeight: 'bold', fontSize: '1.4rem' }}>
              {linkTo ? (
                <Link to={linkTo} style={{ color: '#6366f1', textDecoration: 'underline' }}>
                  {property.title}
                </Link>
              ) : property.title}
            </h5>
            <p className="card-text mb-1"><strong>Address:</strong> <span style={{ color: '#06b6d4' }}>{property.address}, {property.city}</span></p>
            <p className="card-text mb-1"><strong>Price:</strong> <span style={{ color: '#16a34a', fontWeight: 600 }}>${property.price.toLocaleString()}</span></p>
            <p className="card-text mb-1"><strong>Type:</strong> <span style={{ color: '#6366f1' }}>{property.listingType}</span></p>
            <div className="d-flex flex-wrap mb-2">
              <span className="me-3"><i className="bi bi-house-door"></i> {property.bedrooms} Beds</span>
              <span className="me-3"><i className="bi bi-bath"></i> {property.bathrooms} Baths</span>
              <span><i className="bi bi-car-front"></i> {property.carSpots} Car Spots</span>
            </div>
            <p className="card-text" style={{ color: '#334155' }}>{property.description}</p>
            {onFavorite && (
              <button
                className={`btn ${isFavorite ? 'btn-danger' : 'btn-outline-primary'} btn-sm px-3 py-2`}
                style={{ fontWeight: 500, borderRadius: '2rem' }}
                onClick={e => { e.stopPropagation(); e.preventDefault(); onFavorite(property.id); }}
              >
                {isFavorite ? 'Remove Favorite' : 'Save as Favorite'}
              </button>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
