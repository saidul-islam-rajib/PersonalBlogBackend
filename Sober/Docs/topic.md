# TOPIC MODELS

#### TOPIC API ENDPOINTS
```js
{
  CreateTopic: POST /user/{:userId}/topic
  GetAllTopics: GET /topics
  GetTopicById: GET /topics/{:topicId}
  GetTopicByTitle: GET /topics/{:title}
  DeleteTopic: DELETE /user/{:userId}/delete/{:topicId}
}
```

#### TOPIC FUNCTIONS
```csharp
class Post
{
	TopicResponse CreateTopic(TopicRequest topic);
  TopicResponse GetTopicById(Guid topicId);
  List<TopicResponse> GetAllTopics();
  List<TopicResponse> GetTopicByTitle(string title);
  bool DeleteTopic(Guid topicId);
}
```

#### TOPIC REQUEST
```json
POST /user/{:userId}/topic
```
```json
{
  "title": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER"
}
```


#### TOPIC RESPONSE
```json
GET /topics/{:topicId}
```

```json
{
  "id": "6126960c-0e94-46d6-a270-e836bf767b6a",
  "title": "HELPFUL TIPS TO BECOME SOFTWARE ENGINEER",
  "userId": "123e4567-e89b-12d3-a456-426614174000",
  "createdDate": "04/12/2024"
}
```
