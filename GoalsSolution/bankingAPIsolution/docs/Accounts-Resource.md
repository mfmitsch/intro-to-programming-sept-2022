# Accounts Resource

Development authority: http://localhost:9000
## Accounts

### GET /accounts


```json
{

    "data": [
        {"id": "89898", "name": "Bob Smith" },
        {"id": "89393", "name": "Barb Watson" }

    ]
}

```


### GET /accounts/{id}

GET /accounts/89898

```json 
{
    "id": "89898",
    "name": "Bob Smith",
    
}

```
### POST /account

{}
