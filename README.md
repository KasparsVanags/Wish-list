# Wish-list

REST API for wishlist management.

## API Reference

### Create wish
Adds a wish to the list

```
  POST /api/wishList/wish/create
```

Request body

```json
{
  "name": "string",
  "url": "string",
  "notes": "string"
}
```

| Parameter  | Type       | Description                |
|:-----------|:-----------|:---------------------------|
| `name`     | `string`   | **Required**. Name of item |
| `url`      | `string`   | **Optional**. Link to item |
| `notes`    | `string`   | **Optional**. Notes        |

---

### Update wish
Updates wish properties by id

```
  PUT /api/wishList/wish/update/(id)
```

Request body

```json
{
  "name": "string",
  "url": "string",
  "notes": "string"
}
```

| Parameter  | Type       | Description             |
|:-----------|:-----------|:------------------------|
| `name`     | `string`   | **Required**. New name  |
| `url`      | `string`   | **Required**. New link  |
| `notes`    | `string`   | **Required**. New notes |

---

### Delete wish
Deletes a wish by id

```
  DELETE /api/wishList/wish/delete/(id)
```

---

### Get wish by id
Returns a wish by id

```
  GET /api/wishList/wish/get/(id)
```

Response body

```json
{
  "name": "string",
  "url": "string",
  "notes": "string",
  "id": 1
}
```

---

### Get wish list
Returns all wishes

```
  GET /api/wishList/getAll
```

Response body

```json
[
  {
    "name": "string",
    "url": "string",
    "notes": "string",
    "id": 1
  },
  {
    "name": "string",
    "url": "string",
    "notes": "string",
    "id": 2
  },
  {
    "name": "string",
    "url": "string",
    "notes": "string",
    "id": 99
  }
]
```

---

### Get usernames from user array
Returns a comma separated string of usernames

```
  POST /api/users/getNames
```

Request body
```json
{
  "users": 
  [
    {
      "type": "user",
      "id": 150709,
      "name": "johnsmith",
      "email": "jsmith@example.com"
    },
    {
      "type": "user",
      "id": 150710,
      "name": "angelinasmith",
      "email": "asmith@example.com"
    },
    {
      "type": "user",
      "id": 150910,
      "name": "adamivanov",
      "email": "aivanov@another.org"
    }
  ]
}
```

Response body

```
johnsmith,angelinasmith,adamivanov
```