using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class TagRepository : ITag
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TagRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //function to create a tag
        public Tag Create(Tag tag)
        {
            _applicationDbContext.Add(tag);
            _applicationDbContext.SaveChanges();

            return tag;
        }

        //funciton to delete a tag
        public void Delete(Tag tag)
        {
            _applicationDbContext.Remove(tag);
            _applicationDbContext.SaveChanges();
        }

        //function to get a single tag
        public Tag? Get(int id)
        {
            Tag? tag = _applicationDbContext.Tags.Find(id);

            return tag;
        }

        //function to get all tags
        public List<Tag> GetAll()
        {
            return _applicationDbContext.Tags.ToList();
        }

        //function to update a tag
        public Tag? Update(Tag tag)
        {
            Tag? existingTag = _applicationDbContext.Tags.Find(tag.Id);

            existingTag.Name = tag.Name;

            _applicationDbContext.Tags.Update(existingTag);
            _applicationDbContext.SaveChanges();

            return existingTag;
        }
    }
}
