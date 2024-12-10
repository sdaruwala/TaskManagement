# TaskManagement

# Getting Started
1. .NET 9.0
2. .NET ASPIRE
3. Visual Studio 2022
4. Blazor Server App



# Project Overview
TaskManagement is a Blazor Server application that provides a user-friendly interface for managing tasks using LATEST .NET 9. It integrates with a RESTful API to perform CRUD operations on tasks. This project is structured into multiple projects to facilitate better organization and separation of concerns.

# Project Structure

  # TaskManagement.API:  
    
    # Description: This project is a .NET Core Web API that handles all server-side operations related to tasks. It provides endpoints for adding, updating, deleting, and retrieving tasks.
      Features:
      CRUD operations for managing tasks.
      Uses unit testing of service logic.
      Dependencies:
      TaskManagement.Models: A shared library containing data models.
      TaskManagement.Services: Service layer for interacting with the database and handling business logic.
      
  # TaskManagement.API.Test:

    # Description: This project contains unit tests for the TaskManagement.API. It uses xUnit as the testing framework to ensure the reliability of the API.
      Features:
      Test coverage for the API endpoints.
      Tests for service methods.
      Dependencies:
      TaskManagement.Models: Required for data models.
      TaskManagement.Services: To test the service layer interactions.
    
  # TaskManagement.Apphost:
  
    # Description: This project was created using .NET Aspire Orchestrator, This is the host project that brings together the API and UI. It initializes and configures the application, including services, middleware, and routing. 

  # Taskmanagement.Service.Defaults :
    # Description: This project was created using .NET Aspire Orchestrator
  
  # TaskManagement.UI:
    # Description: This project is a Blazor Server application providing a user interface for managing tasks. It consumes the API to display, edit, and delete tasks.


   


 # License
This project is licensed under the MIT License - see the LICENSE file for details.
