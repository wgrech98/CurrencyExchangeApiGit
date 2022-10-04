# CurrencyExchangeApi

This is a readme file for the implementation of the Currency Exchange API

# Structure of the solution
## Controllers
### Orders controller
Hosts actions related to orders/currency exchange transactions

### Accounts controller
Hosts actions related to Accounts management

## Models
The models were split into the following areas 

The following models were created:

### Models related to deserializing the response from the API (found in ResponseModels folder)
1. Deserializing the response as per json format - CurrencyConversionResponse.cs
2. Extract the necessary fields from the response model needed to capture when a user submits a currency exchange transaction - CurrencyConversion.cs

### Models related to the orders
1. View the currency exchange transactions you added to your cart - OrderCartItem.cs (represents 1 item (currency exchange transaction) in the order cart)/ OrderCartVM.cs (represents what properties are involved in the order cart for the user)
2. View the orders you completed in the order history - Order.cs (represents a completed order which hosts a list of orderItems i.e. OrderItem.cs

### Models related to Accounts/Users
1. Inherits from IdentityUser - ApplicationUser.cs
2. Properties for the login page - LoginVM.cs
3. Properties for the Register page - RegisterVM.cs

## Services
### Services related to orders
The orders interface inherits from the IOrders interface

# Run the solution
To run the solution, clone the solution and set up a local sql server database. Copy the connection string in the appsettings.json file. 









