# Wish-list

REST API for wishlist management.

## API Reference

### Create wish
Adds a wish to the list

```
  POST /api/wishList/wish/create
```

Request

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

Request

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

Response

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

Response

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