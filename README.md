# Real Estate Portal

A full-stack real estate portal for property buyers to search, explore, and save favorite listings. Built with React (Vite) frontend and .NET 9 backend (SQL Server, EF Core, Clean Architecture, JWT Auth).

## Features
- Property search with filters (city, price, bedrooms)
- Responsive, modern UI (Bootstrap 5)
- User registration and login (JWT)
- Save favorites and view recently seen properties
- Shareable search URLs
- Backend seeding with 100 properties from major cities in Pakistan
- Clean Architecture, DTOs, Automapper

## Tech Stack
- **Frontend:** React (Vite), Bootstrap 5, React Router, Axios
- **Backend:** .NET 9 Web API, EF Core, SQL Server, JWT Auth
- **Database:** SQL Server (LocalDB or full SQL Server)

## Setup Instructions

### Prerequisites
- Node.js (v18+)
- .NET 9 SDK
- SQL Server (LocalDB or full)

### Backend Setup
1. Navigate to `backend` folder.
2. Update `appsettings.json` with your SQL Server connection string.
3. Run EF Core migrations:
   ```cmd
   dotnet ef database update --project RealEstatePortal.Infrastructure
   ```
4. Start the backend API:
   ```cmd
   dotnet run --project RealEstatePortal.Api
   ```
   The API will run at `http://localhost:5093` by default.

### Frontend Setup
1. Navigate to `frontend` folder.
2. Install dependencies:
   ```cmd
   npm install
   ```
3. Start the frontend:
   ```cmd
   npm run dev
   ```
   The app will run at `http://localhost:5173` by default.

## API Endpoints

### Authentication
- `POST /api/auth/register`
  - **Input:** `{ email, password }`
  - **Output:** `{ token }`
- `POST /api/auth/login`
  - **Input:** `{ email, password }`
  - **Output:** `{ token }`

### Properties
- `GET /api/properties`
  - **Query Parameters:**
    - `city` (string, optional)
    - `minPrice` (decimal, optional)
    - `maxPrice` (decimal, optional)
    - `bedrooms` (int, optional)
    - `page` (int, optional, default: 1)
    - `pageSize` (int, optional, default: 12)
  - **Output:**
    ```json
    {
      "totalCount": 100,
      "page": 1,
      "pageSize": 12,
      "properties": [
        {
          "id": 1,
          "title": "Modern Villa in Karachi",
          "city": "Karachi",
          "price": 5000000,
          "bedrooms": 4,
          "description": "...",
          "images": [ { "id": 1, "url": "..." } ]
        }
      ]
    }
    ```
- `GET /api/properties/{id}`
  - **Output:** Property details (same as above)

### Favorites
- `GET /api/favorites` (JWT required)
  - **Output:** List of favorite properties for the user
- `POST /api/favorites/{propertyId}` (JWT required)
  - **Output:** Success status
- `DELETE /api/favorites/{propertyId}` (JWT required)
  - **Output:** Success status

## Project Structure
```
real-estate-app/
├── backend/
│   ├── RealEstatePortal.Api/         # .NET Web API
│   ├── RealEstatePortal.Domain/      # Domain models
│   ├── RealEstatePortal.Infrastructure/ # EF Core, DbContext
│   └── ...
├── frontend/
│   ├── src/
│   │   ├── pages/                    # React pages
│   │   ├── components/               # Reusable components
│   │   ├── api/                      # Axios config
│   │   └── ...
│   └── ...
└── README.md
```

## Notes
- CORS is enabled for frontend-backend communication.
- All DTOs and models are in their own files for maintainability.
- Backend is seeded with realistic property data for demo/testing.
- JWT tokens are stored in localStorage on the frontend.

## How to Contribute
- Fork the repo, create a feature branch, and submit a pull request.
- Please follow Clean Architecture and keep DTOs/models in their own files.

## License
MIT
