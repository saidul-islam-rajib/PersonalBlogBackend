# POST MODELS

#### POST API ENDPOINTS
```js
{
  CreatePost: POST /user/{:id}/post
  UpdatePost: PUT /user/{:id}/update/post/{:id}
  UpdateSection: PATCH /user/{:id}/update-section/post{:id}
  DeletePost: DELETE /user/{:id}/delete/{:id}
  GetAllPost: GET /posts
  GetPostById: GET /posts/{:id}
  GetPostByTitle: GET /posts/{:title}
  GetPostByTopics: GET /posts/{:topicIds}
}
```

#### POST FUNCTIONS
```csharp
class Post
{
	PostResponse CreatePost(PostRequest post);
  PostResponse UpdatePost(PostRequest post);
  PostResponse UpdateSection(PostSection section);
	bool DeletePost(Guid id);
  List<PostResponse> GetAllPost();
  PostResponse GetPostById(Guid id);
  List<PostResponse> GetPostByTitle(string title);
  List<PostResponse> GetPostByTopics(string topics);
}
```

#### POST REQUEST
```json
POST /user/{:id}/post
```
```json
{
  "title": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
  "abstract": "This tips will helpful for those people want...", 
  "sections": [
    {
      "title": "INTRODUCTION",
      "description": "1st section description will be here",
      "items": [
        {
          "itemTitle": "SELF OBSERVATION",
          "itemDescription": "1st item description will be here",
          "itemImages":"image link will be here."
        },
        {
          "itemTitle": "SELF OBSERVATION",
          "itemDescription": "1st item description will be here",
          "itemImages":"image link will be here."
        }
      ]
    }
  ],
  "topicIds": [1,2,3,4,5,...,10]
}
```


#### POST RESPONSE
```json
POST /post/{:id}
```

```json
{
    "id": "6126960c-0e94-46d6-a270-e836bf767b6a",
    "title": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
    "date":"December 04, 2024",
    "abstract": "This tips will helpful for those people want...",
    "averageRating": 0,    
    "sections": [
      {
        "id": "07e8b33e-5b0c-4fc2-b284-2c92e5dd3fd9",
        "title": "INTRODUCTION",
        "description": "1st section description will be here",
        "items": [
          {
            "id": "a1d50fea-36d7-490a-ba50-2b4879215e01",
            "itemTitle": "SELF OBSERVATION",
            "itemDescription": "1st item description will be here",
            "itemImages":"image link will be here."
          },
          {
            "id": "a1d50fea-36d7-490a-ba50-2b4879215e01",
            "itemTitle": "SELF OBSERVATION",
            "itemDescription": "1st item description will be here",
            "itemImages":"image link will be here."
          }
        ]
      }
    ],
    "userId": "123e4567-e89b-12d3-a456-426614174000",
    "topicIds": [1,2,3,4,5,...,10],
    "commentIds": [1,2,3,4,5,6,...,50],
    "createdDate": "04/12/2024",
    "updatedDate": "04/12/2024"
}
```
