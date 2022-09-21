# MatchDataManager API

- [MatchDataManager API](#matchdatamanager-api)
  - [Locations](#locations)
    - [Add Location](#add-location)
    - [Delete Location](#delete-location)
    - [Get Locations](#get-locations)
    - [Get Location](#get-location)
    - [Update Location](#update-location)
  - [Teams](#teams)
    - [Add Team](#add-team)
    - [Delete Team](#delete-team)
    - [Get Teams](#get-teams)
    - [Get Team](#get-team)
    - [Update Team](#update-team)

## Locations

### Create Location

#### Create Request

```js
POST {{host}}/api/locations
```

```json
{
  "Name": "GL",
  "City": "Gliwice"
}
```

#### Create Response

```js
201 Ok
```

### Delete Location

#### Delete Request

```js
DELETE {{host}}/api/locations/{{id:guid}}
```

#### Delete Response

```js
204 No Content
```

### Get Locations

#### Get Request

```js
GET {{host}}/api/locations
```

#### Get Response

```js
200 Ok
```

```json
[
  {
    "Name": "GL",
    "City": "Gliwice"
  },
  {
    "Name": "RK",
    "City": "Rybnik"
  }
]
```

### Get Location

#### Get Request

```js
GET {{host}}/api/locations/{{id}}
```

#### Get Response

```js
200 Ok
```

```json
{
    "Name": "GL",
    "City": "Gliwice"
}
```

### Update Location

#### Update Request

```js
PUT {{host}}/api/locations/{{id:guid}}
```

#### Update Response

```js
204 No Content
```

## Teams

### Create Team

#### Create Request

```js
POST {{host}}/api/teams
```

```json
{
  "Name": "Gliwice Team",
  "CoachName": "Karol"
}
```

#### Create Response

```js
201 Ok
```

### Delete Team

#### Delete Request

```js
DELETE {{host}}/api/teams/{{id:guid}}
```

#### Delete Response

```js
204 No Content
```

### Get Teams

#### Get Request

```js
GET {{host}}/api/teams
```

#### Get Response

```js
200 Ok
```

```json
[
  {
    "Name": "Gliwice Team",
    "CoachName": "Karol"
  },
  {
    "Name": "Rybnik Team",
    "CoachName": "Damian"
  }
]
```

### Get Team

#### Get Request

```js
GET {{host}}/api/teams/{{id:guid}}
```

#### Get Response

```js
200 Ok
```

```json
{
  "Name": "Gliwice Team",
  "CoachName": "Karol"
}
```

### Update Team

#### Update Request

```js
PUT {{host}}/api/teams/{{id:guid}}
```

#### Update Response

```js
204 No Content
```
