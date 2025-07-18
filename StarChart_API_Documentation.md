# StarChart API Documentation

This project implements a minimal ASP.NET Core Web API for managing celestial objects. The application stores objects in an in-memory database and exposes endpoints to retrieve data about them. Unit tests covering the expected functionality are located in the `StarChartTests` project.

## Project Structure

- **StarChart** – ASP.NET Core application containing controllers, models and data access code.
- **StarChartTests** – xUnit tests describing expected behaviors.
- **Dockerfile** – basic build container for the application.
- **README.md** – setup notes for running and testing the project.

## Model

The main model is `CelestialObject` defined in `StarChart/Models/CelestialObject.cs`:

- `Id` – integer primary key.
- `Name` – name of the object (required).
- `OrbitedObjectId` – optional reference to another `CelestialObject`.
- `Satellites` – list of orbiting objects; not mapped in the database.
- `OrbitalPeriod` – orbital period as a `TimeSpan`.

## API Endpoints

`CelestialObjectController` (in `StarChart/Controllers`) exposes the following read-only endpoints:

- `GET /{id:int}` – Returns a single object by `Id`. Responds with `404` when not found.
- `GET /{name}` – Returns all objects with a matching `Name`. Responds with `404` when none match.
- `GET /` – Returns all celestial objects.

Each returned object has its `Satellites` property populated with any orbiting bodies.

The unit tests also reference additional actions (Create, Update, RenameObject and Delete) which are not included in the current implementation.

## Building and Running

To build or test the solution locally install the .NET SDK (see the main `README.md`). The application can then be run from the `StarChart` directory using `dotnet run` or tested with `dotnet test` from the repository root.

