# Domain Models

## Location

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "Name": "GL",
  "City": "Gliwice"
}
```

> Note: Name is required and it's maximum length should be 255.
> Note: City is required and it's maximum length should be 55.
> Note: There can't be more than one location with the same name.

## Team

```json
{
  "Id": "00000000-0000-0000-0000-000000000000",
  "Name": "Gliwice Team",
  "CoachName": "Karol"
}
```

> Note: Name is required and it's maximum length should be 255.
> Note: CoachName is required and it's maximum length should be 55.
> Note: There can't be more than one team with the same name.
