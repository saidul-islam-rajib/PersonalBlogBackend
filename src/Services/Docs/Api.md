# Dinner API

- [Dinner Api](#dinner-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Register
```js
POST {{host}}/auth/register
```

#### Register Request
```js
{
  "firstName": "Rajib",
  "lastName": "Ahmed",
  "email": "saidul.is.rajib@gmail.com",
  "password": "242342"
}  
```

#### Register Response
```js
{
  "id": "d2c7b6ad-2c1b-4a1d-b537-e59d0d97c2f1",
  "firstName": "Rajib",
  "lastName": "Ahmed",
  "email": "saidul.is.rajib@gmail.com",
  "token": "242342...234sdfsef"
}
```


## Login
```js
POST {{host}}/auth/login
```

#### Login Request
```js
{
  "email": "saidul.is.rajib@gmail.com",
  "password": "242342"
}
```

#### Login Response
```js
{
  "id": "d2c7b6ad-2c1b-4a1d-b537-e59d0d97c2f1",
  "firstName": "Rajib",
  "lastName": "Ahmed",
  "email": "saidul.is.rajib@gmail.com",
  "token": "sfsfsf...sfsa23wr"
}
```