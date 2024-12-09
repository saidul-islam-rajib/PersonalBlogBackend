using Mapster;
using Sober.Application.Posts.Commands;
using Sober.Contracts.Request.Posts;
using Sober.Contracts.Response.Posts;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;

namespace Sober.Api.Common.Mappings
{
    public class PostMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(PostRequest Request, Guid UserId), CreatePostCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Post, PostResponse>()
                .Map(dest => dest.PostId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value);

            config.NewConfig<PostSection, PostSectionResponse>()
                .Map(dest => dest.SectionId, src => src.Id.Value);

            config.NewConfig<PostItem, PostSectionItemResponse>()
                .Map(dest => dest.ItemId, src => src.Id.Value)
                .Map(dest => dest.ItemTitle, src => src.PostItemTitle)
                .Map(dest => dest.ItemDescription, src => src.PostItemDescription)
                .Map(dest => dest.ItemImageLink, src => src.PostItemImageLink);

            config.NewConfig<PostTopic, TopicResponse>()
                .Map(dest => dest.TopicId, src => src.Id.Value)
                .Map(dest => dest.UserId, src => src.UserId.Value)
                .Map(dest => dest.TopicTitle, src => src.TopicTitle);
        }
    }
}
