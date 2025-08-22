import 'bootstrap/dist/css/bootstrap.min.css';

export default function Footer() {
  return (
    <footer className="footer text-center py-3 mt-5">
      <div className="container">
        <span style={{ fontWeight: '500', letterSpacing: '1px' }}>&copy; {new Date().getFullYear()} RealEstatePortal. All rights reserved.</span>
      </div>
    </footer>
  );
}
