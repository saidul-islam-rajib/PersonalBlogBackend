# COMMENT MODELS

#### COMMENT API ENDPOINTS
```js
{
  CreateComment: POST /post/{:id}/comment
  GetAllComments: GET /Comments
  GetApprovedComments: GET /Comments/{:status}
  DeleteComment: DELETE /user/{:userId}/delete/{:commentId}
}
```

#### COMMENT FUNCTIONS
```csharp
class Post
{
	void CreateComment(CommentRequest Comment);
  List<CommentResponse> GetAllComments();
  List<CommentResponse> GetApprovedComments(Status status);
  bool DeleteComment(Guid CommentId);
}
```

#### COMMENT REQUEST
```json
POST /user/{:userId}/comment
```
```json
{
  "postId":"6126960c-0e94-46d6-a270-e836bf767b6a",
  "guestname": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
  "comment": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
  "date": "04/12/2024"
}
```


#### Comment RESPONSE
```json
GET /Comments/{:commentId}
```

```json
{
  "id": "6126960c-0e94-46d6-a270-e836bf767b6a",
  "postId":"6126960c-0e94-46d6-a270-e836bf767b6a",
  "postTitle": "POST TITLE",
  "guestname": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
  "comment": "This is the comment...",
  "date": "04/12/2024"
}
```
