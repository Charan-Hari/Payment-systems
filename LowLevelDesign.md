### **Low-Level Design (LLD) Document**

#### 1. **Introduction**

This document describes the low-level design (LLD) for the Payment System Integration with PayPal. It provides detailed information about the system's architecture, class diagrams, and database schema.

#### 2. **System Components**

The system consists of the following components:
- **API Layer (Controller):** Handles incoming requests from the user and calls the service layer to interact with PayPal.
- **Service Layer:** Contains business logic, communicates with PayPal, and manages payment transactions.
- **Models:** Represent the data structures used for creating requests and receiving responses.

#### 3. **Class Diagram**

![Class Diagram](https://via.placeholder.com/500x300?text=Class+Diagram+Placeholder)

*Note: You can use UML tools like Lucidchart, Visual Paradigm, or others to create the class diagram.*

##### Classes:
1. **PaymentController**
   - **Methods:**
     - `CreatePayment()`: Receives payment details and calls `PaymentService.CreatePaymentAsync`.
     - `CapturePayment()`: Captures an authorized payment by calling `PaymentService.CapturePaymentAsync`.
   - **Properties:**
     - `PaymentService`: Dependency injection of `PaymentService`.

2. **PaymentService**
   - **Methods:**
     - `CreatePaymentAsync()`: Creates an order via PayPal's `OrdersCreateRequest`.
     - `CapturePaymentAsync()`: Captures the payment using PayPal's API.
   - **Properties:**
     - `PayPalHttpClient`: Used to make HTTP requests to PayPal.

3. **PaymentRequest**
   - **Properties:**
     - `Amount`: The amount to be paid.
     - `Currency`: The currency in which the payment is made.

4. **PaymentResponse**
   - **Properties:**
     - `OrderId`: The unique identifier for the created order.
     - `Status`: The status of the payment (e.g., CREATED, CAPTURED).
     - `Intent`: The intent of the order (e.g., CAPTURE).

5. **OrderRequest**
   - **Properties:**
     - `PurchaseUnits`: List of purchase unit requests.
     - `ApplicationContext`: Context of the order.
   - **Methods:**
     - `RequestBody()`: Sets the request body for PayPal order creation.

6. **PurchaseUnitRequest**
   - **Properties:**
     - `AmountWithBreakdown`: Contains the amount and breakdown of the payment.
     - `Description`: Description of the items or services being paid for.

7. **AmountWithBreakdown**
   - **Properties:**
     - `CurrencyCode`: Currency of the payment.
     - `Value`: The amount to be paid.

8. **ApplicationContext**
   - **Properties:**
     - `BrandName`: The brand name displayed on PayPal.
     - `LandingPage`: The landing page type (BILLING, LOGIN).
     - `ShippingPreference`: Shipping preference (NO_SHIPPING, etc.).
     - `UserAction`: The user action (e.g., PAY_NOW).

#### 4. **Database Schema (Optional)**

If you're using a database to store payment-related information (e.g., orders, payment status), here's a possible schema:

- **Payments Table:**
  - `PaymentId` (Primary Key, INT)
  - `OrderId` (VARCHAR, UNIQUE)
  - `Amount` (DECIMAL)
  - `Currency` (VARCHAR)
  - `Status` (VARCHAR) — e.g., CREATED, CAPTURED
  - `Intent` (VARCHAR) — e.g., CAPTURE, AUTHORIZE
  - `CreatedAt` (DATETIME)

**ER Diagram:**

+------------------+ +------------------+ | Payments | | Orders | +------------------+ +------------------+ | PaymentId (PK) |<--->| OrderId (PK) | | Amount | | OrderDetails | | Currency | +------------------+ | Status | | Intent | +------------------+
