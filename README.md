# Payment System Integration with PayPal

This project integrates PayPal's payment gateway to facilitate online transactions. It includes an API that communicates with PayPal to create orders and process payments in a secure and reliable manner.

## Project Overview

This system is designed to enable users to initiate payments through PayPal for purchasing services or goods. The system handles the creation of orders, captures payments, and integrates with PayPal's APIs. It allows the user to create a payment order, redirect to PayPal for processing, and capture the payment once the user confirms the transaction.

### Key Features:
- **Order Creation:** Initiates the process of creating an order on PayPal.
- **Payment Processing:** Redirects users to PayPal to complete their payments.
- **Order Capture:** Captures authorized payments after the user has completed the transaction.
- **Error Handling:** Handles scenarios like failed transactions or user cancellations.

## How it Works

1. **User Request:** The user initiates a payment request by providing the amount and currency.
2. **Order Creation:** The backend creates an order with PayPal by calling the PayPal API with the provided details.
3. **Redirection to PayPal:** Once the order is created, the user is redirected to PayPal for completing the transaction.
4. **Payment Capture (Optional):** If the payment is authorized, it can be captured by the merchant.

## Tech Stack

- **Backend:** ASP.NET Core
- **Payment Integration:** PayPal Checkout SDK
- **Frontend (Optional):** JavaScript, React (for front-end communication)


## Setup and Configuration

1. **Clone the Repository:**
git clone https://github.com/your-username/payment-system.git cd payment-system

2. **Install Dependencies:**
- Install the necessary NuGet packages for PayPal SDK:
  ```bash
  dotnet add package PayPalCheckoutSdk
  ```

3. **Configure PayPal Credentials:**
- Add your PayPal Client ID and Secret in `appsettings.json`:
```json
{
  "PayPal": {
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret"
  }
}

4. **Run the Application:**
- Start the application locally: dotnet run
API will be available at http://localhost:5000


## Endpoints
POST /api/payment/create-payment

Initiates the payment process by creating an order.

Request Body:
POST /api/payment/create-payment

Initiates the payment process by creating an order.

Request Body:

json
Copy
{
  "amount": 100.00,
  "currency": "USD"
}
Response:

json
Copy
{
  "orderId": "12345",
  "status": "CREATED",
  "intent": "CAPTURE"
}
POST /api/payment/capture-payment

Captures an authorized payment once the user confirms.

Request Body:

json
Copy
{
  "orderId": "12345"
}
Response:

json
Copy
{
  "status": "CAPTURED",
  "captureId": "67890"
}
Contributing
Fork the repository.

Create a new branch (git checkout -b feature-branch).

Commit your changes (git commit -am 'Add new feature').

Push to the branch (git push origin feature-branch).

Create a new Pull Request.

License
This project is licensed under the MIT License - see the LICENSE file for details.