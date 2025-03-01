# Sales Date Prediction 📈

API to list customers, products, orders and suppliers. It also allows 
listing an estimated date of the customer's next purchase and creation 
of new purchase orders.

## 🚀 Technologies Used
- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **Swagger for Documentation**

## 📥 Getting Started
These instructions will give you a give to install and run the
project in your local machine.

### 📂 Project structure
This project has the following structure:
```
└── 📁Sales Date Prediction
    └── 📁Sales Date Prediction
        └── appsettings.Development.json
        └── appsettings.json
        └── 📁Controllers
            └── CustomersController.cs
            └── EmployeesController.cs
            └── OrdersController.cs
            └── ProductsController.cs
            └── ShippersController.cs
        └── 📁Extensions
            └── AppExtensions.cs
        └── Program.cs
        └── 📁Properties
            └── launchSettings.json
        └── Sales Date Prediction.http
        └── SalesDatePrediction-API.csproj
        └── SalesDatePrediction-API.csproj.user
    └── 📁SalesDatePrediction-Application
        └── 📁Contracts
            └── CreateOrderDto.cs
        └── 📁Interfaces
            └── ICategoryRepository.cs
            └── ICustomerRepository.cs
            └── IEmployeeRepository.cs
            └── IGenericRepository.cs
            └── IOrderDetailsRepository.cs
            └── IOrderRepository.cs
            └── IProductRepository.cs
            └── IShipperRepository.cs
            └── ISupplierRepository.cs
        └── SalesDatePrediction-Application.csproj
        └── 📁Services
            └── CategoryService.cs
            └── CustomerService.cs
            └── EmployeeService.cs
            └── OrderDetailService.cs
            └── OrderService.cs
            └── ProductService.cs
            └── ShipperService.cs
            └── SupplierService.cs
    └── 📁SalesDatePrediction-Domain
        └── 📁Entities
            └── 📁DB
                └── Category.cs
                └── Customer.cs
                └── Employee.cs
                └── Order.cs
                └── OrderDetail.cs
                └── Product.cs
                └── Shipper.cs
                └── Supplier.cs
            └── 📁Models
                └── CustomerModel.cs
        └── SalesDatePrediction-Domain.csproj
    └── 📁SalesDatePrediction-Infraestructure
        └── 📁Persistence
            └── CoreDBContext.cs
        └── 📁Repository
            └── CategoryRepository.cs
            └── CustomerRepository.cs
            └── EmployeeRepository.cs
            └── GenericRepository.cs
            └── OrderDetailsRepository.cs
            └── OrderRepository.cs
            └── ProductRepository.cs
            └── ShipperRepository.cs
            └── SupplierRepository.cs
        └── SalesDatePrediction-Infraestructure.csproj
    └── 📁SalesDatePrediction-Test
        └── 📁Controllers
            └── CustomerControllerTest.cs
            └── EmployeeControllerTest.cs
            └── OrdersControllerTest.cs
            └── ProductsControllerTest.cs
            └── ShippersControllerTest.cs
        └── SalesDatePrediction-Test.csproj
    └── .gitattributes
    └── .gitignore
    └── LICENSE.txt
    └── README.md
    └── Sales Date Prediction.sln
```

### 🔧 Prerequisites
The following software and tools are required for run this project locally:
- [Microsoft Visual Studio](https://visualstudio.microsoft.com)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms)

### 🔥 Installing

1. Clone the repository:
```sh
git clone https://github.com/jett220201/Sales-Date-Prediction.git
cd Sales-Date-Prediction
```
2. Set connection string:
```sh
{
  "ConnectionStrings": {
    "salesDatePredictionConnection": "Server={your_server};Initial Catalog={your_db_catalog};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
  }
}
```
4. Restore NuGet packages:
```sh
dotnet restore
```
6. Run project:
```sh
dotnet run
```
8. Open Swagger in http://localhost:{port}/swagger

## ⚙️ API architecture
This project follows Clean Architecture principles, dividing the application into well-defined layers:

- **Application 🛠️ → Contains the business logic, rules and use cases.**
- **Domain 📦 → Defines the entities and contracts of the application.**
- **Infrastructure 🏗️ → Manages data persistence, database access and external services.**
- **Presentation (API) 🌍 → Exposes drivers and endpoints for interaction with external clients.**

This separation improves the modularity, maintainability and testability of the code, allowing changing technologies without affecting the core business. 🚀

## 📌 API Endpoints

| Method | Endpoint               | Controller         | Description               | Parameters       | Expected Response |
|-------|------------------------|--------------------|---------------------------|------------------|-------------------|
| `GET` | `/api/Customers/GetAll` | `CustomersController`  | Retrieves name, last order date and next predicted order date for each customer | None | List of orders (JSON) |
| `GET` | `/api/Customers/GetByCustomerName` | `CustomersController` | Retrieves name, last order date and next predicted order date for the customers who match the search input | Customer name (string) | List of orders (JSON) |
| `GET` | `/api/Employees/` | `EmployeesController`  | Retrieves id and full name for each employee | None | List of employees (JSON) |
| `GET` | `/api/Orders/` | `OrdersController`  | Retrieves general order information by customer id | Customer id (int) | List of orders (JSON) |
| `POST`| `/api/Orders/` | `OrdersController`  | Create a new order with details | Order and Order Details in a CreateOrderDto class  | New order id (JSON) |
| `GET` | `/api/Products/` | `ProductsController` | Retrieves id and name for each product | None | List of products (JSON) |
| `GET` | `/api/Shippers/` | `ShippersController` | Retrieves id and company name for each shipper| None| List of shippers (JSON) |

## 💡 Model for Post Method
For the new order api method is needed to use the following class:
```
public class CreateOrderDto
{
  public Order Order { get; set; } = new();
  public OrderDetail OrderDetail { get; set; } = new();
}
```

## :octocat: Authors

  - **Juan Esteban Torres Tamayo**

## 📜 License

This project is licensed under the [MIT](LICENSE.md)
License - see the [LICENSE.md](LICENSE.md) file for
details.
