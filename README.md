# Food-ordering-system
This repository contains the source code for a **Food Ordering Web Application** that provides a seamless online ordering experience. The platform allows users to browse menu items, manage their cart, and place orders. Admin users can manage products, track orders, view analytics, and address customer feedback.

---

## **Features**

### **User Functionality**
- User authentication (login, logout, registration).
- View and update profile details.
- Add items to a shopping cart, adjust quantities, and proceed to checkout.
- Secure payment integration for card and Cash on Delivery (COD) options.
- Submit queries and feedback through a contact page.

### **Admin Functionality**
- Manage menu items and categories (add, update, delete).
- View and update order statuses.
- Track business metrics via reporting and analytics.
- Respond to customer queries and feedback.

---

## Repository Structure

```
Food_Ordering_Project/
│
├── Admin/                          # Contains pages and controls for admin functionalities
│   ├── Category.aspx               # Page for managing product categories
│   ├── Contacts.aspx               # Page for viewing and managing contact queries from users
│   ├── Dashboard.aspx              # Admin dashboard for an overview of the application's performance
│   ├── OrderStatus.aspx            # Page for managing and viewing order statuses
│   ├── Products.aspx               # Page for managing products listed in the menu
│   ├── Report.aspx                 # Page for generating and viewing reports and analytics
│   ├── Users.aspx                  # Page for managing user accounts and permissions
│   ├── ...
│
├── App_Data/                   # Database files and resources used by the application
│   ├── ...
│
├── assets/                     # Static assets such as CSS, JavaScript, and image files
│   ├── ...
│
├── Models/                     # Data models representing the business entities used in the application
│   ├── Connection.cs           # Manages the database connections
│   ├── ...
│
├── TemplateFiles/              # Template files for dynamically generating content
│   ├── ...
│
├── User/                       # User-related pages for authentication and profile management
│   ├── About.aspx              # About page for users
│   ├── Cart.aspx               # Shopping cart page for users
│   ├── Contact.aspx            # Contact page for feedback or queries
│   ├── Default.aspx            # Home page for the application
│   ├── Invoice.aspx            # Invoice page for users to review orders
│   ├── Login.aspx              # Login page for user authentication
│   ├── Menu.aspx               # Menu listing page for browsing items
│   ├── Profile.aspx            # User profile management page
│   ├── Registration.aspx       # Registration page for new users
│   ├── ...
│
├── Global.asax                 # Application-wide settings and configuration
├── Web.config                  # Web application configuration file
│
├── Food_Ordering_Project.Tests/
│   ├── CartManagerTests.cs     # Unit tests for the Cart Management module
│   ├── UnitTest1.cs            # General unit tests
│
```

## Setup Instructions

To set up and run the project locally, follow the instructions below:

### Prerequisites
- **Visual Studio 2019 or later** with ASP.NET and Web Development workload.
- **.NET Framework 4.7.2** or later.
- **NuGet Packages**

### Steps

1. **Clone the Repository**  
   Clone this repository to your local machine:
   ```git clone https://github.com/nghiem04/food-order-system.git```

2. **Open the Solution**
    Open the Food_Ordering_Project.sln file in Visual Studio.

3. **Restore NuGet Packages**
    In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console and run:

    run: ```dotnet restore```


4. **Configure the Database**
- Use the `FoodOrderingDB.sql` in MSSQL to create the required tables.
- Open the Web.config file and update the <connectionStrings> section to match your local SQL Server or LocalDB configuration.


5. **Build and Run the Project**
- Build the project in Visual Studio (Ctrl + Shift + B).
- Set Food_Ordering_Project as the startup project.
- Start the application (Ctrl + F5).

6. **Access the Application**
Once the project is running, you can access the application via http://localhost:xxxx/ (replace xxxx with the port number Visual Studio assigns).

7. **Admin Login (for testing)**
    Use the following credentials to log in as an admin:

    Username: admin
    Password: admin123

---

**Running Tests** 

Execute the following commands for testing:

	1.	Restore and build the test project:

	```dotnet restore
		dotnet build --configuration Release
	```

	2. Run tests: 
	```
	dotnet test --logger "trx;LogFileName=TestResults.trx"
	```
---

**Deployment** 

This project uses Continuous Deployment through Azure DevOps. The pipeline automatically builds, tests, and deploys updates. To deploy manually:

	1.	Generate the deployment package:

	```
	dotnet publish --configuration Release --output ./publish_output
	```
	
	2.	Upload the package to Azure App Services or any web server.


---

**Additional Information** 
	Here are the commands to restore, build, push and test locally: 

    - dotnet restore FoodOrdering/FoodOrdering.csproj
    - dotnet build FoodOrdering/FoodOrdering.csproj --configuration Release
    - dotnet publish FoodOrdering/FoodOrdering.csproj --configuration Release --output ./publish_output
    - dotnet test FoodOrdering.Tests/FoodOrdering.Tests.csproj --configuration Release
    - dotnet test FoodOrdering.Tests/FoodOrdering.Tests.csproj --configuration Release --logger "trx;LogFileName=TestResults.trx"
