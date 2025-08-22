export default function Home() {
  return (
    <div
      className="container-fluid text-center py-5"
      style={{
        minHeight: '100vh',
        backgroundImage: 'url(/property-bg.jpg)',
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
      }}
    >
      <div className="row justify-content-center align-items-center">
        <div className="col-lg-8 bg-white bg-opacity-75 rounded p-4 shadow-lg">
          <h1 className="display-3 fw-bold mb-3" style={{ color: '#6366f1', textShadow: '0 2px 8px #06b6d4' }}>
            Discover Your Dream Home
          </h1>
          <p className="lead mb-4" style={{ color: '#06b6d4', fontWeight: 500 }}>
            Search, explore, and save your favorite listings with <span style={{ color: '#6366f1', fontWeight: 700 }}>RealEstatePortal</span>.
          </p>
          <img src="/property-bg.jpg" alt="Property" style={{ width: 220, borderRadius: '1rem', marginBottom: '2rem', boxShadow: '0 2px 12px #6366f1' }} />
          <br />
          <a href="/search" className="btn btn-primary btn-lg px-5 py-3 shadow">
            <i className="bi bi-search me-2"></i> Start Searching
          </a>
        </div>
      </div>
    </div>
  );
}
