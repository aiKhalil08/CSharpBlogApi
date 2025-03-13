using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ITag
    {
        /// <summary>
        /// Create a Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Object of Tag</returns>
        Tag Create(Tag tag);

        /// <summary>
        /// Get all Tag
        /// </summary>
        /// <returns>List of Tags</returns>
        List<Tag> GetAll();

        /// <summary>
        /// Delete Tag
        /// </summary>
        void Delete(Tag tag);

        /// <summary>
        /// Get a single Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Object of Tag</returns>
        Tag? Get(int id);

        /// <summary>
        /// Update Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>Object of Tag</returns>
        Tag? Update(Tag tag);
    }
}
