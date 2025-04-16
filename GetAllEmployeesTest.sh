#!/bin/bash

# Define the login URL and the employees URL
LOGIN_URL="http://localhost:8000/api/login"
EMPLOYEES_URL="http://localhost:8000/api/employees"

# Define the credentials
USERNAME="sarah.johnson@onlybytes.com"
PASSWORD="Password123!"

# Perform the login and store the bearer token
TOKEN=$(curl -s -X POST "$LOGIN_URL" \
-H "Content-Type: application/json" \
-d "{\"email\": \"$USERNAME\", \"password\": \"$PASSWORD\"}" | grep -o '"token":"[^"]*' | grep -o '[^"]*$')

# Check if the token was retrieved successfully
if [ -z "$TOKEN" ]; then
    echo "Failed to retrieve token. Please check your credentials."
    exit 1
fi

echo "Bearer token retrieved: $TOKEN"

# Call the /api/employees endpoint using the bearer token
curl -s -X GET "$EMPLOYEES_URL" \
-H "Authorization: Bearer $TOKEN" \
-H "Content-Type: application/json"

echo
