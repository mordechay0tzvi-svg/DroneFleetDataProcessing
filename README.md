Drone Fleet Data Processing
Overview

This project processes raw drone data from an external sensor system. It validates the data, creates a clean dataset, performs statistical analysis using LINQ, and generates a summary report.

class Drone
    int Id 
    string SerialNumber 
    string Model
    string Category 
    string BaseLocation 
    double FlightHours
    int BatteryHealth 
    double MaxRangeKm 
    int MissionsCompleted
    string Status 
    

Each record is validated for:

Unique id and serialNumber
Valid serial number format (DR-0001)
Allowed values for:
Model
Category
Base
Status
Numeric ranges
Business rule:
A drone with batteryHealth < 20 cannot be Operational

Invalid records are rejected.

Analysis

The report includes:

Non-operational drones
Top 5 drones by flight hours
Available drone models
Number of drones per base
Average battery health per model
Model with the highest total completed missions
One additional LINQ analysis
Project Structure
DroneFleetDataProcessing/
│
├── input/
│   ├── raw/
│   └── test_scenarios/
│
├── output/
│
├── src/
│
└── README.md
Architecture

The project follows Object-Oriented Programming and SOLID principles.

Main components:

Drone – data model
Data Reader – loads JSON files
Validator – validates drone records
Analysis Service – performs LINQ queries
Report Generator – creates the report
Program – coordinates the workflow
