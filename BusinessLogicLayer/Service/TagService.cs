using BusinessLogicLayer.IServices;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Tag? CreateTag(Tag tag, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(tag.Name))
            {
                message = "Name can not be empty";
                return null;
            }

            message = "Created successfully";

            return _unitOfWork.tagRepository.Create(tag);
        }

        public bool DeleteTag(int id, out string message)
        {
            //checking if the id is valid
            if (id <= 0)
            {
                message = "Invalid ID";
                return false;
            }

            Tag? tag = _unitOfWork.tagRepository.Get(id);

            //checking if the id exists
            if (tag == null)
            {
                message = "Tag not found";
                return false;
            }

            _unitOfWork.tagRepository.Delete(tag);

            message = "Tag deleted successfully";
            return true;
        }

        public List<Tag> GetAllTag()
        {
            return _unitOfWork.tagRepository.GetAll();
        }

        public Tag? GetTag(int id)
        {
            //checking if the id is valid
            if (id <= 0)
            {
                return null;
            }

            Tag? tag = _unitOfWork.tagRepository.Get(id);

            //checking if tag exists
            if (tag == null)
            {
                return null;
            }

            return tag;
        }

        public Tag? UpdateTag(Tag tag, out string message)
        {
            //checking if the user enters values
            if (string.IsNullOrEmpty(tag.Name))
            {
                message = "Name can not be empty";
                return null;
            }

            Tag? updatedTag = _unitOfWork.tagRepository.Update(tag);

            //checking if tag exists
            if (updatedTag is null)
            {
                message = "Tag does not exist";
                return null;
            }

            message = "Tag updated successfully";
            return updatedTag;

        }
    }
}
