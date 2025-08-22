import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function Navbar({ isAuthenticated }) {
  const handleLogout = () => {
    localStorage.removeItem('token');
    window.location.reload();
  };
  return (
    <nav
      className="navbar navbar-expand-lg mb-4 shadow-sm"
      style={{
        background: 'linear-gradient(90deg, #232526 0%, #414345 100%)',
        color: '#f8fafc',
        borderBottom: '3px solid #6366f1',
      }}
    >
      <div className="container-fluid">
        <Link className="navbar-brand" to="/" style={{ color: '#f8fafc', fontWeight: 'bold', fontSize: '1.7rem', letterSpacing: '2px' }}>
          <span style={{ textShadow: '0 2px 8px #06b6d4' }}>🏡 RealEstatePortal</span>
        </Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse show" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link" style={{ color: '#f8fafc', fontWeight: 500 }} to="/search">
                <i className="bi bi-search me-1"></i> Search Properties
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" style={{ color: '#f8fafc', fontWeight: 500 }} to="/recent">
                <i className="bi bi-clock-history me-1"></i> Recently Viewed
              </Link>
            </li>
            {isAuthenticated && (
              <>
                <li className="nav-item">
                  <Link className="nav-link" style={{ color: '#f8fafc', fontWeight: 500 }} to="/favorites">
                    <i className="bi bi-heart-fill me-1"></i> My Favorites
                  </Link>
                </li>
                <li className="nav-item">
                  <button className="nav-link btn btn-link" style={{ color: '#f8fafc', fontWeight: 500 }} onClick={handleLogout}>
                    <i className="bi bi-box-arrow-right me-1"></i> Logout
                  </button>
                </li>
              </>
            )}
            {!isAuthenticated && (
              <>
                <li className="nav-item">
                  <Link className="nav-link" style={{ color: '#f8fafc', fontWeight: 500 }} to="/login">
                    <i className="bi bi-person-circle me-1"></i> Login
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" style={{ color: '#f8fafc', fontWeight: 500 }} to="/register">
                    <i className="bi bi-person-plus me-1"></i> Register
                  </Link>
                </li>
              </>
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
}
