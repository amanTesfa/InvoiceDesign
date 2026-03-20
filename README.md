# Invoice Design

## Overview

Invoice Design is a .NET 6 web application for managing and designing invoices. It includes features for invoice preparation and document viewing, using frontend assets and DevExtreme controls.

## Features

- Invoice creation and management
- Invoice preview, export options, and printing functionality
- Custom web document viewer

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

- HTML5, CSS3, Javascript, Jquery, Bootstrap, Devextreme controls
- C# MVC with razor pages
- Devexpress report designer
