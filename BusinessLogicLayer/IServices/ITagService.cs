using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ITagService
    {
        /// <summary>
        /// Create a Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <returns>Object of Tag</returns>
        Tag? CreateTag(Tag tag, out string message);

        /// <summary>
        /// Get all tags
        /// </summary>
        /// <returns>List of Tag</returns>
        List<Tag> GetAllTag();

        /// <summary>
        /// Get a sungle Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of Tag</returns>
        Tag? GetTag(int id);

        /// <summary>
        /// Update Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Tag? UpdateTag(Tag tag, out string message);

        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean true or false</returns>
        bool DeleteTag(int id, out string message);
    }
}
