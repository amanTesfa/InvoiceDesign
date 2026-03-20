# EinvoiceDesign

## Overview

EinvoiceDesign is a .NET 6 web application for electronic invoice management and design. It includes features for invoice preparation document viewing, with frontend assets and DevExtreme controls.

## Features

- Invoice creation and management
- Invoice preview and export options with printing functionalities
- Custom web document viewer
- Modern UI with DevExtreme Combos

## Project Structure

- `InvoiceProject/` — Main application source
  - `Controllers/` — MVC controllers
  - `Models/` — Data models
  - `Views/` — Razor views for UI
  - `wwwroot/` — Static assets (CSS, JS, images)
    - `designer_file/` — Third-party and custom JS/CSS
    - `package.json` — Frontend dependencies
    - `package-lock.json` — Dependency lock file
    - `favicon.ico` — Site icon
- `InvoiceProject.sln` — Solution file

## Getting Started

### Prerequisites

- .NET 6 SDK
- Node.js (for frontend assets, if needed)

### Setup

1. Clone the repository:
   ```
   git clone https://github.com/amanTesfa/InvoiceDesign.git
   ```
2. Restore .NET dependencies:

   ```
   dotnet restore
   ```

3. Build and run the project:
   ```
   dotnet run --project InvoiceProject/InvoiceProject.csproj
   ```

**Technologies Used**

- HTML, CSS, Javascript, Jquery, Bootstrap, Devextreme controls
- C# MVC with razor pages
- Devexpress report designer
