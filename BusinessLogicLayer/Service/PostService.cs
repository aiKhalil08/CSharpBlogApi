using BusinessLogicLayer.IServices;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Post? CreatePost(Post post, List<int> tagIds, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(post.Content))
            {
                message = "Content can not be empty";
                return null;
            }

            if (string.IsNullOrEmpty(post.Title))
            {
                message = "Title can not be empty";
                return null;
            }

            if (string.IsNullOrEmpty(post.UserId))
            {
                message = "User can not be empty";
                return null;
            }

            message = "Created successfully";

            Post createdPost = _unitOfWork.postRepository.Create(post);

            // associate tags
            if (tagIds != null && tagIds.Count > 0)
            {
                foreach (var tagId in tagIds)
                {
                    var tag = _unitOfWork.tagRepository.Get(tagId);
                    if (tag != null)
                    {
                        createdPost.Tags.Add(tag);
                        _unitOfWork.postRepository.Update(createdPost);
                    }
                }
            }

            return createdPost;
        }

        public bool DeletePost(int id, out string message)
        {
            //checking if the id is valid
            if(id <= 0)
            {
                message = "Invalid ID";
                return false;
            }

            Post? post = _unitOfWork.postRepository.Get(id);

            //checking if the id exists
            if(post == null)
            {
                message = "Post not found";
                return false;
            }

            _unitOfWork.postRepository.Delete(post);

            message = "Post deleted successfully";
            return true;
        }

        public List<Post> GetAllPost()
        {
            return _unitOfWork.postRepository.GetAll();
        }

        public Post? GetPost(int id, bool withLikes = false, bool withComments = false, bool withTags = false)
        {
            //checking if the id is valid
            if (id <= 0)
            {
                return null;
            }

            Post? post = _unitOfWork.postRepository.Get(id, withLikes, withComments, withTags);

            //checking if post exists
            if (post == null)
            {
                return null;
            }

            return post;
        }

        public Post? UpdatePost(Post post, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(post.Content))
            {
                message = "Content can not be empty";
                return null;
            }

            if (string.IsNullOrEmpty(post.Title))
            {
                message = "Title can not be empty";
                return null;
            }

            Post? updatedPost = _unitOfWork.postRepository.Update(post);

            //checking if post exists
            if(updatedPost is null)
            {
                message = "Post does not exist";
                return null;
            }

            message = "Post updated successfully";
            return updatedPost;

        }
    }
}
