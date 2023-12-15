# E-Commerce Blazor WebAssembly Project Showcase

Hello there! 👋 Welcome to my repository showcasing my skills as a backend/.NET developer. In this project, I've dedicated my time to building a robust E-Commerce Web Application using Blazor WebAssembly. Below, I've outlined key aspects that reflect my proficiency and commitment to best coding practices.

## Project Highlights

### Architecture and Technologies

- **Walking Skeleton Setup:** Established the project foundation with .NET, Blazor WebAssembly, a Web API, Entity Framework Core, and SQL Server.

- **Best Practices Implementation:** Incorporated industry best practices, leveraging Generics, Data-Transfer-Objects (DTOs), and the Repository Pattern to ensure a maintainable and scalable codebase.

### Feature Implementation

- **E-Commerce Functionality:** Developed essential features for an E-Commerce App, including Search, Pagination, Featured Products, a dynamic Cart (both local & database-based), Orders, and more.

- **Authentication and Authorization:** Implemented secure user authentication using JSON Web Tokens (JWT) and applied Role-Based Authorization for Administrators and Customers.

### Database Management

- **Code-First Migration:** Utilized Entity Framework Core & SQL Server for seamless database management, employing Code-First Migration to maintain a well-structured schema.

### Integration and Customization

- **Payment Gateway Integration:** Integrated Stripe Checkout for smooth and secure payment processing, supporting Credit Card, Apple Pay & Google Pay.

- **Custom Layout Design:** Crafted a custom layout for the Blazor WebAssembly Application, enhancing the overall user experience.

### Administration Features

- **CRUD Operations:** Implemented comprehensive CRUD operations, providing efficient management capabilities.

## How to Run the Project

To explore my project locally, follow these steps:

1. **Clone the Repository:**
   ```
   git clone https://github.com/milance139/BlazorEcommerce.git
   cd BlazorEcommerce
   ```
   
2. **Update Connection Strings:**<br>
   Open the appsettings.json file.<br>
   Update the DefaultConnection string with your SQL Server details
   
4. **Update AppSettings:**<br>
   In the same appsettings.json file, update the JwtToken and create a [Stripe](https://stripe.com/) account to acquire your own 'StripeSecretKey' in the "AppSettings" section
   
6. **Apply Migrations:**<br>
   Execute Entity Framework Core migrations to set up the database schema:
   ```
   dotnet ef database update
   ```
8. **Install and Run Stripe CLI for Webhooks:**<br>
   Download and install the [Stripe CLI](https://stripe.com/docs/stripe-cli).<br>
   In your terminal, run the following command to listen for webhook events locally:
   ```
   stripe listen --forward-to https://localhost:5001/webhooks/stripe
   ```
   Note: Make sure to replace 'https://localhost:5001' with the actual URL where your application is running.
10. **Launch the Application**<br>
    Explore and enjoy

## Contact me
I invite you to explore the features, provide feedback, or suggest improvements. This project reflects my dedication to delivering efficient, secure, and user-friendly solutions. Your insights are highly valued!

Thank you for considering my work. 🚀
