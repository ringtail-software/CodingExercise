# Reichert: Online Ordering

## LAUNCH
- This is an SQL database project, so it can be run either by setting the Data Source in the project's Debug options to an SQL server, or using the (localdb).
- This project contains a small script that will populate the database with a few rows of sample data.



## DATABASE

## Tables
#### Customer
- Id: integer, primary key
- FirstName
- LastName
- DiscountPercent: decimal, expressed as full percent
#### Product
- Id: integer, primary key
- Name: string
- Cost: decimal
#### Order (data that applies to the Ororderder as a whole)
- Id: integer, primary key
- CustomerId: FK to Customer..Id
- UpdateDate: datetime, the date the last change was made to the order
- TotalQuantity: integer, total quantity of all items on the order
- Cost: decimal, the total cost before any discounts are applied
- Price: decimal, the total price the customer is charged, after discounts
- IsComplete: bit, signifies a closed order. Used in calculating customer discounts (only include completed purchases)
#### OrderItem (data that applied to individual product purchases on the order)
- Id: integer, primary key
- ProductId: FK to Product..Id
- Quantity: integer, quantity of this product
- OrderId: integer, FK to Order..Id


## Stored Procedures
#### AddCustomer
- Adds new customer and assigns Id
- Parameters:
- @firstName: varchar(100)
- @lastName: varchar(100)
#### AddOrderItem
- Adds data about an individual product purchase. If the customer has an open order, it will be added to it. Otherwise, a new order will be created.
- Parameters:
- @ProductId: key to Product..Id
- @Quantity: quantity of this product
- @CustomerId: key to Customer..Id, the customer making the purchase
#### AddProduct
- Adds new product and assigns Id
- Parameters
- @Name: varchar(100)
- @Cost: decimal, cost of 1 unit of product, pre-discount
#### DeleteOrderItem
- Removes an OrderItem from the Order. If it is the only/last item on the order, the order will be deleted.
- Parameters
- @OrderItemId: key to OrderItem..Id, the unique Id of the line-item purchase
#### GetOrderDetails
- Returns two query results.
- First result set is requested data about the order as a whole (total quantity, price before and after discount, customer name, etc)
- Second result set is an itemized list of all of the purchase orders on the order (product name, pduct quantity, product cost and price, etc)
- Parameters:
- @OrderId: key to Order..Id, the unique Id of the order
#### RecalculateOrder
- Updates Order data when there is a change to an OrderItem attached to that Order
- Recalculates Quantity, Price, Cost, and updates Order..UpdatedDate
#### UpdateCustomerDiscount
- Updates a Customer's Discount based on the calculations supplied
- Parameters:
- @customerId: key to Customer..Id
#### UpdateOrderItem
- Updates the Quantity of an OrderItem, as well as the data on the Order itself
- Parameters:
- @OrderItemId: key to OrderItem..Id, the unique Id of the line-item purchase
- @Quantity: the new quantity of the product 
