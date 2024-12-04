# SUBSCRIPTION MODELS

#### SUBSCRIPTION REQUEST
```json
POST /user/{:id}/publication
```
```json
{
  "name": "Saidul Islam Rajib",
  "email": "saidul.is.rajib@gmail.com"  
}
```


#### SUBSCRIPTION RESPONSE
```json
GET /publication/{:id}
```

```json
{
  "subscriberId": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Saidul Islam Rajib",
  "email": "saidul.is.rajib@gmail.com"
}
```
