# CurrencyExchangeApp

This is a readme file for the implementation of the Currency Exchange Application

# Structure of the solution
## Controllers
### Orders controller
Hosts actions related to orders/currency exchange transactions
### Accounts controller
Hosts actions related to Accounts management

## Models
The models were split into the following areas:

### Models related to deserializing the response from the API (found in ResponseModels folder)
1. Deserializing the response as per json format - CurrencyConversionResponse.cs
2. Extract the necessary fields from the response model needed to capture when a user submits a currency exchange transaction e.g. From: EUR, To: GBP, Original Amount: 100, Conversion Result: 110 - CurrencyConversion.cs

### Models related to the orders
1. View the currency exchange transactions you added to your cart - OrderCartItem.cs (represents 1 item (currency exchange transaction) in the order cart)/ OrderCartVM.cs (represents the properties involved in the order cart for the user)
2. View the orders you completed in the order history - Order.cs (represents a completed order which hosts a list of orderItems i.e. OrderItem.cs

### Models related to Accounts/Users
1. Properties for Application User, inherits from IdentityUser - ApplicationUser.cs
2. Properties for the login page - LoginVM.cs
3. Properties for the Register page - RegisterVM.cs


## Services
### Services related to orders
The orders interface inherits from the IOrders interface


# Run the solution
To run the solution, clone the solution and set up a local sql server database. Copy the connection string in the appsettings.json file


# Guidance on the usage of the solution
The solution greets the user with the login screen. There are two types of Accounts - User and Admin

You can also use the solution without logging in as a user or Admin, however, you cannot complete an order in this scenario

The login details for a demo user and admin account are available in AppDbInitializer.cs

## User View
1. Can submit a new currency exchange transaction (can submit more than one currency exchange transaction in one order) - Click on the navbar brand (CurrencyExchange) in the Navbar
2. Can view the current order - Click on the basket
3. Can view a list of that user's completed orders - Click on the Orders Item in the Navbar

## Admin View
1. Can view a list of all completed orders along with the username that submitted the order
2. Can view a list of existing users - Click on the users item in the navbar


# Logging and Caching

Logging is used to log:
* login attempts by existing users
* Register a new account attempt
* Currency Conversion attempts

Caching is used to:
* Cache the list of existing users in the system
* Cache the orders of each user
* The ResponseCache mechnanism is used to cache responses from the API Server. The Duration property will produce the max-age header, which we use to set the cache duration for 30 minutes (1800 seconds)  

# IP Rate Limiting
IP rate limiting is used to limit each client to 10 currency exchange trades per hour. This limit is imposed on the "POST:/Orders/AddItemToOrderCart" endpoint which is the post action where the user submits a currency exchange transaction in the application. The configuration is done in the appsettings.json file








