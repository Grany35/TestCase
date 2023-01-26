# mallconomyTestCase


## API Documentation

### Award

#### Get all Awards

```http
  GET /api/Awards
```


#### Get Awards Of User

```http
  GET /api/Awards?UserId=${UserId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `UserId`      | `string` | **Optional** Filter By UserId |

Example Response

```
[
  {
    "id": "63d2f7d39c394d98ba463485",
    "user_Id": "628b514c1ba3abddabf15fe1",
    "award": "First Prize"
  },
  {
    "id": "63d2f7d39c394d98ba463488",
    "user_Id": "628b514c1ba3abddabf15fe1",
    "award": "25$"
  },
  {
    "id": "63d2f7d39c394d98ba4634ec",
    "user_Id": "628b514c1ba3abddabf15fe1",
    "award": "Consolation Prize - 12,5$"
  }
]
```

### LeaderBoard

#### Get all LeaderBoards

```http
  GET /api/LeaderBoard
```


#### Get LeaderBoards Of Month

```http
  GET /api/LeaderBoard?Month=${Month}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Month`      | `int` | **Optional** LeaderBoards of Month |

#### Get LeaderBoard Of User

```http
  GET /api/LeaderBoard?UserId=${UserId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `UserId`      | `string` | **Optional** LeaderBoard of User |

Example Response

```
[
  {
    "id": "63d2f7d79c394d98ba4638d4",
    "user_Id": "628b514c1ba3abddabf15fe1",
    "rank": 1,
    "total_Points": 10000,
    "date": "2023-01-26T21:59:51.212Z"
  }
]
```

#### Post LeaderBoard

```http
  POST /api/LeaderBoard
```

Retrieves score information from the https://cdn.mallconomy.com/testcase/points.json address and creates a leaderboard only once within the same month, gives 'First Prize' to the 1st, 'Second Prize' to the 2nd, 'Third Prize' to the 3rd, '25$' to the first 100 users, and 12.500$ prize equally divided and given to the first 1000 users.


